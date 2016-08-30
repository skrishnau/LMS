using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace One.Views.Academy.UserControls
{
    public partial class AcademicYearListUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadAcademicYear(int academicYearId, string name, DateTime startDate
            , DateTime endDate, bool active, List<Academic.DbEntities.Session> sessionList)
        {
            lnkAcademicYearName.Text = name;
            lnkAcademicYearName.NavigateUrl = "~/Views/Academy/AcademicYear/AcademicYearDetail.aspx?aId=" + academicYearId;
            lblEndDate.Text = endDate.ToShortDateString();
            lblStartDate.Text = startDate.ToShortDateString();
            if (active)
                pnlBody.BackColor = Color.LightGreen;

            if (!sessionList.Any())
            {
                //lblTitleInSessionsList.Text = "Sessions:";
                pnlSessionsList.Controls.Add(new Literal() { Text = "None" });

            }
            else
            {
                foreach (var sess in sessionList)
                {
                    var hypSes = new HyperLink()
                    {
                        Text = sess.Name
                        ,
                        NavigateUrl = "~/Views/Academy/Session/SessionDetail.aspx?sId=" + sess.Id
                        ,
                    };
                    if (active && sess.IsActive)
                    {
                        hypSes.BackColor = Color.LightGreen;
                    }
                    //hypSes.Attributes.Add("margin","2px 0");
                    pnlSessionsList.Controls.Add(hypSes);
                    pnlSessionsList.Controls.Add(new Literal() { Text = "<br />" });
                    //pnlSessionsList.Controls.Add(new HtmlGenericControl("br"));
                }
            }
        }
    }
}