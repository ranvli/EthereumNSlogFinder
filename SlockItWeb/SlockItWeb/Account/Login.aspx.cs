using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;


namespace SlockItWeb
{
    public partial class Login : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Login to SlockItWeb";

            if (!IsPostBack)
            {
                if (Request.QueryString["action"] != null)
                {
                    string action = Request.QueryString["action"].ToString();

                    if (action == "logout")
                    {
                        Session["CurrentUser"] = null;
                        Session.Abandon();
                        Session.Clear();
                        Response.Cookies.Clear();
                        lblStatus.Text = "User has been logged out.";
                    }
                }
            }
        }



        protected void LogIn(object sender, EventArgs e)
        {
            
                    // Validate the user password
                    string email = txtEmail.Text;
                    string pass = txtPassword.Text;


            if (email == "test@test.it" && pass == "testit")
            {

                Session["CurrentUser"] = email;
                FormsAuthentication.SetAuthCookie(email, false);
                FormsAuthenticationTicket ticket1 =
                   new FormsAuthenticationTicket(
                        1,                                   // version
                       email,   // get username  from the form
                        DateTime.Now,                        // issue time is now
                        DateTime.Now.AddMinutes(30),         // expires in 30 minutes
                        false,      // cookie is not persistent
                        ""                              // role assignment is stored
                                                        // in userData
                        );

                HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket1));
                Response.Cookies.Add(cookie1);

                // 4. Do the redirect. 
                FormsAuthentication.RedirectFromLoginPage(email, false);
            }
            else
            {
                lblStatus.Text = "Login y/o clave incorrectos.";
            }       
              
        }
    }
}