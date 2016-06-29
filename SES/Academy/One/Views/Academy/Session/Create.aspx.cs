using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.InitialValues;

namespace One.Views.Academy.Session
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
        }
/*
        protected void cmbSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var sch = cmbSchool.SelectedValue == "" ? "0" : cmbSchool.SelectedValue;
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //if (cmbSchool.SelectedValue == "0")
            //{
            //    RequiredFieldValidator2.IsValid = false;
            //}
            //else
            //{
            //    RequiredFieldValidator2.IsValid = true;
            //}

            if (cmbAcademicYear.SelectedValue == "0" || cmbAcademicYear.SelectedValue == "")
            {
                RequiredFieldValidator3.IsValid = false;
            }
            else
            {
                RequiredFieldValidator3.IsValid = true;
            }

            if (IsValid)
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
                        AcademicYearId =Convert.ToInt32(cmbAcademicYear.SelectedValue)
                        ,IsActive = CheckBox1.Checked
                        ,SessionType = txtType.Text
                        
                    };
                    helper.AddOrUpdateSession(session);
                }
            }
        }

        protected void cmbAcademicYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = cmbAcademicYear.SelectedIndex - 1;
                if (index > 0)
                {
                    var items = (List<Academic.DbEntities.AcademicYear>) Session["AcademicYears"];
                    dtEnd.MinDate = items[index].StartDate;
                    dtEnd.MaxDate = items[index].EndDate;

                    dtStart.MinDate = items[index].StartDate;
                    dtStart.MaxDate = items[index].EndDate;
                }
            }
            catch
            {
                
            }
        }*/

        
    }
}