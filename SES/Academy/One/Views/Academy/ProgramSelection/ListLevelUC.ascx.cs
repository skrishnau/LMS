using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Academy.ProgramSelection
{
    public partial class ListLevelUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void AddControl(ListFacultyUC uc)
        {
            this.pnlSubControls.Controls.Add(uc);
        }

        public void AddControl(UserControl uc)
        {
            this.pnlSubControls.Controls.Add(uc);
        }

        public void SetName(int id, string name, string url)
        {
            this.hidStructureId.Value = id.ToString();
            this.lblName.Text = name;
            this.lblName.NavigateUrl = url;
        }

        public List<ListFacultyUC> GetControls()
        {
            var list = new List<ListFacultyUC>();
            foreach (ListFacultyUC uc in pnlSubControls.Controls)
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