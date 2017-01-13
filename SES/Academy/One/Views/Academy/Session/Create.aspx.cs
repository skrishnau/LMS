using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
//using Academic.InitialValues;

namespace One.Views.Academy.Session
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                var aId = Request.QueryString["aId"];
                var sId = Request.QueryString["sId"];

                if (aId != null)
                {
                    try
                    {
                        AcademicYearId = Convert.ToInt32(aId);
                        //hidAcademicYear.Value = aId;
                        //lnknewSession.NavigateUrl = "~/Views/Academy/Session/Create.aspx?aId=" + aId;
                    }
                    catch { Response.Redirect("../List.aspx"); }
                }
                if (sId != null)
                {
                    try
                    {
                        SessionId = Convert.ToInt32(sId);
                    }
                    catch { }
                }
                if (aId == null && sId == null)
                {
                    Response.Redirect("../List.aspx");
                }
                ////DbHelper.ComboLoader.LoadSchool(ref cmbSchool, InitialValues.CustomSession["InstitutionId"]);
                //List<Academic.DbEntities.AcademicYear> acaYears = DbHelper.ComboLoader.LoadAcademicYear(
                //    ref cmbAcademicYear,Values.Session.GetSchool(Session));
                //Session["AcademicYears"] = acaYears;

                //dtEnd.CheckDateRangeMax = true;
                //dtEnd.CheckDateRangeMin = true;
                //dtEnd.MaxDateValidationMessage = "Can't be greater than Academic year end date.";
                //dtEnd.MinDateValiationMessage = "Can't be less than Academic year start date.";

                //dtStart.CheckDateRangeMax = true;
                //dtStart.CheckDateRangeMin = true;
                //dtStart.MaxDateValidationMessage = "Can't be greater than Academic year end date.";
                //dtStart.MinDateValiationMessage = "Can't be less than Academic year start date.";
            }
            LoadData();
        }

        void LoadData()
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
                        //lblHeading.Text = "New Session Create";
                        lblAcademicHeading.Text =  aca.Name ;
                        lblAcademicStart.Text =  aca.StartDate.ToString("D");
                        lblAcademicEnd.Text =  aca.EndDate.ToString("D");

                        ViewState["AcademicYearStartDate"] = aca.StartDate.Date;
                        ViewState["AcademicYearEndDate"] = aca.EndDate.Date;
                    }
                    if (session != null)
                    {
                        //lblHeading.Text = @"Edit Session """ + session.Name + @"""";
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Academy/AcademicYear/AcademicYearDetail.aspx?aId=" + AcademicYearId);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //var btn = (Button)sender;
            //bool task = btn.ID == "btnSaveAndAddMore";
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
                    var sav = helper.AddOrUpdateSession(AcademicYearId, session);
                    if (sav)
                    {
                        //if (!task)
                        //{
                        Response.Redirect("~/Views/Academy/AcademicYear/AcademicYearDetail.aspx?aId=" + AcademicYearId
                            +"&edit=1");
                        //Response.Redirect("~/Views/Academy/List.aspx");
                        //}
                        //else
                        //{
                        //    ResetTextBoxes();
                        //}
                    }
                    else lblError.Visible = true;
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