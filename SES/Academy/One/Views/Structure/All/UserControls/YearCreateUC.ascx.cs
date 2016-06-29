using Academic.DbHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using One.Values;

namespace One.Views.Structure.All.UserControls
{
    public partial class YearCreateUC : System.Web.UI.UserControl
    {
        public event EventHandler<MessageEventArgs> OnSaveClicked;

        protected void Page_Load(object sender, EventArgs e)
        {
            AllValidatorVisibility = false;
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
                DbHelper.ComboLoader.LoadProgram(ref cmbProgram, Convert.ToInt32(hidFacultyId.Value), true);

            }
        }

        public int ProgramId
        {
            get { return Convert.ToInt32(hidProgram); }
            set
            {
                hidProgram.Value = value.ToString();
                cmbProgram.ClearSelection();
                cmbProgram.SelectedValue = value.ToString();
                cmbProgram.Enabled = false;
                //DbHelper.ComboLoader.LoadYear(ref cmbYear, Convert.ToInt32(hidLevelId.Value), true);

            }
        }

        public bool AllValidatorVisibility
        {
            set
            {
                valiTxtName.Visible = value;
                valiProgram.Visible = value;
                valitxtPosition.Visible = value;
            }
        }

        protected void btnSaveYear_Click(object sender, EventArgs e)
        {
            bool isvalid = true;
            if (string.IsNullOrEmpty(txtName.Text))
            {
                isvalid = false;
                valiTxtName.Visible = true;
            }
            if (cmbProgram.SelectedValue == "" || cmbProgram.SelectedValue == "0")
            {
                isvalid = false;
                valiProgram.Visible = true;
            }
            if (string.IsNullOrEmpty(txtPosition.Text))
            {
                isvalid = false;
                valitxtPosition.Visible = true;
            }
            if (isvalid)
            {
                var year = new Academic.DbEntities.Structure.Year()
                {
                    Name =  txtName.Text
                    ,
                    Position = Convert.ToInt32(txtPosition.Text)
                   ,ProgramId = Convert.ToInt32(cmbProgram.SelectedValue)
                   ,Description = txtDescription.Text
                   ,
                };

                using (var helper = new DbHelper.Structure())
                {
                    var saved = helper.AddOrUpdateYear(year);
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
            //if (OnSaveClicked != null)
            //{
            //    OnSaveClicked(this,EventArgs.Empty);
            //}
        }

        void ClearCreateTextBoxes()
        {
            txtName.Text = "";
            txtDescription.Text = "";
            txtPosition.Text = "";
        }
    }
}