using System;
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
        int pcq = 0, rsq = 0, rfq = 0, peq = 0, dcq = 0, cq = 0, irq = 0, overall = 0;
        string overall_cmt = string.Empty, pcq_cmt = string.Empty, rsq_cmt = string.Empty, rfq_cmt = string.Empty, peq_cmt = string.Empty, dcq_cmt = string.Empty, cq_cmt = string.Empty, irq_cmt = string.Empty;

        int pcq_high = 0, pcq_med = 0, pcq_low = 0;
        int rsq_high = 0, rsq_med = 0, rsq_low = 0;
        int rfq_high = 0, rfq_med = 0, rfq_low = 0;
        int peq_high = 0, peq_med = 0, peq_low = 0;
        int dcq_high = 0, dcq_med = 0, dcq_low = 0;
        int cq_high = 0, cq_med = 0, cq_low = 0;
        int irq_high = 0, irq_med = 0, irq_low = 0;

        protected void btnHide_Click(object sender, EventArgs e)
        {
            Session["user_mail"] = txt_EmalId.Text.ToString();
            dal.SaveUser(Session["user_mail"].ToString(), Session["userId"].ToString());
            CreatePdf(Convert.ToInt32(Session["overall"]), Convert.ToInt32(Session["pcq"]), Convert.ToInt32(Session["rsq"]), Convert.ToInt32(Session["rfq"]), Convert.ToInt32(Session["peq"]), Convert.ToInt32(Session["dcq"]), Convert.ToInt32(Session["cq"]), Convert.ToInt32(Session["irq"]), Session["overall_cmt"].ToString(), Session["pcq_cmt"].ToString(), Session["rsq_cmt"].ToString(), Session["rfq_cmt"].ToString(), Session["peq_cmt"].ToString(), Session["dcq_cmt"].ToString(), Session["cq_cmt"].ToString(), Session["irq_cmt"].ToString(), Session["pcq_status"].ToString(), Session["rsq_status"].ToString(), Session["peq_status"].ToString(), Session["dcq_status"].ToString(), Session["cq_status"].ToString(), Session["irq_status"].ToString());
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


            int counter1 = 0, counter2 = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (row["question_type"].ToString() == "Privacy Culture Questions")
                {
                    if (row["answer_wt"].ToString() != "-1")
                    {
                        pcq = pcq + Convert.ToInt32(row["answer_wt"]);
                    }

                    if (row["ans_Text"].ToString() == "YES")
                    {
                        pcq_high++;
                    }
                    else
                    if (row["ans_Text"].ToString() == "SOMEWHAT")
                    {
                        pcq_med++;
                    }
                    else
                    if(row["ans_Text"].ToString() == "NO" || row["ans_Text"].ToString() == "UNSURE")
                    {
                        pcq_low++;
                    }
                }
                else
                if (row["question_type"].ToString() == "Regional Specific Questions")
                {
                    if (row["answer_wt"].ToString() != "-1")
                    {
                        rsq = rsq + Convert.ToInt32(row["answer_wt"]);
                        counter1++;
                    }

                    if (row["ans_Text"].ToString() == "YES")
                    {
                        rsq_high++;
                    }
                    else
                    if (row["ans_Text"].ToString() == "SOMEWHAT")
                    {
                        rsq_med++;
                    }
                    else
                    if (row["ans_Text"].ToString() == "NO" || row["ans_Text"].ToString() == "UNSURE")
                    {
                        rsq_low++;
                    }
                }
                else
                if (row["question_type"].ToString() == "Regional Fines")
                {
                    if (row["answer_wt"].ToString() != "-1")
                    {
                        rfq = rfq + Convert.ToInt32(row["answer_wt"]);
                        counter2++;
                    }

                    if (row["ans_Text"].ToString() == "YES")
                    {
                        rfq_high++;
                    }
                    else
                    if (row["ans_Text"].ToString() == "SOMEWHAT")
                    {
                        rfq_med++;
                    }
                    else
                    if (row["ans_Text"].ToString() == "NO" || row["ans_Text"].ToString() == "UNSURE")
                    {
                        rfq_low++;
                    }
                }
                else
                if (row["question_type"].ToString() == "Privacy Engineering")
                {
                    if (row["answer_wt"].ToString() != "-1")
                    {
                        peq = peq + Convert.ToInt32(row["answer_wt"]);
                    }

                    if (row["ans_Text"].ToString() == "YES")
                    {
                        peq_high++;
                    }
                    else
                    if (row["ans_Text"].ToString() == "SOMEWHAT")
                    {
                        peq_med++;
                    }
                    else
                    if (row["ans_Text"].ToString() == "NO" || row["ans_Text"].ToString() == "UNSURE")
                    {
                        peq_low++;
                    }
                }
                else
                if (row["question_type"].ToString() == "Data Control")
                {
                    if (row["answer_wt"].ToString() != "-1")
                    {
                        dcq = dcq + Convert.ToInt32(row["answer_wt"]);
                    }
                    else
                    {
                        DAL dalobj = new DAL();
                        int dc_ans23 = dalobj.GetQues23Wt();
                        dcq = dcq + dc_ans23;
                    }

                    if (row["ans_Text"].ToString() == "YES")
                    {
                        dcq_high++;
                    }
                    else
                    if (row["ans_Text"].ToString() == "SOMEWHAT")
                    {
                        dcq_med++;
                    }
                    else
                    if (row["ans_Text"].ToString() == "NO" || row["ans_Text"].ToString() == "UNSURE")
                    {
                        dcq_low++;
                    }
                }
                else
                if (row["question_type"].ToString() == "Consent")
                {
                    if (row["answer_wt"].ToString() != "-1")
                    {
                        cq = cq + Convert.ToInt32(row["answer_wt"]);
                    }

                    if (row["ans_Text"].ToString() == "YES")
                    {
                        cq_high++;
                    }
                    else
                    if (row["ans_Text"].ToString() == "SOMEWHAT")
                    {
                        cq_med++;
                    }
                    else
                    if (row["ans_Text"].ToString() == "NO" || row["ans_Text"].ToString() == "UNSURE")
                    {
                        cq_low++;
                    }
                }
                else
                if (row["question_type"].ToString() == "Incident Response")
                {
                    if (row["answer_wt"].ToString() != "-1")
                    {
                        irq = irq + Convert.ToInt32(row["answer_wt"]);
                    }

                    if (row["ans_Text"].ToString() == "YES")
                    {
                        irq_high++;
                    }
                    else
                    if (row["ans_Text"].ToString() == "SOMEWHAT")
                    {
                        irq_med++;
                    }
                    else
                    if (row["ans_Text"].ToString() == "NO" || row["ans_Text"].ToString() == "UNSURE")
                    {
                        irq_low++;
                    }
                }
            }

            rsq = Convert.ToInt32(rsq / (counter1 - 2));
            rfq = Convert.ToInt32(rfq / counter2);
            overall = rsq + rfq + peq + dcq + cq + irq;

            DataTable dt_Report = new DataTable();
            dt_Report = dal.GetReportComments();
            foreach (DataRow row in dt_Report.Rows)
            {
                if ((row["criteria"].ToString() == "Overall"))
                {
                    if (pcq < 650)
                    {
                        overall_cmt = row["low_cmt"].ToString();
                    }
                    else
                    if (pcq >= 650 && pcq <= 750)
                    {
                        overall_cmt = row["med_cmt"].ToString();
                    }
                    else
                    if (pcq > 751)
                    {
                        overall_cmt = row["high_cmt"].ToString();
                    }
                }
                if ((row["criteria"].ToString() == "Privacy Culture Questions"))
                {
                    //if (pcq < 650)
                    //{
                    //    pcq_cmt = row["low_cmt"].ToString();
                    //    img_pcq.ImageUrl = Page.ResolveUrl("~/images/red.PNG");
                    //}
                    //else
                    //if (pcq >= 650 && pcq <= 750)
                    //{
                    //    pcq_cmt = row["med_cmt"].ToString();
                    //    img_pcq.ImageUrl = Page.ResolveUrl("~/images/yellow.PNG");
                    //}
                    //else
                    //if (pcq > 751)
                    //{
                    //    pcq_cmt = row["high_cmt"].ToString();
                    //    img_pcq.ImageUrl = Page.ResolveUrl("~/images/green.PNG");
                    //}

                    if(pcq_low > 0)
                    {
                        pcq_cmt = row["low_cmt"].ToString();
                        img_pcq.ImageUrl = Page.ResolveUrl("~/images/red.PNG");
                        Session["pcq_status"] = "LOW";
                    }
                    else
                    if(pcq_low == 0 && pcq_med >0)
                    {
                        pcq_cmt = row["med_cmt"].ToString();
                        img_pcq.ImageUrl = Page.ResolveUrl("~/images/yellow.PNG");
                        Session["pcq_status"] = "MED";
                    }
                    else
                    if(pcq_low == 0 && pcq_med == 0 && pcq_high > 0)
                    {
                        pcq_cmt = row["high_cmt"].ToString();
                        img_pcq.ImageUrl = Page.ResolveUrl("~/images/green.PNG");
                        Session["pcq_status"] = "HIGH";
                    }
                }
                else
                if (row["criteria"].ToString() == "Regional Specific Questions")
                {
                    //if (rsq < 650)
                    //{
                    //    rsq_cmt = row["low_cmt"].ToString();
                    //    img_rsq.ImageUrl = Page.ResolveUrl("~/images/red.PNG");
                    //}
                    //else
                    //if (rsq >= 650 && rsq <= 750)
                    //{
                    //    rsq_cmt = row["med_cmt"].ToString();
                    //    img_rsq.ImageUrl = Page.ResolveUrl("~/images/yellow.PNG");
                    //}
                    //else
                    //if (rsq > 751)
                    //{
                    //    rsq_cmt = row["high_cmt"].ToString();
                    //    img_rsq.ImageUrl = Page.ResolveUrl("~/images/green.PNG");
                    //}

                    if (rsq_low > 0)
                    {
                        rsq_cmt = row["low_cmt"].ToString();
                        img_rsq.ImageUrl = Page.ResolveUrl("~/images/red.PNG");
                        Session["rsq_status"] = "LOW";
                    }
                    else
                    if (rsq_low == 0 && rsq_med > 0)
                    {
                        rsq_cmt = row["med_cmt"].ToString();
                        img_rsq.ImageUrl = Page.ResolveUrl("~/images/yellow.PNG");
                        Session["rsq_status"] = "MED";
                    }
                    else
                    if (rsq_low == 0 && rsq_med == 0 && rsq_high > 0)
                    {
                        rsq_cmt = row["high_cmt"].ToString();
                        img_rsq.ImageUrl = Page.ResolveUrl("~/images/green.PNG");
                        Session["rsq_status"] = "HIGH";
                    }
                }
                else
                if (row["criteria"].ToString() == "Regional Fines")
                {
                    if (rfq < 650)
                    {
                        rfq_cmt = row["low_cmt"].ToString();
                    }
                    else
                    if (rfq >= 650 && rfq <= 750)
                    {
                        rfq_cmt = row["med_cmt"].ToString();
                    }
                    else
                    if (rfq > 751)
                    {
                        rfq_cmt = row["high_cmt"].ToString();
                    }

                }
                else
                if (row["criteria"].ToString() == "Privacy Engineering")
                {
                    //if (peq < 650)
                    //{
                    //    peq_cmt = row["low_cmt"].ToString();
                    //    img_peq.ImageUrl = Page.ResolveUrl("~/images/red.PNG");
                    //}
                    //else
                    //if (peq >= 650 && peq <= 750)
                    //{
                    //    peq_cmt = row["med_cmt"].ToString();
                    //    img_peq.ImageUrl = Page.ResolveUrl("~/images/yellow.PNG");
                    //}
                    //else
                    //if (peq > 750)
                    //{
                    //    peq_cmt = row["high_cmt"].ToString();
                    //    img_peq.ImageUrl = Page.ResolveUrl("~/images/green.PNG");
                    //}

                    if (peq_low > 0)
                    {
                        peq_cmt = row["low_cmt"].ToString();
                        img_peq.ImageUrl = Page.ResolveUrl("~/images/red.PNG");
                        Session["peq_status"] = "LOW";
                    }
                    else
                    if (peq_low == 0 && peq_med > 0)
                    {
                        peq_cmt = row["med_cmt"].ToString();
                        img_peq.ImageUrl = Page.ResolveUrl("~/images/yellow.PNG");
                        Session["peq_status"] = "MED";
                    }
                    else
                    if (peq_low == 0 && peq_med == 0 && peq_high > 0)
                    {
                        peq_cmt = row["low_cmt"].ToString();
                        img_peq.ImageUrl = Page.ResolveUrl("~/images/red.PNG");
                        Session["peq_status"] = "HIGH";
                    }
                }
                else
                if (row["criteria"].ToString() == "Data Control")
                {
                    //if (dcq < 650)
                    //{
                    //    dcq_cmt = row["low_cmt"].ToString();
                    //    img_dcq.ImageUrl = Page.ResolveUrl("~/images/red.PNG");
                    //}
                    //else
                    //if (dcq >= 650 && dcq <= 750)
                    //{
                    //    dcq_cmt = row["med_cmt"].ToString();
                    //    img_dcq.ImageUrl = Page.ResolveUrl("~/images/yellow.PNG");
                    //}
                    //else
                    //if (dcq > 750)
                    //{
                    //    dcq_cmt = row["high_cmt"].ToString();
                    //    img_dcq.ImageUrl = Page.ResolveUrl("~/images/green.PNG");
                    //}

                    if (dcq_low > 0)
                    {
                        dcq_cmt = row["low_cmt"].ToString();
                        img_dcq.ImageUrl = Page.ResolveUrl("~/images/red.PNG");
                        Session["dcq_status"] = "LOW";
                    }
                    else
                    if (dcq_low == 0 && dcq_med > 0)
                    {
                        dcq_cmt = row["med_cmt"].ToString();
                        img_dcq.ImageUrl = Page.ResolveUrl("~/images/yellow.PNG");
                        Session["dcq_status"] = "MED";
                    }
                    else
                    if (dcq_low == 0 && dcq_med == 0 && dcq_high > 0)
                    {
                        dcq_cmt = row["high_cmt"].ToString();
                        img_dcq.ImageUrl = Page.ResolveUrl("~/images/green.PNG");
                        Session["dcq_status"] = "HIGH";
                    }

                }
                else
                if (row["criteria"].ToString() == "Consent")
                {
                    //if (cq < 650)
                    //{
                    //    cq_cmt = row["low_cmt"].ToString();
                    //    img_cq.ImageUrl = Page.ResolveUrl("~/images/red.PNG");
                    //}
                    //else
                    //if (cq >= 650 && cq <= 750)
                    //{
                    //    cq_cmt = row["med_cmt"].ToString();
                    //    img_cq.ImageUrl = Page.ResolveUrl("~/images/yellow.PNG");
                    //}
                    //else
                    //if (cq > 750)
                    //{
                    //    cq_cmt = row["high_cmt"].ToString();
                    //    img_cq.ImageUrl = Page.ResolveUrl("~/images/green.PNG");
                    //}

                    if (cq_low > 0)
                    {
                        cq_cmt = row["low_cmt"].ToString();
                        img_cq.ImageUrl = Page.ResolveUrl("~/images/red.PNG");
                        Session["cq_status"] = "LOW";
                    }
                    else
                    if (cq_low == 0 && cq_med > 0)
                    {
                        cq_cmt = row["med_cmt"].ToString();
                        img_cq.ImageUrl = Page.ResolveUrl("~/images/yellow.PNG");
                        Session["cq_status"] = "MED";
                    }
                    else
                    if (cq_low == 0 && cq_med == 0 && cq_high > 0)
                    {
                        cq_cmt = row["high_cmt"].ToString();
                        img_cq.ImageUrl = Page.ResolveUrl("~/images/green.PNG");
                        Session["cq_status"] = "HIGH";
                    }

                }
                else
                if (row["criteria"].ToString() == "Incident Response")
                {
                    //if (irq < 650)
                    //{
                    //    irq_cmt = row["low_cmt"].ToString();
                    //    img_irq.ImageUrl = Page.ResolveUrl("~/images/red.PNG");
                    //}
                    //else
                    //if (irq >= 650 && irq <= 750)
                    //{
                    //    irq_cmt = row["med_cmt"].ToString();
                    //    img_irq.ImageUrl = Page.ResolveUrl("~/images/yellow.PNG");
                    //}
                    //else
                    //if (irq > 750)
                    //{
                    //    irq_cmt = row["high_cmt"].ToString();
                    //    img_irq.ImageUrl = Page.ResolveUrl("~/images/green.PNG");
                    //}

                    if (irq_low > 0)
                    {
                        irq_cmt = row["low_cmt"].ToString();
                        img_irq.ImageUrl = Page.ResolveUrl("~/images/red.PNG");
                        Session["irq_status"] = "LOW";
                    }
                    else
                    if (irq_low == 0 && irq_med > 0)
                    {
                        irq_cmt = row["med_cmt"].ToString();
                        img_irq.ImageUrl = Page.ResolveUrl("~/images/yellow.PNG");
                        Session["irq_status"] = "MED";
                    }
                    else
                    if (irq_low == 0 && irq_med == 0 && irq_high > 0)
                    {
                        irq_cmt = row["high_cmt"].ToString();
                        img_irq.ImageUrl = Page.ResolveUrl("~/images/green.PNG");
                        Session["irq_status"] = "HIGH";
                    }

                }
            }

            Session["overall_cmt"] = overall_cmt;
            Session["overall"] = overall;

            bullet1.Text = "\u25C9";
            comment1.Text = pcq_cmt;
            Session["pcq_cmt"] = comment1.Text;
            lbl_pcq_score.Text = pcq.ToString();
            Session["pcq"] = pcq;

            bullet2.Text = "\u25C9";
            comment2.Text = rsq_cmt;
            Session["rsq_cmt"] = comment2.Text;
            lbl_rsq_score.Text = rsq.ToString();
            Session["rsq"] = rsq;

            Session["rfq_cmt"] = rfq_cmt;
            Session["rfq"] = rfq;

            bullet4.Text = "\u25C9";
            comment4.Text = peq_cmt;
            Session["peq_cmt"] = comment4.Text;
            lbl_peq_score.Text = peq.ToString();
            Session["peq"] = peq;

            bullet5.Text = "\u25C9";
            comment5.Text = dcq_cmt;
            Session["dcq_cmt"] = comment5.Text;
            lbl_dcq_score.Text = dcq.ToString();
            Session["dcq"] = dcq;

            bullet6.Text = "\u25C9";
            comment6.Text = cq_cmt;
            Session["cq_cmt"] = comment6.Text;
            lbl_cq_score.Text = cq.ToString();
            Session["cq"] = cq;

            bullet7.Text = "\u25C9";
            comment7.Text = irq_cmt;
            Session["irq_cmt"] = comment7.Text;
            lbl_irq_score.Text = irq.ToString();
            Session["irq"] = irq;

        }

        private void CreatePdf(int overall, int pcq, int rsq, int rfq, int peq, int dcq, int cq, int irq, string overall_cmt, string pcq_cmt, string rsq_cmt, string rfq_cmt, string peq_cmt, string dcq_cmt, string cq_cmt, string irq_cmt, string pcq_status, string rsq_status, string peq_status, string dcq_status, string cq_status, string irq_status)
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
                        writer.PageEvent = new PDFFooter();
                        pdfDoc.Open();

                        //Add border to page
                        PdfContentByte content = writer.DirectContent;
                        Rectangle rectangle = new Rectangle(pdfDoc.PageSize);
                        rectangle.Left += pdfDoc.LeftMargin;
                        rectangle.Right -= pdfDoc.RightMargin;
                        rectangle.Top -= pdfDoc.TopMargin;
                        rectangle.Bottom += pdfDoc.BottomMargin + 10;
                        content.SetColorStroke(BaseColor.BLACK);
                        content.Rectangle(rectangle.Left, rectangle.Bottom, rectangle.Width, rectangle.Height);
                        content.Stroke();

                        //Watermark
                        string bgimagepath = Server.MapPath("images");
                        Image bgimg = Image.GetInstance(bgimagepath + "/newLogo-watermark.png");
                        bgimg.ScaleToFit(1000, 500);
                        bgimg.Alignment = Image.UNDERLYING;
                        bgimg.SetAbsolutePosition((PageSize.A4.Width - bgimg.ScaledWidth) / 2, (PageSize.A4.Height - bgimg.ScaledHeight) / 2);
                        pdfDoc.Add(bgimg);

                        table = new PdfPTable(2);
                        table.TotalWidth = 500f;
                        table.LockedWidth = true;
                        table.SetWidths(new float[] { 0.3f, 0.7f });
                        table.DefaultCell.Border = Rectangle.NO_BORDER;

                        //Armor Logo
                        string imagepath = Server.MapPath("images");
                        Image img = Image.GetInstance(imagepath + "/newLogo.png");
                        img.ScaleAbsolute(50, 61);
                        cell = new PdfPCell(img);
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.PaddingBottom = 0f;
                        cell.PaddingTop = 0f;
                        table.AddCell(cell);

                        //Armor Address
                        phrase = new Phrase();
                        phrase.Add(new Chunk("Armor CyberSecurity\n\n", FontFactory.GetFont("Arial", 18, Font.BOLD, new BaseColor(7, 149, 214))));
                        phrase.Add(new Chunk("77 Bloor St West,\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk("Suite 600, Toronto\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk("ON M5S 1M2", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.Border = PdfPCell.NO_BORDER;
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
                        table.SetWidths(new float[] { 2f, 8f });
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
                        cell.PaddingBottom = 5f;
                        cell.PaddingTop = 5f;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk("Your clients’ data is your greatest asset. If the data is breached you will lose money, time, and credibility. Breaches can be avoided with good cyber security practices and compliance with regulations. Companies are legally required to fulfill the privacy regulations determined by the geographical location of both the company and their customers/clients. Compliance is a large task, but when done properly the first time, it becomes simple to maintain. Doing due diligence helps mitigate risk to customers, protects a company’s reputation, and drastically reduces fines." + "\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell.VerticalAlignment = Element.ALIGN_TOP;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.PaddingBottom = 5f;
                        cell.PaddingTop = 5f;
                        cell.Colspan = 2;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk("Overall Score – Are you Privacy Regulation Compliant?", FontFactory.GetFont("Arial", 16, Font.BOLD | Font.UNDERLINE, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.VerticalAlignment = Element.ALIGN_TOP;
                        cell.PaddingBottom = 5f;
                        cell.PaddingTop = 5f;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.Colspan = 2;
                        table.AddCell(cell);

                        Image overall_img;
                        if (overall < 650)
                        {
                            overall_img = Image.GetInstance(imagepath + "/red_circle.png");
                            overall_img.ScaleAbsolute(75f, 75f);
                            cell = new PdfPCell(overall_img);
                        }
                        else
                        if (overall >= 650 && overall <= 750)
                        {
                            overall_img = Image.GetInstance(imagepath + "/yellow_circle.png");
                            overall_img.ScaleAbsolute(75f, 75f);
                            cell = new PdfPCell(overall_img);
                        }
                        else
                        if (overall > 751)
                        {
                            overall_img = Image.GetInstance(imagepath + "/green_circle.png");
                            overall_img.ScaleAbsolute(75f, 75f);
                            cell = new PdfPCell(overall_img);
                        }
                        cell.BorderColor = BaseColor.WHITE;
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.PaddingBottom = 0f;
                        cell.PaddingTop = 0f;
                        cell.Border = PdfPCell.NO_BORDER;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk("Your Risk Score is : " + overall + "\n", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)));
                        phrase.Add(new Chunk(overall_cmt + "\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.PaddingBottom = 5f;
                        cell.PaddingTop = 5f;
                        table.AddCell(cell);

                        /* Introduction */

                        /* Privacy Culture */
                        phrase = new Phrase();
                        phrase.Add(new Chunk("Privacy Culture", FontFactory.GetFont("Arial", 16, Font.BOLD | Font.UNDERLINE, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.VerticalAlignment = Element.ALIGN_TOP;
                        cell.PaddingBottom = 5f;
                        cell.PaddingTop = 5f;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.Colspan = 2;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk("As a company you are entrusted with protecting data for both your customers and your employees. Putting in place a proper privacy program ensures that you mitigate risk to customers, protect your company’s reputation, and drastically reduces fines. ", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell.VerticalAlignment = Element.ALIGN_TOP;
                        cell.PaddingBottom = 5f;
                        cell.PaddingTop = 5f;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.Colspan = 2;
                        table.AddCell(cell);

                        Image pcq_img;
                        if (pcq_status == "LOW")
                        {
                            pcq_img = Image.GetInstance(imagepath + "/red_circle.png");
                            pcq_img.ScaleAbsolute(75f, 75f);
                            cell = new PdfPCell(pcq_img);
                        }
                        else
                        if (pcq_status == "MED")
                        {
                            pcq_img = Image.GetInstance(imagepath + "/yellow_circle.png");
                            pcq_img.ScaleAbsolute(75f, 75f);
                            cell = new PdfPCell(pcq_img);
                        }
                        else
                        if (pcq_status == "HIGH")
                        {
                            pcq_img = Image.GetInstance(imagepath + "/green_circle.png");
                            pcq_img.ScaleAbsolute(75f, 75f);
                            cell = new PdfPCell(pcq_img);
                        }
                        cell.BorderColor = BaseColor.WHITE;
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.PaddingBottom = 0f;
                        cell.PaddingTop = 0f;
                        cell.Border = PdfPCell.NO_BORDER;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk("Your Risk Score is : " + pcq + "\n", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)));
                        phrase.Add(new Chunk(pcq_cmt + "\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.PaddingBottom = 5f;
                        cell.PaddingTop = 5f;
                        table.AddCell(cell);
                        /* Privacy Culture */

                        /* Regional Specific Questions */
                        phrase = new Phrase();
                        phrase.Add(new Chunk("Regional Specific Questions", FontFactory.GetFont("Arial", 16, Font.BOLD | Font.UNDERLINE, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.VerticalAlignment = Element.ALIGN_TOP;
                        cell.PaddingBottom = 5f;
                        cell.PaddingTop = 5f;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.Colspan = 2;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk("Both your location and that of your customers determine the legally required legislations for your company. ", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell.VerticalAlignment = Element.ALIGN_TOP;
                        cell.PaddingBottom = 5f;
                        cell.PaddingTop = 5f;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.Colspan = 2;
                        table.AddCell(cell);

                        Image rsq_img;
                        if (rsq_status == "LOW")
                        {
                            rsq_img = Image.GetInstance(imagepath + "/red_circle.png");
                            rsq_img.ScaleAbsolute(75f, 75f);
                            cell = new PdfPCell(rsq_img);
                        }
                        else
                        if (rsq_status == "MED")
                        {
                            rsq_img = Image.GetInstance(imagepath + "/yellow_circle.png");
                            rsq_img.ScaleAbsolute(75f, 75f);
                            cell = new PdfPCell(rsq_img);
                        }
                        else
                        if (rsq_status == "HIGH")
                        {
                            rsq_img = Image.GetInstance(imagepath + "/green_circle.png");
                            rsq_img.ScaleAbsolute(75f, 75f);
                            cell = new PdfPCell(rsq_img);
                        }
                        cell.BorderColor = BaseColor.WHITE;
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.PaddingBottom = 0f;
                        cell.PaddingTop = 0f;
                        cell.Border = PdfPCell.NO_BORDER;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk("Your Risk Score is : " + rsq + "\n", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)));
                        phrase.Add(new Chunk(rsq_cmt + "\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.PaddingBottom = 5f;
                        cell.PaddingTop = 5f;
                        table.AddCell(cell);
                        /* Regional Specific Questions */

                        /* Privacy Engineering */
                        phrase = new Phrase();
                        phrase.Add(new Chunk("Privacy Engineering", FontFactory.GetFont("Arial", 16, Font.BOLD | Font.UNDERLINE, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.VerticalAlignment = Element.ALIGN_TOP;
                        cell.PaddingBottom = 5f;
                        cell.PaddingTop = 5f;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.Colspan = 2;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk("Putting Privacy at the foundation of all of your services and products is the key to building a strong base that is regulation compliant and protects your customers/clients. A proper privacy engineering implementation includes the use of Privacy by Design principles, running of a DPIA (Data Privacy Impact Assessment), categorization of your PII (Personally identifiable information), and proper vendor management.", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell.VerticalAlignment = Element.ALIGN_TOP;
                        cell.PaddingBottom = 5f;
                        cell.PaddingTop = 5f;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.Colspan = 2;
                        table.AddCell(cell);

                        Image peq_img;
                        if (peq_status == "LOW")
                        {
                            peq_img = Image.GetInstance(imagepath + "/red_circle.png");
                            peq_img.ScaleAbsolute(75f, 75f);
                            cell = new PdfPCell(peq_img);
                        }
                        else
                        if (peq_status == "MED")
                        {
                            peq_img = Image.GetInstance(imagepath + "/yellow_circle.png");
                            peq_img.ScaleAbsolute(75f, 75f);
                            cell = new PdfPCell(peq_img);
                        }
                        else
                        if (peq_status == "HIGH")
                        {
                            peq_img = Image.GetInstance(imagepath + "/green_circle.png");
                            peq_img.ScaleAbsolute(75f, 75f);
                            cell = new PdfPCell(peq_img);
                        }
                        cell.BorderColor = BaseColor.WHITE;
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.PaddingBottom = 0f;
                        cell.PaddingTop = 0f;
                        cell.Border = PdfPCell.NO_BORDER;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk("Your Risk Score is : " + peq + "\n", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)));
                        phrase.Add(new Chunk(peq_cmt + "\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.PaddingBottom = 5f;
                        cell.PaddingTop = 5f;
                        table.AddCell(cell);
                        /* Privacy Engineering */

                        pdfDoc.Add(table);


                        /* ########################################SECOND PAGE######################################## */
                        pdfDoc.NewPage();

                        //Add border to page
                        rectangle.Left += pdfDoc.LeftMargin - 10;
                        rectangle.Right -= pdfDoc.RightMargin - 10;
                        rectangle.Top -= pdfDoc.TopMargin - 10;
                        rectangle.Bottom += pdfDoc.BottomMargin;
                        content.SetColorStroke(BaseColor.BLACK);
                        content.Rectangle(rectangle.Left, rectangle.Bottom, rectangle.Width, rectangle.Height);
                        content.Stroke();

                        string bgimagepath2 = Server.MapPath("images");
                        Image bgimg2 = Image.GetInstance(bgimagepath2 + "/newLogo-watermark.png");
                        bgimg2.ScaleToFit(1000, 500);
                        bgimg2.Alignment = Image.UNDERLYING;
                        bgimg2.SetAbsolutePosition((PageSize.A4.Width - bgimg.ScaledWidth) / 2, (PageSize.A4.Height - bgimg.ScaledHeight) / 2);
                        pdfDoc.Add(bgimg2);

                        table = new PdfPTable(2);
                        table.TotalWidth = 500f;
                        table.LockedWidth = true;
                        table.SetWidths(new float[] { 0.3f, 0.7f });
                        table.DefaultCell.Border = Rectangle.NO_BORDER;

                        //Armor Logo
                        img.ScaleAbsolute(50, 61);
                        cell = new PdfPCell(img);
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.PaddingBottom = 0f;
                        cell.PaddingTop = 0f;
                        table.AddCell(cell);

                        //Armor Address
                        phrase = new Phrase();
                        phrase.Add(new Chunk("Armor CyberSecurity\n\n", FontFactory.GetFont("Arial", 18, Font.BOLD, new BaseColor(7, 149, 214))));
                        phrase.Add(new Chunk("77 Bloor St West,\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk("Suite 600, Toronto\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk("ON M5S 1M2", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.PaddingBottom = 2f;
                        cell.PaddingTop = 0f;
                        table.AddCell(cell);

                        color = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"));
                        DrawLine(writer, 25f, pdfDoc.Top - 79f, pdfDoc.PageSize.Width - 25f, pdfDoc.Top - 79f, color);
                        DrawLine(writer, 25f, pdfDoc.Top - 80f, pdfDoc.PageSize.Width - 25f, pdfDoc.Top - 80f, color);

                        pdfDoc.Add(table);

                        table = new PdfPTable(2);
                        table.WidthPercentage = 90f;
                        table.HorizontalAlignment = Element.ALIGN_CENTER;
                        table.SetWidths(new float[] { 2f, 8f });
                        table.SpacingBefore = 20f;
                        table.DefaultCell.Border = Rectangle.NO_BORDER;

                        /* Data Control */
                        phrase = new Phrase();
                        phrase.Add(new Chunk("Data Control", FontFactory.GetFont("Arial", 16, Font.BOLD | Font.UNDERLINE, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.VerticalAlignment = Element.ALIGN_TOP;
                        cell.PaddingBottom = 5f;
                        cell.PaddingTop = 5f;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.Colspan = 2;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk("Users have the right to access their data. Depending on the legislation, they may have the rights to check for accuracy, request correction, or simply review what is held. ", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell.VerticalAlignment = Element.ALIGN_TOP;
                        cell.PaddingBottom = 5f;
                        cell.PaddingTop = 5f;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.Colspan = 2;
                        table.AddCell(cell);

                        Image dcq_img;
                        if (dcq_status == "LOW")
                        {
                            dcq_img = Image.GetInstance(imagepath + "/red_circle.png");
                            dcq_img.ScaleAbsolute(75f, 75f);
                            cell = new PdfPCell(dcq_img);
                        }
                        else
                        if (dcq_status == "MED")
                        {
                            dcq_img = Image.GetInstance(imagepath + "/yellow_circle.png");
                            dcq_img.ScaleAbsolute(75f, 75f);
                            cell = new PdfPCell(dcq_img);
                        }
                        else
                        if (dcq_status == "HIGH")
                        {
                            dcq_img = Image.GetInstance(imagepath + "/green_circle.png");
                            dcq_img.ScaleAbsolute(75f, 75f);
                            cell = new PdfPCell(dcq_img);
                        }
                        cell.BorderColor = BaseColor.WHITE;
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.PaddingBottom = 0f;
                        cell.PaddingTop = 0f;
                        cell.Border = PdfPCell.NO_BORDER;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk("Your Risk Score is : " + dcq + "\n", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)));
                        phrase.Add(new Chunk(dcq_cmt + "\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.PaddingBottom = 5f;
                        cell.PaddingTop = 5f;
                        table.AddCell(cell);
                        /* Data Control */

                        /* Consent */
                        phrase = new Phrase();
                        phrase.Add(new Chunk("Consent", FontFactory.GetFont("Arial", 16, Font.BOLD | Font.UNDERLINE, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.VerticalAlignment = Element.ALIGN_TOP;
                        cell.PaddingBottom = 5f;
                        cell.PaddingTop = 5f;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.Colspan = 2;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk("In accordance to the legislations, the privacy policy must explain to users what their rights are and how to execute on those rights. It is also important to establish a legal basis for which data is being collected. Users must have the ability to Opt in and out of having their data collected, stored, and transferred. ", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell.VerticalAlignment = Element.ALIGN_TOP;
                        cell.PaddingBottom = 5f;
                        cell.PaddingTop = 5f;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.Colspan = 2;
                        table.AddCell(cell);

                        Image cq_img;
                        if (cq_status == "LOW")
                        {
                            cq_img = Image.GetInstance(imagepath + "/red_circle.png");
                            cq_img.ScaleAbsolute(75f, 75f);
                            cell = new PdfPCell(cq_img);
                        }
                        else
                        if (cq_status == "MED")
                        {
                            cq_img = Image.GetInstance(imagepath + "/yellow_circle.png");
                            cq_img.ScaleAbsolute(75f, 75f);
                            cell = new PdfPCell(cq_img);
                        }
                        else
                        if (cq_status == "HIGH")
                        {
                            cq_img = Image.GetInstance(imagepath + "/green_circle.png");
                            cq_img.ScaleAbsolute(75f, 75f);
                            cell = new PdfPCell(cq_img);
                        }
                        cell.BorderColor = BaseColor.WHITE;
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.PaddingBottom = 0f;
                        cell.PaddingTop = 0f;
                        cell.Border = PdfPCell.NO_BORDER;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk("Your Risk Score is : " + cq + "\n", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)));
                        phrase.Add(new Chunk(cq_cmt + "\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.PaddingBottom = 5f;
                        cell.PaddingTop = 5f;
                        table.AddCell(cell);
                        /* Consent */

                        /* Incident Response */
                        phrase = new Phrase();
                        phrase.Add(new Chunk("Incident Response", FontFactory.GetFont("Arial", 16, Font.BOLD | Font.UNDERLINE, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.VerticalAlignment = Element.ALIGN_TOP;
                        cell.PaddingBottom = 5f;
                        cell.PaddingTop = 5f;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.Colspan = 2;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk("Lack of an incident response plan can cost a company upwards of $500k USD.  All privacy breaches and incidents must be assessed for risk of harm. Depending on the legislation, breaches will need to be documented, authorities contacted, and users informed. ", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell.VerticalAlignment = Element.ALIGN_TOP;
                        cell.PaddingBottom = 5f;
                        cell.PaddingTop = 5f;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.Colspan = 2;
                        table.AddCell(cell);

                        Image irq_img;
                        if (irq_status == "LOW")
                        {
                            irq_img = Image.GetInstance(imagepath + "/red_circle.png");
                            irq_img.ScaleAbsolute(75f, 75f);
                            cell = new PdfPCell(irq_img);
                        }
                        else
                        if (irq_status == "MED")
                        {
                            irq_img = Image.GetInstance(imagepath + "/yellow_circle.png");
                            irq_img.ScaleAbsolute(75f, 75f);
                            cell = new PdfPCell(irq_img);
                        }
                        else
                        if (irq_status == "HIGH")
                        {
                            irq_img = Image.GetInstance(imagepath + "/green_circle.png");
                            irq_img.ScaleAbsolute(75f, 75f);
                            cell = new PdfPCell(irq_img);
                        }
                        cell.BorderColor = BaseColor.WHITE;
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.PaddingBottom = 0f;
                        cell.PaddingTop = 0f;
                        cell.Border = PdfPCell.NO_BORDER;
                        table.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk("Your Risk Score is : " + irq + "\n", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)));
                        phrase.Add(new Chunk(irq_cmt + "\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.PaddingBottom = 5f;
                        cell.PaddingTop = 5f;
                        table.AddCell(cell);
                        /* Incident Response */

                        /* Call for action */
                        phrase = new Phrase();
                        phrase.Add(new Chunk("To best protect your clients, your company and your reputation, you should be confident with your results. We are here to help. For more information contact us at ", FontFactory.GetFont("Arial", 12, Font.ITALIC, BaseColor.BLACK)));
                        phrase.Add(new Chunk("privacy@armourcyber.ca ", FontFactory.GetFont("Arial", 12, Font.UNDERLINE, new BaseColor(0, 0, 238))));
                        phrase.Add(new Chunk("to discuss your custom roadmap and solution.", FontFactory.GetFont("Arial", 12, Font.ITALIC, BaseColor.BLACK)));
                        cell = new PdfPCell(phrase);
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell.VerticalAlignment = Element.ALIGN_TOP;
                        cell.PaddingBottom = 5f;
                        cell.PaddingTop = 50f;
                        cell.Border = PdfPCell.NO_BORDER;
                        cell.Colspan = 2;
                        table.AddCell(cell);
                        /* Call for action */

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

                        string email_body = "Hello,<br /><br />" + Environment.NewLine;
                        email_body = email_body + "You or a member of your team filled out our level 1 assessment questionnaire to determine your preparedness for Global Data Privacy Regulations such as GDPR, PIPEDA, LGPD etc. Companies are legally required to fulfill the privacy regulations determined by the geographical location of both the company and their customers/clients.Compliance is a large task, but when done properly the first time, it becomes simple to maintain. Doing due diligence helps mitigate risk to customers, protects a company’s reputation, and drastically reduces fines.<br /><br />" + Environment.NewLine;
                        email_body = email_body + "Attached you will find your company's personalized Privacy Compliance Report.Take time to review your result and then reach out with any questions or concerns you may have.To best protect your clients, your company and your reputation, you should be confident with your results. We are here to help.<br /><br />" + Environment.NewLine;
                        email_body = email_body + "For more information contact us at Contact privacy@armourcyber.ca to discuss your custom roadmap and solution.<br /><br />" + Environment.NewLine;
                        email_body = email_body + "Cat Coode, Senior Privacy Consultant<br />" + Environment.NewLine;
                        email_body = email_body + "Privacy Compliance Group<br />" + Environment.NewLine;
                        email_body = email_body + "Powered by Armour Cybersecurity 2020<br />" + Environment.NewLine;


                        //MailMessage mm = new MailMessage("roshandeep810@gmail.com", "roshandeep1995@gmail.com");
                        MailMessage mm = new MailMessage("roshandeep810@gmail.com", Session["user_mail"].ToString());
                        mm.Subject = "Your Company's Privacy Compliance Report";
                        mm.Body = email_body;
                        mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "CyberRiskAssessmentReport.pdf"));
                        mm.IsBodyHtml = true;
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
            string userId = Session["userId"].ToString();
            //string userId = "b094f717-8cf5-472a-bd55-7a73aa73f94c";
            DataTable dt = new DataTable();
            dt = dal.GetUserReport(userId);
            return dt;
        }

    }
    public class PDFFooter : PdfPageEventHelper
    {
        // write on top of document
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            base.OnOpenDocument(writer, document);
        }

        // write on start of each page
        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);
        }
        // write on end of each page
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);
            PdfPTable tabFot = new PdfPTable(1);
            PdfPCell cell;
            tabFot.TotalWidth = 500F;
            Phrase phrase = new Phrase();
            phrase.Add(new Chunk("Armor CyberSecurity", FontFactory.GetFont("Arial", 18, Font.BOLD, new BaseColor(7, 149, 214))));
            cell = new PdfPCell(phrase);
            tabFot.AddCell(cell);
            tabFot.WriteSelectedRows(0, -1, 150, document.Bottom, writer.DirectContent);
        }

        //write on close of document
        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);
        }
    }

}
