using One.Views.Student.Batch.AddProgramsTreeNodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.Batches;
using Academic.DbHelper;

namespace One.Views.Student.Batch.Create
{
    public partial class AddProgramsUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
            lblMsg.Text = "";
            TreeViewUC.SchoolId = SchoolId;
            TreeViewUC.BatchId = BatchId;

            LoadTree();
            StudentEntr.CloseClicked += StudentEntr_CloseClicked;
        }



        #region Properties

        public int BatchId
        {
            get { return Convert.ToInt32(hidBatchId.Value); }
            set { hidBatchId.Value = value.ToString(); }
        }

        public int SchoolId
        {
            get { return Convert.ToInt32(hidSchoolId.Value); }
            set { hidSchoolId.Value = value.ToString(); }
        }

        #endregion

        #region Load Functions

        private void LoadTree()
        {
            //it is the position of subyear to be displayed
            int subYearPos = -1;

            List<Academic.DbEntities.Structure.Level> levels;
            List<Academic.DbEntities.Batches.ProgramBatch> programBatches;

            using (var helper = new DbHelper.Structure())
            using (var batchHelper = new DbHelper.Batch())
            {

                levels = helper.GetLevelsWithAllIncluded(SchoolId);
                programBatches = batchHelper.GetProgramBatchList(BatchId);
                var batch = batchHelper.GetBatch(BatchId);

                TreeViewUC.RootNode.Text = batch.Name;
                TreeViewUC.RootNode.Level = 0;

                for (var lev = 0; lev < levels.Count(); lev++) //in levels
                {
                    TreeNodeUC leveluc =
                        (TreeNodeUC)
                            Page.LoadControl("~/Views/Student/Batch/AddProgramsTreeNodes/TreeNodeUC.ascx");

                    leveluc.SetParameters(levels.ElementAt(lev).Name, levels.ElementAt(lev).Id.ToString(), lev, levels.Count);
                    TreeViewUC.RootNode.AddNode(leveluc);

                    List<Academic.DbEntities.Structure.Faculty> faculties = levels[lev].Faculty.ToList();
                    for (int fac = 0; fac < faculties.Count(); fac++)
                    {
                        //.Where(x => x.FacultyId == faculties[fac].Id).Distinct().ToList();
                        TreeNodeUC facuc =
                            (TreeNodeUC)Page
                                .LoadControl("~/Views/Student/Batch/AddProgramsTreeNodes/TreeNodeUC.ascx");

                        facuc.SetParameters(faculties[fac].Name, faculties[fac].Id.ToString(), fac, faculties.Count());
                        leveluc.AddNode(facuc);


                        var programs = faculties[fac].Programs.ToList();
                        for (var pro = 0; pro < programs.Count(); pro++)
                        {
                            TreeNodeUC proguc =
                                (TreeNodeUC)Page
                                    .LoadControl("~/Views/Student/Batch/AddProgramsTreeNodes/TreeNodeUC.ascx");
                            proguc.SetParameters(programs[pro].Name, programs[pro].Id.ToString(), pro, programs.Count);
                            proguc.Type = "Program";
                            var prgBatch =
                                programBatches.FirstOrDefault(
                                    x => x.ProgramId == programs[pro].Id && x.BatchId == BatchId);//&& (x.Void ?? false)
                            if (prgBatch != null)
                            {
                                proguc.ProgramBatchId = prgBatch.Id;
                                proguc.Checked = !(prgBatch.Void ?? false);
                            }

                            proguc.StructureId = programs[pro].Id;
                            proguc.BatchId = BatchId;
                            proguc.StudentsButtonClick += proguc_StudentsButtonClick;
                            facuc.AddNode(proguc);

                        }
                    }
                }
            }
        }

        public void LoadData(int schoolId, int batchId)
        {
            SchoolId = schoolId;
            BatchId = batchId;
            TreeViewUC.SchoolId = SchoolId;
            TreeViewUC.BatchId = BatchId;
        }

        #endregion

        #region Student Button Events

        void proguc_StudentsButtonClick(object sender, ProgramBatchEventArgs e)
        {
            pnlStudentEntry.Visible = true;
        }
        void StudentEntr_CloseClicked(object sender, MessageEventArgs e)
        {
            pnlStudentEntry.Visible = false;
        }

        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveExamPrograms();
        }
   
        private void SaveExamPrograms()
        {
            var root = TreeViewUC.LeafNodes.Where(x => x.Type == "Program" && x.IsLeafNode);
            List<Academic.DbEntities.Batches.ProgramBatch> programBatches = new List<ProgramBatch>();
            foreach (var treeNodeUc in root)
            {
                if (treeNodeUc.Checked || treeNodeUc.ProgramBatchId > 0)
                {
                    var pb = new ProgramBatch()
                    {
                        Id = treeNodeUc.ProgramBatchId
                        ,
                        BatchId = this.BatchId
                        ,
                        ProgramId = treeNodeUc.StructureId
                        ,
                        Void = !(treeNodeUc.Checked)
                    };
                    programBatches.Add(pb);
                }
            }
            using (var helper = new DbHelper.Batch())
            {
                var saved = helper.AddOrUpdateProgramBatch(SchoolId, programBatches);
                if (saved)
                {
                    Response.Redirect("~/Views/Student/Batch/ListBatch.aspx");
                }
                else
                {
                    lblMsg.Text = "Couldn't Save";
                }
            }
        }

        List<TreeNodeUC> _checkedList = new List<TreeNodeUC>();
        void GetCheckedNodes(TreeNodeUC node)
        {
            if (node.Checked)
            {
                _checkedList.Add(node);
            }
            if (node.ChildNodes != null)
                foreach (TreeNodeUC child in node.ChildNodes)
                {
                    //child.Checked = node.Checked;
                    GetCheckedNodes(child);
                }
        }

    }
}