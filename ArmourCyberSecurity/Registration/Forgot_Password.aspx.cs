using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;
using System.Data;

namespace ArmourCyberSecurity
{
    public partial class Forgot_Password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Forgot_Password_Click(object sender, EventArgs e)
        {
            string connetionString = @"Server=localhost\SQLEXPRESS01;Database=CyberArmourRoshan;Trusted_Connection=True;";

            using (SqlConnection con = new SqlConnection(connetionString))
            {
                string userID = null;

                using (SqlCommand command = new SqlCommand("SELECT userId FROM Users WHERE Email = @Email"))
                {
                    command.Parameters.AddWithValue("@Email", txtEmail.Text.Trim().ToString());
                    command.Connection = con;
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        userID = reader["userId"].ToString();
                        con.Close();
                        PasswordResetEmail(userID);
                        ltMessage.Text = "Check your inbox for a new email titled 'Password Reset'";
                    }
                    else
                    {
                        //no userId found
                        con.Close();
                        ltMessage.Text = "Invalid Forgot Password code.";
                    }
                    
                }
            }



            
        }


        protected void PasswordResetEmail(string userId)
        {
            string constr = @"Server=localhost\SQLEXPRESS01;Database=CyberArmourRoshan;Trusted_Connection=True;";
            string forgot_password_code = Guid.NewGuid().ToString();
            string email_body = "Please click the following link to reset your password. <br /><br />" + Environment.NewLine;
            email_body += "<a href = '" + Request.Url.AbsoluteUri.Replace("Registration/Forgot_Password", "Registration/Reset_Password.aspx?ForgotPasswordCode=" + forgot_password_code) + "'>Click here to activate your account.</a>" + Environment.NewLine;
            email_body += "Privacy Compliance Group <br />" + Environment.NewLine;
            email_body += "Powered by Armour CyberSecurity 2020 <br />" + Environment.NewLine;


            //MailMessage mm = new MailMessage("roshandeep810@gmail.com", "roshandeep1995@gmail.com");
            MailMessage mm = new MailMessage("PasswordReset@PrivacyComplianceSolutions.com", txtEmail.Text.Trim().ToString())
            {
                Subject = "Password Reset",
                Body = email_body,
                IsBodyHtml = true
            };
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential();
            NetworkCred.UserName = "roshandeep810@gmail.com";
            NetworkCred.Password = "Simran@3395";
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);







                using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO ForgotPassword VALUES(@UserId, @ForgotPasswordCode)"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@ForgotPasswordCode", forgot_password_code);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }


        //static async Task PasswordResetEmail(string username, string body, string emailAddress)
        //{
        //    var apiKey = "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";
        //    var client = new SendGridClient(apiKey);
        //    var from = new EmailAddress("PasswordReset@CyberArmourSecurity.com", "Password Reset");
        //    var subject = "Password Reset";
        //    var to = new EmailAddress(emailAddress, username);
        //    var plainTextContent = "and easy to do anywhere, even with C#";
        //    var htmlContent = body;
        //    var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        //    var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
        //}
    }
}