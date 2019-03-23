using SlockItWeb.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SlockItWeb
{
    public partial class Default : System.Web.UI.Page
    {

        MainService.IENSService mainService = new MainService.ENSServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                calFechaDesde.SelectedDate = DateTime.Today.AddDays(-1);
            }
        }

        private void CargaDatos(string sortExpression, SortDirection sortDirection)
        {
            Int64? FiltroFechaDesde = ViewState["FiltroFechaDesde"] == null ? (Int64?)null : Convert.ToInt64(ViewState["FiltroFechaDesde"]);

            if (String.IsNullOrEmpty(txtEDN.Text))
            {
                lblStatus.Text = "Address is a mandatory field";
                return;
            }

            MainService.SearchParameter searchParameter = new MainService.SearchParameter() { Any = txtEDN.Text, From = (ulong) FiltroFechaDesde };
            
            List<MainService.ENSHistoryDomain> items = HttpContext.Current.Cache[ConstantsHelper.cacheKeyActivity] as List<MainService.ENSHistoryDomain>;
            string hexAddr = "N/A";
            if (items == null)
            {
                items = mainService.GetHistoryAny(searchParameter).ToList<MainService.ENSHistoryDomain>();
                hexAddr = items.First().Address;
                if (items != null & items.First().NumberOfTransactions > 0)
                {
                    HttpContext.Current.Cache.Insert(ConstantsHelper.cacheKeyActivity, items, null, DateTime.Now.AddMinutes(180), TimeSpan.Zero);
                }
                else if (items != null & items.First().NumberOfTransactions == 0)
                {
                    lblStatus.Text = "Address does not exist.";
                    return;
                }
                else if (items != null & items.First().NumberOfTransactions == -1)
                {
                    lblStatus.Text = "It seems domain does not exist: " + txtEDN.Text;
                    return;
                }
                else if (items != null & items.First().NumberOfTransactions == -2)
                {
                    lblStatus.Text = "No records found for " + txtEDN.Text + " / Hex Address: " + hexAddr;
                    return;
                }
            }


            if (sortExpression != "")
            {
                if (ViewState["e.SortDirection"] == null) ViewState["e.SortDirection"] = sortDirection.ToString();
                string sortDir = ViewState["e.SortDirection"].ToString();
                items = Helpers.Util.OrderByField(items.AsQueryable(), sortExpression, sortDir == "Ascending").ToList();
            }

            lblResultActivity.InnerText = "Result of activity. Results returned: " + items.Count + " for hex address: " + hexAddr;

            gdvActivity.DataSource = items;
            gdvActivity.DataBind();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string SortExpression = ViewState["e.SortExpression"] == null ? "" : (string)ViewState["e.SortExpression"];
            SortDirection sd = ViewState["e.SortDirection"] == null ? SortDirection.Ascending : ViewState["e.SortDirection"].ToString() == "Ascending" ? SortDirection.Ascending : SortDirection.Descending;
             
            ViewState["FiltroFechaDesde"] = ((DateTimeOffset)calFechaDesde.SelectedDate).ToUnixTimeSeconds();

            lblResultActivity.InnerText = "Result of activity.";
            HttpContext.Current.Cache.Remove(ConstantsHelper.cacheKeyActivity);
            gdvActivity.DataSource = null;
            gdvActivity.DataBind();

            CargaDatos(SortExpression, sd);
        }

        protected void gdvActivity_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string SortExpression = ViewState["e.SortExpression"] == null ? "" : (string)ViewState["e.SortExpression"];
            SortDirection sd = ViewState["e.SortDirection"] == null ? SortDirection.Ascending : ViewState["e.SortDirection"].ToString() == "Ascending" ? SortDirection.Ascending : SortDirection.Descending;

            gdvActivity.PageIndex = e.NewPageIndex;
            CargaDatos(SortExpression, sd);
        }

        protected void gdvActivity_Sorting(object sender, GridViewSortEventArgs e)
        {
            ViewState["e.SortExpression"] = e.SortExpression;

            if (ViewState["e.SortDirection"] == null) ViewState["e.SortDirection"] = e.SortDirection;
            string sortDir = ViewState["e.SortDirection"].ToString();

            if (sortDir == "Ascending")
            {
                ViewState["e.SortDirection"] = "Descending";
            }
            else
            {
                ViewState["e.SortDirection"] = "Ascending";
            }

            sortDir = ViewState["e.SortDirection"].ToString();

            CargaDatos(e.SortExpression, e.SortDirection);
        }

        protected void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (gdvActivity.Rows.Count == 0)
            {
                lblStatus.Text = "Grid has no rows. Nothing exported.";
                return;
            }

            gdvActivity.PagerSettings.Visible = false;

            //To Export all pages
            gdvActivity.AllowPaging = false;
            string SortExpression = ViewState["e.SortExpression"] == null ? "" : (string)ViewState["e.SortExpression"];
            SortDirection sd = ViewState["e.SortDirection"] == null ? SortDirection.Ascending : ViewState["e.SortDirection"].ToString() == "Ascending" ? SortDirection.Ascending : SortDirection.Descending;
            CargaDatos(SortExpression, sd);


            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=ContractActivity.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);


                gdvActivity.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in gdvActivity.HeaderRow.Cells)
                {
                    cell.BackColor = gdvActivity.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gdvActivity.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gdvActivity.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gdvActivity.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                gdvActivity.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }


            gdvActivity.PagerSettings.Visible = true;
            gdvActivity.AllowPaging = true;
            CargaDatos(SortExpression, sd);

        }

        private void ExportGridToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "ContractActivity.xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            gdvActivity.GridLines = GridLines.Both;
            gdvActivity.HeaderStyle.Font.Bold = true;
            gdvActivity.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

        protected void gdvActivity_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewTransactions")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow gvr = gdvActivity.Rows[index];
                int blockNumber = Convert.ToInt32(gdvActivity.DataKeys[index].Value);

                Response.Redirect("~/Transactions.aspx?blockNumber=" + blockNumber);

            }

        }
    }
}