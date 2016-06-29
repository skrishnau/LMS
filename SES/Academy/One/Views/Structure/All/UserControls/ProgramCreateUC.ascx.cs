using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values;

namespace One.Views.Structure.All.UserControls
{
    public partial class ProgramCreateUC : System.Web.UI.UserControl
    {
        public event EventHandler<MessageEventArgs> OnSaveClicked;

        protected void Page_Load(object sender, EventArgs e)
        {
            AllValidatorVisibility = false;
        }

        public bool AllValidatorVisibility
        {
            set
            {
                valiTxtName.Visible = value;
                valiFaculty.Visible =value;
            }
        }
        public int SchoolId
        {
            get { return Convert.ToInt32(hidSchoolId.Value); }
            set
            {
                hidSchoolId.Value = value.ToString();
                DbHelper.ComboLoader.LoadLevel(ref cmbLevel, Convert.ToInt32(hidSchoolId.Value), true);
            }
        }
        public int LevelId
        {
            get { return Convert.ToInt32(hidLevelId.Value); }
            set
            {
                hidLevelId.Value = value.ToString();
                cmbLevel.ClearSelection();
                cmbLevel.SelectedValue = value.ToString();
                cmbLevel.Enabled = false;
                DbHelper.ComboLoader.LoadFaculty(ref cmbFaculty, Convert.ToInt32(hidLevelId.Value), true);
            }
        }

        public int FacultyId
        {
            get { return Convert.ToInt32(hidFacultyId); }
            set
            {
                hidFacultyId.Value = value.ToString();
                cmbFaculty.ClearSelection();
                cmbFaculty.SelectedValue = value.ToString();
                cmbFaculty.Enabled = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void cmbLevel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSaveProgram_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(txtName.Text))
            {
                isValid = false;
                valiTxtName.Visible = true;
            }
            if (cmbFaculty.SelectedValue == "" || cmbFaculty.SelectedValue == "0")
            {
                isValid = false;
                valiFaculty.Visible = true;
            }

            if (isValid)
            {
                //save
                var prog = new Academic.DbEntities.Structure.Program()
                {
                    Name = txtName.Text
                    ,
                    FacultyId = Convert.ToInt32(cmbFaculty.SelectedValue)
                    ,Description =  txtDescription.Text
                    
                };
                using (var helper = new DbHelper.Structure())
                {
                    var saved = helper.AddOrUpdateProgram(prog);
                    if (saved != null)
                    {
                        if (OnSaveClicked != null)
                        {
                            OnSaveClicked(this, StaticValues.SuccessSaveMessageEventArgs);
                        }
                        ClearCreateTextBoxes();
                    }
                    else
                    {
                        if (OnSaveClicked != null)
                        {
                            OnSaveClicked(this, StaticValues.ErrorSaveMessageEventArgs);
                        }
                    }
                }
            }
           
        }
        void ClearCreateTextBoxes()
        {
            txtName.Text = "";
            txtDescription.Text = "";
            
        }
    }
}