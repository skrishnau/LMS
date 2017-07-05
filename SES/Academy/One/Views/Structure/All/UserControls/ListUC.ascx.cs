using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.Structure.All.UserControls
{
    public partial class ListUC : System.Web.UI.UserControl
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



        public void SetName(int id, string name, string editUrl, bool edit=false, string addUrl="",string addText="", bool expand = false)
        {
            this.hidStructureId.Value = id.ToString();
            this.lblName.Text = "♦" + name;
            lnkEdit.Visible = edit;
            lnkDelete.Visible = edit;
            lnkAdd.Visible = edit;
            if (edit)
            {
                lnkEdit.NavigateUrl = editUrl;
                lnkAdd.NavigateUrl = addUrl;
                lblAddText.Text = addText;
                lnkAdd.ToolTip = addText + " in " + name.Replace("♦", "").Replace("●", "");
               
                var redUrl = "~/Views/All_Resusable_Codes/Delete/DeleteForm.aspx?task=" +
                                                  DbHelper.StaticValues.Encode("structure") +
                                                  "&progId=" + id
                                                  + "&showText="
                                                  + DbHelper.StaticValues.Encode("Are you sure to delete the program, "
                                                  + name + "?")
                                                  ;
                lnkDelete.NavigateUrl = redUrl;
            }
            pnlSubControls.Visible = expand;
        }

        protected void lnkName_OnClick(object sender, EventArgs e)
        {
            pnlSubControls.Visible = !pnlSubControls.Visible;
            if (pnlSubControls.Visible)
            {
                imgShowHide.ImageUrl = "~/Content/Icons/Arrow/down-arrow.png";
            }
            else
            {
                imgShowHide.ImageUrl = "~/Content/Icons/Arrow/right-arrow.png";
            }
        }
    }
}