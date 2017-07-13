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
                                lblJoinLastDate.Text = cls.JoinLastDate.HasValue
                                   ? cls.JoinLastDate.Value.ToString("D")
                                   : "";
                               
                                var joined = helper.HasTheUserAlreadyJoinedThisClass(user.Id, cls.Id);
                                if (!(cls.SessionComplete ?? false) 
                                    && (cls.JoinLastDate??DateTime.MaxValue.Date)>=DateTime.Now.Date
                                    && cls.EnrollmentMethod==2
                                    && !joined)
                                {
                                    lnkEnrollNow.Visible = true;
                                    lnkEnrollNow.NavigateUrl = "";
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

    }
}