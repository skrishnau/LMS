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
                        lnkAddClasses.NavigateUrl = "~/Views/Academy/ProgramSelection/ProgramSelect.aspx?aId="+aId;
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
                        sessUc.LoadSessionData(academic.Id, sess.Id, sess.Name, sess.StartDate, sess.EndDate);
                        pnlSessions.Controls.Add(sessUc);
                    }

                }

            }

            using (var helper = new DbHelper.AcademicPlacement())
            {
                var classes = helper.ListRunningClasses(AcademicYearId, 0);//.OrderBy(p=>p.ProgramBatch.Program.Name);
                
                if (classes.Any())
                    pnlSessionPrograms.Visible = true;
               
                ListView1.DataSource = classes;
                ListView1.DataBind();
            }
        }

        protected void btnActivate_Click(object sender, EventArgs e)
        {

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
                ret += " , " + s.Name;
            }
            return ret;
        }
    }
}