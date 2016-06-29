using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.Office.School
{
    public partial class SchoolTypeUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DbHelper.ComboLoader.LoadInstitution(ref cmbInstitution,InstitutionId);
            }
            lblVali.Visible = false;
        }

        public bool AdminView
        {
            get { return this.phAdminView.Visible; }
            set { this.phAdminView.Visible = value; }
        }

        public int InstitutionId
        {
            get
            {
                return Convert.ToInt32(txtInstId.Text == "" ? "0" : txtInstId.Text);
            }
            set
            {
                AdminView = false;                
                this.txtInstId.Text = value.ToString();
            }
        }

        public bool Visible_
        {
            get { return this.Visible; }
            set { this.Visible = value; }
        }

        public int SavedId
        {
            get { return Convert.ToInt32(txtId.Text == "" ? "0" : txtId.Text); }
            set { txtId.Text = value.ToString(); }
        }

        public bool Save()
        {
            btnSave_Click(new object(), new EventArgs());
            return !lblVali.Visible;
        }

        public void Cancel()
        {
            btnClose_Click(new object(), new EventArgs());
        }
       
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSchoolTypeName.Text == "")
            {
                lblVali.Visible = true;
                return;
            }
            {
                using (var helper = new DbHelper.Office())
                {
                    var schTyp = new Academic.DbEntities.Office.SchoolType()
                    {
                        Name = txtSchoolTypeName.Text

                    };
                    //if (InstitutionId != 0)
                    //{
                    //    schTyp.InstitutionId = InstitutionId;
                    //}
                    var tp = helper.AddOrUpdateSchoolType(schTyp);
                    if (tp != null)
                    {
                        txtId.Text = tp.Id.ToString();
                    }
                    Visible_ = false;
                }
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            this.Visible_ = false;
            lblVali.Visible = false;
        }

        public string Name
        {
            get { return txtSchoolTypeName.Text; }
            set { txtSchoolTypeName.Text = value; }
        }
    }
}