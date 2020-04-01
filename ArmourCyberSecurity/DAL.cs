using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ArmourCyberSecurity
{
    public class DAL
    {
        //RDSS Local
        string connetionString = @"Server=LAPTOP-HM18U6J6; Database=ArmourCyberSecurity;Integrated Security=true;";

        SqlCommand cmd;

        public DataTable LoadLevel1Questions()
        {
            SqlConnection cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "SELECT question_id, question, question_type, ctrl_type, question_wt_yes, question_wt_no, question_wt_somewhat, question_wt_unsure FROM [ar_sec_Feedback_Questions_level1]";
            cmd = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cnn.Close();
            return ds.Tables[0];
        }

        public DataTable LoadSectionState(int section, string userId)
        {
            SqlConnection cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "SELECT question_id, question_type, ans_Text, answer_wt FROM ar_sec_User_Feedback_Collection_Level2 WHERE stagesCompleted = @stagesCompleted AND userid = @userid";
            cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.Add(new SqlParameter("@stagesCompleted", section));
            cmd.Parameters.Add(new SqlParameter("@userId", userId));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cnn.Close();
            return ds.Tables[0];
        }

        public string GetUserId(string emailId)
        {
            SqlConnection cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "SELECT DISTINCT userId FROM ar_sec_users WHERE email_id = @email_id";
            cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.Add(new SqlParameter("@email_id", emailId));
            string exsists = cmd.ExecuteScalar().ToString();
            cnn.Close();
            return exsists;
        }

        public DataTable LoadLevel2Questions()
        {
            SqlConnection cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "SELECT question_id, question, question_type, ctrl_type, question_wt_yes, question_wt_no, question_wt_somewhat, question_wt_unsure FROM [ar_sec_Feedback_Questions_level2]";
            //string sql = "SELECT question_id, question, question_type, ctrl_type, question_wt_yes, question_wt_no, question_wt_somewhat, question_wt_unsure FROM [ar_sec_Feedback_Questions_level2]";
            cmd = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cnn.Close();
            return ds.Tables[0];
        }

        public DataTable GetUserReport(string userId)
        {
            SqlConnection cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "SELECT question_id, question_type, answer_wt, ans_Text FROM ar_sec_User_Feedback_Collection_Level1 WHERE userId = @userId";
            cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.Add(new SqlParameter("@userId", userId));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cnn.Close();
            return ds.Tables[0];
        }

        public void SaveUser(string emailId, string userId)
        {
            SqlConnection cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "INSERT INTO ar_sec_users(userId, userName, email_id, level1_complete, level2_complete, subscriber, premium_member) VALUES (@userId, @userName, @email_id, @level1_complete, @level2_complete, @subscriber, @premium_member);";
            cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.Add(new SqlParameter("@userId", userId));
            cmd.Parameters.Add(new SqlParameter("@userName", emailId));
            cmd.Parameters.Add(new SqlParameter("@email_id", emailId));
            cmd.Parameters.Add(new SqlParameter("@level1_complete", "1"));
            cmd.Parameters.Add(new SqlParameter("@level2_complete", "0"));
            cmd.Parameters.Add(new SqlParameter("@subscriber", "1"));
            cmd.Parameters.Add(new SqlParameter("@premium_member", "0"));
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void SaveFreeUser(string userID, string email)
        {
            SqlConnection cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "INSERT INTO FreeUsers(userId, Email) VALUES (@userID, @email";
            cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.Add(new SqlParameter("@userID", userID));
            cmd.Parameters.Add(new SqlParameter("@email", email));
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public int CheckIfUserExists(string email)
        {
            SqlConnection cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("CheckIfUserExists", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@IsExists", 0);
            int rowAffected = cmd.ExecuteNonQuery();
            cnn.Close();
            return rowAffected;
            // rowAffected contains your Result
        }

        public DataTable LoadRegion()
        {
            SqlConnection cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "SELECT region_id, region_name FROM ar_sec_region";
            cmd = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cnn.Close();
            return ds.Tables[0];
        }

        public void SaveAnswers(string userId, int quesId, string quesType, string ansWt, string ansText)
        {
            SqlConnection cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "INSERT INTO ar_sec_User_Feedback_Collection_Level1(userid, question_id, question_type, answer_wt, ans_Text) VALUES (@userId, @quesId, @quesType, @ansWt, @ansText);";
            cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.Add(new SqlParameter("@userId", userId));
            cmd.Parameters.Add(new SqlParameter("@quesId", quesId));
            cmd.Parameters.Add(new SqlParameter("@quesType", quesType));
            cmd.Parameters.Add(new SqlParameter("@ansWt", ansWt));
            cmd.Parameters.Add(new SqlParameter("@ansText", ansText));
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public int CheckAllSections(string userId)
        {
            SqlConnection cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "SELECT DISTINCT COUNT(stagesCompleted) FROM ar_sec_User_Feedback_Collection_Level2 WHERE userid = @userid";
            cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.Add(new SqlParameter("@userid", userId));
            int noOfSec = Convert.ToInt32(cmd.ExecuteScalar());
            cnn.Close();
            return noOfSec;
        }

        public void SaveLevel2Answers(string userId, int quesId, string quesType, string ansWt, string ansText, int stagesCompleted)
        {
            string sql = string.Empty;
            SqlConnection cnn = new SqlConnection(connetionString);
            cnn.Open();
            sql = "SELECT DISTINCT COUNT(*) FROM ar_sec_User_Feedback_Collection_Level2 WHERE userid = @userId AND question_id = @quesId;";
            cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.Add(new SqlParameter("@userId", userId));
            cmd.Parameters.Add(new SqlParameter("@quesId", quesId));
            int AnsExists = Convert.ToInt32(cmd.ExecuteScalar());

            if (AnsExists > 0)
            {
                sql = "UPDATE ar_sec_User_Feedback_Collection_Level2 SET userid = @userId, question_id = @quesId, question_type = @quesType, answer_wt = @ansWt, ans_Text = @ansText, stagesCompleted = @stagesCompleted WHERE userid = @userId AND question_id = @quesId;";
                cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.Add(new SqlParameter("@userId", userId));
                cmd.Parameters.Add(new SqlParameter("@quesId", quesId));
                cmd.Parameters.Add(new SqlParameter("@quesType", quesType));
                cmd.Parameters.Add(new SqlParameter("@ansWt", ansWt));
                cmd.Parameters.Add(new SqlParameter("@ansText", ansText));
                cmd.Parameters.Add(new SqlParameter("@stagesCompleted", stagesCompleted));
            }
            else
            {
                sql = "INSERT INTO ar_sec_User_Feedback_Collection_Level2(userid, question_id, question_type, answer_wt, ans_Text, stagesCompleted) VALUES (@userId, @quesId, @quesType, @ansWt, @ansText, @stagesCompleted);";
                cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.Add(new SqlParameter("@userId", userId));
                cmd.Parameters.Add(new SqlParameter("@quesId", quesId));
                cmd.Parameters.Add(new SqlParameter("@quesType", quesType));
                cmd.Parameters.Add(new SqlParameter("@ansWt", ansWt));
                cmd.Parameters.Add(new SqlParameter("@ansText", ansText));
                cmd.Parameters.Add(new SqlParameter("@stagesCompleted", stagesCompleted));
            }
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public DataTable GetReportComments()
        {
            SqlConnection cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "SELECT criteria, low_cmt, med_cmt, high_cmt FROM [ar_sec_Level1_FeedbackReport]";
            cmd = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cnn.Close();
            return ds.Tables[0];
        }

        public int GetQues23Wt()
        {
            SqlConnection cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "SELECT question_wt_yes FROM ar_sec_Feedback_Questions_level1 WHERE question_id = 23";
            cmd = new SqlCommand(sql, cnn);
            int answt = Convert.ToInt32(cmd.ExecuteScalar());
            cnn.Close();
            return answt;
        }
    }
}