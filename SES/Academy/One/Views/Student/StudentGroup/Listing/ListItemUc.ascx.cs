using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Student.StudentGroup.Listing
{
    public partial class ListItemUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Properties

        public int StudentGroupId
        {
            get { return Convert.ToInt32(hidStudentGroupId.Value); }
            set { hidStudentGroupId.Value = value.ToString(); }
        }

        #endregion

        #region Events

        protected void lblName_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Load Functions

        public void LoadData(int stdGroupId, string name, string numberOfStudents
            , string program, string year, string subYear)
        {
            StudentGroupId = stdGroupId;
            lblName.Text = name;
            lblNoOfStudents.Text = numberOfStudents;
            lblProgram.Text = program;
            lblYear.Text = year;
            lblSubYear.Text = subYear;
        }

        #endregion

    }
}