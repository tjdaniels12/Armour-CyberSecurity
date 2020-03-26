using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArmourCyberSecurity
{
    public partial class Forgot_Password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        static async Task PasswordResetEmail(string username, string body, string emailAddress)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("PasswordReset@CyberArmourSecurity.com", "Password Reset");
            var subject = "Password Reset";
            var to = new EmailAddress(emailAddress, username);
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = body;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
        }

    }
}