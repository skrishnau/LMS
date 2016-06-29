using Academic.DbHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.ViewModel.AcademicPlacement;

namespace One.Views.UserControls.Structure.TreeViewOverriden
{
    public partial class TreeViewUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //using (var helper = new Academic.DbHelper.DbHelper.AcademicPlacement())
                {
                    var list = GetClassStructureInTreeView(Values.Session.GetSchool(Session)
                        //, ref TreeView1
                                                                    , 0
                                                                    , 0);
                }
                TreeView1.Attributes.Add("onclick", "fireCheckChanged(event)");
                TreeView1.ExpandAll();
            }
        }



        #region Properties of this usercontrol

        public int SchoolId
        {
            get { return Convert.ToInt32(hidSchoolId.Value); }
            set
            {
                this.hidSchoolId.Value = value.ToString();
                LoadAcademicYear();
            }
        }

        public int AcademicYearId
        {
            get { return Convert.ToInt32(hidAcaId.Value); }
            set
            {
                LoadAcademicYear();
                this.hidAcaId.Value = value.ToString();
            }
        }

        #endregion

        #region Selected Index Changed

        protected void cmbAcademicYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSession();
            LoadTree();
        }

        protected void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTree();
        }
        #endregion

        #region Load Functions

        private void LoadAcademicYear()
        {
            DbHelper.ComboLoader.LoadAcademicYear(ref cmbAcademicYear, SchoolId, AcademicYearId);
            if (AcademicYearId > 0)
            {
                cmbAcademicYear.Enabled = false;
                LoadSession();
            }
        }

        private void LoadSession()
        {
            DbHelper.ComboLoader.LoadSession(ref cmbSession, Convert.ToInt32(cmbAcademicYear.SelectedValue), false, true);
        }

        private void LoadTree()
        {
            TreeView1.Attributes.Remove("onclick");
            TreeView1.Nodes.Clear();
            //using (var helper = new Academic.DbHelper.DbHelper.AcademicPlacement())
            {
                var list = GetClassStructureInTreeView(Values.Session.GetSchool(Session)
                    //, ref TreeView1
                    , Convert.ToInt32(cmbAcademicYear.SelectedValue == "" ? "0" : cmbAcademicYear.SelectedValue)
                    , Convert.ToInt32(cmbSession.SelectedValue == "" ? "0" : cmbSession.SelectedValue));
            }

            TreeView1.Attributes.Add("onclick", "fireCheckChanged(event)");
            TreeView1.ExpandAll();
        }
        #endregion

        protected void TreeView1_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
        {
            CheckAllChildren(e.Node);

        }

        void CheckAllChildren(TreeNode node)
        {
            foreach (TreeNode child in node.ChildNodes)
            {
                child.Checked = node.Checked;
                CheckAllChildren(child);
            }
        }

        protected void TreeView1_TreeNodeCollapsed(object sender, TreeNodeEventArgs e)
        {
            e.Node.ExpandAll();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var saved = AddOrUpdateRunningClasses(ref TreeView1
                    , Convert.ToInt32(cmbAcademicYear.SelectedValue)
                    , Convert.ToInt32(cmbSession.SelectedValue));
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            LoadTree();
        }

        public bool AddOrUpdateRunningClasses(ref MyTreeView tree, int academicYearId, int sessionId = 0)
        {
            try
            {
                List<Academic.DbEntities.AcacemicPlacements.RunningClass> classes = new List<Academic.DbEntities.AcacemicPlacements.RunningClass>();

                foreach (MyTreeNode level in tree.Nodes)
                {
                    foreach (MyTreeNode fac in level.ChildNodes)
                    {
                        foreach (MyTreeNode prog in fac.ChildNodes)
                        {
                            foreach (MyTreeNode year in prog.ChildNodes)
                            {
                                if (year.Type == "year")
                                {
                                    if (year.ChildNodes.Count == 0)
                                    {
                                        var cls = new Academic.DbEntities.AcacemicPlacements.RunningClass()
                                        {
                                            Id = year.RunningClassId
                                            ,
                                            AcademicYearId = academicYearId
                                            ,
                                            YearId = Convert.ToInt32(year.Value)
                                            ,

                                        };
                                        if (sessionId > 0)
                                            cls.SessionId = sessionId;
                                        classes.Add(cls);
                                    }
                                }
                                foreach (MyTreeNode subyear in year.ChildNodes)
                                {
                                    if (subyear.Type == "subyear")
                                    {
                                        var cls = new Academic.DbEntities.AcacemicPlacements.RunningClass()
                                        {
                                            Id = subyear.RunningClassId
                                            ,
                                            AcademicYearId = academicYearId
                                            ,
                                            SubYearId = Convert.ToInt32(subyear.Value)
                                            ,
                                            YearId = subyear.yearId

                                        };
                                        if (sessionId > 0)
                                            cls.SessionId = sessionId;
                                        classes.Add(cls);
                                    }
                                }
                            }
                        }
                    }
                }

                ////check for year
                //foreach (MyTreeNode checkedNode in tree.CheckedNodes)
                //{
                //    if (checkedNode.Type == "subyear")
                //    {
                //        var cls = new RunningClass()
                //        {
                //            Id = checkedNode.RunningClassId
                //            ,
                //            AcademicYearId = academicYearId
                //            ,
                //            SubYearId = Convert.ToInt32(checkedNode.Value)
                //            ,
                //            YearId = checkedNode.yearId

                //        };
                //        if (sessionId > 0)
                //            cls.SessionId = sessionId;
                //        classes.Add(cls);
                //    }
                //    else if (checkedNode.Type == "year")
                //    {
                //        if (checkedNode.ChildNodes.Count == 0)
                //        {
                //            var cls = new RunningClass()
                //            {
                //                Id = checkedNode.RunningClassId
                //                ,
                //                AcademicYearId = academicYearId
                //                ,
                //                YearId = Convert.ToInt32(checkedNode.Value)
                //                ,

                //            };
                //            if (sessionId > 0)
                //                cls.SessionId = sessionId;
                //            classes.Add(cls);
                //        }
                //    }//phase hudaina... phase is entered by teacher
                //}
                ////CheckForYear(tree.CheckedNodes)
                using (var helper = new DbHelper.AcademicPlacement())
                {
                    var saved = helper.AddOrUpdateRunningClass(classes);
                    return saved;
                }

            }
            catch
            {
                return false;
            }
        }


        public object GetClassStructureInTreeView(int schoolId, int academicYearId, int sessionId = 0)
        {
            List<Academic.DbEntities.Structure.Level> levels;
            List<Academic.DbEntities.AcacemicPlacements.RunningClass> runningClasses;
            using (var helper = new DbHelper.Structure())
            using (var clshelper = new DbHelper.AcademicPlacement())
            {
                levels = helper.GetLevelsWithAllIncluded(schoolId);
                runningClasses = clshelper.GetClassesOfAcademicYear(academicYearId, sessionId);


                //var runningClasses = GetClassesOfAcademicYear(academicYearId, sessionId);

                List<TreeNode> nodeList = new List<TreeNode>();
                //levels already occured for this academic year
                var savedLevels = runningClasses.Select(x => x.Year.Program.Faculty.Level.Id);
                var savedFaculties = runningClasses.Select(x => x.Year.Program.Faculty.Id);
                var savedPrograms = runningClasses.Select(x => x.Year.Program.Id);
                var savedYears = runningClasses.Select(x => x.Year.Id);
                var savedsubyears =
                    runningClasses.Select(x => x.SubYear).Where(y => (y.ParentId ?? 0) == 0).Select(m => m.Id);
                //var savedPhases = runningClasses.Select(x => x.SubYear).Where(y => (y.ParentId ?? 0) != 0).Select(m => m.Id);

                foreach (var level in levels)
                {
                    var levelNode = new MyTreeNode(level.Name, level.Id.ToString());
                    if (savedLevels.Contains(level.Id))
                        levelNode.Checked = true;
                    levelNode.Type = "level";
                    levelNode.SelectAction = TreeNodeSelectAction.Select;
                    levelNode.ExpandAll(); // = true;
                    nodeList.Add(levelNode);
                    TreeView1.Nodes.Add(levelNode);



                    foreach (var faculty in level.Faculty.Where(x => !(x.Void ?? false) && (x.IsActive ?? true)))
                    {
                        var facNode = new MyTreeNode(faculty.Name, faculty.Id.ToString());
                        if (savedFaculties.Contains(faculty.Id))
                            facNode.Checked = true;
                        facNode.Type = "faculty";
                        levelNode.ChildNodes.Add(facNode);

                        foreach (var program in faculty.Programs.Where(x => !(x.Void ?? false) && (x.IsActive ?? true)))
                        {
                            var progNode = new MyTreeNode(program.Name, program.Id.ToString());
                            if (savedPrograms.Contains(program.Id))
                                progNode.Checked = true;
                            progNode.Type = "program";
                            facNode.ChildNodes.Add(progNode);


                            foreach (var year in program.Year.Where(x => !(x.Void ?? false) && (x.IsActive ?? true)))
                            {
                                var yearNode = new MyTreeNode(year.Name, year.Id.ToString());
                                if (savedYears.Contains(year.Id))
                                {
                                    yearNode.Checked = true;
                                    var rcId = runningClasses
                                        .First(x => x.AcademicYearId == academicYearId
                                                    && (x.SessionId ?? 0) == sessionId
                                                    && (x.IsActive ?? true)
                                                    && !(x.Void ?? false)
                                                    && x.YearId == year.Id
                                                    && (x.SubYearId ?? 0) == 0).Id;
                                    //if (rcId != null)
                                    yearNode.RunningClassId = rcId;
                                }
                                yearNode.Type = "year";
                                progNode.ChildNodes.Add(yearNode);

                                foreach (var subyear in year.SubYears.Where(x => x.ParentId == null
                                                                                 && !(x.Void ?? false) &&
                                                                                 (x.IsActive ?? true)))
                                {
                                    var subyearNode = new MyTreeNode(subyear.Name, subyear.Id.ToString());
                                    if (savedsubyears.Contains(subyear.Id))
                                    {
                                        subyearNode.Checked = true;
                                        var rcId = runningClasses
                                            .First(x => x.AcademicYearId == academicYearId
                                                        && (x.SessionId ?? 0) == sessionId
                                                        && (x.IsActive ?? true)
                                                        && !(x.Void ?? false)
                                                        && x.YearId == year.Id
                                                        && (x.SubYearId ?? 0) != 0).Id;
                                        //if (rcId != null)
                                        subyearNode.RunningClassId = rcId;
                                    }
                                    subyearNode.yearId = year.Id;
                                    subyearNode.Type = "subyear";
                                    yearNode.ChildNodes.Add(subyearNode);

                                    //foreach (var phase in year.SubYears.Where(x => x.ParentId == subyear.Id
                                    //                                               && !(x.Void ?? false) &&
                                    //                                               (x.IsActive ?? true)))
                                    //{
                                    //    var phaseNode = new MyTreeNode(phase.Name, phase.Id.ToString());
                                    //    if (savedPhases.Contains(phase.Id))
                                    //        phaseNode.Checked = true;
                                    //    phaseNode.Type = "phase";
                                    //    subyearNode.ChildNodes.Add(phaseNode);
                                    //}
                                }
                            }
                        }
                    }
                }
                return nodeList;
            }
        }

    }
}