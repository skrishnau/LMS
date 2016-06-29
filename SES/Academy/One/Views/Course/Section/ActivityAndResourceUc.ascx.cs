using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Course.Section
{
    public partial class ActivityAndResourceUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Properties

        public int ActOrResId { get; set; }

        public string Title { get { return lblTitle.Text; } set { lblTitle.Text = value; } }
        public string Summary { get { return lblSummary.Text; } set { lblSummary.Text = value; } }
        public string ImageUrl{get { return imgIcon.ImageUrl; } set { imgIcon.ImageUrl = value; }}

        public int ActivityAndResourceId
        {
            get { return Convert.ToInt32(hidActOrResId.Value); }
            set { hidActOrResId.Value = value.ToString(); }
        }

        public string Type
        {
            get { return hidType.Value; } set { hidType.Value = value; }
        }

        #endregion

        //edit
        protected void imgEditBtn_Click(object sender, ImageClickEventArgs e)
        {
            //display delete button
        }
    }
}