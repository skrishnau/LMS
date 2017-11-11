using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One.Views.Course
{
    public partial class CourseDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Page.User as CustomPrincipal;
            if (user != null)
            {
                if (!IsPostBack)
                {
                    var csId = Request.QueryString["cId"];
                    if (csId != null)
                    {
                        var edt = Session["editMode"] as string;// Session["edit"];// Request.QueryString["edit"];
                        var edit = edt == "1";

                        var courseId = Convert.ToInt32(csId);

                        var manager = user.IsInRole("manager") || user.IsInRole("course-editor") ||
                                      user.IsInRole("admitter");
                        var teacher = user.IsInRole("teacher");

                        var managerEdit = manager && edit;

                        lnkEdit.Visible = managerEdit ;
                        lnkDelete.Visible = managerEdit;
                        lnkNewClass.Visible = managerEdit;

                        Edit = edit;

                        pnlClasses.Visible = manager || teacher;
                        dlistClasses.Visible = manager || teacher;

                        if (manager || teacher)
                        {
                            LoadInitialData(courseId);
                        }
                        else
                        {
                            pnlClassFilter.Visible = false;
                        }
                    }
                    else { Response.Redirect("~/Views/Course/"); }
                }
            }
        }

        public bool Edit
        {
            get { return Convert.ToBoolean(hidEditClasses.Value); }
            set { hidEditClasses.Value = value.ToString(); }
        }

        private void LoadInitialData(int courseId)
        {
            try
            {

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

                        if ((sub.Void ?? false))
                        {
                            Response.Redirect("~/Views/All_Resusable_Codes/Error/ErrorPage.aspx");
                            return;
                        }
                        if (SiteMap.CurrentNode != null)
                        {
                            var list = new List<IdAndName>()
                            {
                               new IdAndName(){
                                            Name=SiteMap.RootNode.Title
                                            ,Value =  SiteMap.RootNode.Url
                                            ,Void=true
                                        },
                                new IdAndName(){
                                    Name = SiteMap.CurrentNode.ParentNode.Title
                                    ,Value = SiteMap.CurrentNode.ParentNode.Url
                                    ,Void=true
                                }
                                , new IdAndName(){
                                    Name = sub.FullName
                                }
                            };
                            SiteMapUc.SetData(list);
                        }
                        //if (sub != null)
                        {
                            //if (SiteMap.CurrentNode != null)
                            //{
                            //    SiteMap.CurrentNode.ReadOnly = false;
                            //    SiteMap.CurrentNode.Title = sub.FullName;
                            //    SiteMap.CurrentNode.Url = Request.Url.PathAndQuery;
                            //}



                            lblFullName.Text = sub.FullName;
                            lblCategory.Text = sub.SubjectCategory.Name;
                            lblShortName.Text = sub.ShortName;
                            lblHeading.Text = sub.FullName;

                            //other componenets
                            lnkNewClass.NavigateUrl = "~/Views/Class/CourseSessionCreate.aspx?cId=" + courseId;

                            //lnkView.NavigateUrl = "~/Views/Course/Section/Master/CourseSectionListing.aspx?SubId=" + courseId
                            lnkView.NavigateUrl = "~/Views/Course/Section/?SubId=" + courseId
                                + "&from=detail";
                            lnkEdit.NavigateUrl = "~/Views/Course/CourseCreate.aspx?crsId=" + courseId;
                            lnkDelete.NavigateUrl = "~/Views/All_Resusable_Codes/Delete/DeleteForm.aspx?task=" +
                                                    DbHelper.StaticValues.Encode("course") +
                                                    "&crsId=" + courseId +
                                                    "&catId=" + sub.SubjectCategoryId
                                                    + "&showText="
                                                    + DbHelper.StaticValues.Encode("Are you sure to delete the course " + sub.FullName + "?")
                                                    ;

                            hidCourseId.Value = courseId.ToString();

                            var sessions = cHelper.ListClassesOfSubject(cId, "All");
                            dlistClasses.DataSource = sessions;
                            dlistClasses.DataBind();
                        }
                    }
                }
            }
            catch { Response.Redirect("~/Views/Course/"); }
            //load course detail

        }

        public int CourseId
        {
            get { return Convert.ToInt32(hidCourseId.Value); }
            set { hidCourseId.Value = value.ToString(); }
        }

        public string GetImageUrl(object complete, object startDate, object endDate)
        {
            var url = "";
            try
            {
                var completed = (complete == null) ? "False" : complete.ToString();

                if (completed == "True")
                {
                    //completed
                    url = "~/Content/Icons/Stop/Stop_10px.png";
                }
                else
                {
                    var startD = (startDate == null) ? DateTime.MinValue : Convert.ToDateTime(startDate);
                    var endD = (endDate == null) ? DateTime.MaxValue : Convert.ToDateTime(endDate.ToString());

                    if (startD.Date > DateTime.Now.Date)
                    {
                        //not started yet
                        url = "~/Content/Icons/Hourglass/schedule_14px.png";
                    }
                    else if (endD < DateTime.Now)
                    {
                        //due
                        url = "~/Content/Icons/Watch/alarm_clock_14px.png";
                    }
                    else
                    {
                        url = "~/Content/Icons/Start/active_icon_10px.png";
                    }
                }
            }
            catch
            {
                //active
                //url = "~/Content/Icons/DueDate/pay-policy-duedate.png";
            }
            return url;
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
            btnAll.CssClass = "btn btn-default";
            btnCompleted.CssClass = "btn btn-default";
            btnCurrentlyRunning.CssClass = "btn btn-default";
            btnDue.CssClass = "btn btn-default";
            btnNotStartedYet.CssClass = "btn btn-default";
            button.CssClass = "btn btn-default active";
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