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
                TreeViewWithCheckBoxInLeft.CheckChanged += TreeViewWithCheckBoxInLeft_CheckChanged;
            }
        }

        void TreeViewWithCheckBoxInLeft_CheckChanged(object sender, Values.BatchEventArgs e)
        {

            var progList = ViewState["SelectedProgramBatchList"] as List<Academic.ViewModel.Batch.BatchViewModel>;
            if (progList != null)
            {
                if (e.ProgramBatchId > 0)
                {
                    //proggrambatchId exists,,, so it was previously saved in database and we have to void it
                    //entry is marked only on the check property .. we should not remove the data from viewstate
                    var found = progList.Find(x => x.ProgramId == e.ProgramId && x.ProgramBatchId == e.ProgramBatchId);
                    if (found != null)
                    {
                        found.Check = e.Checked;
                    }
                }
                else
                {
                    //else new entry or just check uncheck only.
                    if (e.Checked)
                    {
                        progList.Add(new BatchViewModel()
                        {
                            Check = true
                            ,
                            ProgramId = e.ProgramId
                            ,
                            ProgramBatchId = e.ProgramBatchId
                        });
                    }
                    else
                    {
                        var found = progList.Find(x => x.ProgramId == e.ProgramId);
                        if (found != null)
                        {
                            progList.Remove(found);
                        }
                    }
                }
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
            Response.Redirect("~/Views/Student/Batch/ListBatch.aspx");           
        }


        private void SaveBatch()
        {
            if (SchoolId > 0)
            {
                var progList = ViewState["SelectedProgramBatchList"] as List<Academic.ViewModel.Batch.BatchViewModel>;
                if (progList != null)
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

                        var saved = helper.AddOrUpdateBatch(batch, progList);
                        if (saved != null)
                        {
                            Response.Redirect("~/Views/Student/Batch/ListBatch.aspx");
                        }
                    }
            }
        }

        //private void SaveBatchPrograms(int batchId)
        //{
        //    //var root = TreeViewUC.LeafNodes.Where(x => x.Type == "Program" && x.IsLeafNode);
        //    List<Academic.DbEntities.Batches.ProgramBatch> programBatches = new List<ProgramBatch>();
        //    foreach (var treeNodeUc in root)
        //    {
        //        if (treeNodeUc.Checked || treeNodeUc.ProgramBatchId > 0)
        //        {
        //            var pb = new ProgramBatch()
        //            {
        //                Id = treeNodeUc.ProgramBatchId
        //                ,
        //                BatchId = this.BatchId
        //                ,
        //                ProgramId = treeNodeUc.StructureId
        //                ,
        //                Void = !(treeNodeUc.Checked)
        //            };
        //            programBatches.Add(pb);
        //        }
        //    }
        //    using (var helper = new DbHelper.Batch())
        //    {
        //        var saved = helper.AddOrUpdateProgramBatch(SchoolId, programBatches);
        //        if (saved)
        //        {
        //            Response.Redirect("~/Views/Student/Batch/ListBatch.aspx");
        //        }
        //        else
        //        {
        //            lblMsg.Text = "Couldn't Save";
        //        }
        //    }
        //}


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

                    //check all the programs which are in database (saved)

                    //ShowProgramAddPanel(batch.SchoolId, batch.Id);
                }
            }
        }

        //public void ShowProgramAddPanel(int schoolId, int batchId)
        //{
        //    pnlProgramsAdd.Visible = true;
        //    AddProgramsUc.LoadData(schoolId, batchId);
        //}
    }
}