using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.InitialValues;
using Microsoft.Ajax.Utilities;

namespace One.Views.Structure.Year
{
    public partial class Create : System.Web.UI.Page
    {
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
                //using (var helper = new DbHelper.Structure())
                //{

                //    var year = new Academic.DbEntities.Structure.Year()
                //    {
                //        Name = txtName.Text
                //        ,
                //        ProgramId = Convert.ToInt32(cmbProgram.SelectedValue)
                //        ,
                //    };
                //    bool saved = helper.AddOrUpdateYear(year);
                //    if (!saved)
                        Response.Write("Error while saving.");

                //}
            }
        }
    }
}