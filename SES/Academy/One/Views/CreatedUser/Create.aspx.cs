using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
//using Academic.InitialValues;

namespace One.Views.CreatedUser
{
    public partial class Create : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            lblSaveStatus.Visible = false;
            if (!IsPostBack)
            {
                LoadDivisions();
                DbHelper.ComboLoader.LoadGender(ref cmbGender);
                //DbHelper.ComboLoader.LoadSchool(ref cmbSchool, InitialValues.CustomSession["InstitutionId"]);
                //DbHelper.ComboLoader.LoadUserType(ref cmbRole, InitialValues.CustomSession["InstitutionId"]);
            }
        }

        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    if (IsValid)
        //    {
        //        List<int> DivisonsAssigned = new List<int>();
        //        using (var helper = new DbHelper.Student())
        //        {
        //            //helper.
        //        }
        //        int role = (cmbRole.SelectedValue == "") ? 0 : Convert.ToInt32(cmbRole.SelectedValue.ToString());
        //        var dob=DateTime.MinValue.Date;
        //        try
        //        {
        //            if (txtDOB.Text != "")
        //                dob = DateTime.Parse(txtDOB.Text).Date;
        //        }
        //        catch { }
        //        var date = DateTime.Now.Date;
        //        var createdUser = new Academic.DbEntities.User.CreatedUser()
        //            {
        //                Citizenship = txtCitizenship.Text
        //                ,
        //                City = txtCity.Text
        //                ,
        //                Country = txtCountry.Text
        //                ,
        //                CreatedDate = date
        //                ,
        //                Email = txtEmail.Text
        //                ,
        //                FirstName = txtFirstName.Text
        //                ,
        //                MiddleName = txtMidName.Text
        //                ,
        //                LastName = txtLastName.Text
        //                ,
        //                GenderId = Convert.ToByte(cmbGender.SelectedValue)
        //                //,
        //                //InstitutionId = InitialValues.CustomSession["InstitutionId"]
        //                ,
        //                IsActive = true
        //                ,
        //                IsDeleted = false
        //                ,
        //                UserName = txtUserName.Text
        //                ,
        //                Password = txtPassword.Text
        //                ,
        //                Phone1 = txtPhone1.Text
        //                ,
        //                Phone2 = txtPhone2.Text
        //                ,
        //                UserTypeId = role
        //                ,
        //                Street = txtStreet.Text
        //            };
        //        //if(dob!=DateTime.MinValue)
        //            createdUser.DOB = dob;
        //        var SchoolId = Convert.ToInt32(cmbSchool.SelectedValue);
        //        if (SchoolId > 0)
        //        {
        //            createdUser.SchoolId = SchoolId;
        //        }
        //        foreach (ListItem divisions in CheckBoxList1.Items)
        //        {
        //            if (divisions.Selected)
        //            {
        //                DivisonsAssigned.Add(Convert.ToInt32(divisions.Value));
        //            }
        //        }
        //        using (var helper = new DbHelper.User())
        //        {
        //            helper.SaveCreatedUser(createdUser, DivisonsAssigned, FileUpload1.PostedFile);
        //        }
        //        lblSaveStatus.Text=("Save Successful.");
        //        lblSaveStatus.Visible = true;
        //        ResetTextAndCombos();
        //    }
        //}

        private void ResetTextAndCombos()
        {
            txtMidName.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtDOB.Text = "";
            txtCitizenship.Text = "";
            txtCity.Text = "";
            txtCountry.Text = "";
            txtStreet.Text = "";
            txtEmail.Text = "";
            //txtJobTitle.Text = "";
            txtPassword.Text = "";
            txtUserName.Text = "";
            txtPhone1.Text = "";
            txtPhone2.Text = "";
            //cmbSchool.SelectedValue = "0";
            //cmbGender.SelectedValue = "0";

        }

        protected void cmbSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDivisions();
        }

        private void LoadDivisions()
        {
            using (var helper = new DbHelper.User())
            {
                CheckBoxList1.Items.Clear();
                var divId = (cmbSchool.SelectedValue == "") ? 0 : Convert.ToInt32(cmbSchool.SelectedValue);
                //var divs = helper.GetDivisionsForCombo(divId);
                //foreach (var division in divs)
                //{
                //    CheckBoxList1.Items.Add(new ListItem(division.Name, division.Id.ToString()));
                //}
            }
        }
    }
}