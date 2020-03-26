//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Data;

//namespace ArmourCyberSecurity
//{
//    public partial class SelfEvaluation : System.Web.UI.Page
//    {
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if(!Page.IsPostBack)
//            {
//                LoadQuestionnaire();
//            }
//        }

//        protected void Page_PreInit(object sender, EventArgs e)
//        {
//            //LoadQuestions();
//        }

//        //private void LoadQuestions()
//        //{
//        //    DAL dal = new DAL();
//        //    DataTable dt = new DataTable();
//        //    dt = dal.LoadLevel1Questions();
//        //    DisplayQuestions(dt);
//        //}

//        //private void DisplayQuestions(DataTable dt)
//        //{
//        //    foreach (DataRow row in dt.Rows)
//        //    {
//        //        if (row["question_type"].ToString() == "Privacy Culture Questions")
//        //        {
//        //            if (row["ctrl_type"].ToString() == "dd4")
//        //            {
//        //                TableRow tr = new TableRow();

//        //                TableCell td1 = new TableCell();
//        //                Label lbl = new Label();
//        //                lbl.Attributes.Add("runat", "server");
//        //                lbl.ID = "Ques" + row["question_id"].ToString();
//        //                lbl.Text = row["question"].ToString();
                        
//        //                td1.Controls.Add(lbl);

//        //                TableCell td2 = new TableCell();
//        //                DropDownList ddl = new DropDownList();
//        //                ddl.Attributes.Add("runat", "server");
//        //                ddl.ID = "Ans" + row["question_id"].ToString();
//        //                ddl.Items.Add(new ListItem("YES", row["question_wt_yes"].ToString()));
//        //                ddl.Items.Add(new ListItem("NO", row["question_wt_no"].ToString()));
//        //                ddl.Items.Add(new ListItem("SOMEWHAT", row["question_wt_somewhat"].ToString()));
//        //                ddl.Items.Add(new ListItem("UNSURE", row["question_wt_unsure"].ToString()));
                        
//        //                td2.Controls.Add(ddl);

//        //                tr.Cells.Add(td1);
//        //                tr.Cells.Add(td2);

//        //                tbl_PrivacyCulture.Rows.Add(tr);

//        //            }
//        //        }
//        //        else
//        //        if (row["question_type"].ToString() == "Regional Specific Questions")
//        //        {
//        //            if (row["ctrl_type"].ToString() == "chkbx4")
//        //            {
//        //                TableRow tr = new TableRow();

//        //                TableCell td1 = new TableCell();
//        //                Label lbl = new Label();
//        //                lbl.Attributes.Add("runat", "server");
//        //                lbl.ID = "Ques" + row["question_id"].ToString();
//        //                lbl.Text = row["question"].ToString();
//        //                td1.Controls.Add(lbl);

//        //                TableCell td2 = new TableCell();
//        //                CheckBoxList chkbxlist = new CheckBoxList();
//        //                chkbxlist.Attributes.Add("runat", "server");
//        //                chkbxlist.ID = "Ans" + row["question_id"].ToString();
//        //                chkbxlist.Items.Add(new ListItem("Canada"));
//        //                chkbxlist.Items.Add(new ListItem("Europe"));
//        //                chkbxlist.Items.Add(new ListItem("Brazil"));
//        //                chkbxlist.ClientIDMode = ClientIDMode.Static;
//        //                foreach (ListItem lstitem in chkbxlist.Items)
//        //                {
//        //                    lstitem.Attributes.Add("onclick", "callFunction(this,Ques7.UniqueID,Ans7.UniqueID);");
//        //                }
//        //                td2.Controls.Add(chkbxlist);

//        //                tr.Cells.Add(td1);
//        //                tr.Cells.Add(td2);

//        //                tbl_RegionalSpecific.Rows.Add(tr);
//        //            }
//        //            else
//        //            if (row["ctrl_type"].ToString() == "dd2")
//        //            {
//        //                TableRow tr = new TableRow();

