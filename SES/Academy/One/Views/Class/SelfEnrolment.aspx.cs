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
    public partial class SelfEnrolment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomDialog.OkClick += CustomDialog_OkClick;
            CustomDialog.CancelClick += CustomDialog_CancelClick;
            var user = Page.User as CustomPrincipal;
            if (user != null)
                if (!IsPostBack)
                {
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
                                var subject = cls.IsRegular ? cls.SubjectStructure.Subject : cls.Subject;
                                ListOfSectionsInCourseUC.UserId = user.Id;
                                ListOfSectionsInCourseUC.CourseId = subject.Id;

                                var teacherRoleId = usrHelper.GetRole(Academic.DbHelper.DbHelper.StaticValues.Roles.Teacher)
                                                                            .Id;
                                lbldNotice.Visible = !cls.ClassUsers.Any(x => x.RoleId == teacherRoleId
                                                                                    && !(x.Void ?? false));
                                var clsname = cls.GetName;
                                lblTitle.Text = clsname;
                                lblClassName.Text = clsname;//cls.IsRegular ? cls.GetName : cls.Name;
                                lblCourseName.Text = subject.FullName;//cls.IsRegular

                                lblEndDate.Text = cls.EndDate == null ? " - " : cls.EndDate.Value.ToString("D");
                                lblStartDate.Text = cls.StartDate == null ? " - " : cls.StartDate.Value.ToString("D");


                                if (!(user.IsInRole("manager") || user.IsInRole("teacher")))
                                {
                                    var joinedClass = helper.HasTheUserAlreadyJoinedThisClass(user.Id, cls.Id);
                                    if (!(cls.SessionComplete ?? false)
                                        && cls.EnrollmentMethod == 2)
                                    {
                                        if (joinedClass != null)
                                        {
                                            lblJoinLastDate.Text = joinedClass.StartDate.HasValue
                                                ? joinedClass.StartDate.Value.ToString("D")
                                                : "-";
                                            lblJoinLstDateTitle.Text = "Joined on";

                                            SetEnrollDialog(false);
                                            btnEnroll.Text = "Remove enrolment";
                                            btnEnroll.Visible = true;
                                        }
                                        else if ((cls.JoinLastDate ?? DateTime.MaxValue.Date) >= DateTime.Now.Date)
                                        {
                                            lblJoinLastDate.Text = cls.JoinLastDate.HasValue
                                                ? cls.JoinLastDate.Value.ToString("D")
                                                : "-";

                                            SetEnrollDialog(true);
                                            btnEnroll.Visible = true;
                                        }
                                        //lnkEnrollNow.NavigateUrl = "";
                                    }
                                    //else if (joinedClass!=null && !(cls.SessionComplete ?? false))
                                    //{

                                    //}
                                }
                                else
                                {
                                    lblJoinLastDate.Text = cls.JoinLastDate == null ? " - " : cls.JoinLastDate.Value.ToString("D");
                                }

                                lnkViewCourse.Visible = true;
                                lnkViewCourse.NavigateUrl = "~/Views/Course/Section/?SubId=" + subject.Id;
                                hidOrderby.Value = "name";
                                LoadSitemap(cls);
                            }

                        }
                    }
                }
        }

        private void SetEnrollDialog(bool enroll)
        {
            if (enroll)
            {
                CustomDialog.AddControl(new Label()
                {
                    Text = "Are you sure to enroll in this class?"
                });

                CustomDialog.SetValues("Enroll to the class?", null
                    , "", "ok", "cancel");
            }
            else
            {
                CustomDialog.AddControl(new Label()
                {
                    Text = "Are you sure to remove enrolment from this class?"
                });

                CustomDialog.SetValues("Remove Enrolment from the class?", null
                    , "", "ok", "cancel");
            }
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
                    bool enrolled = false;
                    bool saved = helper.Enroll(SubjectClassId, user.Id, ref enrolled);
                    if (saved)
                    {
                        CustomDialog.CloseDialog();
                        Response.Redirect(this.Request.Url.PathAndQuery, true);
                        return;
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
                                    //new IdAndName(){
                                    //    Name = SiteMap.CurrentNode.ParentNode.ParentNode.Title
                                    //    ,Value = SiteMap.CurrentNode.ParentNode.ParentNode.Url
                                    //    ,Void=true
                                    //},
                                    new IdAndName(){
                                        Name = cls.GetCourseFullName
                                        ,Value = "~/Views/Course/Section/?SubId="+cls.GetCourseId+"&from=detail"
                                        //,Value = SiteMap.CurrentNode.ParentNode.Url+"?cId="+(cls.GetCourseId)
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
            CustomDialog.OpenDialog();
            //Response.Redirect("~/Views/Class/Enrollment/Enrollment.aspx?ccId=" + hidSubjectSessionId.Value);
        }

    }
}