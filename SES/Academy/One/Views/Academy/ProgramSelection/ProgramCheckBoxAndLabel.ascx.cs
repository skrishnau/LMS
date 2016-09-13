using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using One.Views.Structure.All.UserControls;

namespace One.Views.Academy.ProgramSelection
{
    public partial class ProgramCheckBoxAndLabel : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetName(int id, string name, string url = "")
        {
            hidId.Value = id.ToString();
            chkBox.Text = name;
        }

        protected void chkBox_CheckedChanged(object sender, EventArgs e)
        {
            //var cntrl = pnlSubControls.FindControl("yearControl"+hidId.Value+chkBox.Text)
            //    as ProgramCheckBoxAndLabel;
            var cntrls = pnlSubControls.Controls;
            foreach (YearCheckBoxAndLabel ycb in pnlSubControls.Controls)
            {
                ycb.Check(chkBox.Checked);
            }

            //if (cntrl != null)
            //{
                
            //}
        }

        public void AddControl(ListUC uc)
        {
            this.pnlSubControls.Controls.Add(uc);
        }

        public void AddControl(ProgramCheckBoxAndLabel uc)
        {
            this.pnlSubControls.Controls.Add(uc);
        }

        public void AddControl(UserControl uc)
        {
            this.pnlSubControls.Controls.Add(uc);
        }
        ////YearCheckBoxAndLabel



        public List<YearCheckBoxAndLabel> GetControls()
        {
            var list = new List<YearCheckBoxAndLabel>();
            foreach (YearCheckBoxAndLabel uc in pnlSubControls.Controls)
            {
                list.Add(uc);
            }
            return list;
        }

         public List<OnlyListing.ProgramUC> GetControlsForListing()
        {
            var list = new List<OnlyListing.ProgramUC>();
            foreach (OnlyListing.ProgramUC uc in pnlSubControls.Controls)
            {
                list.Add(uc);
            }
            return list;
        }


        public Control FindCustomControl(string id)
        {
            return pnlSubControls.FindControl(id);
        }
    }
}