using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.Batches;
using Academic.DbHelper;
using Academic.ViewModel.Batch;
using One.Values.MemberShip;

namespace One.Views.Student.Batch.Create
{
    public partial class CreateBatchUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;

            var user = Page.User as CustomPrincipal;
            var list = new List<Academic.ViewModel.Batch.BatchViewModel>();
            if (user != null)
            {
                if (!IsPostBack)
                {

                    TreeViewWithCheckBoxInLeft.BatchId = BatchId;
                    ViewState["SelectedProgramBatchList"] = list;
                }
                TreeViewWithCheckBoxInLeft.LoadStructure(user.SchoolId, list);
                //TreeViewWithCheckBoxInLeft.CheckChanged += TreeViewWithCheckBoxInLeft_CheckChanged;
            }
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
            SaveBatch();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Student/Batch/");
        }


        private void SaveBatch()
        {
            if (SchoolId > 0)
            {
                //var progList = ViewState["SelectedProgramBatchList"] as List<Academic.ViewModel.Batch.BatchViewModel>;
                
                //var progList = 
                //if (progList != null)
                //    using (var helper = new DbHelper.Batch())
                //    {
                //        var batch = new Academic.DbEntities.Batches.Batch()
                //        {
                //            Id = BatchId,

                //            Name = txtName.Text
                //            ,
                //            Description = txtDescription.Text
                //            ,
                //            SchoolId = SchoolId
                //            ,
                //            CreatedDate = DateTime.Now
                //        };

                //        if (txtCommenceDate.Text != "")
                //        {
                //            batch.ClassCommenceDate = Convert.ToDateTime(Convert.ToDateTime(txtCommenceDate.Text).ToLongDateString());
                //        }

                //        var saved = helper.AddOrUpdateBatch(batch, progList);
                //        if (saved != null)
                //        {
                //            Response.Redirect("~/Views/Student/");
                //        }
                //        else
                //        {
                //            lblError.Visible = true;
                //        }
                //    }
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
                }
            }
        }


    }
}