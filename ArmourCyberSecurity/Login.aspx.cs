using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using System.Configuration;

namespace ArmourCyberSecurity
{
    public partial class Login : System.Web.UI.Page
    {
        //RDSS Local
        string connetionString = @"Server=LAPTOP-HM18U6J6; Database=ArmourCyberSecurity;Integrated Security=true;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.Params["logout"]))
            {
                FormsAuthentication.SignOut();
                Response.Redirect("~/Level1/LandingPage.aspx");
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
<<<<<<< Updated upstream
            if (ValidateUser(Login1.UserName, Login1.Password))
            {
                //FormsAuthentication.RedirectFromLoginPage(Login1.UserName, true);
                Response.Redirect("~/Section1.aspx", false);
            }

            else
            {
                Login1.FailureText += "\nCredentials do not match our records.";
            }
        }

        bool IsValidEmail(string strIn)
        {
            // Return true if strIn is in valid email format.
            return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
=======
            if (ValidateUser(Login1.UserName.Trim().ToString(), Login1.Password.Trim().ToString()))
                using (SqlConnection con = new SqlConnection(connetionString))
                {
                    
                    using (SqlCommand command = new SqlCommand("SELECT ConfirmedEmail FROM Users WHERE Email = @Email"))
                    {
                        command.Parameters.AddWithValue("@Email", Login1.UserName.Trim().ToString());
                        command.Connection = con;
                        con.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            bool verifiedEmail = Convert.ToBoolean(reader["ConfirmedEmail"]);
                            if (verifiedEmail == true)
                            {
                                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, true);
                                con.Close();
                                //Response.Redirect("~/Section1.aspx", true);
                            }
                            else
                            {
                                Login1.FailureText = "This email is not verified. Please check your inbox for a confirmation email.";
                            }
                        }
                        else
                        {
                            //username not found, which is impossible here
                            Login1.FailureText += "This should never happen";
                        }
                    }
                    con.Close();
                }
            else
            {
                Login1.FailureText = "Credentials do not match our records.";
            }
                
>>>>>>> Stashed changes
        }




        bool ValidateUser(string user, string pass)
        {

            using (SqlConnection conn = new SqlConnection(connetionString))
            {
                conn.Open();
                string passwordSQL = "select password, salt from users where email = @email";
                SqlCommand cmd = new SqlCommand(passwordSQL, conn);
                cmd.Parameters.AddWithValue("@email", user);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string salt = reader["salt"].ToString();
                    string hash = reader["password"].ToString();
                    conn.Close();
                    return VerifyPassword(pass, hash, salt);

                }
                else
                {
                    conn.Close();
                    return false;
                }
                
               
            }
        }

        internal class Example
        {
            private static void Main()
            {
                Email().Wait();
            }

            static async Task Email()
            {
                var apiKey = "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";
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("plswork@example.com", "Example User");
                var subject = "Sending with SendGrid is Fun";
                var to = new EmailAddress("tjdaniels1212@gmail.com", "Tyler");
                var plainTextContent = "and easy to do anywhere, even with C#";
                var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);
            }

        }

        public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            var saltBytes = Convert.FromBase64String(storedSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(enteredPassword, saltBytes, 10000);
            return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == storedHash;
        }
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

    }
}