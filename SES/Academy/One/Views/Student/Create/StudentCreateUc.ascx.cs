using Academic.DbHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using One.Values;

namespace One.Views.Student.Create
{
    public partial class StudentCreateUc : System.Web.UI.UserControl
    {
        public event EventHandler<MessageEventArgs> CloseClicked;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblSaveStatus.Visible = false;
            if (!IsPostBack)
            {
                //LoadDivisions();
                DbHelper.ComboLoader.LoadGender(ref cmbGender);
                //DbHelper.ComboLoader.LoadSchool(ref cmbSchool, InitialValues.CustomSession["InstitutionId"]);
                DbHelper.ComboLoader.LoadUserType(ref cmbRole,Values.Session.GetSchool(Session), "Student");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //List<int> DivisonsAssigned = new List<int>();
                using (var helper = new DbHelper.Student())
                {
                    //helper.
                }
                int role = (cmbRole.SelectedValue == "") ? 0 : Convert.ToInt32(cmbRole.SelectedValue.ToString());
                var dob = new DateTime(1900, 1, 1).Date;
                try
                {
                    if (txtDOB.Text != "")
                        dob = DateTime.Parse(txtDOB.Text);
                    dob = dob.Date;
                }

                catch { }
                var date = DateTime.Parse(DateTime.Now.Date.ToShortDateString());
                var createdUser = new Academic.DbEntities.User.Users()
                {
                    City = txtCity.Text
                    ,
                    Country = txtCountry.Text
                    ,
                    CreatedDate = date
                    ,
                    Email = txtEmail.Text
                    ,
                    FirstName = txtFirstName.Text
                    ,
                    LastName = txtLastName.Text
                    ,
                    GenderId = Convert.ToByte(cmbGender.SelectedValue)
                    ,
                    IsActive = true
                    ,
                    IsDeleted = false
                    ,
                    UserName = txtUserName.Text
                    ,
                    Password = txtPassword.Text
                    ,
                    Phone = txtPhone1.Text
                    ,

                };
                var student = new Academic.DbEntities.Students.Student()
                {
                    CRN = txtCRN.Text,
                    //CreatedUserId =
                    ExamRollNoGlobal = txtExamRoll.Text,
                    GuardianContactNo = txtGuarContact.Text,
                    GuardianEmail = txtGuarEmail.Text,
                    GuardianName = txtGuarName.Text

                };


                createdUser.DOB = DateTime.Parse(dob.Date.ToShortDateString());
                var SchoolId = Values.Session.GetSchool(Session);
                if (SchoolId > 0)
                {

                    createdUser.SchoolId = SchoolId;
                }

                using (var helper = new DbHelper.Student())
                {
                    var saved = helper.AddOrUpdateStudent(createdUser, student);
                    if (saved!=null)
                    {
                        lblSaveStatus.Text = ("Save Successful.");
                        Button btn = (Button) sender;
                        if (btn.ID == "btnSaveNAddMore")
                        {
                            lblSaveStatus.Visible = true;
                            ResetTextAndCombos();
                        }
                        else
                        {
                            if (CloseClicked != null)
                            {
                                CloseClicked(this, StaticValues.CancelClickedMessageEventArgs);
                            }
                        }
                    }
                    else
                    {
                        lblSaveStatus.Visible = true;
                        lblSaveStatus.Text = "Couldn't Save.";
                    }
                }

            }
        }

        private void ResetTextAndCombos()
        {
            txtMidName.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtDOB.Text = "";
            txtCity.Text = "";
            txtCountry.Text = "";
            txtStreet.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtUserName.Text = "";
            txtPhone1.Text = "";
            //cmbSchool.SelectedValue = "0";
            //cmbGender.SelectedValue = "0";

        }



        //private void LoadDivisions()
        //{
        //    using (var helper = new DbHelper.User())
        //    {
        //        CheckBoxList1.Items.Clear();
        //        var divId = (cmbSchool.SelectedValue == "") ? 0 : Convert.ToInt32(cmbSchool.SelectedValue);
        //        var divs = helper.GetDivisionsForCombo(divId);
        //        foreach (var division in divs)
        //        {
        //            CheckBoxList1.Items.Add(new ListItem(division.Name, division.Id.ToString()));
        //        }
        //    }
        //}
    }
}