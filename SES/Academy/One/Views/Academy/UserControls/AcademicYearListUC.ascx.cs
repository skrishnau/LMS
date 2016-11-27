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
            , DateTime endDate, bool active, List<Academic.DbEntities.Session> sessionList
            , bool complete)
        {
            lnkAcademicYearName.Text = " " + name + " ";
            lnkAcademicYearName.NavigateUrl = "~/Views/Academy/AcademicYear/AcademicYearDetail.aspx?aId=" + academicYearId;
            lblEndDate.Text = endDate.ToShortDateString();
            lblStartDate.Text = startDate.ToShortDateString();
            if (complete)
            {
                lblActiveIndicator.Text = " (Complete)";
                lblActiveIndicator.ForeColor = Color.DarkGray;
                divBody.Style.Add("border-left", "10px solid lightgrey");

                //pnlBody.BackColor = //Color.LightGray;
                //        Color.FromArgb(225, 225, 225);
            }
            else if (active)
            {

                //pnlBody.BackColor = Color.LightGreen;
                lblActiveIndicator.Text = " (Active)";
                lblActiveIndicator.ForeColor = Color.Green;
                divBody.Style.Add("border-left", "10px solid green");
                //pnlBody.BackColor = //Color.LightGreen;
                //                        Color.FromArgb(193, 252, 193);
                //Color.FromArgb(208, 255, 208);
                //lblActiveIndicator.ForeColor = Color.Green;
                //lnkAcademicYearName.BackColor = Color.LightGreen;
            }

            if (!sessionList.Any())
            {
                //lblTitleInSessionsList.Text = "Sessions:";
                lblTitleInSessionsList.Text = "None";
                //pnlSessionsList.Controls.Add(new Label() { Text = "None" , ForeColor = Color.DarkSlateGray});

            }
            else
            {
                foreach (var sess in sessionList)
                {
                    var hypSes = new HyperLink()
                    {
                        Text = sess.Name
                        ,
                        //NavigateUrl = "~/Views/Academy/Session/SessionDetail.aspx?sId=" + sess.Id
                        //,
                    };
                    pnlSessionsList.Controls.Add(hypSes);
                    if (active && sess.IsActive)
                    {
                        //hypSes.BackColor = Color.LightGreen;
                        var activeIndicator = new Label() { Text = " (Active)", ForeColor = Color.Green };
                        pnlSessionsList.Controls.Add(activeIndicator);
                    }
                    //hypSes.Attributes.Add("margin","2px 0");
                    pnlSessionsList.Controls.Add(new Literal() { Text = "<br />" });
                    //pnlSessionsList.Controls.Add(new HtmlGenericControl("br"));
                }
            }
        }
    }
}