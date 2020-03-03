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
        //Local
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
    }
}