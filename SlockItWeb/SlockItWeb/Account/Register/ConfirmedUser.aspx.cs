using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SlockItWeb
{
    public partial class ConfirmedUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["msg"] != null)
            {
                string msg = Request.QueryString["msg"].ToString();

                if (msg == "created")
                {
                    lblStatus.Text = "User has been created. Please check your email to confirm and activate your user before login.";
                }
            }
        }
    }
}