using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArmourCyberSecurity.Registration
{
    public partial class Reset_Password : System.Web.UI.Page
    {
        string connetionString = @"Server=localhost\SQLEXPRESS01;Database=CyberArmourRoshan;Trusted_Connection=True;";
        
        protected void ResetClick(object sender, EventArgs e)
        {
            //MAJOR SECURITY ISSUE IN HERE NEEDS TO BE FIXED, DONT PROMPT FOR EMAIL AT ALL, GRAB EMAIL FORM DB BASED ON ACTIVATION CODE
            string email = txtEmail.Text.Trim().ToString();
            if (bool.TryParse(Session["valid"].ToString(), out bool valid))
            {
                if (valid)
                {
                    HashSalt hashSalt = GenerateSaltedHash(16, txtPassword.Text.Trim().ToString());
                    using (SqlConnection con = new SqlConnection(connetionString))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            using (SqlCommand update = new SqlCommand("UPDATE Users SET Password = @Password, Salt = @Salt WHERE email = @Email"))
                            {
                                update.CommandType = CommandType.Text;
                                update.Parameters.AddWithValue("@Email", email);
                                update.Parameters.AddWithValue("@Password", hashSalt.Hash);
                                update.Parameters.AddWithValue("@Salt", hashSalt.Salt);
                                update.Connection = con;
                                con.Open();
                                int result = update.ExecuteNonQuery();
                                con.Close();
                                if (result > 0)
                                {
                                    Response.Redirect("~/Level1/LandingPage.aspx", false);
                                }
                                else
                                {
                                    FailureText.Text = "Email not found.";
                                }

                            }

                        }
                    }
                }
            }



        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string forgot_password_code = !string.IsNullOrEmpty(Request.QueryString["ForgotPasswordCode"]) ? Request.QueryString["ForgotPasswordCode"] : Guid.Empty.ToString();
                using (SqlConnection con = new SqlConnection(connetionString))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM ForgotPassword WHERE ForgotPasswordCode = @ForgotPasswordCode"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@ForgotPasswordCode", forgot_password_code);
                            cmd.Connection = con;
                            con.Open();

                            int rowsAffected = cmd.ExecuteNonQuery();
                            con.Close();

                            if (rowsAffected == 1)
                            {
                                //Response.Redirect("~/Login.aspx", false);
                                Session["valid"] = true;
                            }
                            else
                            {
                                FailureText.Text = "Invalid Activation code.";
                            }
                        }
                    }
                }

            }
        }

        bool ValidateUser(string user, string pass)
        {

            using (SqlConnection conn = new SqlConnection(connetionString))
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