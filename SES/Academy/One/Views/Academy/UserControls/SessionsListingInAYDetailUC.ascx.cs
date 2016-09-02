using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.Academy.UserControls
{
    public partial class SessionsListingInAYDetailUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int AcademicYearYearId
        {
            get { return Convert.ToInt32(hidAcademicYearId.Value); }
            set { hidAcademicYearId.Value = value.ToString(); }
        }

        public int SessionId
        {
            get { return Convert.ToInt32(hidSessionId.Value); }
            set { hidSessionId.Value = value.ToString(); }
        }

        public void LoadSessionData(int academicYearId,int sessionId, string name, DateTime start, DateTime end)
        {
            hidAcademicYearId.Value = academicYearId.ToString();
            hidSessionId.Value = sessionId.ToString();

            lnkSessionName.Text = name;
            lnkSessionName.NavigateUrl = "~/Views/Academy/Session/SessionDetail.aspx?sId=" + sessionId;
            lblStartDate.Text = start.ToShortDateString();
            
            lblEndDate.Text = end.ToShortDateString();

            lnkAddClasses.NavigateUrl ="~/Views/Academy/ProgramSelection/ProgramSelect.aspx?aId="+academicYearId+"&sId="+sessionId;
            //GetPrograms in these sessions and add to pnlPrograms
            LoadPrograms();
        }



        public void LoadPrograms()
        {
            using (var helper = new DbHelper.AcademicPlacement())
            {
                var classes = helper.ListRunningClasses(AcademicYearYearId, SessionId);//.OrderBy(p=>p.ProgramBatch.Program.Name);

                if (classes.Any())
                    pnlSessionPrograms.Visible = true;
                

                ListView1.DataSource = classes;
                ListView1.DataBind();
            }
        }

        public string GetName(object programBatch)
        {
            var p = programBatch as Academic.DbEntities.Batches.ProgramBatch;
            if (p != null)
            {
                return p.NameFromBatch;
            }
            return "";
        }

        public string GetCurrent(object year, object subyear)
        {
            string ret = "";
            var y = year as Academic.DbEntities.Structure.Year;
            var s = (subyear == null) ? null : subyear as Academic.DbEntities.Structure.SubYear;
            if (y != null)
            {
                ret = y.Name;

            }
            if (s != null)
            {
                ret +=" , "+ s.Name;
            }
            return ret;
        }
        
    }
}