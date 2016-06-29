using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.ViewsSite.DashBoard.Student.ExtraCourses
{
    public partial class CourseMessageUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Properties

        public string ImageLink
        {
            get { return this.imgMessage.ImageUrl; }
            set { this.imgMessage.ImageUrl = value; }
        }

        public string Text
        {
            get { return linkMessage.Text; }
            set { linkMessage.Text = value; }
        }

        public string NavigateUrl
        {
            get { return linkMessage.NavigateUrl; }
            set { linkMessage.NavigateUrl = value; }
        }


        #endregion


    }
}