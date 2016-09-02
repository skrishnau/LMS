using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.Academy.Activation
{
    public partial class ActivateUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetName(int academicYearId, int sessionId, string name)
        {
            lblName.Text = name;
            hidAcademicYearId.Value = academicYearId.ToString();
            hidSessionId.Value = sessionId.ToString();
        }

        public int AcademicYearId
        {
            get { return Convert.ToInt32(hidAcademicYearId.Value); }
            set { hidAcademicYearId.Value = value.ToString(); }
        }

        public int SessionId
        {
            get { return Convert.ToInt32(hidSessionId.Value); }
            set { hidSessionId.Value = value.ToString(); }
        }

        protected void btnActivate_Click(object sender, EventArgs e)
        {
            int aId = AcademicYearId;
            int sId = SessionId;
            using (var helper = new DbHelper.AcademicYear())
            {
                //then session need to be activated
                helper.ActivateAcademicYearSession(aId, sId);
            }

        }
    }
}