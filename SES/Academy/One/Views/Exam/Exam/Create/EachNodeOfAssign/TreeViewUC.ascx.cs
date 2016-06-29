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

namespace One.Views.Exam.Exam.Create.EachNodeOfAssign
{
    public partial class TreeViewUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _forceCheck = false;
            if (!IsPostBack)
            {
            }
            if (ExamId > 0)
                LoadTree();
        }

        #region Properties

        public int SchoolId
        {
            get { return Convert.ToInt32(hidSchoolId.Value); }
            set { this.hidSchoolId.Value = value.ToString(); }
        }

        public int AcademicYearId
        {
            get { return Convert.ToInt32(hidAcademicYear.Value); }
            set { this.hidAcademicYear.Value = value.ToString(); }
        }

        public int SessionId
        {
            get { return Convert.ToInt32(hidSessionId.Value); }
            set { this.hidSessionId.Value = value.ToString(); }
        }

        public int ExamId
        {
            get { return Convert.ToInt32(hidExamId.Value); }
            set
            {
                this.hidExamId.Value = value.ToString();
                Academic.DbEntities.Exams.Exam exam;
                if (AcademicYearId <= 0)
                {
                    using (var helper = new DbHelper.Exam())
                    {
                        exam = helper.Find(value);

                        if (exam != null)
                        {
                            hidAcademicYear.Value = exam.AcademicYearId.ToString();
                            AcademicYearName = exam.AcademicYear.Name;
                        }
                    }
                    if (SessionId <= 0)
                    {
                        if (exam != null)
                        {
                            hidSessionId.Value = exam.SessionId.ToString();
                            SessionName = exam.Session.Name;
                        }
                    }
                }
                LoadTree();
            }
        }

        public string AcademicYearName { get; set; }
        public string SessionName { get; set; }
        #endregion


        private void LoadTree()
        {

            List<Academic.DbEntities.Structure.Level> levels;
            List<Academic.DbEntities.AcacemicPlacements.RunningClass> runningClasses;
            using (var helper = new DbHelper.Structure())
            using (var clshelper = new DbHelper.AcademicPlacement())
            {
                runningClasses = clshelper.GetClassesOfAcademicYear(AcademicYearId
                    , SessionId);
                //added
                var savedLevels = runningClasses.Select(x => x.Year.Program.Faculty.Level.Id);
                var savedFaculties = runningClasses.Select(x => x.Year.Program.Faculty.Id);
                var savedPrograms = runningClasses.Select(x => x.Year.Program.Id);
                var savedYears = runningClasses.Select(x => x.Year.Id);
                var savedtemp =
                    runningClasses.Select(x => x.SubYear);
                List<int> savedsubyears = new List<int>();
                levels = helper.GetLevelsWithAllIncluded(SchoolId).Where(x => savedLevels.Contains(x.Id)).ToList();

                foreach (var sav in savedtemp)
                {
                    if (sav != null)
                    {
                        if ((sav.ParentId ?? 0) == 0)
                            savedsubyears.Add(sav.Id);
                    }
                }

                Root.Text = "Academic";
                Root.Level = 0;

                //level
                for (var lev = 0; lev < levels.Count(); lev++)
                {
                    TreeNodeUC leveluc =
                        (TreeNodeUC)
                            Page.LoadControl("~/Views/Exam/Exam/Create/EachNodeOfAssign/TreeNodeUC.ascx");

                    leveluc.SetParameters(levels.ElementAt(lev).Name, levels.ElementAt(lev).Id.ToString(), lev, levels.Count);
                    Root.AddNode(leveluc);

                    //faculty
                    var faculties = levels[lev].Faculty.Where(x => savedFaculties.Contains(x.Id)).ToList();
                    for (int fac = 0; fac < faculties.Count(); fac++)
                    {
                        TreeNodeUC facuc =
                            (TreeNodeUC)Page
                                .LoadControl("~/Views/Exam/Exam/Create/EachNodeOfAssign/TreeNodeUC.ascx");

                        facuc.SetParameters(faculties[fac].Name, faculties[fac].Id.ToString(), fac, faculties.Count());
                        leveluc.AddNode(facuc);

                        //program
                        var programs = faculties[fac].Programs.Where(x => savedPrograms.Contains(x.Id)).ToList();
                        for (var pro = 0; pro < programs.Count(); pro++)
                        {
                            TreeNodeUC proguc =
                                (TreeNodeUC)Page
                                    .LoadControl("~/Views/Exam/Exam/Create/EachNodeOfAssign/TreeNodeUC.ascx");

                            proguc.SetParameters(programs[pro].Name, programs[pro].Id.ToString(), pro, programs.Count);
                            facuc.AddNode(proguc);

                            //year
                            var years = programs[pro].Year.Where(x => savedYears.Contains(x.Id)).ToList();
                            for (var ye = 0; ye < years.Count; ye++)
                            {
                                TreeNodeUC yearuc =
                                    (TreeNodeUC)Page
                                        .LoadControl(
                                            "~/Views/Exam/Exam/Create/EachNodeOfAssign/TreeNodeUC.ascx");

                                yearuc.Type = "year";
                                yearuc.StudentsButtonClick += uc_StudentsButtonClick;

                                yearuc.SetParameters(years[ye].Name, years[ye].Id.ToString(), ye, years.Count);
                                proguc.AddNode(yearuc);

                                //yearuc.Checked = true;
                                yearuc.ForceCheck = _forceCheck;

                                var rcId = runningClasses
                                    .FirstOrDefault(x => x.AcademicYearId == AcademicYearId
                                                         && (x.SessionId ?? 0) == SessionId
                                                         && (x.IsActive ?? true)
                                                         && !(x.Void ?? false)
                                                         && x.YearId == years[ye].Id);

                                if (rcId != null)
                                    yearuc.RunningClassId = rcId.Id;

                                CheckForSubjectOfYear(years, ref yearuc, ye, runningClasses);

                                //subyear
                                var subyears = years[ye].SubYears.Where(x => x.ParentId == null && savedsubyears.Contains(x.Id)).ToList();
                                for (var sub = 0; sub < subyears.Count; sub++)
                                {
                                    TreeNodeUC subyearuc =
                                        (TreeNodeUC)Page
                                            .LoadControl(
                                                "~/Views/Exam/Exam/Create/EachNodeOfAssign/TreeNodeUC.ascx");

                                    subyearuc.YearId = years[ye].Id;
                                    subyearuc.Type = "subyear";
                                    subyearuc.StudentsButtonClick += uc_StudentsButtonClick;

                                    subyearuc.SetParameters(subyears[sub].Name, subyears[sub].Id.ToString(), sub, subyears.Count);
                                    yearuc.AddNode(subyearuc);


                                    subyearuc.ForceCheck = _forceCheck;
                                    subyearuc.Checked = true;
                                    subyearuc.BorderColor = Color.LimeGreen;
                                    var rc = runningClasses
                                        .FirstOrDefault(x => x.AcademicYearId == AcademicYearId
                                                    && (SessionId == 0) ? true : ((x.SessionId ?? 0) == SessionId)
                                                    && (x.IsActive ?? true)
                                                    && !(x.Void ?? false)
                                                    && x.YearId == years[ye].Id
                                                    && (x.SubYearId ?? 0) != 0);
                                    //if (rcId != null)
                                    if (rc != null)
                                        subyearuc.RunningClassId = rc.Id;

                                    CheckForSubjectOfSubYear(years, ref subyearuc, subyears.ToList(), ye, sub, runningClasses);

                                }
                            }
                        }
                    }
                }
            }



            string root = "";
            List<Academic.DbEntities.AcacemicPlacements.RunningClass> classes = null;

            using (var helper = new DbHelper.AcademicPlacement())
            {
                if (SessionId > 0)
                {
                    root = SessionName;
                    classes = helper.GetClassesOfAcademicYear(AcademicYearId, SessionId);
                }
                else if (AcademicYearId > 0)
                {
                    root = AcademicYearName;
                    classes = helper.GetClassesOfAcademicYear(AcademicYearId);
                }
            }
        }

        private void CheckForSubjectOfSubYear(List<Academic.DbEntities.Structure.Year> years
           , ref TreeNodeUC subyearuc, List<Academic.DbEntities.Structure.SubYear> subyears
           , int ye, int sub, List<Academic.DbEntities.AcacemicPlacements.RunningClass> runningClasses)
        {
            var withSubject =
                                runningClasses.Where(x => x.YearId == years[ye].Id && x.SubYearId == subyears[sub].Id);
            if (years[ye].SubYears.Count > 0)
            {
                foreach (var run in withSubject)
                {
                    int subPos = 0;
                    foreach (var subcls in run.SubjectClasses)
                    {
                        //CheckForSubject(years,ref subyearuc,ye,runningClasses);

                        TreeNodeUC subjectuc =
               (TreeNodeUC)Page
                   .LoadControl(
                       "~/Views/Exam/Exam/Create/EachNodeOfAssign/TreeNodeUC.ascx");

                        subjectuc.YearId = years[ye].Id;
                        subjectuc.Type = "subject";
                        subjectuc.StudentsButtonClick += uc_StudentsButtonClick;

                        subjectuc.SetParameters(subcls.Subject.Name, subcls.Subject.Id.ToString(), subPos, run.SubjectClasses.Count);
                        subyearuc.AddNode(subjectuc);

                        subPos++;

                    }
                }
            }
        }

        private void CheckForSubjectOfYear(List<Academic.DbEntities.Structure.Year> years
            , ref TreeNodeUC yearuc, int ye, List<Academic.DbEntities.AcacemicPlacements.RunningClass> runningClasses)
        {
            var yearwithSubject =
                                  runningClasses.Where(x => x.YearId == years[ye].Id && x.SubYearId == null);
            if (years[ye].SubYears.Count == 0)
            {
                foreach (var run in yearwithSubject)
                {
                    int subPos = 0;

                    foreach (var subcls in run.SubjectClasses)
                    {
                        TreeNodeUC subjectuc =
               (TreeNodeUC)Page
                   .LoadControl(
                       "~/Views/Exam/Exam/Create/EachNodeOfAssign/TreeNodeUC.ascx");

                        subjectuc.YearId = years[ye].Id;
                        subjectuc.Type = "subject";
                        subjectuc.StudentsButtonClick += uc_StudentsButtonClick;

                        subjectuc.SetParameters(subcls.Subject.Name, subcls.Subject.Id.ToString(), subPos, run.SubjectClasses.Count);
                        yearuc.AddNode(subjectuc);

                        subPos++;
                    }
                }
            }
        }



        private bool _forceCheck = false;

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //if (Page.IsValid)
            //{
            //    var saved = AddOrUpdateRunningClasses(ref Root,
            //        Convert.ToInt32(cmbAcademicYear.SelectedValue)
            //        , Convert.ToInt32(cmbSession.SelectedValue));
            //}
        }

        public bool AddOrUpdateRunningClasses(ref TreeNodeUC tree, int academicYearId, int sessionId = 0)
        {
            try
            {
                List<Academic.DbEntities.AcacemicPlacements.RunningClass> classes = new List<Academic.DbEntities.AcacemicPlacements.RunningClass>();

                foreach (var level in tree.ChildNodes)
                {
                    foreach (var fac in level.ChildNodes)
                    {
                        foreach (var prog in fac.ChildNodes)
                        {
                            foreach (var year in prog.ChildNodes)
                            {
                                if (year.Type == "year" && year.Checked)
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
                                foreach (var subyear in year.ChildNodes)
                                {
                                    if (subyear.Type == "subyear" && subyear.Checked)
                                    {
                                        var cls = new Academic.DbEntities.AcacemicPlacements.RunningClass()
                                        {
                                            Id = subyear.RunningClassId
                                            ,
                                            AcademicYearId = academicYearId
                                            ,
                                            SubYearId = Convert.ToInt32(subyear.Value)
                                            ,
                                            YearId = subyear.YearId

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

        #region Events

        public bool EarlierStudentEntryFormVisible = false;
        public TreeNodeUC EarlierEntryClentOfStudentEntryForm { get; set; }
        public string XValue { get; set; }
        public string YValue { get; set; }



        void uc_StudentsButtonClick(object sender, Values.RunningClassEventArgs e)
        {
            TreeNodeUC node = (TreeNodeUC)sender;
            StudentEntry entry =
                                        (StudentEntry)Page
                                            .LoadControl(
                                                "~/Views/AcademicPlacement/StudentClass/StudentEntry.ascx");

            //node.AddEntryForm(entry);



            //pnlStudentEntry.Style["top"] = YValue;//e.Y.ToString();
            //pnlStudentEntry.Style["left"] = XValue;//e.X.ToString();
            //if (EarlierStudentEntryFormVisible
            //    && EarlierEntryClentOfStudentEntryForm.YearId == node.YearId
            //    && EarlierEntryClentOfStudentEntryForm.Value == node.Value)
            //{
            //    pnlStudentEntry.Visible = false;
            //    EarlierStudentEntryFormVisible = false;
            //}
            //else
            //{
            //    EarlierStudentEntryFormVisible = true;
            //    pnlStudentEntry.Visible = true;
            //}


            if (e.Type == "year")
            {
                if (EarlierStudentEntryFormVisible)
                {
                    //StudentEntry1.RunningClassId = node.RunningClassId;
                    //StudentEntry1.StudentClasses = node.StudentClasses;
                }

            }
            else if (e.Type == "subyear")
            {

            }
        }

        //void StudentEntry1_DoneClicked(object sender, Values.StudentEntryEventArgs e)
        //{
        //    //save the data to the node
        //    TreeNodeUC node = (TreeNodeUC)sender;
        //    if (e.StudentClasses.Count > 0)
        //        node.StudentClasses = e.StudentClasses;
        //}

        public TreeViewUC StudentEntryLoadedFor { get; set; }



        #endregion //Events end
    }
}