using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Course.ListingMain.CourseMain.RegularCoursesLising
{
    public partial class ListItemUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadData(string name, string description, int noOfSections)
        {
            lblName.Text = name;
            lblDescription.Text = description;
            lblSectionCount.Text = noOfSections.ToString();
        }
    }
}