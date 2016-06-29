using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.Academy
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            using (var helper = new DbHelper.AcademicYear())
            {
                var aca = helper.GetAcademicYearListForSchool(Values.Session.GetSchool(Session));
                for (var i = 0; i < aca.Count; i++)
                {
                    var ses = helper.GetSessionListForAcademicYear(aca[i].Id);
                    aca[i].SchoolId = ses.Count;

                }
                GridView1.DataSource = aca;
                GridView1.DataBind();

            }

        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //GridView1.Columns[1].Visible = false;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Academy/AcademicYear/Create.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Academy/Session/Create.aspx");
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //switch (e.)
            //{
                    
            //}
        }

    }
}