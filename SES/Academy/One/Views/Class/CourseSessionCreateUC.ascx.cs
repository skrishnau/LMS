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
            lblErrorMsg.Visible = false;
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
                try
                {
                    var now = DateTime.Now;
                    var subjectClass = new Academic.DbEntities.Class.SubjectClass()
                    {
                        Id = SubjectSessionId
                        ,
                        Name = txtName.Text
                        ,
                        CreatedDate = now
                        ,
                        IsRegular = false
                        ,
                        SubjectId = CourseId
                        ,
                        EnrollmentMethod = (byte)ddlEnrollmentMethod.SelectedIndex
                    };

                    try
                    {
                        subjectClass.StartDate = Convert.ToDateTime(txtStart.Text);
                    }
                    catch
                    {
                        valiStartDate.IsValid = false;
                    }
                    try
                    {
                        subjectClass.EndDate = Convert.ToDateTime(txtEnd.Text);
                    }
                    catch
                    {
                        valiEndDate.IsValid = false;
                    }

                    if (ddlGroupingOfStudents.SelectedIndex == 0)
                        subjectClass.HasGrouping = false;

                    if (Page.IsValid)
                    {
                        using (var helper = new DbHelper.Classes())
                        {
                            var saved = helper.AddOrUpdateSubjectSession(subjectClass);
                            if (saved)
                                Response.Redirect("~/Views/Course/CourseDetail.aspx?cId=" + CourseId);
                            else
                                lblErrorMsg.Visible = true;
                        }
                    }
                }
                catch { }


            }
        }
    }
}