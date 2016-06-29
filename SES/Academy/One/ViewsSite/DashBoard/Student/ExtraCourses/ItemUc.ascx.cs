using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.ViewsSite.DashBoard.Student.ExtraCourses
{
    public partial class ItemUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        //======================//
        #region Properties

        public int SubjectSubscriptionId
        {
            get { return Convert.ToInt32(hidSubSubscriptionId.Value); }
            set { hidSubSubscriptionId.Value = value.ToString(); }
        }

        public string Id { get; set; }

        public string Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }
        public string TitleNavigationTarget { get; set; }

        public Academic.ViewModel.AcademicPlacement.StudentSubjectModel StudentSubjectModel { get; set; }

        #endregion
        //========================//



        #region Functions

        public void AddMessages(CourseMessageUC msgUc)
        {
            //CourseMessageUC uc =
            //    (CourseMessageUC) Page.LoadControl("~/ViewsSite/DashBoard/Student/CourseOverView/CourseMessageUC.ascx");
            this.pnlMessages.Controls.Add(msgUc);

        }

        #endregion

        protected void lnkWithdraw_Click(object sender, EventArgs e)
        {
            using (var helper = new DbHelper.AcademicPlacement())
            {
                bool stat = helper.WithdrawFromCourse(SubjectSubscriptionId);
            }
        }

        protected void lblTitle_Click(object sender, EventArgs e)
        {
            var url = "~/Views/Course/Display/CourseDetails.aspx";
            if (!String.IsNullOrEmpty(Id))
            {
                //var resolvedReturnUrl = ResolveUrl(Id);
                url += "?SubId="+Id; //+ HttpUtility.UrlEncode(resolvedReturnUrl);
            }
            Response.Redirect(url);
        }

        public bool WithdrawVisible
        {
            get { return lnkWithdraw.Visible; } 
            set { lnkWithdraw.Visible = value; }
        }
    }
}