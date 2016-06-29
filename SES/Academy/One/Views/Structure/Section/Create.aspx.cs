using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.InitialValues;
using One.Values;

namespace One.Views.Structure.Section
{
    public partial class Create : System.Web.UI.Page
    {
        public event EventHandler<MessageEventArgs> OnSaveClicked;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DbHelper.ComboLoader.LoadSchool(ref cmbSchool, InitialValues.CustomSession["InstitutionId"]);
            }
        }
        protected void cmbSchool_SelectedIndexChanged(object sender, EventArgs e)
        {

            DbHelper.ComboLoader.LoadLevel(ref cmbLevel, Convert.ToInt32(cmbLevel.SelectedValue));
        }

        protected void cmbLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            DbHelper.ComboLoader.LoadFaculty(ref cmbFaculty, Convert.ToInt32(cmbLevel.SelectedValue));

        }


        protected void cmbFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            DbHelper.ComboLoader.LoadProgram(ref cmbProgram, Convert.ToInt32(cmbFaculty.SelectedValue));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (cmbProgram.SelectedValue == "")
            {
                valiProg.IsValid = false;
            }
            if (IsValid)
            {
                //save year
                using (var helper = new DbHelper.Structure())
                {

                    var section = new Academic.DbEntities.Structure.SubYear()
                    {
                        Name = txtName.Text
                        ,
                        YearId = Convert.ToInt32(cmbProgram.SelectedValue)
                        ,
                    };
                    var saved = helper.AddOrUpdateSubYear(section);
                    if (saved != null)
                    {
                        if (OnSaveClicked != null)
                        {
                            OnSaveClicked(this, StaticValues.SuccessSaveMessageEventArgs);
                        }
                    }
                    else
                    {
                        if (OnSaveClicked != null)
                        {
                            OnSaveClicked(this, StaticValues.ErrorSaveMessageEventArgs);
                        }
                        
                    }
                        //Response.Write("Error while saving.");

                }
            }
        }

        protected void cmbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DbHelper.ComboLoader.LoadYear(ref cmbYear, Convert.ToInt32(cmbProgram.SelectedValue));
        }

    }
}