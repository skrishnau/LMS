using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Course.ListingMain.CourseMain
{
    public partial class ListItemUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int SubjectGroupId
        {
            get { return Convert.ToInt32(hidSubjectGroupId.Value); }
            set { hidSubjectGroupId.Value = value.ToString(); }
        }
        public int YearId
        {
            get { return Convert.ToInt32(hidYearId.Value); }
            set { hidYearId.Value = value.ToString(); }
        }
        public int SubYearId
        {
            get { return Convert.ToInt32(hidSubYearId.Value); }
            set { hidSubYearId.Value = value.ToString(); }
        }


        public void LoadData(int groupId,int yearId, int subYearId, string groupName, string description, int countOfSubjects)
        {
            SubjectGroupId = groupId;
            YearId = yearId;
            SubYearId = subYearId;
            lblGroupName.Text = groupName;
            lblDescription.Text = description;
            lblCourseCount.Text = countOfSubjects.ToString();
        }

        protected void lblGroupName_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Course/ListingMain/CourseMain/RegularCoursesLising/RegularCourseListing.aspx" 
                + "?IdY=" + YearId + "&IdS=" + SubYearId);
        }
    }
}