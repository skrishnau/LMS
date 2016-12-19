using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;

namespace One.Views.Course
{
    public partial class CourseDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Page.User as CustomPrincipal;
            if (user != null)
                if (!IsPostBack)
                {
                    if (user.IsInRole("manager") || user.IsInRole("course-editor"))
                    {
                        lnkEdit.Visible = true;
                        lnkDelete.Visible = true;
                        lnkNewClass.Visible = true;
                        pnlClasses.Visible = true;
                        LoadInitialData();
                    }
                    else if (user.IsInRole("teacher"))
                    {
                        lnkEdit.Visible = false;
                        lnkDelete.Visible = false;
                        lnkNewClass.Visible = false;
                        pnlClasses.Visible = true;
                        LoadInitialData();
                    }
                    else
                    {
                        lnkEdit.Visible = false;
                        lnkDelete.Visible = false;
                        lnkNewClass.Visible = false;
                        pnlClassFilter.Visible = false;
                        dlistClasses.Visible = false;
                        pnlClasses.Visible = false;
                    }


                }
        }


        private void LoadInitialData()
        {
            var courseId = Request.QueryString["cId"];
            try
            {
                if (courseId != null)
                {
                    var cId = Convert.ToInt32(courseId);
                    using (var cHelper = new DbHelper.Classes())
                    using (var helper = new DbHelper.Subject())
                    {

                        var sub = helper.GetCourse(cId);
                        if (sub == null)
                        {
                            Response.Redirect("~/Views/All_Resusable_Codes/Error/ErrorPage.aspx");
                            return;
                        }
                        //if (sub != null)
                        {
                            if ((sub.Void ?? false))
                            {
                                Response.Redirect("~/Views/All_Resusable_Codes/Error/ErrorPage.aspx");
                                return;
                            }
                            lblFullName.Text = sub.FullName;
                            lblCategory.Text = sub.SubjectCategory.Name;
                            lblShortName.Text = sub.ShortName;
                            lblHeading.Text = sub.FullName;

                            //other componenets
                            lnkNewClass.NavigateUrl = "~/Views/Class/CourseSessionCreate.aspx?cId=" + courseId;

                            lnkView.NavigateUrl = "~/Views/Course/Section/Master/CourseSectionListing.aspx?SubId=" + courseId;
                            lnkEdit.NavigateUrl = "~/Views/Course/CourseCreate.aspx?crsId=" + courseId;
                            lnkDelete.NavigateUrl = "~/Views/All_Resusable_Codes/Delete/DeleteForm.aspx?task=" +
                                                    DbHelper.StaticValues.Encode("course") +
                                                    "&crsId=" + courseId +
                                                    "&catId=" + sub.SubjectCategoryId
                                                    + "&showText="
                                                    + DbHelper.StaticValues.Encode("Are you sure to delete the course " + sub.FullName + "?")
                                                    ;

                            hidCourseId.Value = courseId;

                            var sessions = cHelper.ListClassesOfSubject(cId, "All");
                            dlistClasses.DataSource = sessions;
                            dlistClasses.DataBind();
                        }
                    }
                }
                else { Response.Redirect("~/Views/Course/"); }
            }
            catch { Response.Redirect("~/Views/Course/"); }
            //load course detail

        }

        public int CourseId
        {
            get { return Convert.ToInt32(hidCourseId.Value); }
            set { hidCourseId.Value = value.ToString(); }
        }

        public Color GetCompletedColor(object complete, object startDate, object endDate)
        {
            try
            {
                var completed = (complete == null) ? "False" : complete.ToString();
                //var color = Color.LightBlue;
                if (completed == "True")
                {
                    //return Color.LightGreen;
                    //return Color.FromArgb(215, 227, 231);
                    return Color.FromArgb(191, 191, 191);
                    //return Color.FromArgb(188, 244, 188);
                }
                var startD = (startDate == null) ? DateTime.MinValue : Convert.ToDateTime(startDate);
                var endD = (endDate == null) ? DateTime.MaxValue : Convert.ToDateTime(endDate.ToString());


                if (startD.Date > DateTime.Now.Date)
                {
                    //return Color.LightYellow;
                    return Color.FromArgb(251, 251, 63);
                    //return Color.FromArgb(253, 253, 194);
                }
                else if (endD < DateTime.Now)
                {
                    //return Color.LightPink;
                    return Color.FromArgb(255, 154, 170);
                    //return Color.FromArgb(253, 214, 220);
                }
                //return Color.LightBlue;
                //return Color.FromArgb(215, 227, 231);
                return Color.FromArgb(0, 234, 0);
            }
            catch
            {
                //return Color.LightBlue;
                //return Color.FromArgb(215, 227, 231);
                return Color.FromArgb(0, 234, 0);
                //return Color.FromArgb(188, 244, 188);
            }

        }

        protected void lnkClassFilter_Click(object sender, EventArgs e)
        {
            if (lblFilterArrow.Text == "►")
            {
                lblFilterArrow.Text = "▼";
                pnlClassFilter.Visible = true;
            }
            else
            {
                lblFilterArrow.Text = "►";
                pnlClassFilter.Visible = false;
            }

            //if (imgFilter.ImageUrl.Contains("arrow_down"))
            //{
            //    imgFilter.ImageUrl = "~/Content/Icons/Arrow/arrow_right.png";
            //}
            //else
            //{
            //    imgFilter.ImageUrl = "~/Content/Icons/Arrow/arrow_down.png";
            //}
            //pnlClassFilter.Visible = !pnlClassFilter.Visible;
        }

        protected void btnFilterCrieteria_Click(object sender, EventArgs e)
        {
            var button = (LinkButton)sender;

            ApplyFilterAndLoadData(button.ID);
        }

        private void ApplyFilterAndLoadData(string courseCompletionType)
        {
            using (var helper = new DbHelper.Classes())
            {
                var sessions = helper.ListClassesOfSubject(CourseId, courseCompletionType);
                dlistClasses.DataSource = sessions;
                dlistClasses.DataBind();
            }
        }
    }
}