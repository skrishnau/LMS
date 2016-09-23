using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.ViewModel;

namespace One.Views.ActivityResource.Book.BookItems
{
    public partial class TocItemsUc : System.Web.UI.UserControl
    {
        public event EventHandler<IdAndNameEventArgs> ChapterClicked;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetData(int marginwidth, int chapterId,string chapterName, bool selected)
        {
            main_span.Attributes.Add("style", "margin-left:" + marginwidth+"px;");
            lnkChapter.Text = chapterName;
            ChapterId = chapterId;
            if (selected)
            {
                lnkChapter.BackColor =Color.LightSeaGreen;
                
            }
        }

        public bool Selected { set{lnkChapter.BackColor = Color.LightSeaGreen;} }

        public int ChapterId
        {
            get { return Convert.ToInt32(hidChapterId.Value); }
            set { hidChapterId.Value = value.ToString(); }
        }


        protected void lnkChapter_Click(object sender, EventArgs e)
        {
            if (ChapterClicked != null)
            {
                ChapterClicked(this,new IdAndNameEventArgs(){Id = ChapterId, Name = lnkChapter.Text});
            }
        }
    }
}