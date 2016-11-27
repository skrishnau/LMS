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

namespace One.Views.Structure.All.UserControls.StructureView
{
    public partial class TreeViewWithCheckBoxInLeft : System.Web.UI.UserControl
    {

        //public event EventHandler<BatchEventArgs> CheckChanged;
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Page.User as CustomPrincipal;
            //if (user != null)
            //{
            //    LoadStructure(user.SchoolId);
            //}
        }

        public int BatchId
        {
            get { return Convert.ToInt32(hidBatchId.Value); }
            set { hidBatchId.Value = value.ToString(); }
        }


        //  // Note :: ├ ==>1 ,    └ ==> 2 .   ┌ ==> 3 ,   │ ==> 4 ,  empty ==> 0
        public void LoadStructure(int schoolId, List<Academic.ViewModel.Batch.BatchViewModel> progList)
        {
            if (progList != null)
                using (var batchHelper = new DbHelper.Batch())
                using (var helper = new DbHelper.Structure())
                {
                    var progBatchList = batchHelper.GetProgramBatchList(BatchId);

                    var programs = helper.ListPrograms(schoolId);
                    var ip = 1;
                    programs.ForEach(p =>
                    {
                        var puc =
                            (LabelAndCheckBoxUC)
                                Page.LoadControl(
                                    "~/Views/Structure/All/UserControls/StructureView/LabelAndCheckBoxUC.ascx");

                        var pbId = 0;
                        if (progBatchList != null)
                        {
                            var saved = progBatchList.FirstOrDefault(x => x.ProgramId == p.Id);
                            if (saved != null)
                            {
                                pbId = saved.Id;
                                progList.Add(new BatchViewModel()
                                {
                                    ProgramBatchId = saved.Id
                                    ,
                                    ProgramId = saved.ProgramId
                                    ,
                                    Check = true
                                });
                                puc.Check = true;
                            }
                        }

                        puc.SetName( p.Id, p.Name, pbId);
                        //puc.CheckedChange += puc_CheckedChange;
                        pnlTree.Controls.Add(puc);
                        ip++;
                    });
                }
        }

        //void puc_CheckedChange(object sender, BatchEventArgs e)
        //{
        //    if (CheckChanged != null)
        //    {
        //        CheckChanged(this, e);
        //    }
        //}

    }
}