//        //                TableCell td1 = new TableCell();
//        //                Label lbl = new Label();
//        //                lbl.Attributes.Add("runat", "server");
//        //                lbl.ID = "Ques" + row["question_id"].ToString();
//        //                lbl.Text = row["question"].ToString();
//        //                td1.Controls.Add(lbl);

//        //                TableCell td2 = new TableCell();
//        //                DropDownList ddl = new DropDownList();
//        //                ddl.Attributes.Add("runat", "server");
//        //                ddl.ID = "Ans" + row["question_id"].ToString();
//        //                ddl.Items.Add(new ListItem("YES", row["question_wt_yes"].ToString()));
//        //                ddl.Items.Add(new ListItem("NO", row["question_wt_no"].ToString()));
//        //                ddl.ClientIDMode = ClientIDMode.Static;
//        //                td2.Controls.Add(ddl);

//        //                tr.Cells.Add(td1);
//        //                tr.Cells.Add(td2);

//        //                tbl_RegionalSpecific_reflex.Rows.Add(tr);
//        //            }
//        //        }
//        //        else
//        //        if (row["question_type"].ToString() == "Regional Fines")
//        //        {
//        //            if (row["ctrl_type"].ToString() == "dd2")
//        //            {
//        //                TableRow tr = new TableRow();

//        //                TableCell td1 = new TableCell();
//        //                Label lbl = new Label();
//        //                lbl.Attributes.Add("runat", "server");
//        //                lbl.ID = "Ques" + row["question_id"].ToString();
//        //                lbl.Text = row["question"].ToString();
//        //                td1.Controls.Add(lbl);

//        //                TableCell td2 = new TableCell();
//        //                DropDownList ddl = new DropDownList();
//        //                ddl.Attributes.Add("runat", "server");
//        //                ddl.ID = "Ans" + row["question_id"].ToString();
//        //                ddl.Items.Add(new ListItem("YES", row["question_wt_yes"].ToString()));
//        //                ddl.Items.Add(new ListItem("NO", row["question_wt_no"].ToString()));
//        //                td2.Controls.Add(ddl);

//        //                tr.Cells.Add(td1);
//        //                tr.Cells.Add(td2);

//        //                tbl_RegionalFines.Rows.Add(tr);
//        //            }
//        //        }
//        //        else
//        //        if (row["question_type"].ToString() == "Privacy Engineering")
//        //        {
//        //            if (row["ctrl_type"].ToString() == "dd4")
//        //            {
//        //                TableRow tr = new TableRow();

//        //                TableCell td1 = new TableCell();
//        //                Label lbl = new Label();
//        //                lbl.Attributes.Add("runat", "server");
//        //                lbl.ID = "Ques" + row["question_id"].ToString();
//        //                lbl.Text = row["question"].ToString();
                        
//        //                td1.Controls.Add(lbl);

//        //                TableCell td2 = new TableCell();
//        //                DropDownList ddl = new DropDownList();
//        //                ddl.Attributes.Add("runat", "server");
//        //                ddl.ID = "Ans" + row["question_id"].ToString();
//        //                ddl.Items.Add(new ListItem("YES", row["question_wt_yes"].ToString()));
//        //                ddl.Items.Add(new ListItem("NO", row["question_wt_no"].ToString()));
//        //                ddl.Items.Add(new ListItem("SOMEWHAT", row["question_wt_somewhat"].ToString()));
//        //                ddl.Items.Add(new ListItem("UNSURE", row["question_wt_unsure"].ToString()));
                        
//        //                td2.Controls.Add(ddl);

//        //                tr.Cells.Add(td1);
//        //                tr.Cells.Add(td2);

//        //                tbl_PrivacyEngg.Rows.Add(tr);

//        //            }
//        //        }
//        //        else
//        //        if (row["question_type"].ToString() == "Data Control")
//        //        {
//        //            if (row["ctrl_type"].ToString() == "dd4")
//        //            {
//        //                TableRow tr = new TableRow();

