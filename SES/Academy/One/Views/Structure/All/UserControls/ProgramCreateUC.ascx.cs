using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values;
using One.Values.MemberShip;

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
                //valiFaculty.Visible =value;
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
            //if (cmbFaculty.SelectedValue == "" || cmbFaculty.SelectedValue == "0")
            //{
            //    isValid = false;
            //    valiFaculty.Visible = true;
            //}
            var user = Page.User as CustomPrincipal;
            if(user!=null)
            if (isValid)
            {
                //save
                var prog = new Academic.DbEntities.Structure.Program()
                {
                    Name = txtName.Text
                    ,
                    SchoolId = user.SchoolId//Convert.ToInt32(cmbFaculty.SelectedValue)
                    ,Description =  txtDescription.Text
                    
                };
                using (var helper = new DbHelper.Structure())
                {
                    var saved = helper.AddOrUpdateProgram(prog);
                    if (saved != null)
                    {
                        if (OnSaveClicked != null)
                        {
                            OnSaveClicked(this, DbHelper.StaticValues.SuccessSaveMessageEventArgs);
                        }
                        ClearCreateTextBoxes();
                    }
                    else
                    {
                        if (OnSaveClicked != null)
                        {
                            OnSaveClicked(this, DbHelper.StaticValues.ErrorSaveMessageEventArgs);
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