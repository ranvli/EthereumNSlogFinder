using SlockItWeb.Helpers;
using System;
using System.Web.UI;

namespace SlockItWeb
{
    public partial class Register : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Register in SlockItWeb";
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            string EncodedResponse = Request.Form["g-Recaptcha-Response"];
            bool IsCaptchaValid = (ReCaptchaClass.Validate(EncodedResponse) == "true" ? true : false);


            

        }
 
    }
}