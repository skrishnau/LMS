using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;

namespace One.Views.Academy.Session
{
    public partial class CreateUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            valiStartDate.ErrorMessage = "Required";
            valiEnd.ErrorMessage = "Required";
            if (!IsPostBack)
            {
                using (var helper = new DbHelper.AcademicYear())
                {
                    var aca = helper.GetAcademicYear(AcademicYearId);
                    var session = helper.GetSession(SessionId);

                    if (aca != null)
                    {
                        lblHeading.Text = "New Session Create";
                        lblAcademicHeading.Text = @"Session create in Academic Year: """ + aca.Name + @"""";
                        lblAcademicStart.Text = "Start Date: " + aca.StartDate.ToShortDateString();
                        lblAcademicEnd.Text = "End Date:   " + aca.EndDate.ToShortDateString();

                        ViewState["AcademicYearStartDate"] = aca.StartDate.Date;
                        ViewState["AcademicYearEndDate"] = aca.EndDate.Date;
                    }
                    if (session != null)
                    {
                        lblHeading.Text = @"Edit Session """ + session.Name + @"""";
                        LoadSessionData(session);
                    }
                    //LoadSessionParametersAndDate();
                }

            }
        }

        private void LoadSessionData(Academic.DbEntities.Session session)
        {
            txtName.Text = session.Name;
            txtEnd.Text = session.EndDate.Date.ToShortDateString();
            txtStart.Text = session.StartDate.Date.ToShortDateString();
            hidSessionId.Value = session.Id.ToString();
            AcademicYearId = session.AcademicYearId;
        }

        public int AcademicYearId
        {
            get { return Convert.ToInt32(hidAcademicYear.Value); }
            set { hidAcademicYear.Value = value.ToString(); }
        }
        public int SessionId
        {
            get { return Convert.ToInt32(hidSessionId.Value); }
            set { hidSessionId.Value = value.ToString(); }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            bool task = btn.ID == "btnSaveAndAddMore";
            var startdate = DateTime.Now;
            var enddate = DateTime.Now;
            var start = (DateTime)ViewState["AcademicYearStartDate"];
            var end = (DateTime)ViewState["AcademicYearEndDate"];

            try
            {
                startdate = Convert.ToDateTime(txtStart.Text);
                if (startdate < start || startdate > end)
                {
                    valiStartDate.ErrorMessage = "Should be between Start and End dates of Academic year.";
                    valiStartDate.IsValid = false;
                }
            }
            catch
            {
                valiStartDate.IsValid = false;
                valiStartDate.ErrorMessage = "Not in right format.";
            }
            try
            {
                //if (Page.IsValid)
                {
                    enddate = Convert.ToDateTime(txtEnd.Text);
                    if (enddate < start || enddate > end)
                    {
                        valiEnd.ErrorMessage = "Should be between Start and End dates of Academic year.";
                        valiEnd.IsValid = false;
                    }
                    if (enddate < startdate)
                    {
                        valiStartDate.ErrorMessage = "Can't be greater than end date";
                        valiStartDate.IsValid = false;
                        valiEnd.ErrorMessage = "Can't be less than start date";
                        valiEnd.IsValid = false;
                    }
                }
            }
            catch
            {
                valiEnd.IsValid = false;
                valiEnd.ErrorMessage = "Not in right format.";
            }

            if (Page.IsValid)
            {
                using (var helper = new DbHelper.AcademicYear())
                {
                    var session = new Academic.DbEntities.Session()
                    {
                        Id = SessionId,
                        Name = txtName.Text
                        ,
                        EndDate = enddate
                        ,
                        StartDate = startdate
                        ,
                        AcademicYearId = AcademicYearId
                    };
                    //var sav = helper.AddOrUpdateSession(AcademicYearId, session);
                    //if (sav)
                    //{
                    //    if (!task)
                    //    {
                    //        Response.Redirect("~/Views/Academy/List.aspx");
                    //    }
                    //    else
                    //    {
                    //        ResetTextBoxes();
                    //    }
                    //}
                    //else lblError.Visible = true;
                }
            }
        }

        private void ResetTextBoxes()
        {
            txtName.Text = "";
            txtStart.Text = "";
            txtEnd.Text = "";
            hidSessionId.Value = "0";
        }
    }
}