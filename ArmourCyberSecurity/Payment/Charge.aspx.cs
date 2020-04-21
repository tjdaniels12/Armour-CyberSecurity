using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArmourCyberSecurity.Payment
{
    public partial class Charge : System.Web.UI.Page
    {
        public string stripePublishableKey = WebConfigurationManager.AppSettings["StripePublishableKey"];

        protected void Page_Load(object sender, EventArgs e)
        {


        }
    }
}