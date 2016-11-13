using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;

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
            var user = Page.User as CustomPrincipal;
            if (user != null)
            //if (user.SchoolId > 0)
            {
                if (user.IsInRole("manager"))
                {
                    lnkAdd.Visible = true;
                    btnAutoUpdate.Visible = true;
                }
                else
                {
                    lnkAdd.Visible = false;
                    btnAutoUpdate.Visible = false;
                }

                if (lnkAdd.Visible || user.IsInRole("teacher"))
                    using (var helper = new DbHelper.AcademicYear())
                    {
                        var aca = helper.GetAcademicYearListForSchool(
                            user.SchoolId);
                        //for (var i = 0; i < aca.Count; i++)
                        //{
                        //    var ses = helper.GetSessionListForAcademicYear(aca[i].Id);
                        //    aca[i].SchoolId = ses.Count;

                        //}
                        //GridView1.DataSource = aca;
                        //GridView1.DataBind();

                        foreach (var ay in aca)
                        {
                            var uc =
                                (UserControls.AcademicYearListUC)
                                    Page.LoadControl("~/Views/Academy/UserControls/AcademicYearListUC.ascx");
                            uc.LoadAcademicYear(
                                ay.Id, ay.Name, ay.StartDate, ay.EndDate
                                , ay.IsActive, ay.Sessions.ToList(), ay.Completed ?? false);
                            pnlAcademicYearListing.Controls.Add(uc);
                        }

                    }
            }

        }

        public string GetDatePartOnly(object date)
        {
            if (date != null)
            {
                return Convert.ToDateTime(date.ToString()).ToShortDateString();
            }
            return "";
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //GridView1.Columns[1].Visible = false;
        }

        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/Views/Academy/AcademicYear/Create.aspx");
        //}

        //protected void LinkButton2_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/Views/Academy/Session/Create.aspx");
        //}

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //switch (e.)
            //{

            //}
        }

        protected void btnAutoUpdate_Click(object sender, EventArgs e)
        {
            //using (var helper = new DbHelper.AcademicYear())
            //{
            //    //helper.AutoUpdateAcademicYear();
            //}
        }

    }
}