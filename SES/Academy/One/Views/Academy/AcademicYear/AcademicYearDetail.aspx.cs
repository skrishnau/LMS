using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.Academy.AcademicYear
{
    public partial class AcademicYearDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var aId = Request.QueryString["aId"];
                if (aId != null)
                {
                    try
                    {
                        hidAcademicYear.Value = aId;
                        lnknewSession.NavigateUrl = "~/Views/Academy/Session/Create.aspx?aId=" + aId;
                        lnkAddPrograms.NavigateUrl = "~/Views/Academy/ProgramSelection/ProgramSelect.aspx?aId="+aId;
                    }
                    catch { Response.Redirect("../List.aspx"); }
                }
            }
            LoadData();
        }

        public int AcademicYearId
        {
            get { return Convert.ToInt32(hidAcademicYear.Value); }
            set { hidAcademicYear.Value = value.ToString(); }
        }


        public void LoadData()
        {
            using (var helper = new DbHelper.AcademicYear())
            {
                var academic = helper.GetAcademicYear(AcademicYearId);
                if (academic != null)
                {
                    lblEndDate.Text = academic.EndDate.ToShortDateString();
                    lblStartDate.Text = academic.StartDate.ToShortDateString();
                    lblAcademicYearName.Text = academic.Name;

                    foreach (var sess in academic.Sessions.ToList())
                    {
                        var sessUc = (Academy.UserControls.SessionsListingInAYDetailUC)
                            Page.LoadControl("~/Views/Academy/UserControls/SessionsListingInAYDetailUC.ascx");
                        sessUc.LoadSessionData(sess.Id, sess.Name, sess.StartDate, sess.EndDate);
                        pnlSessions.Controls.Add(sessUc);
                    }

                }
            }
        }

        protected void btnActivate_Click(object sender, EventArgs e)
        {

        }
    }
}