using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArmourCyberSecurity
{
    public partial class Section3 : System.Web.UI.Page
    {
        string userId = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            GetUserId();

            if (!Page.IsPostBack)
            {
                LoadQuestionnaire();
                LoadPreviousState();
            }
            else
            {

            }
        }

        private void GetUserId()
        {
            userId = Session["userId"].ToString();
        }

        private void LoadPreviousState()
        {
            DAL dal = new DAL();
            DataTable dt = new DataTable();
            dt = dal.LoadSectionState(2, userId);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["question_type"].ToString() == "Privacy Engineering")
                    {
                        var ddl = (DropDownList)this.Master.FindControl("ContentPlaceHolder1").FindControl("ddlAns" + row["question_id"].ToString());
                        if (ddl != null)
                        {
                            ddl.SelectedValue = row["answer_wt"].ToString();
                        }

                    }
                }
            }
        }

        private void LoadQuestionnaire()
        {
            DAL dal = new DAL();
            DataTable dt = new DataTable();
            dt = dal.LoadLevel2Questions();
            foreach (DataRow row in dt.Rows)
            {
                var label = (Label)this.Master.FindControl("ContentPlaceHolder1").FindControl("lblQues" + row["question_id"].ToString());
                if (label != null)
                {
                    label.Text = row["question"].ToString();
                }
                if (row["question_type"].ToString() == "Privacy Engineering")
                {
                    if (row["ctrl_type"].ToString() == "dd4")
                    {
                        var ddl = (DropDownList)this.Master.FindControl("ContentPlaceHolder1").FindControl("ddlAns" + row["question_id"].ToString());
                        if (ddl != null)
                        {
                            ddl.Items.Add(new ListItem("YES", row["question_wt_yes"].ToString()));
                            ddl.Items.Add(new ListItem("NO", row["question_wt_no"].ToString()));
                            ddl.Items.Add(new ListItem("SOMEWHAT", row["question_wt_somewhat"].ToString()));
                            ddl.Items.Add(new ListItem("UNSURE", row["question_wt_unsure"].ToString()));
                        }
                    }
                }
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            DAL dal = new DAL();
            DataTable dt = new DataTable();
            dt = dal.LoadLevel2Questions();

            SaveAnswers(dt);
        }

        private void SaveAnswers(DataTable dt)
        {
            List<string> ansText = new List<string>();
            DAL dal = new DAL();

            foreach (DataRow row in dt.Rows)
            {
                string quesType = string.Empty, answerWt = string.Empty, answer = string.Empty;
                int quesId;

                if (row["question_type"].ToString() == "Privacy Engineering")
                {

                    if (row["ctrl_type"].ToString() == "dd4")
                    {
                        var ddl = ((DropDownList)this.Master.FindControl("ContentPlaceHolder1").FindControl("ddlAns" + row["question_id"].ToString()));
                        if (ddl != null)
                        {
                            quesId = Convert.ToInt32(row["question_id"].ToString());
                            if (ddl.SelectedIndex == -1)
                            {
                                answer = ddl.SelectedIndex.ToString();
                                answerWt = ddl.SelectedIndex.ToString();
                                quesType = row["question_type"].ToString();
                                dal.SaveLevel2Answers(userId, quesId, quesType, answerWt, answer, 2);
                            }
                            else
                            {
                                answer = ddl.SelectedItem.Text.ToString();
                                answerWt = ddl.SelectedItem.Value.ToString();
                                quesType = row["question_type"].ToString();
                                dal.SaveLevel2Answers(userId, quesId, quesType, answerWt, answer, 2);
                            }
                        }
                    }
                }
            }
        }
    }
}