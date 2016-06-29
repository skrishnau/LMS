using Academic.DbHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.ViewsSite.DashBoard.Student.CourseSection
{
    public partial class CourseSectionListing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                CourseDetailUc1.AddNewButtonVisibility = false;
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