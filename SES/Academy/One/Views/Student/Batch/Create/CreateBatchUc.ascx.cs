using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.Student.Batch.Create
{
    public partial class CreateBatchUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Properties

        public int SchoolId
        {
            get { return Convert.ToInt32(hidSchoolId.Value); }
            set { hidSchoolId.Value = value.ToString(); }
        }

        public int BatchId
        {
            get { return Convert.ToInt32(hidBatchId.Value); }
            set
            {
                hidBatchId.Value = value.ToString();
            }
        }

        #endregion


        protected void btnSaveAndReturnToList_Click(object sender, EventArgs e)
        {
            SaveBatch(1);
        }

        protected void btnSaveAndAddProgramsToThisBatch_Click(object sender, EventArgs e)
        {
            SaveBatch(2);
        }


        private void SaveBatch(int value)
        {
            if (SchoolId > 0)
            {
                using (var helper = new DbHelper.Batch())
                {
                    var batch = new Academic.DbEntities.Batches.Batch()
                    {
                        Id = BatchId,

                        Name = txtName.Text
                        ,
                        Description = txtDescription.Text
                        ,
                        SchoolId = SchoolId
                        ,
                        CreatedDate = DateTime.Now
                    };
                    if (txtCommenceDate.Text != "")
                    {
                        batch.ClassCommenceDate = Convert.ToDateTime(Convert.ToDateTime(txtCommenceDate.Text).ToLongDateString());
                    }
                    var saved = helper.AddOrUpdateBatch(batch);
                    if (saved != null)
                    {
                        if (value == 1)
                        {
                            Response.Redirect("~/Views/Student/Batch/ListBatch.aspx");
                        }
                        else if (value == 2)
                        {
                            ShowProgramAddPanel(saved.SchoolId, saved.Id);
                        }
                    }
                }
            }
        }


        public void SetDatasForEdit(int batchId)
        {
            using (var helper = new DbHelper.Batch())
            {
                var batch = helper.GetBatch(batchId);
                if (batch != null)
                {
                    BatchId = batch.Id;
                    txtName.Text = batch.Name;
                    txtDescription.Text = batch.Description;
                    txtCommenceDate.Text = batch.ClassCommenceDate == null ? "" : batch.ClassCommenceDate.Value.ToShortDateString();

                    ShowProgramAddPanel(batch.SchoolId, batch.Id);
                }
            }
        }

        public void ShowProgramAddPanel(int schoolId, int batchId)
        {
            pnlProgramsAdd.Visible = true;
            AddProgramsUc.LoadData(schoolId, batchId);
        }
    }
}