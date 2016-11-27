using System;
using System.Collections.Generic;
using System.Drawing;
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

        public bool SessionNameVisible
        {
            set
            {
                lnkSessionName.Visible = value;
                lblActiveIndicator.Visible = value;
            }
            get { return lnkSessionName.Visible; }
        }

        public void LoadSessionData(int academicYearId, int sessionId, string name, DateTime start, DateTime end
          , bool active, bool sesComplete,bool editable,bool showSessionName=true)
        {
            hidAcademicYearId.Value = academicYearId.ToString();
            hidSessionId.Value = sessionId.ToString();

            if (showSessionName)
            {
                lnkSessionName.Text = name; //
                lblActiveIndicator.Text = ((sesComplete) ? " (Complete)" : (active ? " (Active)" : ""));
            }
            else
            {
                lnkSessionName.Visible = false;
                lblActiveIndicator.Visible = false;
            }

            lnkSessionName.NavigateUrl = "~/Views/Academy/Session/SessionDetail.aspx?aId=" 
                    + academicYearId + "&sId=" + sessionId;
            lblStartDate.Text = start.ToShortDateString();

            lblEndDate.Text = end.ToShortDateString();

            if (editable)
            {
                lnkEditClasses.NavigateUrl = "~/Views/Academy/ClassAssign/ClassAssignCreate.aspx?aId=" 
                    + academicYearId + "&sId=" + sessionId;
               
            }
            //GetPrograms in these sessions and add to pnlPrograms
            LoadPrograms();
            lnkEditClasses.Visible = !sesComplete && editable;

            if (sesComplete)
            {
                divBody.Style.Add("border-left","10px solid lightgrey");
                //pnlbody.BackColor = //Color.LightGray;
                //Color.FromArgb(225, 225, 225);
            }
            else if (active)
            {
                divBody.Style.Add("border-left", "10px solid green");
                
                //pnlbody.BackColor = //Color.LightGreen;
                //    Color.FromArgb(193, 252, 193);
            }
        }



        public void LoadPrograms()
        {
            using (var helper = new DbHelper.AcademicPlacement())
            {
                var classes = helper.ListRunningRunningClasses(AcademicYearYearId, SessionId);//.OrderBy(p=>p.ProgramBatch.Program.Name);

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

        public string GetUrl(object pbId)
        {
            if (pbId != null)
            {
                return "~/Views/Student/Batch/StudentDisplay/Students/StudentListInProgramBatch.aspx?pbId=" + pbId;
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
                ret += " , " + s.Name;
            }
            return ret;
        }

    }
}