using Academic.DbHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.ViewModel;

namespace One.Views.Class
{
    public partial class CourseSessionCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var courseId = Request.QueryString["cId"];
                var classId = Request.QueryString["subclsId"];
                if (courseId != null)
                {

                    //hidCourseId.Value = courseId;
                    try
                    {
                        CourseSessionCreateUC1.CourseId = Convert.ToInt32(courseId);
                        CourseSessionCreateUC1.SubjectSessionId = Convert.ToInt32(classId);

                        using (var helper = new DbHelper.Subject())
                        {
                            var course = helper.GetCourse(CourseSessionCreateUC1.CourseId);
                            if (course != null)
                            {

                                if (SiteMap.CurrentNode != null)
                                {
                                    var list = new List<IdAndName>()
                                    {
                                        new IdAndName()
                                        {
                                            Name = SiteMap.RootNode.Title
                                            ,
                                            Value = SiteMap.RootNode.Url
                                            ,
                                            Void = true
                                        },
                                        new IdAndName()
                                        {
                                            Name = SiteMap.CurrentNode.ParentNode.ParentNode.Title
                                            ,
                                            Value = SiteMap.CurrentNode.ParentNode.ParentNode.Url
                                            ,
                                            Void = true
                                        },
                                        new IdAndName()
                                        {
                                            Name = course.FullName
                                            ,
                                            Value = SiteMap.CurrentNode.ParentNode.Url + "?cId=" + course.Id + "&edit=1"
                                            ,
                                            Void = true
                                        },
                                        new IdAndName()
                                        {
                                            Name = "Class edit"
                                        }
                                    };
                                    SiteMapUc.SetData(list);
                                }
                                CourseSessionCreateUC1.CourseName = course.FullName;
                            }
                            else
                            {
                                Response.Redirect("~/Views/Course/");
                            }
                        }

                    }
                    catch { Response.Redirect("~/Views/Course/"); }
                }
                else
                {
                    Response.Redirect("~/Views/Course/");
                }
                //load course detail
                using (var helper = new DbHelper.Subject())
                {
                    try
                    {
                        var cId = Convert.ToInt32(courseId);
                        var sub = helper.GetCourse(cId);

                        //if (sub != null)
                        //{
                        //    lblFullName.Text = sub.Name;
                        //    lblCategory.Text = sub.SubjectCategory.Name;
                        //    lblShortName.Text = sub.ShortName;
                        //}

                    }
                    catch { }
                }
            }
        }
    }
}