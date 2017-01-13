using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.ViewsSite.User.ModulesUc
{
    public partial class EarlierUc_NodesUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {



        }



        public void SetStructureData(Academic.DbEntities.Structure.Year year
            , Academic.DbEntities.Structure.SubYear subYear
            , List<Academic.DbEntities.Subjects.Subject> subjectsList
            
            , bool earlier = false)
        {
            if (year != null)
                lblStructureName.Text = year.Name + ((subYear == null) ? "" : (" / " + subYear.Name));
            dListCourses.DataSource = subjectsList;
            dListCourses.DataBind();
            if (earlier)
            {
                Image1.Visible = true;
                lblStructureName.Enabled = true;
                dListCourses.Visible = false;
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            dListCourses.Visible = !dListCourses.Visible;
        }
    }
}