//        //                TableCell td1 = new TableCell();
//        //                Label lbl = new Label();
//        //                lbl.Attributes.Add("runat", "server");
//        //                lbl.ID = "Ques" + row["question_id"].ToString();
//        //                lbl.Text = row["question"].ToString();
                        
//        //                td1.Controls.Add(lbl);

//        //                TableCell td2 = new TableCell();
//        //                DropDownList ddl = new DropDownList();
//        //                ddl.Attributes.Add("runat", "server");
//        //                ddl.ID = "Ans" + row["question_id"].ToString();
//        //                ddl.Items.Add(new ListItem("YES", row["question_wt_yes"].ToString()));
//        //                ddl.Items.Add(new ListItem("NO", row["question_wt_no"].ToString()));
//        //                ddl.Items.Add(new ListItem("SOMEWHAT", row["question_wt_somewhat"].ToString()));
//        //                ddl.Items.Add(new ListItem("UNSURE", row["question_wt_unsure"].ToString()));
                        
//        //                td2.Controls.Add(ddl);

//        //                tr.Cells.Add(td1);
//        //                tr.Cells.Add(td2);

//        //                tbl_DataControl.Rows.Add(tr);

//        //            }
//        //        }
//        //        else
//        //        if (row["question_type"].ToString() == "Consent")
//        //        {
//        //            if (row["ctrl_type"].ToString() == "dd4")
//        //            {
//        //                TableRow tr = new TableRow();

//        //                TableCell td1 = new TableCell();
//        //                Label lbl = new Label();
//        //                lbl.Attributes.Add("runat", "server");
//        //                lbl.ID = "Ques" + row["question_id"].ToString();
//        //                lbl.Text = row["question"].ToString();
                        
//        //                td1.Controls.Add(lbl);

//        //                TableCell td2 = new TableCell();
//        //                DropDownList ddl = new DropDownList();
//        //                ddl.Attributes.Add("runat", "server");
//        //                ddl.ID = "Ans" + row["question_id"].ToString();
//        //                ddl.Items.Add(new ListItem("YES", row["question_wt_yes"].ToString()));
//        //                ddl.Items.Add(new ListItem("NO", row["question_wt_no"].ToString()));
//        //                ddl.Items.Add(new ListItem("SOMEWHAT", row["question_wt_somewhat"].ToString()));
//        //                ddl.Items.Add(new ListItem("UNSURE", row["question_wt_unsure"].ToString()));
                        
//        //                td2.Controls.Add(ddl);

//        //                tr.Cells.Add(td1);
//        //                tr.Cells.Add(td2);

//        //                tbl_Consent.Rows.Add(tr);

//        //            }
//        //        }
//        //        else
//        //        if (row["question_type"].ToString() == "Incident Response")
//        //        {
//        //            if (row["ctrl_type"].ToString() == "dd4")
//        //            {
//        //                TableRow tr = new TableRow();

//        //                TableCell td1 = new TableCell();
//        //                Label lbl = new Label();
//        //                lbl.Attributes.Add("runat", "server");
//        //                lbl.ID = "Ques" + row["question_id"].ToString();
//        //                lbl.Text = row["question"].ToString();
                        
//        //                td1.Controls.Add(lbl);

//        //                TableCell td2 = new TableCell();
//        //                DropDownList ddl = new DropDownList();
//        //                ddl.Attributes.Add("runat", "server");
//        //                ddl.ID = "Ans" + row["question_id"].ToString();
//        //                ddl.Items.Add(new ListItem("YES", row["question_wt_yes"].ToString()));
//        //                ddl.Items.Add(new ListItem("NO", row["question_wt_no"].ToString()));
//        //                ddl.Items.Add(new ListItem("SOMEWHAT", row["question_wt_somewhat"].ToString()));
//        //                ddl.Items.Add(new ListItem("UNSURE", row["question_wt_unsure"].ToString()));
                        
//        //                td2.Controls.Add(ddl);

//        //                tr.Cells.Add(td1);
//        //                tr.Cells.Add(td2);

//        //                tbl_IncidentResp.Rows.Add(tr);

