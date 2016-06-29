using One.ViewsSite.DashBoard.Student.CourseOverView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.ViewsSite.DashBoard.Student.ExtraCourses
{
    public partial class UnjoinedListUc : System.Web.UI.UserControl
    {
        //public event EventHandler OnSubjectSubscribed;
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //========== Properties ============//
        #region Properties

        public string Id { get; set; }

        public int StudentClassId
        {
            get { return Convert.ToInt32(hidStdClsId.Value); }
            set { hidStdClsId.Value = value.ToString(); }
        }

        public int SubjectClassId
        {
            get { return Convert.ToInt32(hidSubClsId.Value); }
            set { hidSubClsId.Value = value.ToString(); }
        }


        public string Title { get { return this.lblTitle.Text; } set { this.lblTitle.Text = value; } }
        public string TitleNavigationTarget { get; set; }

        public Academic.ViewModel.AcademicPlacement.StudentSubjectModel StudentSubjectModel { get; set; }

        public void DisplaySaveStatus(string message)
        {
            pnlContent.Visible = false;
            pnlStatus.Visible = true;
            lblStat.Text = message;
        }


        #endregion
        //===========   END   =============//



        #region Functions

        public void AddMessages(CourseMessageUC msgUc)
        {
            //CourseMessageUC uc =
            //    (CourseMessageUC) Page.LoadControl("~/ViewsSite/DashBoard/Student/CourseOverView/CourseMessageUC.ascx");
            this.pnlDescription.Controls.Add(msgUc);

        }

        #endregion

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //subscribe
            Subscribe();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            //subscribe
            Subscribe();
        }

        public void Subscribe()
        {
            var subsc = new Academic.DbEntities.AcacemicPlacements.SubjectSubscription()
            {
                Active = true
                ,StudentClassId = this.StudentClassId
                ,SubjectClassId = this.SubjectClassId
                ,Suspended = false
                ,Permitted = true
                
            };
            using (var helper = new DbHelper.AcademicPlacement())
            {
                bool subscribed = helper.Subscribe(subsc);
                if (subscribed)
                {
                    DisplaySaveStatus("You have now participated in "+lblTitle.Text);
                    //if (OnSubjectSubscribed != null)
                    //{
                    //    OnSubjectSubscribed(this,new EventArgs());
                    //}
                }
            }

        }

        protected void lblTitle_Click(object sender, EventArgs e)
        {
            var redirectUrl = "~/Views/Course/Display/CourseDetails.aspx";
            if (!String.IsNullOrEmpty(Id))
            {
                //var resolvedReturnUrl = ResolveUrl(Id);
                redirectUrl += "?Id=" + Id; //+ HttpUtility.UrlEncode(resolvedReturnUrl);
            }
            Response.Redirect(redirectUrl);
        }
    }
}