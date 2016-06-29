using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.Structure;
using Academic.DbHelper;
using One.Views.AcademicPlacement.StudentClass;

namespace One.Views.Student.Batch.AddProgramsTreeNodes
{
    public partial class TreeViewUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //_forceCheck = false;
            if (!IsPostBack)
            {
                //ViewState["StudentClassList"] = new List<Academic.DbEntities.AcacemicPlacements.StudentClass>();
            }

            //LoadTree();
            
        }

        
        #region Properties

        public int BatchId
        {
            get { return Convert.ToInt32(hidBatchId.Value); }
            set { this.hidBatchId.Value = value.ToString(); }
        }

        public int SchoolId
        {
            get { return Convert.ToInt32(hidSchoolId.Value); }
            set { this.hidSchoolId.Value = value.ToString(); }
        }

        public TreeNodeUC RootNode
        {
            get { return this.Root; }
        }

        public List<TreeNodeUC> CheckedNodes {
            get
            {
                GetCheckedNodes(Root);
                return _checkedList;
            }
        }
        
        #endregion
        

        #region Load Functions

      /*  private void LoadTree()
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

                Root.Text = batch.Name;
                Root.Level = 0;

                for (var lev = 0; lev < levels.Count(); lev++) //in levels
                {
                    TreeNodeUC leveluc =
                        (TreeNodeUC)
                            Page.LoadControl("~/Views/Student/Batch/AddProgramsTreeNodes/TreeNodeUC.ascx");

                    leveluc.SetParameters(levels.ElementAt(lev).Name, levels.ElementAt(lev).Id.ToString(), lev, levels.Count);
                    Root.AddNode(leveluc);

                    List<Academic.DbEntities.Structure.Faculty> faculties = levels[lev].Faculty.ToList();
                    for (int fac = 0; fac < faculties.Count(); fac++)
                    {
                        //.Where(x => x.FacultyId == faculties[fac].Id).Distinct().ToList();
                        TreeNodeUC facuc =
                            (TreeNodeUC)Page
                                .LoadControl("~/Views/Student/Batch/AddProgramsTreeNodes/TreeNodeUC.ascx");

                        facuc.SetParameters(faculties[fac].Name, faculties[fac].Id.ToString(), fac, faculties.Count());
                        //facuc.StudentsButtonClick += proguc_StudentsButtonClick;
                        leveluc.AddNode(facuc);

                        var programs = faculties[fac].Programs.ToList();
                        for (var pro = 0; pro < programs.Count(); pro++)
                        {
                            TreeNodeUC proguc =
                                (TreeNodeUC)Page
                                    .LoadControl("~/Views/Student/Batch/AddProgramsTreeNodes/TreeNodeUC.ascx");
                            proguc.SetParameters(programs[pro].Name, programs[pro].Id.ToString(), pro, programs.Count);
                            //proguc.StudentsButtonClick += proguc_StudentsButtonClick;
                            facuc.AddNode(proguc);
                        }
                    }
                }
            }
        }*/

        //void proguc_StudentsButtonClick(object sender, Values.ProgramBatchEventArgs e)
        //{
        //    //pnlStudentEntry.Visible = true;

        //}

        #endregion

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

        public List<TreeNodeUC> LeafNodes
        {
            get
            {
                GetLeafNodes(Root);
                return _leafNodeList;
            }
        }

        List<TreeNodeUC> _leafNodeList = new List<TreeNodeUC>();
        void GetLeafNodes(TreeNodeUC node)
        {
            if (node.IsLeafNode)
            {
                _leafNodeList.Add(node);
            }
            if (node.ChildNodes != null)
                foreach (TreeNodeUC child in node.ChildNodes)
                {
                    //child.Checked = node.Checked;
                    GetLeafNodes(child);
                }
        }
        //public bool AddOrUpdateRunningClasses(ref TreeNodeUC tree, int academicYearId, int sessionId = 0)
        //{
        //    try
        //    {
        //        List<Academic.DbEntities.AcacemicPlacements.RunningClass> classes = new List<Academic.DbEntities.AcacemicPlacements.RunningClass>();

        //        foreach (var level in tree.ChildNodes)
        //        {
        //            foreach (var fac in level.ChildNodes)
        //            {
        //                foreach (var prog in fac.ChildNodes)
        //                {
        //                    foreach (var year in prog.ChildNodes)
        //                    {
        //                        if (year.Type == "year")//&& year.Checked
        //                        {
        //                            if (year.ChildNodes.Count == 0)
        //                            {
        //                                var cls = new Academic.DbEntities.AcacemicPlacements.RunningClass()
        //                                {
        //                                    Id = year.RunningClassId
        //                                    ,
        //                                    AcademicYearId = academicYearId
        //                                    ,
        //                                    YearId = Convert.ToInt32(year.Value)
        //                                    ,
        //                                    Void = !year.Checked
        //                                };
        //                                if (sessionId > 0)
        //                                    cls.SessionId = sessionId;
        //                                classes.Add(cls);
        //                            }
        //                        }
        //                        foreach (var subyear in year.ChildNodes)
        //                        {
        //                            if (subyear.Type == "subyear")//&& subyear.Checked
        //                            {
        //                                var cls = new Academic.DbEntities.AcacemicPlacements.RunningClass()
        //                                {
        //                                    Id = subyear.RunningClassId
        //                                    ,
        //                                    AcademicYearId = academicYearId
        //                                    ,
        //                                    SubYearId = Convert.ToInt32(subyear.Value)
        //                                    ,
        //                                    YearId = subyear.YearId
        //                                    ,
        //                                    Void = !subyear.Checked
        //                                };
        //                                if (sessionId > 0)
        //                                    cls.SessionId = sessionId;
        //                                classes.Add(cls);
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }

               
        //        using (var helper = new DbHelper.AcademicPlacement())
        //        {
        //            var saved = helper.AddClassesToAcademicYear(classes);
        //            return saved;
        //        }

        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

       
    }
}