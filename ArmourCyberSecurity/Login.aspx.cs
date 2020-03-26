using System;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using System.Data;

namespace ArmourCyberSecurity
{

    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.Params["logout"]))
            {
                FormsAuthentication.SignOut();
                Response.Redirect("./");
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateUser(Login1.UserName, Login1.Password))
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, true);
            else
                Login1.FailureText += "\nCredentials do not match our records.";
        }

        bool IsValidEmail(string strIn)
        {
            // Return true if strIn is in valid email format.
            return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }




        bool ValidateUser(string user, string pass)
        {
            string connStr = ConfigurationManager.ConnectionStrings["Main"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                //string sql = "select email from users where email = @email and password = @password";
                //SqlCommand cmd = new SqlCommand(sql, conn);
                string passwordSQL = "select password, salt from users where email = @email";
                SqlCommand cmd = new SqlCommand(passwordSQL, conn);
                cmd.Parameters.AddWithValue("@email", user);
                //cmd.Parameters.AddWithValue("@password", Sha1(Salt(pass)));
                //cmd.Parameters.AddWithValue("@password", pass);
                //return cmd.ExecuteScalar() is string;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string salt = reader["salt"].ToString();
                    string hash = reader["password"].ToString();
                    Login1.FailureText += "\nreached VerifyPassword.";
                    Login1.FailureText += "\nsalt:" + salt + "\nhash:" + hash;
                    return VerifyPassword(pass, hash, salt);

                }
                else
                {
                    Login1.FailureText += "reader.Read() failed.";
                    return false;
                }

                //protected void btn_Submit_Click(object sender, EventArgs e)
                //{
                //    if(FormsAuthentication.Authenticate(txt_Username.Text, txt_Password.Text))
                //    {
                //        FormsAuthentication.RedirectFromLoginPage(txt_Username.Text, false);
                //    }
                //    else
                //    {
                //        lbl_Error.Text = "Invalid Username";
                //    }
                //}
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