using Academic.DbHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using One.Values;
using One.Values.MemberShip;

namespace One.Views.Course.Section.Master
{
    public partial class CourseSectionListing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                var id = Request.QueryString["SubId"];
                var edit = Request.QueryString["edit"];
                if (id != null)
                {
                    if (edit != null)
                    {
                        Response.Redirect("~/Views/Course/Section/?SubId="+id+"&edit="+edit);
                    }
                    else
                    {
                        Response.Redirect("~/Views/Course/Section/?SubId="+id);
                    }
                }
                else
                {
                    Response.Redirect("~/");
                }


            //    var user = Page.User as CustomPrincipal;
            //    if (user != null)
            //    {
            //        ListOfSectionsInCourseUC1.UserId = user.Id;
            //        if ((user.IsInRole(DbHelper.StaticValues.Roles.CourseEditor)
            //             || user.IsInRole(DbHelper.StaticValues.Roles.Manager)
            //             || user.IsInRole(DbHelper.StaticValues.Roles.Teacher)))
            //        {
            //            if (edit != null)
            //            {
            //                var path = Request.Url.AbsolutePath + "?SubId=" + id ;
            //                if (edit == "1")
            //                {
            //                    //edit on all sections
            //                    //link on edit 
                               
            //                    lnkEdit.NavigateUrl = path+ "&edit=0";
            //                    lblEdit.Text = "Exit Edit mode";
            //                    //ListOfSectionsInCourseUC1.AddNewButtonVisibility = true;
            //                    ListOfSectionsInCourseUC1.EditEnabled = true;

            //                }
            //                else
            //                {
            //                    lnkEdit.NavigateUrl = path + "&edit=1";
            //                    lblEdit.Text = "Edit";
            //                }
            //            }
            //            else
            //            {
            //                lnkEdit.NavigateUrl = Request.Url.PathAndQuery + "&edit=1";
            //                lblEdit.Text = "Edit";
            //            }

            //        }
            //        else
            //        {
            //            lnkEdit.Visible = false;
            //            lnkEdit.Enabled = false;
            //        }
            //    }

            //    int subId = 0;
            //    var succ = int.TryParse(id, out subId);
            //    if (succ)
            //    {
            //        Id = subId;
            //        LoadCourse(subId);
            //    }
            }

        }

        //public int Id { get; set; }

        //private void LoadCourse(int courseId)
        //{
        //    using (var helper = new DbHelper.Subject())
        //    {

        //        var sub = helper.Find(courseId);
        //        if (sub != null)
        //        {
        //            txtSubjectName.Text = sub.FullName;
        //            //uncomment
        //            ListOfSectionsInCourseUC1.CourseId = Id;
        //        }
        //        //CourseDetailUc1.
        //    }

        //}
    }
}