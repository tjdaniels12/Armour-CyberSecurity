using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace ArmourCyberSecurity
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterUser(object sender, EventArgs e)
        {
            int userId = 0;
            string constr = ConfigurationManager.ConnectionStrings["Main"].ConnectionString;
            HashSalt hashSalt = GenerateSaltedHash(16, txtPassword.Text.Trim());
            FailureText.Text = "\n\n\nSALT: " + hashSalt.Salt;
            FailureText.Text += "\n\n\nHASH: " + hashSalt.Hash;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Insert_User"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", hashSalt.Hash);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Salt", hashSalt.Salt);
                        cmd.Connection = con;
                        con.Open();
                        userId = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                }
                string message = string.Empty;
                switch (userId)
                {
                    case -1:
                        message = "Username already exists.\\nPlease choose a different username.";
                        break;
                    case -2:
                        message = "Supplied email address has already been used.";
                        break;
                    default:
                        message = "Registration successful.\\nAn activation email has been sent.";
                        SendActivationEmail(userId);
                        break;
                }
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
            }
        }


        private void SendActivationEmail(int userId)
        {
            //string constr = ConfigurationManager.ConnectionStrings["main"].ConnectionString;
            string constr = @"Server=LAPTOP-HM18U6J6; Database=ArmourCyberSecurity;Integrated Security=true;";
            string activationCode = Guid.NewGuid().ToString();
            string emailAddress = txtEmail.Text.Trim();
            string username = txtUsername.Text.Trim();
            string body = "Hello " + username + ",";
            body += "<br /><br />Please click the following link to activate your account";
            body += "<br /><a href = '" + Request.Url.AbsoluteUri.Replace("Register", "Account_Activation?ActivationCode=" + activationCode) + "'>Click here to activate your account.</a>";
            body += "<br /><br />Thanks";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO UserActivation VALUES(@UserId, @ActivationCode)"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@ActivationCode", activationCode);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            ConfirmationEmail(activationCode, username, body, emailAddress).Wait();

        }


        static async Task ConfirmationEmail(string activationCode, string username, string body, string emailAddress)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("EmailVerification@CyberArmourSecurity.com", "Example User");
            var subject = "Account Activation";
            var to = new EmailAddress(emailAddress, username);
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = body;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
        }

        //private static string CreateSalt(int size)
        //{
        //    // Generate a cryptographic random number using the cryptographic 
        //    // service provider
        //    RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        //    byte[] buff = new byte[size];
        //    rng.GetBytes(buff);
        //    // Return a Base64 string representation of the random number
        //    return Convert.ToBase64String(buff);
        //}

        public class HashSalt
        {
            public string Hash { get; set; }
            public string Salt { get; set; }
        }

        public static HashSalt GenerateSaltedHash(int size, string password)
        {
            var saltBytes = new byte[size];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(saltBytes);
            var salt = Convert.ToBase64String(saltBytes);

            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);

            /*
             * Rfc2898DeriveBytes class is used to generate the hash using the RFC2898 specification, 
             * which uses a method known as PBKDF2 (Password Based Key Derivation Function #2) 
             * and is currently recommend by the IETF (Internet Engineering Task Force) for new applications.
             */

            var hashPassword = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            HashSalt hashSalt = new HashSalt { Hash = hashPassword, Salt = salt };
            return hashSalt;
        }
        bool IsValidEmail(string strIn)
        {
            // Return true if strIn is in valid email format.
            return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }
}