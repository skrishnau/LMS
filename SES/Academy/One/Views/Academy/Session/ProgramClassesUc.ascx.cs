using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Academy.Session
{
    public partial class ProgramClassesUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadData(
            IGrouping<Academic.DbEntities.Structure.Program,
                       Academic.DbEntities.AcacemicPlacements.RunningClass> program
            , int teacherRoleId, string noticeText)
        {
            lnkProgramName.Text = program.Key.Name;

            foreach (var rc in program)
            {
                var teacherPresent = true;
                foreach (var sub in rc.SubjectClasses)
                {
                    teacherPresent = sub.ClassUsers.Any(x =>
                        x.RoleId == teacherRoleId && !(x.Void ?? false));
                    if (teacherPresent == false)
                        break;
                }

                var rcLabel = new HyperLink()
                {
                    NavigateUrl = "~/Views/Academy/RunningClassForm.aspx?rcId=" + rc.Id,
                    CssClass = "list-group-item",
                };
                var label = new Label()
                {
                    Text = " &nbsp;&nbsp;▪ " + rc.ProgramBatch.Batch.Name + " -- " +
                           rc.Year.Name + " " + (rc.SubYear == null ? "" : rc.SubYear.Name),
                    //CssClass = "link",
                };
                var teacherInfoLabel = new Label()
                {
                    Text = (teacherPresent ? "" : noticeText) + "<br/>",
                };
                rcLabel.Controls.Add(label);
                rcLabel.Controls.Add(teacherInfoLabel);

                pnlListing.Controls.Add(rcLabel);
            }
            pnlListing.Controls.Add(new Literal() { Text = "<br/>" });
        }
    }
}