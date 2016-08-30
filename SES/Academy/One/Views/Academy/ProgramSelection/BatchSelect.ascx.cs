using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel.Batch;
using One.Values;
using One.Values.MemberShip;

namespace One.Views.Academy.ProgramSelection
{
    public partial class BatchSelect : System.Web.UI.UserControl
    {
        public event EventHandler<EventArgs> DoneClicked;
        public event EventHandler<ProgramBatchEventArgs> BatchSelected;

        protected void Page_Load(object sender, EventArgs e)
        {


        }

        public void LoadBatches(int programId, int academicYearId, int sessionId = 0,
            int programBatchId = 0)
        {
            ProgramId = programId;
            SelectedProgramBatchId = programBatchId;

            var user = Page.User as CustomPrincipal;
            if (user != null)
            {
                var path = Request.Path;
                var alreadySelected = Session["AlreadySelectedProgramBatches"] as Dictionary<int, List<int>>;
                if (alreadySelected == null)
                {
                    //var path = Request.Path;
                    Response.Redirect(path, true);
                }
                else
                {
                    using (var batchhelper = new DbHelper.Batch())
                    //using (var acaPlcelper = new DbHelper.AcademicPlacement())
                    //using (var acahelper = new DbHelper.AcademicYear())
                    //using (var stdHelper = new DbHelper.Student())
                    {
                        //var batchForTheProgram = batchhelper.ListUnAssignedBatches(programId, academicYearId, sessionId);
                        //var batch = batchhelper.GetBatchList(user.SchoolId);

                        var batch = batchhelper.ListUnAssignedBatches(programId, academicYearId, sessionId);
                        
                        //1. get list of programbatches for the given programId
                        var find = alreadySelected[programId];
                        //2. Remove the programBatchId which is already selected by the same Program's subcategory
                        //this is done to avoid removal of selected programbatch from list
                        find.Remove(programBatchId);
                        //3. for each already selected programbatch remove them from the main batch list
                        // this is done to remove the batches that are already assigned
                        find.ForEach(f =>
                        {
                            batch.Remove(batch.Find(x => x.ProgramBatchId == f));
                        });
                        //4. find the index of the batch that need to be selected in default
                        var index = batch.FindIndex(x => x.ProgramBatchId == programBatchId);

                        batch.Insert(0, new BatchViewModel()
                        {
                            ProgramBatchId = 0,
                            ProgramBatchName = "None"
                        });

                        DataList1.SelectedIndex = (index >= 0) ? index + 1 : index;

                        DataList1.DataSource = batch;
                        DataList1.DataBind();
                    }
                }

            }

        }

        protected void btnDone_Click(object sender, EventArgs e)
        {
            if (DoneClicked != null)
            {
                DoneClicked(this, new EventArgs());
            }
        }

        public int ProgramId
        {
            get { return Convert.ToInt32(hidProgramId.Value); }
            set { this.hidProgramId.Value = value.ToString(); }
        }
        public int SelectedProgramBatchId
        {
            get { return Convert.ToInt32(hidSelectedProgramBatchId.Value); }
            set { hidSelectedProgramBatchId.Value = value.ToString(); }
        }
        //protected void lblBatchName_OnClick(object sender, EventArgs e)
        //{
        //    if (BatchSelected != null)
        //    {
        //        BatchSelected(this,new BatchEventArgs()
        //        {
        //            BatchId = 
        //        });
        //    }
        //}

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var index = DataList1.SelectedIndex;
            //var va = DataList1.SelectedValue;
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            try
            {
                var alreadySelected = Session["AlreadySelectedProgramBatches"] as Dictionary<int, List<int>>;
                if (alreadySelected == null)
                {
                    var path = Request.Path;
                    Response.Redirect(path, true);
                }
                else
                {
                    if (e.CommandName == "Select")
                    {
                        if (BatchSelected != null)
                        {
                            //here programbatchId and programBatchName are received as CommandArgument
                            //and they are separated by comma(,)
                            var argument = e.CommandArgument.ToString().Split(new char[] { ',' });
                            var pbId = Convert.ToInt32(argument[0]);
                            alreadySelected[ProgramId].Remove(SelectedProgramBatchId);
                            alreadySelected[ProgramId].Add(pbId);
                            BatchSelected(this, new ProgramBatchEventArgs()
                            {
                                //BatchId = Convert.ToInt32(e.CommandArgument)
                                ProgramBatchId = pbId
                                ,
                                ProgramBatchName = argument[1]
                            });
                        }
                    }
                }

            }
            catch
            {
            }

            //var command = e.CommandArgument;
            //var s = e.CommandName;
            //var m = e.Item;
            //var ss = e.CommandSource;
            //var ms = e.ToString();
        }
    }
}