using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.Class
{
    public partial class CourseSessionCreateUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //UserEnrollUC_ListDisplay.SubjectSessionId = SubjectSessionId;
            }
        }

        public int SubjectSessionId
        {
            get { return Convert.ToInt32(hidSubjectSessionId.Value); }
            set { hidSubjectSessionId.Value = value.ToString(); }
        }

        public int CourseId
        {
            get { return Convert.ToInt32(hidCourseId.Value); }
            set { hidCourseId.Value = value.ToString(); }
        }

        public string CourseName
        {
            get { return lblCourseName.Text; }
            set { lblCourseName.Text = value; }
        }

        public void SetCourseId(string courseId)
        {
            hidCourseId.Value = courseId;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var now = DateTime.Now;
                var subjectSession = new Academic.DbEntities.Class.SubjectClass()
                {
                    Name = txtName.Text
                    ,
                    CreatedDate = now.Date
                    ,
                    IsRegular = false
                    ,
                    CreatedTime = now.Hour + ":" + now.Minute + ":" + now.Second + ":" + now.Millisecond
                    ,
                    UseDefaultGrouping = true
                    ,
                    SubjectId = CourseId
                };
                using (var helper = new DbHelper.Classes())
                {
                    var saved = helper.AddOrUpdateSubjectSession(subjectSession);
                    Response.Redirect("~/Views/Course/CourseDetail.aspx?cId=" + CourseId);
                }
            }
        }
    }
}