//        //            }
//        //        }
//        //        else
//        //        if (row["question_type"].ToString() == "Employee Training")
//        //        {
//        //            if (row["ctrl_type"].ToString() == "dd4")
//        //            {
//        //                TableRow tr = new TableRow();

//        //                TableCell td1 = new TableCell();
//        //                Label lbl = new Label();
//        //                lbl.Attributes.Add("runat", "server");
//        //                lbl.ID = "Ques" + row["question_id"].ToString();
//        //                lbl.Text = row["question"].ToString();
                        
//        //                td1.Controls.Add(lbl);

//        //                TableCell td2 = new TableCell();
//        //                DropDownList ddl = new DropDownList();
//        //                ddl.Attributes.Add("runat", "server");
//        //                ddl.ID = "Ans" + row["question_id"].ToString();
//        //                ddl.Items.Add(new ListItem("YES", row["question_wt_yes"].ToString()));
//        //                ddl.Items.Add(new ListItem("NO", row["question_wt_no"].ToString()));
//        //                ddl.Items.Add(new ListItem("SOMEWHAT", row["question_wt_somewhat"].ToString()));
//        //                ddl.Items.Add(new ListItem("UNSURE", row["question_wt_unsure"].ToString()));
                        
//        //                td2.Controls.Add(ddl);

//        //                tr.Cells.Add(td1);
//        //                tr.Cells.Add(td2);

//        //                tbl_EmpTraining.Rows.Add(tr);

//        //            }
//        //        }
//        //    }      
                
//        //}

//        protected void btn_Submit_Click(object sender, EventArgs e)
//        {
//            DAL dal = new DAL();
//            DataTable dt = new DataTable();
//            dt = dal.LoadLevel1Questions();

//            SaveAnswers(dt);
//        }

//        private void SaveAnswers(DataTable dt)
//        {
//            List<string> ansText = new List<string>();
//            DAL dal = new DAL();
//            Guid obj = Guid.NewGuid();
//            string userId = obj.ToString();

//            foreach (DataRow row in dt.Rows)
//            {
//                string quesType = string.Empty, answerWt = string.Empty, answer = string.Empty;
//                int quesId;

//                if (row["question_type"].ToString() == "Privacy Culture Questions")
//                {
                    
//                    if (row["ctrl_type"].ToString() == "dd4")
//                    {
//                        var ddl = ((DropDownList)FindControl("ddlAns" + row["question_id"].ToString()));
//                        if (ddl != null)
//                        {
//                            quesId = Convert.ToInt32(row["question_id"].ToString());
//                            if (ddl.SelectedIndex == -1)
//                            {
//                                answer = ddl.SelectedIndex.ToString();
//                                answerWt = ddl.SelectedIndex.ToString();
//                                quesType = row["question_type"].ToString();
//                                dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
//                            }
//                            else
//                            {
//                                answer = ddl.SelectedItem.Text.ToString();
//                                answerWt = ddl.SelectedItem.Value.ToString();
//                                quesType = row["question_type"].ToString();
//                                dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
//                            }
//                        }
//                    }
//                }
//                else
//                if (row["question_type"].ToString() == "Regional Specific Questions")
//                {
//                    if (row["ctrl_type"].ToString() == "chkbx4")
//                    {
//                        var chkbx = ((CheckBoxList)FindControl("chkbxAns" + row["question_id"].ToString()));
//                        if (chkbx != null)
//                        {
//                            quesId = Convert.ToInt32(row["question_id"].ToString());
//                            if (chkbx.SelectedIndex != -1)
//                            {
//                                for (int i = 0; i < chkbx.Items.Count; i++)
//                                {
//                                    if (chkbx.Items[i].Selected == true)
//                                    {
//                                        answer = answer + chkbx.Items[i].Text + " ,";
//                                    }
//                                }
//                                answerWt = chkbx.Items.Count.ToString();
//                                quesType = row["question_type"].ToString();
//                                dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
//                            }

