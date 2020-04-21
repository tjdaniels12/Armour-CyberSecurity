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
using System.Net;
using System.Net.Mail;

namespace ArmourCyberSecurity
{
    public partial class Register : System.Web.UI.Page
    {
        //RDSS Local
        string connetionString = @"Server=localhost\SQLEXPRESS01;Database=CyberArmourRoshan;Trusted_Connection=True;";
        DAL dal = new DAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void RegisterUser(object sender, EventArgs e)
        {
            int result = 0;
            HashSalt hashSalt = GenerateSaltedHash(16, txtPassword.Text.Trim());
            Guid obj = Guid.NewGuid();
            string userId = obj.ToString();
            Session["userId"] = userId;

            using (SqlConnection con = new SqlConnection(connetionString))
            {
                using (SqlCommand cmd = new SqlCommand("Insert_User"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.Parameters.AddWithValue("@Username", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", hashSalt.Hash);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Salt", hashSalt.Salt);
                        cmd.Connection = con;
                        con.Open();
                        result = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                }
                string message = string.Empty;
                bool registered = false;
                switch (result)
                {
                    case -1:
                        message = "Username already exists.\\nPlease choose a different username.";
                        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
                        break;
                    case -2:
                        message = "Supplied email address has already been used.";
                        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
                        break;
                    default:
                        message = "Registration successful.\\nAn activation email has been sent.";
                        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
                        SendActivationEmail(userId);
                        break;
                }  
                if (registered == true)
                {
                    Response.Redirect("~/Login.aspx", false);
                }
            }
        }
        //private void SendActivationEmail(string userId)
        //{
        //    //string constr = ConfigurationManager.ConnectionStrings["main"].ConnectionString;
        //    string constr = @"Server=localhost\SQLEXPRESS01;Database=CyberArmourRoshan;Trusted_Connection=True;";
        //    string activationCode = Guid.NewGuid().ToString();
        //    string emailAddress = txtEmail.Text.Trim();
        //    string username = txtUsername.Text.Trim();
        //    string body = "Hello " + username + ",";
        //    body += "<br /><br />Please click the following link to activate your account";
        //    body += "<br /><a href = '" + Request.Url.AbsoluteUri.Replace("Register", "Account_Activation?ActivationCode=" + activationCode) + "'>Click here to activate your account.</a>";
        //    body += "<br /><br />Thanks";
        //    using (SqlConnection con = new SqlConnection(constr))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("INSERT INTO UserActivation VALUES(@UserId, @ActivationCode)"))
        //        {
        //            using (SqlDataAdapter sda = new SqlDataAdapter())
        //            {
        //                cmd.CommandType = CommandType.Text;
        //                cmd.Parameters.AddWithValue("@UserId", userId);
        //                cmd.Parameters.AddWithValue("@ActivationCode", activationCode);
        //                cmd.Connection = con;
        //                con.Open();
        //                cmd.ExecuteNonQuery();
        //                con.Close();
        //            }
        //        }
        //    }
        //    ConfirmationEmail(activationCode, username, body, emailAddress).Wait();

        //}

        private void SendActivationEmail(string userId)
        {
            string constr = @"Server=localhost\SQLEXPRESS01;Database=CyberArmourRoshan;Trusted_Connection=True;";
            string activationCode = Guid.NewGuid().ToString();
            string username = txtUsername.Text.Trim().ToString();
            string email_body = "Hello, " + username + Environment.NewLine;
            email_body = email_body + "Please click the following link to confirm your email and unlock full access to PrivacyComplianceSolutions.com<br /><br />" + Environment.NewLine;
            email_body = email_body + "<a href = '" + Request.Url.AbsoluteUri.Replace("Registration/Register", "Level1/Account_Activation.aspx?ActivationCode=" + activationCode) + "'>Click here to activate your account.</a>" + Environment.NewLine;
            email_body = email_body + "Privacy Compliance Group<br />" + Environment.NewLine;
            email_body = email_body + "Powered by Armour Cybersecurity 2020<br />" + Environment.NewLine;


            //MailMessage mm = new MailMessage("roshandeep810@gmail.com", "roshandeep1995@gmail.com");
            MailMessage mm = new MailMessage("AccountVerification@PrivacyComplianceSolutions.com", txtEmail.Text.Trim().ToString())
            {
                Subject = "Confirm Your Email",
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