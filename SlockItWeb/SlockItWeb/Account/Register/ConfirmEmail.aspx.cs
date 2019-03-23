using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SlockItWeb
{
    public partial class ConfirmEmail : System.Web.UI.Page
    {
         
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["cid"] == null)
            {
                ViewState["confkey"] = "00000000-0000-0000-0000-000000000000";
            }
            else
            {
                string confkey = Request.QueryString["cid"].ToString();
                ViewState["confkey"] = confkey;
            }

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
             

        }
    }
}