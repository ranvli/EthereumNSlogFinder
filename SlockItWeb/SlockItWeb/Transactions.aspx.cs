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
    public partial class Transactions : System.Web.UI.Page
    {
        MainService.IENSService mainService = new MainService.ENSServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["blockNumber"] != null)
                {
                    ViewState["blockNumber"] = Request.QueryString["blockNumber"];
                    CargaDatos("", SortDirection.Ascending);
                }
            }
        }

        private void CargaDatos(string sortExpression, SortDirection sortDirection)
        {

            ulong blockNumber = Convert.ToUInt64(ViewState["blockNumber"]);
            MainService.SearchParameter searchParameter = new MainService.SearchParameter() { BlockNumber = blockNumber };
            List<MainService.TransactionDomain> items = items = mainService.GetTransactionsByBlockNumber(searchParameter).ToList<MainService.TransactionDomain>();

            if (sortExpression != "")
            {
                if (ViewState["e.SortDirection"] == null) ViewState["e.SortDirection"] = sortDirection.ToString();
                string sortDir = ViewState["e.SortDirection"].ToString();
                items = Helpers.Util.OrderByField(items.AsQueryable(), sortExpression, sortDir == "Ascending").ToList();
            }

            lblResultActivity.InnerText = "Result of transactions. Transactions found: " + items.Count;

            gdvTransactions.DataSource = items;
            gdvTransactions.DataBind();
        }

        

        protected void gdvActivity_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string SortExpression = ViewState["e.SortExpression"] == null ? "" : (string)ViewState["e.SortExpression"];
            SortDirection sd = ViewState["e.SortDirection"] == null ? SortDirection.Ascending : ViewState["e.SortDirection"].ToString() == "Ascending" ? SortDirection.Ascending : SortDirection.Descending;

            gdvTransactions.PageIndex = e.NewPageIndex;
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
         
  
    }
}