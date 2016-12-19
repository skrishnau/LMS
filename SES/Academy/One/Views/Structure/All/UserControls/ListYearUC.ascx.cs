using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.Structure.All.UserControls
{
    public partial class ListYearUC : System.Web.UI.UserControl
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

        public void AddControl(Control c)
        {
            pnlSubControls.Controls.Add(c);
        }

        public void SetName(int id, string name, string editUrl, bool edit=false, string addUrl = "", string addText="")
        {
            hidStructureId.Value = id.ToString();
            lblName.Text = "●" + name;
            lnkEdit.Visible = edit;
            lnkAdd.Visible = edit;
            lnkDelete.Visible = edit;

            if (edit)
            {
                lnkEdit.NavigateUrl = editUrl;
                lnkAdd.NavigateUrl = addUrl;
                lblAddText.Text = addText;
                lnkAdd.ToolTip = addText + " in " + name.Replace("♦", "").Replace("●", "");

                var redUrl = "~/Views/All_Resusable_Codes/Delete/DeleteForm.aspx?task=" +
                                               DbHelper.StaticValues.Encode("structure") +
                                               "&progId=0"
                                               + "&yeaId=" + id
                                               + "&showText="
                                               + DbHelper.StaticValues.Encode("Are you sure to delete the year, "
                                               + name + "?")
                                               ;
                lnkDelete.NavigateUrl = redUrl;
            }
        }
    }
}