using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArmourCyberSecurity.Payment
{
    public partial class Stripe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Form["stripeToken"] != null)
            {
                var customers = new CustomerService();
                var charges = new ChargeService();

                var customer = customers.Create(new CustomerCreateOptions
                {
                    Email = Request.Form["stripeEmail"],
                    Source = Request.Form["stripeToken"]
                });

                var charge = charges.Create(new ChargeCreateOptions
                {
                    Amount = 500,
                    Description = "Level 2 Questionnaire",
                    Currency = "cad",
                    Customer = customer.Id
                });

                Console.WriteLine(charge);
            }

        }
    }
}