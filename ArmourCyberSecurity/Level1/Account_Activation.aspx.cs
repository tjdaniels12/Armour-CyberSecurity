using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArmourCyberSecurity.Level1
{
    public partial class Account_Activation : System.Web.UI.Page
    {
        string connetionString = @"Server=localhost\SQLEXPRESS01;Database=CyberArmourRoshan;Trusted_Connection=True;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string userID = null;
                string activationCode = !string.IsNullOrEmpty(Request.QueryString["ActivationCode"]) ? Request.QueryString["ActivationCode"] : Guid.Empty.ToString();
                using (SqlConnection con = new SqlConnection(connetionString))
                {
                    
                    using (SqlCommand command = new SqlCommand("SELECT userId FROM UserActivation WHERE ActivationCode = @ActivationCode"))
                    {
                        command.Parameters.AddWithValue("@ActivationCode", activationCode);
                        command.Connection = con;
                        con.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            userID = reader["userId"].ToString();
                        }
                        else
                        {
                            //no userId found
                        }
                        con.Close();
                    }







                    using (SqlCommand cmd = new SqlCommand("DELETE FROM UserActivation WHERE ActivationCode = @ActivationCode"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@ActivationCode", activationCode);
                            cmd.Connection = con;
                            con.Open();
                            
                            int rowsAffected = cmd.ExecuteNonQuery();
                            con.Close();

                            if (rowsAffected == 1)
                            {
                                //ltMessage.Text = "Activation successful. You will be redirected to the login page momentarily.";
                                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Activation successful. You will be redirected to the login page momentarily.');", true);
                                using (SqlCommand update = new SqlCommand("UPDATE Users SET ConfirmedEmail = 1 WHERE userId = @UserID"))
                                {
                                    update.CommandType = CommandType.Text;
                                    update.Parameters.AddWithValue("@UserID", userID);
                                    update.Connection = con;
                                    con.Open();
                                    update.ExecuteNonQuery();
                                    con.Close();
                                    
                                }
                                
                                System.Threading.Thread.Sleep(3000);
                                Response.Redirect("~/Login.aspx", false);
                                
                            }
                            else
                            {
                                ltMessage.Text = "Invalid Activation code.";
                            }
                        }
                    }
                }
            }
        }
    }
}