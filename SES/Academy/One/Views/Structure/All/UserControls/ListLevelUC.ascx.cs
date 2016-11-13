using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Structure.All.UserControls
{
    public partial class ListLevelUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void AddControl(ListUC uc)
        {
            this.pnlSubControls.Controls.Add(uc);
        }

        public void AddControl(UserControl uc)
        {
            this.pnlSubControls.Controls.Add(uc);
        }

        public void SetName(int id, string name, string editurl, bool edit = false, string addUrl ="", string addText ="")
        {
            this.hidStructureId.Value = id.ToString();
            this.lblName.Text = name;
            lnkEdit.Visible = edit;
            lnkAdd.Visible = edit;
            if (edit)
            {
                lnkEdit.NavigateUrl = editurl;
                lnkAdd.NavigateUrl = addUrl;
                lblAddText.Text = addText;
                lnkAdd.ToolTip = addText + " in " + name.Replace("♦", "").Replace("●","");
            }
        }
    }
}