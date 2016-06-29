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
                List<Academic.DbEntities.AcademicYear> acaYears = DbHelper.ComboLoader.LoadAcademicYear(
                                     ref cmbAcademicYear, Values.Session.GetSchool(Session));
                Session["AcademicYears"] = acaYears;
                AcademicYearList = acaYears.Select(x => x.Id).ToList();
                LoadSessionParametersAndDate();

            }
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

        public List<int> AcademicYearList { get; set; }

        public bool ValidationEnabled
        {
            get { return RequiredFieldValidator1.Enabled || RequiredFieldValidator3.Enabled; }
            set
            {
                RequiredFieldValidator1.Enabled = value;
                RequiredFieldValidator3.Enabled = value;
            }
        }

        public int AcademicYear
        {
            get
            {
                return Convert.ToInt32(hidAcademicYear.Value);
            }
            set
            {

                List<Academic.DbEntities.AcademicYear> acaYears = DbHelper.ComboLoader.LoadAcademicYear(
                    ref cmbAcademicYear, Values.Session.GetSchool(Session), value);


                int index = cmbAcademicYear.SelectedIndex;
                if (index >= 0)
                {
                    //var items = acaYears;//(List<Academic.DbEntities.AcademicYear>)Session["AcademicYears"];
                    dtEnd.MinDate = acaYears[index].StartDate;
                    dtEnd.MaxDate = acaYears[index].EndDate;

                    dtStart.MinDate = acaYears[index].StartDate;
                    dtStart.MaxDate = acaYears[index].EndDate;
                }
                //LoadSessionParametersAndDate();
                //this.cmbAcademicYear.ClearSelection();
                //var item = cmbAcademicYear.Items.FindByValue(value.ToString());
                //var se = cmbAcademicYear.Items.IndexOf(item);
                //this.cmbAcademicYear.SelectedIndex = se; ;
                cmbAcademicYear.Enabled = false;
                this.hidAcademicYear.Value = value.ToString();
            }
        }


        protected void cmbSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var sch = cmbSchool.SelectedValue == "" ? "0" : cmbSchool.SelectedValue;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //if (cmbSchool.SelectedValue == "0")
            //{
            //    RequiredFieldValidator2.IsValid = false;
            //}
            //else
            //{
            //    RequiredFieldValidator2.IsValid = true;
            //}

            var btn = (Button)sender;
            bool task = btn.ID == "btnSaveAndAddMore";

            if (cmbAcademicYear.SelectedValue == "0" || cmbAcademicYear.SelectedValue == "")
            {
                RequiredFieldValidator3.IsValid = false;
            }
            else
            {
                RequiredFieldValidator3.IsValid = true;
            }

            if (Page.IsValid)
            {
                using (var helper = new DbHelper.AcademicYear())
                {
                    var session = new Academic.DbEntities.Session()
                    {
                        Name = txtName.Text
                        ,
                        EndDate = dtEnd.SelectedDate
                        ,
                        StartDate = dtEnd.SelectedDate
                        ,
                        AcademicYearId = Convert.ToInt32(cmbAcademicYear.SelectedValue)
                        ,
                        IsActive = CheckBox1.Checked
                        ,
                        SessionType = txtType.Text

                    };
                    var sav = helper.AddOrUpdateSession(session);
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
            CheckBox1.Checked = false;
            txtType.Text = "";
            if (!(hidAcademicYear.Value == "" || hidAcademicYear.Value == "0"))
            {
                cmbAcademicYear.ClearSelection();
                hidId.Value = "0";
            }
        }

        protected void cmbAcademicYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = cmbAcademicYear.SelectedIndex ;
                if (index >= 0)
                {

                    var items = (List<Academic.DbEntities.AcademicYear>)Session["AcademicYears"];
                    if (items == null)
                    {
                        using (var helper = new DbHelper.AcademicYear())
                        {
                            items = helper.GetAcademicYearListForSchool(Values.Session.GetSchool(Session));
                            if (items.Count > 0)
                                items.Insert(0, new Academic.DbEntities.AcademicYear() { Id = 0, Name = "--Select One--" });

                        }
                    }

                    dtEnd.MinDate = items[index].StartDate;
                    dtEnd.MaxDate = items[index].EndDate;

                    dtStart.MinDate = items[index].StartDate;
                    dtStart.MaxDate = items[index].EndDate;

                }
            }
            catch
            {

            }
        }


    }
}