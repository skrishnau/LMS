using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.ActivityResource.Assignments
{
    public partial class TeacherViewUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var helper = new DbHelper.Classes())
                {
                    helper.ListUserSubmissionses(ARId, ARType);
                }
            }
        }

        public int ARId
        {
            get { return Convert.ToInt32(hidARId.Value); }
            set { hidARId.Value = value.ToString(); }
        }
        public string ARType
        {
            get { return (hidARType.Value); }
            set { hidARId.Value = value; }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}