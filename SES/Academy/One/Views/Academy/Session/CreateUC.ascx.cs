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
            if (!IsPostBack)
            {

                //DbHelper.ComboLoader.LoadSchool(ref cmbSchool, InitialValues.CustomSession["InstitutionId"]);
                //List<Academic.DbEntities.AcademicYear> acaYears = DbHelper.ComboLoader.LoadAcademicYear(
                //                     ref cmbAcademicYear, Values.Session.GetSchool(Session));
                //Session["AcademicYears"] = acaYears;
                //AcademicYearList = acaYears.Select(x => x.Id).ToList();
                using (var helper = new DbHelper.AcademicYear())
                {
                    var aca = helper.GetAcademicYear(AcademicYearId);
                    var session = helper.GetSession(SessionId);

                    if (aca != null)
                    {
                        lblHeading.Text = @"New Session Create";
                        lblAcademicHeading.Text = @"Session create in Academic Year: """ + aca.Name + @"""";
                        lblAcademicStart.Text = "Start Date: " + aca.StartDate.ToShortDateString();
                        lblAcademicEnd.Text = "End Date:   " + aca.EndDate.ToShortDateString();
                    }
                    if (session != null)
                    {
                        lblHeading.Text = @"Edit Session """ + session.Name + @"""";
                        LoadSessionData(session);
                    }
                    LoadSessionParametersAndDate();
                }

            }
        }

        private void LoadSessionData(Academic.DbEntities.Session session)
        {
            txtName.Text = session.Name;
            dtEnd.SelectedDate = session.EndDate.Date;
            dtStart.SelectedDate = session.StartDate.Date;
            hidSessionId.Value = session.Id.ToString();
            AcademicYearId = session.AcademicYearId;

            dtEnd.MinDate = session.AcademicYear.StartDate;
            dtEnd.MaxDate = session.AcademicYear.EndDate;

            dtStart.MinDate = session.AcademicYear.StartDate;
            dtStart.MaxDate = session.AcademicYear.EndDate;

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

        private void LoadSessionParametersAndDate()
        {
            dtEnd.CheckDateRangeMax = true;
            dtEnd.CheckDateRangeMin = true;
            dtEnd.MaxDateValidationMessage = "Can't be greater than Academic year end date.";
            dtEnd.MinDateValiationMessage = "Can't be less than Academic year start date.";

            dtStart.CheckDateRangeMax = true;
            dtStart.CheckDateRangeMin = true;
            dtStart.MaxDateValidationMessage = "Can't be greater than Academic year end date.";
            dtStart.MinDateValiationMessage = "Can't be less than Academic year start date.";

        }

        //public List<int> AcademicYearList { get; set; }

        //public bool ValidationEnabled
        //{
        //    get { return RequiredFieldValidator1.Enabled || RequiredFieldValidator3.Enabled; }
        //    set
        //    {
        //        RequiredFieldValidator1.Enabled = value;
        //        RequiredFieldValidator3.Enabled = value;
        //    }
        //}

        //[Obsolete]
        //public int AcademicYear
        //{
        //    get
        //    {
        //        return Convert.ToInt32(hidAcademicYear.Value);
        //    }
        //    set
        //    {

        //        List<Academic.DbEntities.AcademicYear> acaYears = DbHelper.ComboLoader.LoadAcademicYear(
        //            ref cmbAcademicYear, Values.Session.GetSchool(Session), value);


        //        int index = cmbAcademicYear.SelectedIndex;
        //        if (index >= 0)
        //        {
        //            //var items = acaYears;//(List<Academic.DbEntities.AcademicYear>)Session["AcademicYears"];
        //            dtEnd.MinDate = acaYears[index].StartDate;
        //            dtEnd.MaxDate = acaYears[index].EndDate;

        //            dtStart.MinDate = acaYears[index].StartDate;
        //            dtStart.MaxDate = acaYears[index].EndDate;
        //        }
        //        //LoadSessionParametersAndDate();
        //        //this.cmbAcademicYear.ClearSelection();
        //        //var item = cmbAcademicYear.Items.FindByValue(value.ToString());
        //        //var se = cmbAcademicYear.Items.IndexOf(item);
        //        //this.cmbAcademicYear.SelectedIndex = se; ;
        //        cmbAcademicYear.Enabled = false;
        //        this.hidAcademicYear.Value = value.ToString();
        //    }
        //}


        protected void cmbSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var sch = cmbSchool.SelectedValue == "" ? "0" : cmbSchool.SelectedValue;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            bool task = btn.ID == "btnSaveAndAddMore";

            if (Page.IsValid)
            {
                using (var helper = new DbHelper.AcademicYear())
                {
                    var session = new Academic.DbEntities.Session()
                    {
                        Id = SessionId,
                        Name = txtName.Text
                        ,
                        EndDate = dtEnd.SelectedDate
                        ,
                        StartDate = dtStart.SelectedDate
                        ,
                        AcademicYearId = AcademicYearId
                    };
                    var sav = helper.AddOrUpdateSession(AcademicYearId, session);
                    if (sav)
                    {
                        if (!task)
                        {
                            Response.Redirect("~/Views/Academy/List.aspx");
                        }
                        else
                        {
                            ResetTextBoxes();
                        }
                    }
                }
            }
        }

        private void ResetTextBoxes()
        {
            txtName.Text = "";
            dtStart.ResetDate();
            dtEnd.ResetDate();
            hidSessionId.Value = "0";
        }
    }
}