//                        }
//                    }
//                    else
//                    if (row["ctrl_type"].ToString() == "dd2")
//                    {
//                        var ddl = ((DropDownList)FindControl("ddlAns" + row["question_id"].ToString()));
//                        if (ddl != null)
//                        {
//                            quesId = Convert.ToInt32(row["question_id"].ToString());
//                            if (ddl.SelectedIndex == -1)
//                            {
//                                answer = ddl.SelectedIndex.ToString();
//                                answerWt = ddl.SelectedIndex.ToString();
//                                quesType = row["question_type"].ToString();
//                                dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
//                            }
//                            else
//                            {
//                                answer = ddl.SelectedItem.Text.ToString();
//                                answerWt = ddl.SelectedItem.Value.ToString();
//                                quesType = row["question_type"].ToString();
//                                dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
//                            }
//                        }
//                    }
//                }
//                else
//                if (row["question_type"].ToString() == "Regional Fines")
//                {
//                    var ddl = ((DropDownList)FindControl("ddlAns" + row["question_id"].ToString()));
//                    if (ddl != null)
//                    {
//                        quesId = Convert.ToInt32(row["question_id"].ToString());
//                        if (ddl.SelectedIndex == -1)
//                        {
//                            answer = ddl.SelectedIndex.ToString();
//                            answerWt = ddl.SelectedIndex.ToString();
//                            quesType = row["question_type"].ToString();
//                            dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
//                        }
//                        else
//                        {
//                            answer = ddl.SelectedItem.Text.ToString();
//                            answerWt = ddl.SelectedItem.Value.ToString();
//                            quesType = row["question_type"].ToString();
//                            dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
//                        }
//                    }
//                }
//                else
//                if (row["question_type"].ToString() == "Privacy Engineering")
//                {
//                    var ddl = ((DropDownList)FindControl("ddlAns" + row["question_id"].ToString()));
//                    if (ddl != null)
//                    {
//                        quesId = Convert.ToInt32(row["question_id"].ToString());
//                        if (ddl.SelectedIndex == -1)
//                        {
//                            answer = ddl.SelectedIndex.ToString();
//                            answerWt = ddl.SelectedIndex.ToString();
//                            quesType = row["question_type"].ToString();
//                            dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
//                        }
//                        else
//                        {
//                            answer = ddl.SelectedItem.Text.ToString();
//                            answerWt = ddl.SelectedItem.Value.ToString();
//                            quesType = row["question_type"].ToString();
//                            dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
//                        }
//                    }
//                }
//                else
//                if (row["question_type"].ToString() == "Data Control")
//                {
//                    var ddl = ((DropDownList)FindControl("ddlAns" + row["question_id"].ToString()));
//                    if (ddl != null)
//                    {
//                        quesId = Convert.ToInt32(row["question_id"].ToString());
//                        if (ddl.SelectedIndex == -1)
//                        {
//                            answer = ddl.SelectedIndex.ToString();
//                            answerWt = ddl.SelectedIndex.ToString();
//                            quesType = row["question_type"].ToString();
//                            dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
//                        }
//                        else
//                        {
//                            answer = ddl.SelectedItem.Text.ToString();
//                            answerWt = ddl.SelectedItem.Value.ToString();
//                            quesType = row["question_type"].ToString();
//                            dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
//                        }
//                    }
//                }
//                else
//                if (row["question_type"].ToString() == "Consent")
//                {
//                    var ddl = ((DropDownList)FindControl("ddlAns" + row["question_id"].ToString()));
//                    if (ddl != null)
//                    {
//                        quesId = Convert.ToInt32(row["question_id"].ToString());
//                        if (ddl.SelectedIndex == -1)
//                        {
//                            answer = ddl.SelectedIndex.ToString();
//                            answerWt = ddl.SelectedIndex.ToString();
//                            quesType = row["question_type"].ToString();
//                            dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
//                        }
//                        else
//                        {
//                            answer = ddl.SelectedItem.Text.ToString();
//                            answerWt = ddl.SelectedItem.Value.ToString();
//                            quesType = row["question_type"].ToString();
//                            dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
//                        }
//                    }
//                }
//                else
//                if (row["question_type"].ToString() == "Incident Response")
//                {
//                    var ddl = ((DropDownList)FindControl("ddlAns" + row["question_id"].ToString()));
//                    if (ddl != null)
//                    {
//                        quesId = Convert.ToInt32(row["question_id"].ToString());
//                        if (ddl.SelectedIndex == -1)
//                        {
//                            answer = ddl.SelectedIndex.ToString();
//                            answerWt = ddl.SelectedIndex.ToString();
//                            quesType = row["question_type"].ToString();
//                            dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
//                        }
//                        else
//                        {
//                            answer = ddl.SelectedItem.Text.ToString();
//                            answerWt = ddl.SelectedItem.Value.ToString();
//                            quesType = row["question_type"].ToString();
//                            dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
//                        }
//                    }
//                }
//                else
//                if (row["question_type"].ToString() == "Employee Training")
//                {
//                    var ddl = ((DropDownList)FindControl("ddlAns" + row["question_id"].ToString()));
//                    if (ddl != null)
//                    {
//                        quesId = Convert.ToInt32(row["question_id"].ToString());
//                        if (ddl.SelectedIndex == -1)
//                        {
//                            answer = ddl.SelectedIndex.ToString();
//                            answerWt = ddl.SelectedIndex.ToString();
//                            quesType = row["question_type"].ToString();
//                            dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
//                        }
//                        else
//                        {
//                            answer = ddl.SelectedItem.Text.ToString();
//                            answerWt = ddl.SelectedItem.Value.ToString();
//                            quesType = row["question_type"].ToString();
//                            dal.SaveAnswers(userId, quesId, quesType, answerWt, answer);
//                        }
//                    }
//                }
//            }
//        }

