using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.InitialValues;

namespace One.Views.Office.School
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (InitialValues.CustomSession["InstitutionId"] <= 0)
                {
                    Response.Redirect("~/Views/Office/Institution/Create.aspx");
                    return;
                }
                LoadSchoolType();
                //pnlSchTyp.Visible = false;
                SchoolTypeUC.SavedId = 0;
                SchoolTypeUC.Visible_ = false;
                SchoolTypeAllButtonsVisible(false);
            }

            if (Values.Session.GetUser(Session) > 0)
            {
                hidUserId.Value = Values.Session.GetUser(Session).ToString();
            }
            else
            {
                using (var helper = new DbHelper.Office())
                {
                    var sch = helper.GetSchoolOfUser(Values.Session.GetUser(Session));
                    if (sch != null)
                    {
                        //Give to update or edit but not add new.
                        Response.Redirect("~/Views/Dashboard.aspx");                        
                    }
                }
                //redirect to login page.
                Response.Redirect("~/Views/Account/Login.aspx");
            }
            lblMsg.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbSchoolType.SelectedValue == "" || cmbSchoolType.SelectedValue == "0")
            {
                valiSchType.IsValid = false;
                return;
            }
            if (IsValid)
            {
                var school = new Academic.DbEntities.Office.School()
                {
                    Name = txtName.Text
                    ,
                    City = txtCity.Text
                    ,
                    Code = txtCode.Text
                    ,
                    Country = txtCountry.Text
                    ,
                    Email = txtEmail.Text
                    ,
                    Fax = txtFax.Text
                        //,InstitutionId = InitialValues.CustomSession["InstitutionId"]
                    ,
                    IsActive = chkActive.Checked
                    ,
                    Phone = txtPhone.Text
                    ,
                    RegNo = txtRegNo.Text
                        //next version
                    ,
                    SchoolTypeId = Convert.ToInt32(cmbSchoolType.Text)
                    ,
                    Street = txtStreet.Text
                    ,
                    Website = txtWeb.Text
                    ,
                    UserId = Values.Session.GetUser(Session)
                    ,
                    CreatedDate = DateTime.Now
                   ,
                };
                using (var helper = new DbHelper.Office())
                {
                    var saved = helper.AddOrUpdateSchool(school, FileUpload1.PostedFile);
                    if (saved != null)
                    {
                        SchoolTypeUC.SavedId = 0;
                        lblMsg.Visible = true;
                        lblMsg.Text = "Save Successful.";
                    }
                    else
                    {
                        lblMsg.Text = "Error while saving.";
                    }
                }
            }
        }

        protected void cmbSchoolType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSchoolType.SelectedValue == "-1")
            {
                SchoolTypeUC.InstitutionId = InitialValues.CustomSession["InstitutionId"];
                SchoolTypeAllButtonsVisible(true);

            }
            else
            {
                SchoolTypeAllButtonsVisible(false);
                ResetSchoolTypeUc();
            }
        }

        private void ResetSchoolTypeUc()
        {
            SchoolTypeUC.SavedId = 0;
            SchoolTypeUC.Name = "";
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    SchoolTypeUC.Visible_ = false;
        //}

        void LoadSchoolType(int selectedValue = 0)
        {
            DbHelper.ComboLoader.LoadSchoolType(ref  cmbSchoolType,
                    InitialValues.CustomSession["InstitutionId"], selectedValue, false);
            SchoolTypeAllButtonsVisible(false);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            SchoolTypeUC.Cancel();
            SchoolTypeAllButtonsVisible(false);
        }

        void SchoolTypeAllButtonsVisible(bool value)
        {
            //btnCancel.Visible = value;
            //btnSave.Visible = value;
            pnlSchTypeUc.Visible = value;
            SchoolTypeUC.Visible_ = value;
        }

        protected void btnSave1_Click(object sender, EventArgs e)
        {
            var saved = SchoolTypeUC.Save();
            if (saved)
            {
                LoadSchoolType(SchoolTypeUC.SavedId);
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            if (!pnlSchTypeUc.Visible)
            {
                SchoolTypeUC.InstitutionId = InitialValues.CustomSession["InstitutionId"];
                SchoolTypeAllButtonsVisible(true);
            }
            else
            {
                SchoolTypeAllButtonsVisible(false);
            }
        }
    }
}