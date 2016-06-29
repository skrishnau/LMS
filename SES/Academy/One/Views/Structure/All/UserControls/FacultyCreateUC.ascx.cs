using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values;

namespace One.Views.Structure.All.UserControls
{
    public partial class FacultyCreateUC : System.Web.UI.UserControl
    {
        public event EventHandler<MessageEventArgs> OnSaveClicked;
        protected void Page_Load(object sender, EventArgs e)
        {
            AllValidatorVisibility = false;
            if (!IsPostBack)
            {
                var empty = (hidLevelId.Value == "0" || hidId.Value =="");
               DbHelper.ComboLoader.LoadLevel(ref cmbLevel,Values.Session.GetSchool(Session)
                   ,!empty,Convert.ToInt32(hidId.Value));
                if (!empty)
                    cmbLevel.Enabled = false;
            }

        }

        public int _id
        {
            get { return Convert.ToInt32(hidId.Value); }
            set { hidId.Value = value.ToString(); }
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

        public bool AllValidatorVisibility
        {
            set
            {
                valiTxtName.Visible = value;
                valiCmbLevel.Visible = value;
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
                LevelEnabled = false;
            }
        }
        public bool LevelEnabled
        {
            get { return cmbLevel.Enabled; }
            set {cmbLevel.Enabled = value; }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool isvalid = true;
            if (cmbLevel.SelectedValue == "" || cmbLevel.SelectedValue == "0")
            {
                valiCmbLevel.Visible = true;
                isvalid = false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                valiTxtName.Visible = true;
                isvalid = false;
            }
            if (isvalid)
            {
                var fac = new Academic.DbEntities.Structure.Faculty()
                {
                    Name = txtName.Text
                    ,Description = txtDescription.Text
                    ,LevelId = Convert.ToInt32(cmbLevel.SelectedValue)
                    ,
                };
                using (var helper = new DbHelper.Structure())
                {
                    var saved = helper.AddOrUpdateFaculty(fac);
                    if (saved != null)
                    {
                        if (OnSaveClicked != null)
                        {
                            OnSaveClicked(this, Values.StaticValues.SuccessSaveMessageEventArgs);
                        }
                        ClearCreateTextBoxes();
                    }
                    else
                    {
                        if (OnSaveClicked != null)
                        {
                            OnSaveClicked(this, Values.StaticValues.ErrorSaveMessageEventArgs);
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