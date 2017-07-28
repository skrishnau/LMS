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

                        if (stat.Length >= 2)
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
                                if (stat.Length >= 3)
                                {
                                    if (!(user.IsInRole("teacher") || user.IsInRole("manager")))
                                    {
                                        lnkEnroll.Visible = stat[2] != "0";
                                        lnkEnroll.NavigateUrl = "~/Views/Class/SelfEnrolment.aspx?ccId=" + stat[2];
                                        lnkEnroll.Text = "Remove Enrollment";
                                    }
                                    else
                                    {
                                        lnkEnroll.Visible = false;
                                    }
                                   
                                    //btnEnroll.Visible = stat[2] != "0";
                                    //btnEnroll.
                                }
                                imgJoinInfo.Visible = true;
                                imgJoinInfo.ImageUrl = "~/Content/Icons/Start/active_icon_10px.png";
                                break;
                            case "complete":
                                imgJoinInfo.Visible = true;
                                if (!(user.IsInRole("teacher") || user.IsInRole("manager")))
                                    imgJoinInfo.ImageUrl = "~/Content/Icons/Diploma/diploma_16px.png";
                                else
                                {
                                    imgJoinInfo.ImageUrl = "~/Content/Icons/Stop/Stop_10px.png";                                    
                                }
                                break;
                            case "open":
                                //if (!(user.IsInRole("teacher") || user.IsInRole("manager")))
                                //{

                                //    btnEnroll.Visible = true;
                                //    SetEnrollDialog();
                                //}
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

        //private void SetEnrollDialog(bool enroll)
        //{
        //    if (enroll)
        //    {
        //        CustomDialog.AddControl(new Label()
        //        {
        //            Text = "Are you sure to enroll in this class?"
        //        });

        //        CustomDialog.SetValues("Enroll to the class?", null
        //            , "", "ok", "cancel");
        //    }
        //    else
        //    {
        //        CustomDialog.AddControl(new Label()
        //        {
        //            Text = "Are you sure to remove enrolment from this class?"
        //        });

        //        CustomDialog.SetValues("Remove Enrolment from the class?", null
        //            , "", "ok", "cancel");
        //    }
        //}

        //void CustomDialog_CancelClick(object sender, EventArgs e)
        //{
        //    CustomDialog.CloseDialog();
        //}

        //void CustomDialog_OkClick(object sender, IdAndNameEventArgs e)
        //{
        //    //mark complete
        //    var user = Page.User as CustomPrincipal;
        //    //&& (user.IsInRole(DbHelper.StaticValues.Roles.Manager) 
        //    // || user.IsInRole(DbHelper.StaticValues.Roles.Teacher))
        //    if (user != null)
        //        using (var helper = new DbHelper.Classes())
        //        {
        //            bool enrolled = false;
        //            bool saved = helper.Enroll(SubjectClassId, user.Id, ref enrolled);
        //            if (saved)
        //            {
        //                CustomDialog.CloseDialog();
        //                Response.Redirect(this.Request.Url.PathAndQuery, true);
        //                return;
        //            }
        //        }
        //}

        //protected void btnEnroll_Click(object sender, EventArgs e)
        //{

        //    CustomDialog.OpenDialog();
        //    //Response.Redirect("~/Views/Class/Enrollment/Enrollment.aspx?ccId=" + hidSubjectSessionId.Value);
        //}

    }
}