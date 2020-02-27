using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace ArmourCyberSecurity
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            if(FormsAuthentication.Authenticate(txt_Username.Text, txt_Password.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(txt_Username.Text, false);
            }
            else
            {
                lbl_Error.Text = "Invalid Username";
            }
        }
    }
}