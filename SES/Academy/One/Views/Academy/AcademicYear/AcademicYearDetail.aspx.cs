using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.Academy.AcademicYear
{
    public partial class AcademicYearDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var aId = Request.QueryString["aId"];
                if (aId != null)
                {
                    try
                    {
                        hidAcademicYear.Value = aId;

                    }catch{Response.Redirect("../List.aspx");}
                }
            }
        }

        public int AcademicYearId
        {
            get { return Convert.ToInt32(hidAcademicYear.Value); }
            set { hidAcademicYear.Value = value.ToString(); }
        }


        public void LoadData()
        {
            using (var helper = new DbHelper.AcademicYear())
            {
                var academic = helper.GetAcademicYear(AcademicYearId);
                if (academic != null)
                {
                    lblEndDate.Text = academic.EndDate.ToShortDateString();
                    lblStartDate.Text = academic.StartDate.ToShortDateString();

                    foreach (var source in academic.Sessions.ToList())
                    {
                        //var sessUc = (Academy.UserControls.SessionsListingInAYDetailUC)
                        //    Page.LoadControl
                    }

                }
            }
        }

        protected void btnActivate_Click(object sender, EventArgs e)
        {

        }
    }
}