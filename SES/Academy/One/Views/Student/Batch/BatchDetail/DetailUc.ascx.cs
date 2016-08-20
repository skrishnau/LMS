using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.Student.Batch.BatchDetail
{
    public partial class DetailUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lnkEdit.NavigateUrl = "~/Views/Student/Batch/Create/BatchCreate.aspx?Id=" + BatchId;
            }
            LoadData();
        }

        #region Properties

        public int BatchId
        {
            get { return Convert.ToInt32(hidBatchId.Value); }
            set { hidBatchId.Value = value.ToString(); }
        }

        #endregion

        //protected void lnkAddPrograms_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/Views/Student/Batch/BatchDetail/AddPrograms.aspx"+"?Id="+BatchId);
        //}

        public void LoadData()
        {
            //BatchId = Convert.ToInt32(id);
            using (var helper = new DbHelper.Batch())
            {
                var batch = helper.GetBatch(BatchId);
                if (batch != null)
                {
                    lblBatchName.Text = batch.Name;
                    lblSummary.Text = batch.Description;

                }
                var programs = helper.GetProgramBatchList(BatchId);
                foreach (var prog in programs)
                {
                    DetailItemUc item = (DetailItemUc)Page.LoadControl("~/Views/Student/Batch/BatchDetail/DetailItemUc.ascx");
                    item.LoadData(prog.Id, prog.BatchId, prog.NameFromBatch, prog.ProgramId
                        , prog.Program.Name, prog.StartedStudying, prog.StudyCompleted, prog.Void);
                    if (prog.CurrentYear != null)
                    {
                        item.CurrentYear = prog.CurrentYear.Name;
                    }
                    if (prog.CurrentSubYear != null)
                    {
                        item.CurrentSubYear = prog.CurrentSubYear.Name;
                    }

                    item.Enabled = !(prog.Void ?? false);
                    pnlProgramsInTheBatch.Controls.Add(item);
                }
            }
        }

      

    
    }
}