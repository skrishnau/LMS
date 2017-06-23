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

        public void LoadSessionData(int academicYearId, int sessionId, string sessionName, DateTime start, DateTime end
          , bool active, bool sesComplete, bool edit, bool showClasses = true)
        {
            hidAcademicYearId.Value = academicYearId.ToString();
            hidSessionId.Value = sessionId.ToString();

            lnkSessionName.Text = sessionName; //
            lblActiveIndicator.Text = ((sesComplete) ? " (Complete)" : (active ? " (Active)" : ""));

            lnkEdit.Visible = edit;

            //earlier
            //lnkDelete.Visible = edit;

            if (edit)
            {
                lnkEditClasses.NavigateUrl = "~/Views/Academy/ClassAssign/ClassAssignCreate.aspx?aId="
                    + academicYearId + "&sId=" + sessionId;
                lnkEdit.NavigateUrl = "~/Views/Academy/Session/Create.aspx?aId=" + academicYearId + "&sId=" + sessionId;
                
                //earlier
                //if ((active || sesComplete))
                //    lnkDelete.Visible = false;
                //else
                //    lnkDelete.NavigateUrl = "~/Views/All_Resusable_Codes/Delete/DeleteForm.aspx?task=" +
                //                            DbHelper.StaticValues.Encode("session") + "&acaId=" + academicYearId +
                //                            "&sessId=" + sessionId;
            }
            lnkSessionName.NavigateUrl = "~/Views/Academy/Session/SessionDetail.aspx?aId="
                + academicYearId + "&sId=" + sessionId + "&edit=" + (edit ? "1" : "0");

            lblStartDate.Text = start.ToString("D");
            lblEndDate.Text = end.ToString("D");
            //GetPrograms in these sessions and add to pnlPrograms
            if (showClasses)
                LoadPrograms();
            else
            {
                pnlClasses.Controls.Clear();
            }
            lnkEditClasses.Visible = !sesComplete && edit;

            if (sesComplete)
            {
                //divBody.Style.Add("border-left", "10px solid lightgrey");
                imgActive.ImageUrl = "~/Content/Icons/Stop/Stop_10px.png";
                imgActive.Visible = true;
            }
            else if (active)
            {
                //divBody.Style.Add("border-left", "10px solid green");
                imgActive.ImageUrl = "~/Content/Icons/Start/active_icon_10px.png";
                imgActive.Visible = true;
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