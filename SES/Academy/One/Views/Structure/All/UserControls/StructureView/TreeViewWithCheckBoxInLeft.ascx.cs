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

        public event EventHandler<BatchEventArgs> CheckChanged;
        protected void Page_Load(object sender, EventArgs e)
        {
            //var user = Page.User as CustomPrincipal;
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
       public  void LoadStructure(int schoolId, List<Academic.ViewModel.Batch.BatchViewModel> progList)
        {
            //var progList = ViewState["SelectedProgramBatchList"] as List<Academic.ViewModel.Batch.BatchViewModel>;
            if (progList != null)
                using (var batchHelper = new DbHelper.Batch())
                using (var helper = new DbHelper.Structure())
                {
                    var progBatchList = batchHelper.GetProgramBatchList(BatchId);

                    var levels = helper.GetLevels(schoolId);
                    var il = 1;
                    levels.ForEach(l =>
                    {
                        var luc = (LabelOnly)Page.LoadControl("~/Views/Structure/All/UserControls/StructureView/LabelOnly.ascx");

                        //====================== calc =================
                        var levImg = 3;
                        if (il != 1)
                        {
                            if (levels.Count > il)
                            {
                                levImg = 1;
                            }
                            else
                            {
                                levImg = 2;
                            }
                        }
                        //================================================
                        luc.SetName("level", l.Id, l.Name, 1, new List<int>() { levImg });
                        pnlTree.Controls.Add(luc);


                        var faculties = helper.GetFaculties(l.Id);

                        var iff = 1;
                        faculties.ForEach(f =>
                        {
                            var fuc = (LabelOnly)Page.LoadControl("~/Views/Structure/All/UserControls/StructureView/LabelOnly.ascx");

                            //========================= calc =========================//
                            var flist = new List<int>();
                            if (levImg == 1 || levImg == 3)
                            {
                                flist.Add(4);
                            }
                            else
                            {
                                flist.Add(0);
                            }

                            int facImg = 2;
                            if (faculties.Count > iff)
                            {
                                facImg = 1;
                                flist.Add(facImg);
                            }
                            else
                            {
                                flist.Add(facImg);
                            }
                            //=======================================================//

                            fuc.SetName("level", f.Id, f.Name, 2, flist);
                            pnlTree.Controls.Add(fuc);

                            var programs = helper.GetPrograms(f.Id);
                            var ip = 1;
                            programs.ForEach(p =>
                            {
                                var puc =
                                    (LabelAndCheckBoxUC)
                                        Page.LoadControl(
                                            "~/Views/Structure/All/UserControls/StructureView/LabelAndCheckBoxUC.ascx");
                                //===================== calc ==========================//
                                var plist = new List<int>();
                                if (levImg == 1 || levImg == 3)
                                {
                                    plist.Add(4);
                                }
                                else
                                {
                                    plist.Add(0);
                                }

                                if (facImg == 1)
                                {
                                    plist.Add(4);
                                }
                                else
                                {
                                    plist.Add(0);
                                }

                                int proImg = 2;
                                if (programs.Count > ip)
                                {
                                    proImg = 1;
                                    plist.Add(proImg);
                                }
                                else
                                {
                                    plist.Add(proImg);
                                }

                                //======================================================//
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

                                puc.SetName("program", p.Id, p.Name, pbId, plist, 3);
                                puc.CheckedChange += puc_CheckedChange;
                                pnlTree.Controls.Add(puc);
                                ip++;
                            });
                            iff++;
                        });
                        il++;
                    });
                }
        }

        void puc_CheckedChange(object sender, BatchEventArgs e)
        {
            if (CheckChanged != null)
            {
                CheckChanged(this, e);
            }
        }

    }
}