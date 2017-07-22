using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One.Views.Course.Section
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                var id = Request.QueryString["SubId"];

                var user = Page.User as CustomPrincipal;
                if (user != null && id != null)
                {
                    
                    //var isTeacher = user.IsInRole(DbHelper.StaticValues.Roles.Teacher);

                    ListOfSectionsInCourseUC1.UserId = user.Id;

                    using (var helper = new DbHelper.Classes())
                    {
                        var edit = Session["editMode"] as string;//Request.QueryString["edit"];
                        var isManager = user.IsInRole(DbHelper.StaticValues.Roles.CourseEditor)
                                    || user.IsInRole(DbHelper.StaticValues.Roles.Manager);
                        var teacher = helper.IsTheUserTeacher(user.Id, Convert.ToInt32(id));
                        var isTeacher = isManager || teacher;

                        if (edit == "1" && isTeacher)
                        {
                            Edit = "1";
                            ListOfSectionsInCourseUC1.EditEnabled = true;
                            _path = Request.Url.AbsolutePath + "?SubId=" + id;
                        }
                        else
                        {
                            Edit = "0";
                        }
                    }
                }

                int subId = 0;
                var succ = int.TryParse(id, out subId);
                if (succ)
                {
                    Id = subId;
                    LoadCourse(subId);
                }
            }

        }

        private string _path = "";

        public string Edit
        {
            get { return hidEdit.Value; }
            set { hidEdit.Value = value; }
        }

        public int Id { get; set; }

        private void LoadCourse(int courseId)
        {
            var user = Page.User as CustomPrincipal;

            var edit = hidEdit.Value;
            if (user != null)
            {
                using (var cHelper = new DbHelper.Classes())
                using (var strHelper = new DbHelper.Structure())
                using (var helper = new DbHelper.Subject())
                {

                    var sub = helper.Find(courseId);
                    if (sub != null)
                    {

                        LoadSitemap(strHelper, sub);


                        txtSubjectName.Text = sub.FullName;
                        //uncomment
                        ListOfSectionsInCourseUC1.CourseId = Id;
                        lblPageTitle.Text = sub.FullName;

                        var courseStatus = cHelper.GetCourseClassesAvailabilityForUser(user.Id, sub.Id);

                        var stat = courseStatus.Split(new[] { ',' });

                        if (stat.Length == 2)
                        {
                            var fromCls = Request.QueryString["from"];
                            var from = "";
                            if (fromCls == "detail")
                            {
                                from = "&from=detail";
                            }
                            else
                            {
                                from = "&from=view";
                            }

                            lnkMyClasses.Visible = stat[1].Equals(DbHelper.StaticValues.Roles.Teacher);
                            lnkMyClasses.NavigateUrl = "~/Views/Class/MyClasses.aspx?subId=" + courseId + from;

                        }

                        switch (stat[0])
                        {
                            case "current":
                                imgJoinInfo.Visible = true;
                                imgJoinInfo.ImageUrl = "~/Content/Icons/Start/active_icon_10px.png";
                                break;
                            case "complete":
                                imgJoinInfo.Visible = true;
                                imgJoinInfo.ImageUrl = "~/Content/Icons/Diploma/diploma_16px.png";
                                break;
                            case "open":
                                lnkEnroll.Visible = true;
                                break;
                            case "close":

                                break;
                            default:
                                break;

                        }
                        //lblClassInformation.Text = cHelper.GetCourseClassesAvailabilityForUser(user.Id, sub.Id);
                    }
                    //CourseDetailUc1.
                }
            }

        }


        void LoadSitemap(DbHelper.Structure strHelper, Academic.DbEntities.Subjects.Subject sub)
        {
            var fromCls = Request.QueryString["from"];
            var yId = Request.QueryString["yId"];
            var sId = Request.QueryString["sId"];
            if (SiteMap.CurrentNode != null)
            {
                var list = new List<IdAndName>()
                        {
                           new IdAndName(){
                                        Name=SiteMap.RootNode.Title
                                        ,Value =  SiteMap.RootNode.Url
                                        ,Void=true
                                    },
                        };
                if (sId != null && yId != null)
                {
                    //lnkEdit.NavigateUrl += "&yId=" + yId + "&sId=" + sId;
                    list.Add(new IdAndName()
                    {
                        Name = "Manage Programs"
                        ,
                        Value = "~/Views/Structure/"
                        ,
                        Void = true
                    });
                    list.Add(new IdAndName()
                    {
                        Name = strHelper.GetSructureDirectory(Convert.ToInt32(yId), Convert.ToInt32(sId))
                        ,
                        Value = "~/Views/Structure/CourseListing.aspx?yId=" + yId + "&sId=" + sId
                        ,
                        Void = true
                    });
                    list.Add(new IdAndName()
                    {
                        Name = sub.FullName
                    });
                }
                else if (fromCls != null)
                {
                    //lnkEdit.NavigateUrl += "&frmDetailView=" + fromCls;
                    list.Add(new IdAndName()
                    {
                        Name = SiteMap.CurrentNode.ParentNode.Title
                        ,
                        Value = SiteMap.CurrentNode.ParentNode.Url
                        ,
                        Void = true
                    });
                    list.Add(new IdAndName()
                    {
                        Name = sub.FullName
                        ,
                        Value = "~/Views/Course/CourseDetail.aspx?cId=" + sub.Id
                        ,
                        Void = true
                    });
                    list.Add(new IdAndName() { Name = "View" });
                }
                else
                {
                    list.Add(new IdAndName()
                    {
                        Name = sub.FullName
                        ,
                        //Value = "~/Views/Course/CourseDetail.aspx?cId=" + sub.Id
                        //,
                        //Void = true
                    });
                }
                SiteMapUc.SetData(list);
            }
        }
    }
}