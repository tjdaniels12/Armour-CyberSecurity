﻿using System;
using AjaxControlToolkit;
using System.Collections.Generic;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Net.Mail;
using System.Net;
using iTextSharp.text.html.simpleparser;
using System.Text;
using iTextSharp.tool.xml;
using Image = iTextSharp.text.Image;

namespace ArmourCyberSecurity
{
    public partial class SelfEvaluationReport : System.Web.UI.Page
    {

        DAL dal = new DAL();
        int pcq = 0, rsq = 0, rfq = 0, peq = 0, dcq = 0, cq = 0, irq = 0;
        string pcq_cmt = string.Empty, rsq_cmt = string.Empty, rfq_cmt = string.Empty, peq_cmt = string.Empty, dcq_cmt = string.Empty, cq_cmt = string.Empty, irq_cmt = string.Empty;

        protected void btnHide_Click(object sender, EventArgs e)
        {
            CreatePdf(pcq, rsq, rfq, peq, dcq, cq, irq, Session["pcq_cmt"].ToString(), Session["rsq_cmt"].ToString(), Session["rfq_cmt"].ToString(), Session["peq_cmt"].ToString(), Session["dcq_cmt"].ToString(), Session["cq_cmt"].ToString(), Session["irq_cmt"].ToString());
        }

       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ModalPopupExtender1.Show();
                DisplayReport();
            }
        }

        public void DisplayReport()
        {
            DataTable dt = new DataTable();
            dt = GetReport();
            foreach (DataRow row in dt.Rows)
            {
                if ((row["question_type"].ToString() == "Privacy Culture Questions") || (row["question_type"].ToString() == "Employee Training"))
                {
                    if (row["answer_wt"].ToString() != "-1")
                    {
                        pcq = pcq + Convert.ToInt32(row["answer_wt"]);
                    }
                }
                else
                if (row["question_type"].ToString() == "Regional Specific Questions")
                {
                    if (row["answer_wt"].ToString() != "-1")
                    {
                        rsq = rsq + Convert.ToInt32(row["answer_wt"]);
                    }
                }
                else
                if (row["question_type"].ToString() == "Regional Fines")
                {
                    if (row["answer_wt"].ToString() != "-1")
                    {
                        rfq = rfq + Convert.ToInt32(row["answer_wt"]);
                    }
                }
                else
                if (row["question_type"].ToString() == "Privacy Engineering")
                {
                    if (row["answer_wt"].ToString() != "-1")
                    {
                        peq = peq + Convert.ToInt32(row["answer_wt"]);
                    }
                }
                else
                if (row["question_type"].ToString() == "Data Control")
                {
                    if (row["answer_wt"].ToString() != "-1")
                    {
                        dcq = dcq + Convert.ToInt32(row["answer_wt"]);
                    }
                }
                else
                if (row["question_type"].ToString() == "Consent")
                {
                    if (row["answer_wt"].ToString() != "-1")
                    {
                        cq = cq + Convert.ToInt32(row["answer_wt"]);
                    }
                }
                else
                if (row["question_type"].ToString() == "Incident Response")
                {
                    if (row["answer_wt"].ToString() != "-1")
                    {
                        irq = irq + Convert.ToInt32(row["answer_wt"]);
                    }

                }
            }

            DataTable dt_Report = new DataTable();
            dt_Report = dal.GetReportComments();
            foreach (DataRow row in dt_Report.Rows)
            {
                if ((row["criteria"].ToString() == "Privacy Culture Questions"))
                {
                    if (pcq > 6 && pcq <= 10)
                    {
                        pcq_cmt = row["high_cmt"].ToString();
                    }
                    else
                    if (pcq > 4 && pcq <= 6)
                    {
                        pcq_cmt = row["med_cmt"].ToString();
                    }
                    else 
                    if (pcq <= 4)
                    {
                        pcq_cmt = row["low_cmt"].ToString();
                    }
                }
                else
                if (row["criteria"].ToString() == "Regional Specific Questions")
                {
                    if (rsq > 6 && rsq <= 10)
                    {
                        rsq_cmt = row["high_cmt"].ToString();
                    }
                    else
                    if (rsq > 4 && rsq <= 6)
                    {
                        rsq_cmt = row["med_cmt"].ToString();
                    }
                    else
                    if (rsq <= 4)
                    {
                        rsq_cmt = row["low_cmt"].ToString();
                    }
                }
                else
                if (row["criteria"].ToString() == "Regional Fines")
                {
                    if (rfq > 6 && rfq <= 10)
                    {
                        rfq_cmt = row["high_cmt"].ToString();
                    }
                    else
                    if (rfq > 4 && rfq <= 6)
                    {
                        rfq_cmt = row["med_cmt"].ToString();
                    }
                    else
                    if (rfq <= 4)
                    {
                        rfq_cmt = row["low_cmt"].ToString();
                    }

                }
                else
                if (row["criteria"].ToString() == "Privacy Engineering")
                {
                    if (peq > 6 && peq <= 10)
                    {
                        peq_cmt = row["high_cmt"].ToString();
                    }
                    else
                    if (peq > 4 && peq <= 6)
                    {
                        peq_cmt = row["med_cmt"].ToString();
                    }
                    else
                    if (peq <= 4)
                    {
                        peq_cmt = row["low_cmt"].ToString();
                    }
                }
                else
                if (row["criteria"].ToString() == "Data Control")
                {
                    if (dcq > 6 && dcq <= 10)
                    {
                        dcq_cmt = row["high_cmt"].ToString();
                    }
                    else
                    if (dcq > 4 && dcq <= 6)
                    {
                        dcq_cmt = row["med_cmt"].ToString();
                    }
                    else
                    if (dcq <= 4)
                    {
                        dcq_cmt = row["low_cmt"].ToString();
                    }

                }
                else
                if (row["criteria"].ToString() == "Consent")
                {
                    if (cq > 6 && cq <= 10)
                    {
                        cq_cmt = row["high_cmt"].ToString();
                    }
                    else
                    if (cq > 4 && cq <= 6)
                    {
                        cq_cmt = row["med_cmt"].ToString();
                    }
                    else
                    if (cq <= 4)
                    {
                        cq_cmt = row["low_cmt"].ToString();
                    }

                }
                else
                if (row["criteria"].ToString() == "Incident Response")
                {
                    if (irq > 6 && irq <= 10)
                    {
                        irq_cmt = row["high_cmt"].ToString();
                    }
                    else
                    if (irq > 4 && irq <= 6)
                    {
                        irq_cmt = row["med_cmt"].ToString();
                    }
                    else
                    if (irq <= 4)
                    {
                        irq_cmt = row["low_cmt"].ToString();
                    }

                }
            }

            bullet1.Text = "\u25C9";
            comment1.Text = pcq_cmt;
            Session["pcq_cmt"] = comment1.Text;

            bullet2.Text = "\u25C9";
            comment2.Text = rsq_cmt;
            Session["rsq_cmt"] = comment2.Text;

            bullet3.Text = "\u25C9";
            comment3.Text = rfq_cmt;
            Session["rfq_cmt"] = comment3.Text;

            bullet4.Text = "\u25C9";
            comment4.Text = peq_cmt;
            Session["peq_cmt"] = comment4.Text;

            bullet5.Text = "\u25C9";
            comment5.Text = dcq_cmt;
            Session["dcq_cmt"] = comment5.Text;

            bullet6.Text = "\u25C9";
            comment6.Text = cq_cmt;
            Session["cq_cmt"] = comment6.Text;

            bullet7.Text = "\u25C9";
            comment7.Text = irq_cmt;
            Session["irq_cmt"] = comment7.Text;

        }

        private void CreatePdf(int pcq, int rsq, int rfq, int peq, int dcq, int cq, int irq, string pcq_cmt, string rsq_cmt, string rfq_cmt, string peq_cmt, string dcq_cmt, string cq_cmt, string irq_cmt)
        {
            PdfPTable table = null;
            Phrase phrase = null;
            PdfPCell cell = null;
            BaseColor color = null;

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                   
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                        pdfDoc.Open();

                        string bgimagepath = Server.MapPath("images");
                        Image bgimg = Image.GetInstance(bgimagepath + "/Binary-Tattoo.jpg");
                        bgimg.ScaleToFit(1000, 500);
                        bgimg.Alignment = Image.UNDERLYING;
                        bgimg.SetAbsolutePosition(60, 200);
                        pdfDoc.Add(bgimg);

                        table = new PdfPTable(2);
                        table.TotalWidth = 500f;
                        table.LockedWidth = true;
                        table.SetWidths(new float[] { 0.3f, 0.7f });

                        //Armor Logo
                        string imagepath = Server.MapPath("images");
                        Image img = Image.GetInstance(imagepath + "/armor-logo.png");
                        img.ScalePercent(30f);
                        cell = new PdfPCell(img);
                        cell.BorderColor = BaseColor.WHITE;
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.PaddingBottom = 0f;
                        cell.PaddingTop = 0f;
                        table.AddCell(cell);

                        //Armor Address
                        phrase = new Phrase();
                        phrase.Add(new Chunk("Armor CyberSecurity\n\n", FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.RED)));
                        phrase.Add(new Chunk("77 Bloor St West,\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk("Suite 600, Toronto\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk("ON M5S 1M2", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.BorderColor = BaseColor.WHITE;
                        cell.PaddingBottom = 2f;
                        cell.PaddingTop = 0f;
                        table.AddCell(cell);

                        color = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"));
                        DrawLine(writer, 25f, pdfDoc.Top - 79f, pdfDoc.PageSize.Width - 25f, pdfDoc.Top - 79f, color);
                        DrawLine(writer, 25f, pdfDoc.Top - 80f, pdfDoc.PageSize.Width - 25f, pdfDoc.Top - 80f, color);

                        pdfDoc.Add(table);
    
                        table = new PdfPTable(2);
                        //table.TotalWidth = 2000f;
                        table.WidthPercentage = 90f;
                        table.HorizontalAlignment = Element.ALIGN_CENTER;
                        table.SetWidths(new float[] { 1f, 9f });
                        table.SpacingBefore = 20f;
                        table.DefaultCell.Border = Rectangle.NO_BORDER;

                        /* Introduction */
                        phrase = new Phrase();
                        phrase.Add(new Chunk("Global Data Privacy Regulation Compliance \n Self - Assessment", FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.Colspan = 2;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.VerticalAlignment = Element.ALIGN_TOP;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.PaddingBottom = 2f;
                        cell.PaddingTop = 2f;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk("Your clients’ data is your greatest asset. If the data is breached you will lose money, time, and credibility. Breaches can be avoided with good cyber security practices and compliance with regulations. Companies are legally required to fulfill the privacy regulations determined by the geographical location of both the company and their customers/clients. Compliance is a large task, but when done properly the first time, it becomes simple to maintain. Doing due diligence helps mitigate risk to customers, protects a company’s reputation, and drastically reduces fines." + "\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell.VerticalAlignment = Element.ALIGN_TOP;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.Colspan = 2;
                        table.AddCell(cell);

                        /* Introduction */

                        /* Privacy Culture */
                        phrase = new Phrase();
                        phrase.Add(new Chunk("Privacy Culture", FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.VerticalAlignment = Element.ALIGN_TOP;
                        cell.PaddingBottom = 2f;
                        cell.PaddingTop = 2f;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.Colspan = 2;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk("As a company you are entrusted with protecting data for both your customers and your employees. Putting in place a proper privacy program ensures that you mitigate risk to customers, protect your company’s reputation, and drastically reduces fines. ", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell.VerticalAlignment = Element.ALIGN_TOP;
                        cell.PaddingBottom = 2f;
                        cell.PaddingTop = 2f;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.Colspan = 2;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk(pcq + "\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.Border = PdfPCell.NO_BORDER;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk(pcq_cmt + "\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.Border = PdfPCell.NO_BORDER;
                        table.AddCell(cell);
                        /* Privacy Culture */

                        /* Regional Specific Questions */
                        phrase = new Phrase();
                        phrase.Add(new Chunk("Regional Specific Questions", FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.VerticalAlignment = Element.ALIGN_TOP;
                        cell.PaddingBottom = 2f;
                        cell.PaddingTop = 2f;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.Colspan = 2;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk("Both your location and that of your customers determine the legally required legislations for your company. ", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell.VerticalAlignment = Element.ALIGN_TOP;
                        cell.PaddingBottom = 2f;
                        cell.PaddingTop = 2f;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.Colspan = 2;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk(rsq + "\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.Border = PdfPCell.NO_BORDER;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk(rsq_cmt + "\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.Border = PdfPCell.NO_BORDER;
                        table.AddCell(cell);
                        /* Regional Specific Questions */

                        /* Regional Fines */
                        //phrase = new Phrase();
                        //phrase.Add(new Chunk("Regional Fines\n\n", FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK)));
                        //cell = new PdfPCell(phrase);
                        //cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        //cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        //cell.PaddingBottom = 2f;
                        //cell.PaddingTop = 2f;
                        //cell.Border = PdfPCell.NO_BORDER;
                        //table.AddCell(cell);

                        //phrase = new Phrase();
                        //phrase.Add(new Chunk(rfq_cmt + "\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        //cell = new PdfPCell(phrase);
                        //cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        //cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        //cell.Border = PdfPCell.NO_BORDER;
                        //table.AddCell(cell);
                        /* Regional Fines */

                        /* Privacy Engineering */
                        phrase = new Phrase();
                        phrase.Add(new Chunk("Privacy Engineering", FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.VerticalAlignment = Element.ALIGN_TOP;
                        cell.PaddingBottom = 2f;
                        cell.PaddingTop = 2f;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.Colspan = 2;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk("Putting Privacy at the foundation of all of your services and products is the key to building a strong base that is regulation compliant and protects your customers/clients. A proper privacy engineering implementation includes the use of Privacy by Design principles, running of a DPIA (Data Privacy Impact Assessment), categorization of your PII (Personally identifiable information), and proper vendor management.", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell.VerticalAlignment = Element.ALIGN_TOP;
                        cell.PaddingBottom = 2f;
                        cell.PaddingTop = 2f;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.Colspan = 2;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk(peq + "\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.Border = PdfPCell.NO_BORDER;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk(peq_cmt + "\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.Border = PdfPCell.NO_BORDER;
                        table.AddCell(cell);
                        /* Privacy Engineering */

                        /* Data Control */
                        phrase = new Phrase();
                        phrase.Add(new Chunk("Data Control", FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.VerticalAlignment = Element.ALIGN_TOP;
                        cell.PaddingBottom = 2f;
                        cell.PaddingTop = 2f;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.Colspan = 2;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk("Users have the right to access their data. Depending on the legislation, they may have the rights to check for accuracy, request correction, or simply review what is held. ", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell.VerticalAlignment = Element.ALIGN_TOP;
                        cell.PaddingBottom = 2f;
                        cell.PaddingTop = 2f;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.Colspan = 2;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk(dcq + "\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.Border = PdfPCell.NO_BORDER;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk(dcq_cmt + "\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.Border = PdfPCell.NO_BORDER;
                        table.AddCell(cell);
                        /* Data Control */

                        /* Consent */
                        phrase = new Phrase();
                        phrase.Add(new Chunk("Consent", FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.VerticalAlignment = Element.ALIGN_TOP;
                        cell.PaddingBottom = 2f;
                        cell.PaddingTop = 2f;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.Colspan = 2;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk("In accordance to the legislations, the privacy policy must explain to users what their rights are and how to execute on those rights. It is also important to establish a legal basis for which data is being collected. Users must have the ability to Opt in and out of having their data collected, stored, and transferred. ", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell.VerticalAlignment = Element.ALIGN_TOP;
                        cell.PaddingBottom = 2f;
                        cell.PaddingTop = 2f;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.Colspan = 2;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk(cq + "\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.Border = PdfPCell.NO_BORDER;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk(cq_cmt + "\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.Border = PdfPCell.NO_BORDER;
                        table.AddCell(cell);
                        /* Consent */

                        /* Incident Response */
                        phrase = new Phrase();
                        phrase.Add(new Chunk("Incident Response", FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.VerticalAlignment = Element.ALIGN_TOP;
                        cell.PaddingBottom = 2f;
                        cell.PaddingTop = 2f;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.Colspan = 2;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk("Lack of an incident response plan can cost a company upwards of $500k USD.  All privacy breaches and incidents must be assessed for risk of harm. Depending on the legislation, breaches will need to be documented, authorities contacted, and users informed. ", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell.VerticalAlignment = Element.ALIGN_TOP;
                        cell.PaddingBottom = 2f;
                        cell.PaddingTop = 2f;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.Colspan = 2;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk(irq + "\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.Border = PdfPCell.NO_BORDER;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk(irq_cmt + "\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.Border = PdfPCell.NO_BORDER;
                        table.AddCell(cell);
                        /* Incident Response */

                        pdfDoc.Add(table);

                        

                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                        pdfDoc.Close();
                        byte[] bytes = memoryStream.ToArray();
                        memoryStream.Close();
                        //Response.ContentType = "application/pdf";
                        //Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
                        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        //Response.Write(pdfDoc);
                        //Response.End();

                        MailMessage mm = new MailMessage("roshandeep810@gmail.com", "roshandeep1995@gmail.com");
                        mm.Subject = "Cyber Risk Assessment Report";
                        mm.Body = "Cyber Risk Assessment Report";
                        mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "CyberRiskAssessmentReport.pdf"));
                        mm.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential();
                        NetworkCred.UserName = "roshandeep810@gmail.com";
                        NetworkCred.Password = "roshandeep2895";
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 587;
                        smtp.Send(mm);
                    }
                }
            }
        }

        private static void DrawLine(PdfWriter writer, float x1, float y1, float x2, float y2, BaseColor color)
        {
            PdfContentByte contentByte = writer.DirectContent;
            contentByte.SetColorStroke(color);
            contentByte.MoveTo(x1, y1);
            contentByte.LineTo(x2, y2);
            contentByte.Stroke();
        }

        public DataTable GetReport()
        {
            //string userId = Session["userId"].ToString();
            string userId = "c35f931c-6517-4454-90ff-898d52869370";
            DataTable dt = new DataTable();
            dt = dal.GetUserReport(userId);
            return dt;
        }

    }
}
 