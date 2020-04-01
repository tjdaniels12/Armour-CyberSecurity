using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArmourCyberSecurity
{
    public partial class LandingPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void level1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SelfEvaluation.aspx", false);
        }

        protected void level2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Customers/Section1.aspx", false);
        }
    }
}