//        private void LoadQuestionnaire()
//        {
//            DAL dal = new DAL();
//            DataTable dt = new DataTable();
//            dt = dal.LoadLevel1Questions();

//            foreach (DataRow row in dt.Rows)
//            {
//                var label = ((Label)FindControl("lblQues" + row["question_id"].ToString()));
//                if (label != null)
//                {
//                    label.Text = row["question"].ToString();
//                }

//                if (row["question_type"].ToString() == "Privacy Culture Questions")
//                {
//                    if (row["ctrl_type"].ToString() == "dd4")
//                    {
//                        var ddl = ((DropDownList)FindControl("ddlAns" + row["question_id"].ToString()));
//                        if (ddl != null)
//                        {
//                            ddl.Items.Add(new ListItem("YES", row["question_wt_yes"].ToString()));
//                            ddl.Items.Add(new ListItem("NO", row["question_wt_no"].ToString()));
//                            ddl.Items.Add(new ListItem("SOMEWHAT", row["question_wt_somewhat"].ToString()));
//                            ddl.Items.Add(new ListItem("UNSURE", row["question_wt_unsure"].ToString()));
//                        }
//                    }
//                }
//                else
//                if (row["question_type"].ToString() == "Regional Specific Questions")
//                {
//                    if (row["ctrl_type"].ToString() == "chkbx4")
//                    {
//                        var chkbx = ((CheckBoxList)FindControl("chkbxAns" + row["question_id"].ToString()));
//                        if (chkbx != null)
//                        {
//                            LoadRegions(chkbx);
//                        }
//                    }
//                    else
//                    if (row["ctrl_type"].ToString() == "dd2")
//                    {
//                        var ddl = ((DropDownList)FindControl("ddlAns" + row["question_id"].ToString()));
//                        if (ddl != null)
//                        {
//                            ddl.Items.Add(new ListItem("YES", row["question_wt_yes"].ToString()));
//                            ddl.Items.Add(new ListItem("NO", row["question_wt_no"].ToString()));
//                        }
//                    }
//                }
//                else
//                if (row["question_type"].ToString() == "Regional Fines")
//                {
//                    var ddl = ((DropDownList)FindControl("ddlAns" + row["question_id"].ToString()));
//                    if (ddl != null)
//                    {
//                        ddl.Items.Add(new ListItem("YES", row["question_wt_yes"].ToString()));
//                        ddl.Items.Add(new ListItem("NO", row["question_wt_no"].ToString()));
//                    }
//                }
//                else
//                if (row["question_type"].ToString() == "Privacy Engineering")
//                {
//                    var ddl = ((DropDownList)FindControl("ddlAns" + row["question_id"].ToString()));
//                    if (ddl != null)
//                    {
//                        ddl.Items.Add(new ListItem("YES", row["question_wt_yes"].ToString()));
//                        ddl.Items.Add(new ListItem("NO", row["question_wt_no"].ToString()));
//                        ddl.Items.Add(new ListItem("SOMEWHAT", row["question_wt_somewhat"].ToString()));
//                        ddl.Items.Add(new ListItem("UNSURE", row["question_wt_unsure"].ToString()));
//                    }
//                }
//                else
//                if (row["question_type"].ToString() == "Data Control")
//                {
//                    var ddl = ((DropDownList)FindControl("ddlAns" + row["question_id"].ToString()));
//                    if (ddl != null)
//                    {
//                        ddl.Items.Add(new ListItem("YES", row["question_wt_yes"].ToString()));
//                        ddl.Items.Add(new ListItem("NO", row["question_wt_no"].ToString()));
//                        ddl.Items.Add(new ListItem("SOMEWHAT", row["question_wt_somewhat"].ToString()));
//                        ddl.Items.Add(new ListItem("UNSURE", row["question_wt_unsure"].ToString()));
//                    }
//                }
//                else
//                if (row["question_type"].ToString() == "Consent")
//                {
//                    var ddl = ((DropDownList)FindControl("ddlAns" + row["question_id"].ToString()));
//                    if (ddl != null)
//                    {
//                        ddl.Items.Add(new ListItem("YES", row["question_wt_yes"].ToString()));
//                        ddl.Items.Add(new ListItem("NO", row["question_wt_no"].ToString()));
//                        ddl.Items.Add(new ListItem("SOMEWHAT", row["question_wt_somewhat"].ToString()));
//                        ddl.Items.Add(new ListItem("UNSURE", row["question_wt_unsure"].ToString()));
//                    }
//                }
//                else
//                if (row["question_type"].ToString() == "Incident Response")
//                {
//                    var ddl = ((DropDownList)FindControl("ddlAns" + row["question_id"].ToString()));
//                    if (ddl != null)
//                    {
//                        ddl.Items.Add(new ListItem("YES", row["question_wt_yes"].ToString()));
//                        ddl.Items.Add(new ListItem("NO", row["question_wt_no"].ToString()));
//                        ddl.Items.Add(new ListItem("SOMEWHAT", row["question_wt_somewhat"].ToString()));
//                        ddl.Items.Add(new ListItem("UNSURE", row["question_wt_unsure"].ToString()));
//                    }
//                }
//                else
//                if (row["question_type"].ToString() == "Employee Training")
//                {
//                    var ddl = ((DropDownList)FindControl("ddlAns" + row["question_id"].ToString()));
//                    if (ddl != null)
//                    {
//                        ddl.Items.Add(new ListItem("YES", row["question_wt_yes"].ToString()));
//                        ddl.Items.Add(new ListItem("NO", row["question_wt_no"].ToString()));
//                        ddl.Items.Add(new ListItem("SOMEWHAT", row["question_wt_somewhat"].ToString()));
//                        ddl.Items.Add(new ListItem("UNSURE", row["question_wt_unsure"].ToString()));
//                    }
//                }
//            }

//        }

//        private void LoadRegions(CheckBoxList checkBoxList)
//        {
//            DAL dal = new DAL();
//            DataTable dt = new DataTable();
//            dt = dal.LoadRegion();

//            checkBoxList.DataSource = dt;
//            checkBoxList.DataTextField = "region_name";
//            checkBoxList.DataValueField = "region_id";
//            checkBoxList.DataBind();
//        }
//    }
//}