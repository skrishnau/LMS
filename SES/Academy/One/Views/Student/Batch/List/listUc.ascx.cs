using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.Student.Batch.List
{
    public partial class listUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
            LoadBatches();
        }


        #region Properties

        public int SchoolId
        {
            get { return Convert.ToInt32(hidSchoolId.Value); }
            set { this.hidSchoolId.Value = value.ToString(); }
        }

        #endregion


        private void LoadBatches()
        {
            using (var helper = new DbHelper.Batch())
            {
                var lst = helper.GetBatchList(SchoolId, 10
                    , Convert.ToInt32(String.IsNullOrEmpty(txtPageNo.Text) ? "0" : txtPageNo.Text));
                foreach (var batch in lst)
                {
                    ItemUc itemUc = (ItemUc) Page.LoadControl("~/Views/Student/Batch/List/ItemUc.ascx");
                    itemUc.LoadData(batch.Id,batch.Name,batch.Description,batch.ProgramBatches.Count,batch.ClassCommenceDate);
                    pnlItems.Controls.Add(itemUc);
                }
            }
        }
    }
}