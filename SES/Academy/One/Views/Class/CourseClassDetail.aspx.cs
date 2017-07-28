using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One.Views.Class
{
    public partial class CourseClassDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomDialog.OkClick += CustomDialog_OkClick;
            CustomDialog.CancelClick += CustomDialog_CancelClick;
            var user = Page.User as CustomPrincipal;
            if (user != null)
                if (!IsPostBack)
                {


                    var isManager = user.IsInRole(DbHelper.StaticValues.Roles.Manager);
                    var isTeacher = user.IsInRole(DbHelper.StaticValues.Roles.Teacher);

                    if (!isTeacher && !isManager)
                    {
                        Response.Redirect("~/");
                        return;
                    }


                    SetMarkCompletionDialog();

                    var edit = (Session["editMode"] as string) == "1";


                    var classId = Request.QueryString["ccId"];
                    if (classId != null)
                    {
                        var clsId = Convert.ToInt32(classId);
                        SubjectClassId = clsId;

                        using (var helper = new DbHelper.Classes())
                        using (var usrHelper = new DbHelper.User())
                        {
                            var cls = helper.GetSubjectSession(clsId);
                            if (cls != null)
                            {


                                var teacherRoleId = usrHelper.GetRole(Academic.DbHelper.DbHelper.StaticValues.Roles.Teacher)
                                                                            .Id;
                                lbldNotice.Visible = !cls.ClassUsers.Any(x => x.RoleId == teacherRoleId
                                                                                    && !(x.Void ?? false));


                                //lblStartDate.Text =cls.StartDate==null?" - ": cls.StartDate.Value.ToString("D");
                                //lblEndDate.Text = cls.EndDate==null?" - ":cls.EndDate.Value.ToString("D");
                                var clsname = cls.GetName;
                                var coursefullname = cls.GetCourseFullName;
                                lblTitle.Text = clsname;

                                if (cls.SessionComplete ?? false)
                                {
                                    imgIndicate.ToolTip = "Complete";
                                    imgIndicate.Visible = true;
                                }
                                else if (cls.StartDate <= DateTime.Now && cls.EndDate >= DateTime.Now)
                                {
                                    imgIndicate.Visible = true;
                                    imgIndicate.ToolTip = "Active";
                                    imgIndicate.ImageUrl = "~/Content/Icons/Start/active_icon_10px.png";
                                }
                                else
                                {
                                    imgIndicate.Visible = true;
                                    imgIndicate.ToolTip = "Due";
                                    imgIndicate.ImageUrl = "~/Content/Icons/Watch/alarm_clock_14px.png";
                                }

                                lblEnrollmentMethod.Text = cls.EnrollmentMethod == 0
                                    ? "Auto"
                                    : (cls.EnrollmentMethod == 1) ? "Manual" : "Self";

                                var autoEnrollment = cls.EnrollmentMethod == 0;

                                var curTeach = helper.IsTheUserCurrentlyTeacher(user.Id,
                                    cls.IsRegular ? cls.SubjectStructure.SubjectId : cls.SubjectId ?? 0);


                                if (edit && (isManager || curTeach) && !(cls.SessionComplete ?? false))
                                {
                                    lnkMarkCompletion.Visible = true;
                                    lnkEnrollStudents.Visible = (!autoEnrollment || isManager);//&& (isTeacher || isManager);
                                    lnkEnrollTeachers.Visible = isManager;
                                }






                                hidOrderby.Value = autoEnrollment ? "crn" : "name";

                                LoadSitemap(cls);
                                var from = Request.QueryString["from"];
                                lnkReport.NavigateUrl = "~/Views/Report/?ccId=" + cls.Id+"&from="+from;
                                lnkEnrollStudents.NavigateUrl = "~/Views/Class/Enrollment/Enrollment.aspx?ccId=" +
                                                        hidSubjectSessionId.Value + "&type=student";
                                lnkEnrollTeachers.NavigateUrl = "~/Views/Class/Enrollment/Enrollment.aspx?ccId=" +
                                                        hidSubjectSessionId.Value + "&type=teacher";


                                lblClassName.Text = clsname;//cls.IsRegular ? cls.GetName : cls.Name;
                                lblCourseName.Text = coursefullname;//cls.IsRegular
                                //? cls.SubjectStructure.Subject.FullName
                                //: cls.Subject.FullName;


                                lblEndDate.Text = cls.EndDate == null ? " - " : cls.EndDate.Value.ToString("D");
                                lblStartDate.Text = cls.StartDate == null ? " - " : cls.StartDate.Value.ToString("D");



                                //grouping
                                //var grp = "No grouping";
                                //if (cls.HasGrouping)
                                //{
                                //    grp = "";
                                //    cls.SubjectClassGrouping.ToList().ForEach(c =>
                                //    {
                                //        grp += cls.Name + ", ";
                                //    });
                                //    grp = grp.TrimEnd(new char[] { ',' });
                                //}
                                //lblGrouping.Text = grp;



                                //ListView1.DataSource = helper.ListSubjectSessionEnrolledUsers(clsId);
                                //ListView1.DataSource = helper.ListEnrolledUsers(clsId);
                                // ListView1.DataBind();
                            }

                        }
                    }
                }
        }

        private void SetMarkCompletionDialog()
        {
            CustomDialog.AddControl(new Label()
            {
                Text = "Do you really want to mark this class as complete?"
            });

            CustomDialog.SetValues("Mark Completion?", null
            , "", "ok", "cancel");

        }

        void CustomDialog_CancelClick(object sender, EventArgs e)
        {
            CustomDialog.CloseDialog();
        }

        void CustomDialog_OkClick(object sender, IdAndNameEventArgs e)
        {
            //mark complete
            var user = Page.User as CustomPrincipal;
            //&& (user.IsInRole(DbHelper.StaticValues.Roles.Manager) 
            // || user.IsInRole(DbHelper.StaticValues.Roles.Teacher))
            if (user != null)
                using (var helper = new DbHelper.Classes())
                {
                    bool saved = helper.MarkComplete(SubjectClassId, user.Id);
                    if (saved)
                    {
                        lnkMarkCompletion.Visible = false;
                        lnkEnrollStudents.Visible = false;
                        lnkEnrollTeachers.Visible = false;
                        CustomDialog.CloseDialog();
                    }
                }
        }


        void LoadSitemap(Academic.DbEntities.Class.SubjectClass cls)
        {
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
                                        Name = SiteMap.CurrentNode.ParentNode.ParentNode.Title
                                        ,Value = SiteMap.CurrentNode.ParentNode.ParentNode.Url
                                        ,Void=true
                                    },
                                    new IdAndName(){
                                        Name = cls.GetCourseFullName
                                        ,Value = SiteMap.CurrentNode.ParentNode.Url+"?cId="+(cls.GetCourseId)
                                        ,Void=true
                                    }
                                    ,
                                    new IdAndName()
                                    {
                                        Name =cls.GetName
                                    }
                                };
                SiteMapUc.SetData(list);
            }
        }

        public int SubjectClassId
        {
            get { return Convert.ToInt32(hidSubjectSessionId.Value); }
            set { hidSubjectSessionId.Value = value.ToString(); }
        }

        protected void btnEnroll_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Class/Enrollment/Enrollment.aspx?ccId=" + hidSubjectSessionId.Value);
        }

        protected void GridView1_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex % 2 == 0)
                {
                    e.Row.CssClass = "highlight-row-even";
                }
                else
                    e.Row.CssClass = "highlight-row-odd";
            }
        }

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void lnkMarkCompletion_OnClick(object sender, EventArgs e)
        {
            if (!imgIndicate.ImageUrl.Contains("Stop"))
                CustomDialog.OpenDialog();
        }

        //public string GetImageUrl(object imageId)
        //{
        //    if (imageId != null)
        //    {
        //        var id = Convert.ToInt32(imageId.ToString());
        //        using (var helper = new DbHelper.WorkingWithFiles())
        //        {
        //            return helper.GetImageUrl(id);
        //        }
        //    }
        //    return "";
        //}

        //public string GetName(object first, object mid, object last)
        //{
        //    string name = "";
        //    if (first != null)
        //    {
        //        name += first.ToString();
        //        if (mid != null)
        //        {
        //            name += " " + mid.ToString();

        //        }
        //        if (last != null)
        //        {
        //            name += " " + last.ToString();
        //        }
        //    }
        //    return name;
        //}


        //public string GetLastOnline(object onlineDate)
        //{
        //    if (onlineDate != null)
        //    {
        //        try
        //        {
        //            var date = Convert.ToDateTime(onlineDate.ToString());
        //            var difference = DateTime.Now.Subtract(date);// - date;

        //            var days = (difference.Days > 0) ?
        //                (difference.Days == 1) ? "a Day " : difference.Days + " Days " : "";
        //            if (days != "")
        //            {
        //                return days + "ago";
        //            }

        //            var hours = (difference.Hours != 0) ? (difference
        //                .Hours == 1) ? "an Hour " : difference.Hours + " Hours " : "";
        //            if (hours != "")
        //            {
        //                return hours + "ago";
        //            }
        //            var minutes = (difference.Minutes > 0) ?
        //                (difference.Minutes == 1) ? "a Minute " : difference.Minutes + " Minutes " : "";
        //            if (minutes != "")
        //                return minutes;

        //            var seconds = (difference.Seconds <= 5) ?
        //                "5 Seconds " : difference.Seconds + " Seconds ";
        //            return seconds + "ago";
        //        }
        //        catch
        //        {

        //            return "Never Online";
        //        }

        //    }
        //    return "Never Online";
        //}



    }
}