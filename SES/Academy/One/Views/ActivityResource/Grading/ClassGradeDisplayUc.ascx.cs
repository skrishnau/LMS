using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.ActivityResource.Grading
{
    public partial class ClassGradeDisplayUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetData(string className)
        {
            lblClassName.Text = className;
        }

        public void AddControls(UserGradeDisplayUc userUc)
        {
            pnlUsers.Controls.Add(userUc);
        }
        /// <summary>
        /// here showHeading defines if table heading i.e. image, username , email , heading is displayed or not
        /// </summary>
        /// <param name="cntrl"></param>
        /// <param name="showHeading"></param>
        public void AddControlsInsideTable(Control cntrl,bool showHeading)
        {
            pnlUsers.Controls.Add(cntrl);
            headingRow.Visible = showHeading;
        }
        public void AddControlsOusideOfTable(Control cntrl)
        {
            pnlOtherControls.Controls.Add(cntrl);
            headingRow.Visible = false;
        }

        public bool ShowStudentListTableHeading { get { return headingRow.Visible; } set { headingRow.Visible = value; } }

        public bool Enable
        {
            set { pnlUsers.Enabled = value; }
            get { return pnlUsers.Enabled; }
        }
    }
}