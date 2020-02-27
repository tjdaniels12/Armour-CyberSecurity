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
            LoadQuestions();
        }

        private void LoadQuestions()
        {
            DAL dal = new DAL();
            DataTable dt = new DataTable();
            dt = dal.LoadLevel1Questions();
            DisplayQuestions(dt);
        }

        private void DisplayQuestions(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                if (row["question_type"].ToString() == "Privacy Culture Questions")
                {
                    if (row["ctrl_type"].ToString() == "dd4")
                    {
                        TableRow tr = new TableRow();

                        TableCell td1 = new TableCell();
                        Label lbl = new Label();
                        lbl.ID = "Ques" + row["question_id"].ToString();
                        lbl.Text = row["question"].ToString();
                        //pnlQuestionnaire1.Controls.Add(lbl);
                        td1.Controls.Add(lbl);

                        TableCell td2 = new TableCell();
                        DropDownList ddl = new DropDownList();
                        ddl.ID = "Ans" + row["question_id"].ToString();
                        ddl.Items.Add(new ListItem("YES", row["question_wt_yes"].ToString()));
                        ddl.Items.Add(new ListItem("NO", row["question_wt_no"].ToString()));
                        ddl.Items.Add(new ListItem("SOMEWHAT", row["question_wt_somewhat"].ToString()));
                        ddl.Items.Add(new ListItem("UNSURE", row["question_wt_unsure"].ToString()));
                        //pnlQuestionnaire1.Controls.Add(ddl);
                        td2.Controls.Add(ddl);

                        tr.Cells.Add(td1);
                        tr.Cells.Add(td2);

                        Table1.Rows.Add(tr);

                    }
                }
                else
                if (row["question_type"].ToString() == "Regional Specific Questions")
                {
                    if (row["ctrl_type"].ToString() == "chkbx4")
                    {
                        TableRow tr = new TableRow();

                        TableCell td1 = new TableCell();
                        Label lbl = new Label();
                        lbl.ID = "Ques" + row["question_id"].ToString();
                        lbl.Text = row["question"].ToString();
                        td1.Controls.Add(lbl);

                        TableCell td2 = new TableCell();
                        CheckBoxList chkbxlist = new CheckBoxList();
                        chkbxlist.ID = "Ans" + row["question_id"].ToString();
                        chkbxlist.Items.Add(new ListItem("Canada"));
                        chkbxlist.Items.Add(new ListItem("Europe"));
                        chkbxlist.Items.Add(new ListItem("Brazil"));
                        chkbxlist.ClientIDMode = ClientIDMode.Static;
                        foreach (ListItem lstitem in chkbxlist.Items)
                        {
                            lstitem.Attributes.Add("onclick", "callFunction(this);");
                        }
                        td2.Controls.Add(chkbxlist);

                        tr.Cells.Add(td1);
                        tr.Cells.Add(td2);

                        Table1.Rows.Add(tr);
                    }
                    else
                    if (row["ctrl_type"].ToString() == "dd2")
                    {
                        TableRow tr = new TableRow();

                        TableCell td1 = new TableCell();
                        Label lbl = new Label();
                        lbl.ID = "Ques" + row["question_id"].ToString();
                        lbl.Text = row["question"].ToString();
                        td1.Controls.Add(lbl);

                        TableCell td2 = new TableCell();
                        DropDownList ddl = new DropDownList();
                        ddl.ID = "Ans" + row["question_id"].ToString();
                        ddl.Items.Add(new ListItem("YES", row["question_wt_yes"].ToString()));
                        ddl.Items.Add(new ListItem("NO", row["question_wt_no"].ToString()));
                        td2.Controls.Add(ddl);

                        tr.Cells.Add(td1);
                        tr.Cells.Add(td2);

                        Table1.Rows.Add(tr);
                    }
                }
                else
                if (row["question_type"].ToString() == "Regional Fines")
                {
                    if (row["ctrl_type"].ToString() == "dd2")
                    {
                        TableRow tr = new TableRow();

                        TableCell td1 = new TableCell();
                        Label lbl = new Label();
                        lbl.ID = "Ques" + row["question_id"].ToString();
                        lbl.Text = row["question"].ToString();
                        td1.Controls.Add(lbl);

                        TableCell td2 = new TableCell();
                        DropDownList ddl = new DropDownList();
                        ddl.ID = "Ans" + row["question_id"].ToString();
                        ddl.Items.Add(new ListItem("YES", row["question_wt_yes"].ToString()));
                        ddl.Items.Add(new ListItem("NO", row["question_wt_no"].ToString()));
                        td2.Controls.Add(ddl);

                        tr.Cells.Add(td1);
                        tr.Cells.Add(td2);

                        tbl_RegionalFines.Rows.Add(tr);
                    }
                }
                else
                if (row["question_type"].ToString() == "Privacy Engineering")
                {
                    if (row["ctrl_type"].ToString() == "dd4")
                    {
                        TableRow tr = new TableRow();

                        TableCell td1 = new TableCell();
                        Label lbl = new Label();
                        lbl.ID = "Ques" + row["question_id"].ToString();
                        lbl.Text = row["question"].ToString();
                        //pnlQuestionnaire1.Controls.Add(lbl);
                        td1.Controls.Add(lbl);

                        TableCell td2 = new TableCell();
                        DropDownList ddl = new DropDownList();
                        ddl.ID = "Ans" + row["question_id"].ToString();
                        ddl.Items.Add(new ListItem("YES", row["question_wt_yes"].ToString()));
                        ddl.Items.Add(new ListItem("NO", row["question_wt_no"].ToString()));
                        ddl.Items.Add(new ListItem("SOMEWHAT", row["question_wt_somewhat"].ToString()));
                        ddl.Items.Add(new ListItem("UNSURE", row["question_wt_unsure"].ToString()));
                        //pnlQuestionnaire1.Controls.Add(ddl);
                        td2.Controls.Add(ddl);

                        tr.Cells.Add(td1);
                        tr.Cells.Add(td2);

                        Table1.Rows.Add(tr);

                    }
                }
                else
                if (row["question_type"].ToString() == "Data Control")
                {
                    if (row["ctrl_type"].ToString() == "dd4")
                    {
                        TableRow tr = new TableRow();

                        TableCell td1 = new TableCell();
                        Label lbl = new Label();
                        lbl.ID = "Ques" + row["question_id"].ToString();
                        lbl.Text = row["question"].ToString();
                        //pnlQuestionnaire1.Controls.Add(lbl);
                        td1.Controls.Add(lbl);

                        TableCell td2 = new TableCell();
                        DropDownList ddl = new DropDownList();
                        ddl.ID = "Ans" + row["question_id"].ToString();
                        ddl.Items.Add(new ListItem("YES", row["question_wt_yes"].ToString()));
                        ddl.Items.Add(new ListItem("NO", row["question_wt_no"].ToString()));
                        ddl.Items.Add(new ListItem("SOMEWHAT", row["question_wt_somewhat"].ToString()));
                        ddl.Items.Add(new ListItem("UNSURE", row["question_wt_unsure"].ToString()));
                        //pnlQuestionnaire1.Controls.Add(ddl);
                        td2.Controls.Add(ddl);

                        tr.Cells.Add(td1);
                        tr.Cells.Add(td2);

                        Table1.Rows.Add(tr);

                    }
                }
                else
                if (row["question_type"].ToString() == "Consent")
                {
                    if (row["ctrl_type"].ToString() == "dd4")
                    {
                        TableRow tr = new TableRow();

                        TableCell td1 = new TableCell();
                        Label lbl = new Label();
                        lbl.ID = "Ques" + row["question_id"].ToString();
                        lbl.Text = row["question"].ToString();
                        //pnlQuestionnaire1.Controls.Add(lbl);
                        td1.Controls.Add(lbl);

                        TableCell td2 = new TableCell();
                        DropDownList ddl = new DropDownList();
                        ddl.ID = "Ans" + row["question_id"].ToString();
                        ddl.Items.Add(new ListItem("YES", row["question_wt_yes"].ToString()));
                        ddl.Items.Add(new ListItem("NO", row["question_wt_no"].ToString()));
                        ddl.Items.Add(new ListItem("SOMEWHAT", row["question_wt_somewhat"].ToString()));
                        ddl.Items.Add(new ListItem("UNSURE", row["question_wt_unsure"].ToString()));
                        //pnlQuestionnaire1.Controls.Add(ddl);
                        td2.Controls.Add(ddl);

                        tr.Cells.Add(td1);
                        tr.Cells.Add(td2);

                        Table1.Rows.Add(tr);

                    }
                }
                else
                if (row["question_type"].ToString() == "Incident Response")
                {
                    if (row["ctrl_type"].ToString() == "dd4")
                    {
                        TableRow tr = new TableRow();

                        TableCell td1 = new TableCell();
                        Label lbl = new Label();
                        lbl.ID = "Ques" + row["question_id"].ToString();
                        lbl.Text = row["question"].ToString();
                        //pnlQuestionnaire1.Controls.Add(lbl);
                        td1.Controls.Add(lbl);

                        TableCell td2 = new TableCell();
                        DropDownList ddl = new DropDownList();
                        ddl.ID = "Ans" + row["question_id"].ToString();
                        ddl.Items.Add(new ListItem("YES", row["question_wt_yes"].ToString()));
                        ddl.Items.Add(new ListItem("NO", row["question_wt_no"].ToString()));
                        ddl.Items.Add(new ListItem("SOMEWHAT", row["question_wt_somewhat"].ToString()));
                        ddl.Items.Add(new ListItem("UNSURE", row["question_wt_unsure"].ToString()));
                        //pnlQuestionnaire1.Controls.Add(ddl);
                        td2.Controls.Add(ddl);

                        tr.Cells.Add(td1);
                        tr.Cells.Add(td2);

                        Table1.Rows.Add(tr);

                    }
                }
                else
                if (row["question_type"].ToString() == "Employee Training")
                {
                    if (row["ctrl_type"].ToString() == "dd4")
                    {
                        TableRow tr = new TableRow();

                        TableCell td1 = new TableCell();
                        Label lbl = new Label();
                        lbl.ID = "Ques" + row["question_id"].ToString();
                        lbl.Text = row["question"].ToString();
                        //pnlQuestionnaire1.Controls.Add(lbl);
                        td1.Controls.Add(lbl);

                        TableCell td2 = new TableCell();
                        DropDownList ddl = new DropDownList();
                        ddl.ID = "Ans" + row["question_id"].ToString();
                        ddl.Items.Add(new ListItem("YES", row["question_wt_yes"].ToString()));
                        ddl.Items.Add(new ListItem("NO", row["question_wt_no"].ToString()));
                        ddl.Items.Add(new ListItem("SOMEWHAT", row["question_wt_somewhat"].ToString()));
                        ddl.Items.Add(new ListItem("UNSURE", row["question_wt_unsure"].ToString()));
                        //pnlQuestionnaire1.Controls.Add(ddl);
                        td2.Controls.Add(ddl);

                        tr.Cells.Add(td1);
                        tr.Cells.Add(td2);

                        Table1.Rows.Add(tr);

                    }
                }
            }      
                
        }
                
    }
}