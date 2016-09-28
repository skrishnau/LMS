using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.Database;
using Academic.DbHelper;
//using Academic.InitialValues;

namespace One.Course
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                using (var context = new AcademicContext())
                {
                    //var d = context.Level.Where(x => x.SchoolId == InitialValues.CustomSession["SchoolId"]). ToList();
                    //cmbLevel.DataSource = d;
                    //cmbLevel.DataBind();
                }
               var helper = new DbHelper.Structure();
                cmbLevel.Width = 100;

               //cmbLevel.DataSource = helper.GetLevels(InitialValues.CustomSession["SchoolId"]);
                cmbLevel.DataMember = "Id";
                cmbLevel.DataTextField = "Name";
                cmbLevel.DataValueField = "Id";
                cmbLevel.DataBind();
            }
        }

        private void BindData()
        {
            using (var helper = new DbHelper.Subject())
            {
                var levelId = Convert.ToInt32(cmbLevel.SelectedValue==""?"0":cmbLevel.SelectedValue);
                var subjects = helper.ListSubjects(levelId);
                grdView.DataSource = subjects;
                grdView.DataBind();
                //grdView.Columns.Add(new datacontrolfie); = "";
            }
        }

        protected void cmbLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}