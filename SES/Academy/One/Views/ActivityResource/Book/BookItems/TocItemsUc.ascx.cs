using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;

namespace One.Views.ActivityResource.Book.BookItems
{
    public partial class TocItemsUc : System.Web.UI.UserControl
    {
        public event EventHandler<IdAndNameEventArgs> ChapterClicked;
        public event EventHandler<IdAndNameEventArgs> ChapterUpdated;
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetData(int marginwidth, int chapterId, string chapterName, int bookId, string edit
            , bool showup, bool showdown, bool showin, bool showout, int subjectId, int sectionId)
        {
            lnkChapter.Text = chapterName;
            lnkChapter.ToolTip = chapterName;
            ChapterId = chapterId;
            BookId = bookId;
            lnkAddChapter.NavigateUrl = "~/Views/ActivityResource/Book/ChapterCreate.aspx?bId=" + bookId +
                                        "&pcId=" + chapterId+
                                        "&SubId="+subjectId+
                                        "&secId="+sectionId;
            lnkAddChapter.ToolTip = "Add chapter ";


            edit_panel.Visible = (edit == "1");
            //gets maximum length of string in collection
            string maxString = chapterName;
            //converts string length to pixel
            System.Drawing.SizeF sizeF = new System.Drawing.SizeF();
            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(new System.Drawing.Bitmap(1, 1));
            sizeF = graphics.MeasureString(maxString, new System.Drawing.Font("Times New Roman,Arial,Verdana,Helvetica,sans-serif", 13,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point));
            //Font stringFont = new Font("Arial", 16);
            //sizeF = graphics.MeasureString(maxString, stringFont);


            int maxTextWidthinPixel = Convert.ToInt32(sizeF.Width);
            int maxTextHeightinPixel = Convert.ToInt32(sizeF.Height);
            main_span.Style.Add("display", "inline-block");
            main_span.Style.Add("margin-left", marginwidth.ToString() + "px");
            main_span.Style.Add("width", (maxTextWidthinPixel + 60).ToString() + "px");
            main_span.Style.Add("min-width", "100%");
            //main_span.Style.Add("", "");

            //div1.Style.Add("width", maxTextWidthinPixel.ToString());
            //div1.Style.Add("border-style", "solid");
            //div1.Style.Add("border-color", "Red");
            //div1.InnerText = maxString;

            //main_span.Attributes.Add("style",  " width:"+(chapterName.Length*11)+"px;");
            lnkUp.Visible = showup;
            lnkDown.Visible = showdown;
            lnkIn.Visible = showin;
            lnkOut.Visible = showout;

            Deselect();
        }

        public bool Selected { set { lnkChapter.BackColor = Color.LightSeaGreen; } }

        public int ChapterId
        {
            get { return Convert.ToInt32(hidChapterId.Value); }
            set { hidChapterId.Value = value.ToString(); }
        }
        public int BookId
        {
            get { return Convert.ToInt32(hidBookId.Value); }
            set { hidBookId.Value = value.ToString(); }
        }


        protected void lnkChapter_Click(object sender, EventArgs e)
        {
            if (ChapterClicked != null)
            {
                ChapterClicked(this, new IdAndNameEventArgs() { Id = ChapterId, Name = lnkChapter.Text });
            }
        }

        public void Deselect()
        {
            pnlMain.BackColor = Color.White;
            //lnkChapter.BackColor = Color.White;
        }

        public void Select()
        {
            pnlMain.BackColor = Color.FromArgb(241, 241, 241);//.LightGray;
            //lnkChapter.BackColor = Color.LightBlue;
        }

        protected void lnk_Click(object sender, EventArgs e)
        {
            var send = sender as LinkButton;
            if (send != null)
            {
                switch (send.ID)
                {
                    case "lnkIn":
                        UpdateChapter("in");
                        break;
                    case "lnkOut":
                        UpdateChapter("out");
                        break;
                    case "lnkUp":
                        UpdateChapter("move-up");
                        break;
                    case "lnkDown":
                        UpdateChapter("move-down");
                        break;
                }
            }
        }

        private void UpdateChapter(string action)
        {
            using (var helper = new DbHelper.ActAndRes())
            {
                var updated = helper.UpdateChapter(action, ChapterId, BookId);
                if (updated)
                {
                    if (ChapterUpdated != null)
                    {
                        ChapterUpdated(this, new IdAndNameEventArgs());
                    }
                }
                else
                {
                    this.lnkChapter.BackColor = Color.LightCoral;
                }
            }
        }
    }
}