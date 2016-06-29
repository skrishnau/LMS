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
                var user = Page.User as CustomPrincipal;
                if (user != null)
                {
                    if (!(user.IsInRole(StaticValues.Roles.CourseEditor)
                          || user.IsInRole(StaticValues.Roles.Manager)
                          || user.IsInRole(StaticValues.Roles.Teacher)))
                    {
                        CourseDetailUc1.AddNewButtonVisibility = false;                        
                    }
                }
                
                var id = Request.QueryString["SubId"];
                int subId = 0;
                var succ = int.TryParse(id, out subId);
                if (succ)
                {
                    Id = subId;
                    LoadCourse(subId);
                }
            }
            
        }

        public int Id { get; set; }

        private void LoadCourse(int courseId)
        {
            using (var helper = new DbHelper.Subject())
            {

                var sub = helper.Find(courseId);
                if (sub != null)
                {
                    txtSubjectName.Text = sub.Name;
                    CourseDetailUc1.CourseId = Id;
                }
                //CourseDetailUc1.
            }

        }
    }
}