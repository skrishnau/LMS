using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
//using Academic.InitialValues;
using One.Values.MemberShip;

namespace One.Views.Academy.AcademicYear
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //DbHelper.ComboLoader.LoadSchool(ref cmbSchool, InitialValues.CustomSession["InstitutionId"],true);
                //CreateUC1.ValidationEnabled = false;
                pnlSession.Visible = false;
            }
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
            var user = Page.User as CustomPrincipal;
            if(user!=null)
            if (IsValid)
            {
                
                var entity = new Academic.DbEntities.AcademicYear()
                {
                    Id = Convert.ToInt32(hidId.Value)
                    ,
                    Name = txtName.Text
                    ,
                    //EndDate = dtEnd.SelectedDate
                    //,
                    //StartDate = dtStart.SelectedDate
                    //,
                    SchoolId = user.SchoolId// Values.Session.GetSchool(Session)
                    ,
                    IsActive = CheckBox1.Checked
                };
                using (var helper = new DbHelper.AcademicYear())
                {

                    var saved = helper.AddOrUpdateAcademicYear(user.SchoolId, entity);
                    if (saved!=null)
                    {
                        //Response.Write("SAVE SUCCESSFUL!");

                        //earlier uncommented
                        //pnlAcademicYear.Enabled = false;
                        btnSave.Enabled = false;
                        //CreateUC1.ValidationEnabled = true;
                        CreateUC1.AcademicYearId = saved.Id;
                        //earlier uncommented
                        //pnlAcademicYear.BackColor = Color.Aquamarine;
                        pnlSession.Visible = true;
                    }
                }
            }
        }

    }
}