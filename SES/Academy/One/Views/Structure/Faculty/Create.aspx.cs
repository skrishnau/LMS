using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
//using Academic.InitialValues;

namespace One.Views.Structure.Faculty
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //DbHelper.ComboLoader.LoadSchool(ref cmbSchool, InitialValues.CustomSession["InstitutionId"]);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void cmbSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            DbHelper.ComboLoader.LoadLevel(ref cmbLevel,Convert.ToInt32(cmbLevel.SelectedValue) );
        }
    }
}