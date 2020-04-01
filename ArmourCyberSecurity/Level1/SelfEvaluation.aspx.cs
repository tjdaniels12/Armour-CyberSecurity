using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ArmourCyberSecurity
{
    public partial class SelfEvaluation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                LoadQuestionnaire();
            }
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            DAL dal = new DAL();
            DataTable dt = new DataTable();
            dt = dal.LoadLevel1Questions();

            SaveAnswers(dt);

            Response.Redirect("~/Level1/SelfEvaluationReport.aspx", false);
        }

        private void SaveAnswers(DataTable dt)
        {
            List<string> ansText = new List<string>();
            DAL dal = new DAL();
            Guid obj = Guid.NewGuid();
            string userId = obj.ToString();
            Session["userId"] = userId;

            foreach (DataRow row in dt.Rows)
            {
                string quesType = string.Empty, answerWt = string.Empty, answer = string.Empty;
                int quesId;

                if (row["question_type"].ToString() == "Privacy Culture Questions")
                {
                    
                    if (row["ctrl_type"].ToString() == "dd4")
                    {
                        var ddl = ((DropDownList)FindControl("ddlAns" + row["question_id"].ToString()));
                        if (ddl != null)
                        {
                            quesId = Convert.ToInt32(row["question_id"].ToString());
                            if (ddl.SelectedIndex == -1)
                            {
                                answer = ddl.SelectedIndex.ToString();
                                answerWt = ddl.SelectedIndex.ToString();
                                quesType = row["question_type"].ToString();
                                dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
                            }
                            else
                            {
                                answer = ddl.SelectedItem.Text.ToString();
                                answerWt = ddl.SelectedItem.Value.ToString();
                                quesType = row["question_type"].ToString();
                                dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
                            }
                        }
                    }
                }
                else
                if (row["question_type"].ToString() == "Regional Specific Questions")
                {
                    if (row["ctrl_type"].ToString() == "chkbx4")
                    {
                        var chkbx = ((CheckBoxList)FindControl("chkbxAns" + row["question_id"].ToString()));
                        if (chkbx != null)
                        {
                            quesId = Convert.ToInt32(row["question_id"].ToString());
                            if (chkbx.SelectedIndex != -1)
                            {
                                for (int i = 0; i < chkbx.Items.Count; i++)
                                {
                                    if (chkbx.Items[i].Selected == true)
                                    {
                                        answer = answer + chkbx.Items[i].Text + " ,";
                                    }
                                }
                                answerWt = chkbx.Items.Count.ToString();
                                quesType = row["question_type"].ToString();
                                dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
                            }

                        }
                    }
                    else
                    if (row["ctrl_type"].ToString() == "dd2")
                    {
                        var ddl = ((DropDownList)FindControl("ddlAns" + row["question_id"].ToString()));
                        if (ddl != null)
                        {
                            quesId = Convert.ToInt32(row["question_id"].ToString());
                            if (ddl.SelectedIndex == -1)
                            {
                                answer = ddl.SelectedIndex.ToString();
                                answerWt = ddl.SelectedIndex.ToString();
                                quesType = row["question_type"].ToString();
                                dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
                            }
                            else
                            {
                                answer = ddl.SelectedItem.Text.ToString();
                                answerWt = ddl.SelectedItem.Value.ToString();
                                quesType = row["question_type"].ToString();
                                dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
                            }
                        }
                    }
                }
                else
                if (row["question_type"].ToString() == "Regional Fines")
                {
                    var ddl = ((DropDownList)FindControl("ddlAns" + row["question_id"].ToString()));
                    if (ddl != null)
                    {
                        quesId = Convert.ToInt32(row["question_id"].ToString());
                        if (ddl.SelectedIndex == -1)
                        {
                            answer = ddl.SelectedIndex.ToString();
                            answerWt = ddl.SelectedIndex.ToString();
                            quesType = row["question_type"].ToString();
                            dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
                        }
                        else
                        {
                            answer = ddl.SelectedItem.Text.ToString();
                            answerWt = ddl.SelectedItem.Value.ToString();
                            quesType = row["question_type"].ToString();
                            dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
                        }
                    }
                }
                else
                if (row["question_type"].ToString() == "Privacy Engineering")
                {
                    var ddl = ((DropDownList)FindControl("ddlAns" + row["question_id"].ToString()));
                    if (ddl != null)
                    {
                        quesId = Convert.ToInt32(row["question_id"].ToString());
                        if (ddl.SelectedIndex == -1)
                        {
                            answer = ddl.SelectedIndex.ToString();
                            answerWt = ddl.SelectedIndex.ToString();
                            quesType = row["question_type"].ToString();
                            dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
                        }
                        else
                        {
                            answer = ddl.SelectedItem.Text.ToString();
                            answerWt = ddl.SelectedItem.Value.ToString();
                            quesType = row["question_type"].ToString();
                            dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
                        }
                    }
                }
                else
                if (row["question_type"].ToString() == "Data Control")
                {
                    var ddl = ((DropDownList)FindControl("ddlAns" + row["question_id"].ToString()));
                    if (ddl != null)
                    {
                        quesId = Convert.ToInt32(row["question_id"].ToString());
                        if (ddl.SelectedIndex == -1)
                        {
                            answer = ddl.SelectedIndex.ToString();
                            answerWt = ddl.SelectedIndex.ToString();
                            quesType = row["question_type"].ToString();
                            dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
                        }
                        else
                        {
                            answer = ddl.SelectedItem.Text.ToString();
                            answerWt = ddl.SelectedItem.Value.ToString();
                            quesType = row["question_type"].ToString();
                            dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
                        }
                    }
                }
                else
                if (row["question_type"].ToString() == "Consent")
                {
                    var ddl = ((DropDownList)FindControl("ddlAns" + row["question_id"].ToString()));
                    if (ddl != null)
                    {
                        quesId = Convert.ToInt32(row["question_id"].ToString());
                        if (ddl.SelectedIndex == -1)
                        {
                            answer = ddl.SelectedIndex.ToString();
                            answerWt = ddl.SelectedIndex.ToString();
                            quesType = row["question_type"].ToString();
                            dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
                        }
                        else
                        {
                            answer = ddl.SelectedItem.Text.ToString();
                            answerWt = ddl.SelectedItem.Value.ToString();
                            quesType = row["question_type"].ToString();
                            dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
                        }
                    }
                }
                else
                if (row["question_type"].ToString() == "Incident Response")
                {
                    var ddl = ((DropDownList)FindControl("ddlAns" + row["question_id"].ToString()));
                    if (ddl != null)
                    {
                        quesId = Convert.ToInt32(row["question_id"].ToString());
                        if (ddl.SelectedIndex == -1)
                        {
                            answer = ddl.SelectedIndex.ToString();
                            answerWt = ddl.SelectedIndex.ToString();
                            quesType = row["question_type"].ToString();
                            dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
                        }
                        else
                        {
                            answer = ddl.SelectedItem.Text.ToString();
                            answerWt = ddl.SelectedItem.Value.ToString();
                            quesType = row["question_type"].ToString();
                            dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
                        }
                    }
                }
                else
                if (row["question_type"].ToString() == "Employee Training")
                {
                    var ddl = ((DropDownList)FindControl("ddlAns" + row["question_id"].ToString()));
                    if (ddl != null)
                    {
                        quesId = Convert.ToInt32(row["question_id"].ToString());
                        if (ddl.SelectedIndex == -1)
                        {
                            answer = ddl.SelectedIndex.ToString();
                            answerWt = ddl.SelectedIndex.ToString();
                            quesType = row["question_type"].ToString();
                            dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
                        }
                        else
                        {
                            answer = ddl.SelectedItem.Text.ToString();
                            answerWt = ddl.SelectedItem.Value.ToString();
                            quesType = row["question_type"].ToString();
                            dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
                        }
                    }
                }
            }
        }

        private void LoadQuestionnaire()
        {
            DAL dal = new DAL();
            DataTable dt = new DataTable();
            dt = dal.LoadLevel1Questions();

            foreach (DataRow row in dt.Rows)
            {
                var label = ((Label)FindControl("lblQues" + row["question_id"].ToString()));
                if (label != null)
                {
                    label.Text = row["question"].ToString();
                }

                if (row["question_type"].ToString() == "Privacy Culture Questions")
                {
                    if (row["ctrl_type"].ToString() == "dd4")
                    {
                        var ddl = ((DropDownList)FindControl("ddlAns" + row["question_id"].ToString()));
                        if (ddl != null)
                        {
                            ddl.Items.Add(new ListItem("YES", row["question_wt_yes"].ToString()));
                            ddl.Items.Add(new ListItem("NO", row["question_wt_no"].ToString()));
                            ddl.Items.Add(new ListItem("SOMEWHAT", row["question_wt_somewhat"].ToString()));
                            ddl.Items.Add(new ListItem("UNSURE", row["question_wt_unsure"].ToString()));
                        }
                    }
                }
                else
                if (row["question_type"].ToString() == "Regional Specific Questions")
                {
                    if (row["ctrl_type"].ToString() == "chkbx4")
                    {
                        var chkbx = ((CheckBoxList)FindControl("chkbxAns" + row["question_id"].ToString()));
                        if (chkbx != null)
                        {
                            LoadRegions(chkbx);
                        }
                    }
                    else
                    if (row["ctrl_type"].ToString() == "dd2")
                    {
                        var ddl = ((DropDownList)FindControl("ddlAns" + row["question_id"].ToString()));
                        if (ddl != null)
                        {
                            ddl.Items.Add(new ListItem("YES", row["question_wt_yes"].ToString()));
                            ddl.Items.Add(new ListItem("NO", row["question_wt_no"].ToString()));
                        }
                    }
                }
                else
                if (row["question_type"].ToString() == "Regional Fines")
                {
                    var ddl = ((DropDownList)FindControl("ddlAns" + row["question_id"].ToString()));
                    if (ddl != null)
                    {
                        ddl.Items.Add(new ListItem("YES", row["question_wt_yes"].ToString()));
                        ddl.Items.Add(new ListItem("NO", row["question_wt_no"].ToString()));
                    }
                }
                else
                if (row["question_type"].ToString() == "Privacy Engineering")
                {
                    var ddl = ((DropDownList)FindControl("ddlAns" + row["question_id"].ToString()));
                    if (ddl != null)
                    {
                        ddl.Items.Add(new ListItem("YES", row["question_wt_yes"].ToString()));
                        ddl.Items.Add(new ListItem("NO", row["question_wt_no"].ToString()));
                        ddl.Items.Add(new ListItem("SOMEWHAT", row["question_wt_somewhat"].ToString()));
                        ddl.Items.Add(new ListItem("UNSURE", row["question_wt_unsure"].ToString()));
                    }
                }
                else
                if (row["question_type"].ToString() == "Data Control")
                {
                    var ddl = ((DropDownList)FindControl("ddlAns" + row["question_id"].ToString()));
                    if (ddl != null)
                    {
                        ddl.Items.Add(new ListItem("YES", row["question_wt_yes"].ToString()));
                        ddl.Items.Add(new ListItem("NO", row["question_wt_no"].ToString()));
                        ddl.Items.Add(new ListItem("SOMEWHAT", row["question_wt_somewhat"].ToString()));
                        ddl.Items.Add(new ListItem("UNSURE", row["question_wt_unsure"].ToString()));
                    }
                }
                else
                if (row["question_type"].ToString() == "Consent")
                {
                    var ddl = ((DropDownList)FindControl("ddlAns" + row["question_id"].ToString()));
                    if (ddl != null)
                    {
                        ddl.Items.Add(new ListItem("YES", row["question_wt_yes"].ToString()));
                        ddl.Items.Add(new ListItem("NO", row["question_wt_no"].ToString()));
                        ddl.Items.Add(new ListItem("SOMEWHAT", row["question_wt_somewhat"].ToString()));
                        ddl.Items.Add(new ListItem("UNSURE", row["question_wt_unsure"].ToString()));
                    }
                }
                else
                if (row["question_type"].ToString() == "Incident Response")
                {
                    var ddl = ((DropDownList)FindControl("ddlAns" + row["question_id"].ToString()));
                    if (ddl != null)
                    {
                        ddl.Items.Add(new ListItem("YES", row["question_wt_yes"].ToString()));
                        ddl.Items.Add(new ListItem("NO", row["question_wt_no"].ToString()));
                        ddl.Items.Add(new ListItem("SOMEWHAT", row["question_wt_somewhat"].ToString()));
                        ddl.Items.Add(new ListItem("UNSURE", row["question_wt_unsure"].ToString()));
                    }
                }
                else
                if (row["question_type"].ToString() == "Employee Training")
                {
                    var ddl = ((DropDownList)FindControl("ddlAns" + row["question_id"].ToString()));
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

        private void LoadRegions(CheckBoxList checkBoxList)
        {
            DAL dal = new DAL();
            DataTable dt = new DataTable();
            dt = dal.LoadRegion();

            checkBoxList.DataSource = dt;
            checkBoxList.DataTextField = "region_name";
            checkBoxList.DataValueField = "region_id";
            checkBoxList.DataBind();
        }

        protected void chkbxAns7_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListItem item in chkbxAns7.Items)
            {
                if (item.Selected)
                {
                    if (item.Text == "Canada")
                    {
                        lblQues8.Visible = true;
                        ddlAns8.Visible = true;
                        Ques8Div.Visible = true;

                        lblQues12.Visible = true;
                        ddlAns12.Visible = true;
                        Ques12Div.Visible = true;
                    }
                    if (item.Text == "Europe")
                    {
                        lblQues9.Visible = true;
                        ddlAns9.Visible = true;
                        Ques9Div.Visible = true;

                        lblQues13.Visible = true;
                        ddlAns13.Visible = true;
                        Ques13Div.Visible = true;

                        lblQues23.Visible = true;
                        ddlAns23.Visible = true;
                        Ques23Div.Visible = true;
                    }
                    if (item.Text == "California")
                    {
                        lblQues10.Visible = true;
                        ddlAns10.Visible = true;
                        Ques10Div.Visible = true;

                        lblQues14.Visible = true;
                        ddlAns14.Visible = true;
                        Ques14Div.Visible = true;

                        lblQues23.Visible = true;
                        ddlAns23.Visible = true;
                        Ques23Div.Visible = true;
                    }
                    if (item.Text == "Brazil")
                    {
                        lblQues11.Visible = true;
                        ddlAns11.Visible = true;
                        Ques11Div.Visible = true;

                        lblQues15.Visible = true;
                        ddlAns15.Visible = true;
                        Ques15Div.Visible = true;

                        lblQues23.Visible = true;
                        ddlAns23.Visible = true;
                        Ques23Div.Visible = true;
                    }
                }
                else
                {
                    if (item.Text == "Canada")
                    {
                        foreach (ListItem itemIn5 in chkbxAns6.Items)
                        {
                            if (!itemIn5.Selected)
                            {
                                if (itemIn5.Text == "Canada")
                                {
                                    lblQues8.Visible = false;
                                    ddlAns8.Visible = false;
                                    reqAns8.Enabled = false;
                                    Ques8Div.Visible = false;

                                    lblQues12.Visible = false;
                                    ddlAns12.Visible = false;
                                    reqAns12.Enabled = false;
                                    Ques8Div.Visible = false;
                                }
                            }
                        }
                    }
                    if (item.Text == "Europe")
                    {
                        foreach (ListItem itemIn5 in chkbxAns6.Items)
                        {
                            if (!itemIn5.Selected)
                            {
                                if (itemIn5.Text == "Europe")
                                {
                                    lblQues9.Visible = false;
                                    ddlAns9.Visible = false;
                                    reqAns9.Enabled = false;
                                    Ques9Div.Visible = false;

                                    lblQues13.Visible = false;
                                    ddlAns13.Visible = false;
                                    reqAns13.Enabled = false;
                                    Ques13Div.Visible = false;

                                    lblQues23.Visible = false;
                                    ddlAns23.Visible = false;
                                    reqAns23.Enabled = false;
                                    Ques23Div.Visible = false;
                                }
                            }
                        }
                    }
                    if (item.Text == "California")
                    {
                        foreach (ListItem itemIn5 in chkbxAns6.Items)
                        {
                            if (!itemIn5.Selected)
                            {
                                if (itemIn5.Text == "California")
                                {
                                    lblQues10.Visible = false;
                                    ddlAns10.Visible = false;
                                    reqAns10.Enabled = false;
                                    Ques10Div.Visible = false;

                                    lblQues23.Visible = false;
                                    ddlAns23.Visible = false;
                                    reqAns23.Enabled = false;
                                    Ques23Div.Visible = false;
                                }
                            }
                        }

                        lblQues14.Visible = false;
                        ddlAns14.Visible = false;
                        Ques14Div.Visible = false;
                    }
                    if (item.Text == "Brazil")
                    {
                        foreach (ListItem itemIn5 in chkbxAns6.Items)
                        {
                            if (!itemIn5.Selected)
                            {
                                if (itemIn5.Text == "Brazil")
                                {
                                    lblQues11.Visible = false;
                                    ddlAns11.Visible = false;
                                    reqAns11.Enabled = false;
                                    Ques11Div.Visible = false;

                                    lblQues15.Visible = false;
                                    ddlAns15.Visible = false;
                                    reqAns15.Enabled = false;
                                    Ques15Div.Visible = false;

                                    lblQues23.Visible = false;
                                    ddlAns23.Visible = false;
                                    reqAns23.Enabled = false;
                                    Ques23Div.Visible = false;
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void chkbxAns6_SelectedIndexChanged1(object sender, EventArgs e)
        {
            foreach (ListItem item in chkbxAns6.Items)
            {
                if (item.Selected)
                {
                    if (item.Text == "Canada")
                    {
                        lblQues8.Visible = true;
                        ddlAns8.Visible = true;
                        Ques8Div.Visible = true;

                        lblQues12.Visible = true;
                        ddlAns12.Visible = true;
                        Ques12Div.Visible = true;
                    }
                    if (item.Text == "Europe")
                    {
                        lblQues9.Visible = true;
                        ddlAns9.Visible = true;
                        Ques9Div.Visible = true;

                        lblQues13.Visible = true;
                        ddlAns13.Visible = true;
                        Ques13Div.Visible = true;

                        lblQues23.Visible = true;
                        ddlAns23.Visible = true;
                        Ques23Div.Visible = true;
                    }
                    if (item.Text == "California")
                    {
                        lblQues10.Visible = true;
                        ddlAns10.Visible = true;
                        Ques10Div.Visible = true;

                        lblQues23.Visible = true;
                        ddlAns23.Visible = true;
                        Ques23Div.Visible = true;
                    }
                    if (item.Text == "Brazil")
                    {
                        lblQues11.Visible = true;
                        ddlAns11.Visible = true;
                        Ques11Div.Visible = true;

                        lblQues15.Visible = true;
                        ddlAns15.Visible = true;
                        Ques15Div.Visible = true;

                        lblQues23.Visible = true;
                        ddlAns23.Visible = true;
                        Ques23Div.Visible = true;
                    }
                }
                else
                {
                    if (item.Text == "Canada")
                    {
                        foreach (ListItem itemIn6 in chkbxAns7.Items)
                        {
                            if (!itemIn6.Selected)
                            {
                                if (itemIn6.Text == "Canada")
                                {
                                    lblQues8.Visible = false;
                                    ddlAns8.Visible = false;
                                    reqAns8.Enabled = false;
                                    Ques8Div.Visible = false;
                                }
                            }
                        }
                    }
                    if (item.Text == "Europe")
                    {
                        foreach (ListItem itemIn6 in chkbxAns7.Items)
                        {
                            if (!itemIn6.Selected)
                            {
                                if (itemIn6.Text == "Europe")
                                {
                                    lblQues9.Visible = false;
                                    ddlAns9.Visible = false;
                                    reqAns9.Enabled = false;
                                    Ques9Div.Visible = false;

                                    lblQues13.Visible = false;
                                    ddlAns13.Visible = false;
                                    reqAns13.Enabled = false;
                                    Ques13Div.Visible = false;

                                    lblQues23.Visible = false;
                                    ddlAns23.Visible = false;
                                    reqAns23.Enabled = false;
                                    Ques23Div.Visible = false;
                                }
                            }
                        }
                    }
                    if (item.Text == "California")
                    {
                        foreach (ListItem itemIn6 in chkbxAns7.Items)
                        {
                            if (!itemIn6.Selected)
                            {
                                if (itemIn6.Text == "California")
                                {
                                    lblQues10.Visible = false;
                                    ddlAns10.Visible = false;
                                    reqAns10.Enabled = false;
                                    Ques10Div.Visible = false;

                                    lblQues23.Visible = false;
                                    ddlAns23.Visible = false;
                                    reqAns23.Enabled = false;
                                    Ques23Div.Visible = false;
                                }
                            }
                        }
                    }
                    if (item.Text == "Brazil")
                    {
                        foreach (ListItem itemIn6 in chkbxAns7.Items)
                        {
                            if (!itemIn6.Selected)
                            {
                                if (itemIn6.Text == "Brazil")
                                {
                                    lblQues11.Visible = false;
                                    ddlAns11.Visible = false;
                                    reqAns11.Enabled = false;
                                    Ques11Div.Visible = false;

                                    lblQues15.Visible = false;
                                    ddlAns15.Visible = false;
                                    reqAns15.Enabled = false;
                                    Ques15Div.Visible = false;

                                    lblQues23.Visible = false;
                                    ddlAns23.Visible = false;
                                    reqAns23.Enabled = false;
                                    Ques23Div.Visible = false;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}