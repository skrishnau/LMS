using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.Structure;
using Academic.DbHelper;
using One.Values;
using One.Views.AcademicPlacement.StudentClass;

namespace One.Views.AcademicPlacement.Master.ListingUserControls
{
    public partial class TreeViewUC : System.Web.UI.UserControl
    {
        private bool _forceCheck = false;

        //------------------------------------------------//
        protected void Page_Load(object sender, EventArgs e)
        {
            _forceCheck = false;
            if (!IsPostBack)
            {
                LoadAcademicYear();
                ViewState["StudentClassList"] = new List<Academic.DbEntities.AcacemicPlacements.StudentClass>();
            }
            //else
            //{
            //string passedArgument = Request.Params.Get("__EVENTARGUMENT");
            //string controlName = Request.Params.Get("__EVENTTARGET");
            //string[] values = passedArgument.Split(new char[] { ',' });
            //if (Length == 2 && controlName == "imgStdGrp")
            //{
            //    //hidX.Value = values[0];
            //    //hidY.Value = values[1];
            //    XValue = values[0];
            //    YValue = values[1];
            //    //lnlbtn123_Click(this, new EventArgs());
            //}
            //}

            StudentEntry1.SaveClicked += StudentEntry1_SaveClicked;
            StudentEntry1.CloseClicked += StudentEntry1_CloseClicked;
            if (IsSessionSelected())
                LoadMaximumNoOfSubYears();

            LoadTree();


            //for (int i = 0; i < 2; i++)
            //{
            //    CurrentAcademicYear.ListDisplay.NodeUC uc =
            //        (CurrentAcademicYear.ListDisplay.NodeUC)Page.LoadControl("~/Views/Academy/CurrentAcademicYear/ListDisplay/NodeUC.ascx");

            //    uc.LabelText = "i=" + i.ToString();
            //    uc.Level = 1;
            //    for (int j = 0; j < 3; j++)
            //    {
            //        CurrentAcademicYear.ListDisplay.NodeUC innerUc =
            //        (CurrentAcademicYear.ListDisplay.NodeUC)Page.LoadControl("~/Views/Academy/CurrentAcademicYear/ListDisplay/NodeUC.ascx");
            //        innerUc.LabelText = "j=" + j.ToString();
            //        innerUc.Level = 2;
            //        uc.AddNode(innerUc);

            //    }
            //    Root.AddNode(uc);
            //    //Nodes.Controls.Add(uc);
            //}
        }

        #region Properties

        public int SchoolId
        {
            get { return Convert.ToInt32(hidSchoolId.Value); }
            set { this.hidSchoolId.Value = value.ToString(); }
        }
        public int AcademicYearId
        {
            get
            {
                if (hidAcademicYear.Value == "0" || hidAcademicYear.Value == "")
                {
                    return Convert.ToInt32(cmbAcademicYear.SelectedValue == "" ? "0" : cmbAcademicYear.SelectedValue);
                }
                return Convert.ToInt32(hidAcademicYear.Value);
            }
            set
            {
                this.hidAcademicYear.Value = value.ToString();
                LoadAcademicYear();
            }
        }
        public int SessionId
        {
            get
            {
                if (hidSessionId.Value == "0" || hidSessionId.Value == "")
                {
                    return Convert.ToInt32(cmbSession.SelectedValue == "" ? "0" : cmbSession.SelectedValue);
                }
                return Convert.ToInt32(hidSessionId.Value);
            }
            set { this.hidSessionId.Value = value.ToString(); }
        }
        public int SwitchSubYear
        {
            get { return Convert.ToInt32(cmbSubYearSwitch.SelectedValue); }
            set { cmbSubYearSwitch.SelectedValue = value.ToString(); }
        }

        private bool IsSessionSelected()
        {
            return (!(String.IsNullOrEmpty(cmbSession.SelectedValue) || cmbSession.SelectedValue == "0"));
        }

        public TreeNodeUC EarlierEntryClentOfStudentEntryForm { get; set; }
        public TreeViewUC StudentEntryLoadedFor { get; set; }


        //public bool PnlBatchSelectVisible
        //{
        //    set
        //    {
        //        CheckBox1.Checked = !CheckBox1.Checked;
        //        CheckBox2.Checked = value;
        //    }
        //} //set { pnlBatchSelect.Visible = value; } 
        #endregion

        #region Load Functions

        private void LoadAcademicYear()
        {
            DbHelper.ComboLoader.LoadAcademicYear(ref cmbAcademicYear, SchoolId, AcademicYearId);
            if (AcademicYearId > 0)
            {
                //cmbAcademicYear.Enabled = false;
                LoadSession();
            }
        }
        private void LoadSession()
        {
            DbHelper.ComboLoader.LoadSession(ref cmbSession, Convert.ToInt32(cmbAcademicYear.SelectedValue), SessionId
                , true, true, false);
        }
        private void LoadTree()
        {
            //it is the position of subyear to be displayed
            int subYearPos = -1;
            if (IsSessionSelected())
            {
                subYearPos = Convert.ToInt32(cmbSubYearSwitch.SelectedValue);
            }

            List<Academic.DbEntities.Structure.Level> levels;
            List<Academic.DbEntities.AcacemicPlacements.RunningClass> runningClasses;
            using (var helper = new DbHelper.Structure())
            using (var clshelper = new DbHelper.AcademicPlacement())
            {
                levels = helper.GetLevelsWithAllIncluded(SchoolId);
                runningClasses = clshelper.GetClassesOfAcademicYear(Convert.ToInt32((string.IsNullOrEmpty(cmbAcademicYear.SelectedValue) ? "0" : cmbAcademicYear.SelectedValue))
                    , Convert.ToInt32((string.IsNullOrEmpty(cmbSession.SelectedValue) ? "0" : cmbSession.SelectedValue)));

                var savedLevels = runningClasses.Select(x => x.Year.Program.Faculty.Level.Id);
                var savedFaculties = runningClasses.Select(x => x.Year.Program.Faculty.Id);
                var savedPrograms = runningClasses.Select(x => x.Year.Program.Id);

                /*The below commented line gets all years that occur in runningClasses rows.. 
                    but we need only those years
                    1. whose conscutive subyear in runningClasses Table is null
                    2. or if subyear is not null then select those years whose consecutive subyear in runningClasses
                       have position in Subyear table  equal to the subYearPos
                */
                ////var savedYears = runningClasses.Select(x => x.Year.Id);

                var savedYears = runningClasses.Where(x =>
                    ((x.Year.SubYears.OrderBy(o => o.Position).ToList().ElementAtOrDefault(subYearPos) ?? new SubYear() { Id = 0 })).Id
                                == (x.SubYearId ?? 0))
                      .Select(y => y.YearId);

                var savedtemp =
                    runningClasses.Select(x => x.SubYear);
                List<int> savedsubyears = new List<int>();
                foreach (var sav in savedtemp)
                {
                    if (sav != null)
                    {
                        if ((sav.ParentId ?? 0) == 0)
                            savedsubyears.Add(sav.Id);
                    }
                }
                //if(savedtemp!=null)
                //{
                //    savedsubyears = savedtemp.Where(y => (y.ParentId ?? 0) == 0).Select(m => m.Id).ToList();
                //}


                Root.Text = "Academic";
                Root.Level = 0;

                string s = "";
                //string s = "0,";
                for (var lev = 0; lev < levels.Count(); lev++) //in levels
                {
                    TreeNodeUC leveluc =
                        (TreeNodeUC)
                            Page.LoadControl("~/Views/AcademicPlacement/Master/ListingUserControls/TreeNodeUC.ascx");

                    leveluc.Text = levels.ElementAt(lev).Name; //"i=" + i.ToString();
                    leveluc.Level = 1;
                    //if (lev < levels.Count() - 1)
                    //    s += "1,";
                    //else s += "0,";
                    leveluc.NoOfVertBars = s;

                    Root.AddNode(leveluc);
                    List<Academic.DbEntities.Structure.Faculty> faculties = levels[lev].Faculty.ToList();
                    for (int fac = 0; fac < faculties.Count(); fac++)
                    {
                        //.Where(x => x.FacultyId == faculties[fac].Id).Distinct().ToList();
                        TreeNodeUC facuc =
                            (TreeNodeUC)Page
                                .LoadControl("~/Views/AcademicPlacement/Master/ListingUserControls/TreeNodeUC.ascx");

                        facuc.Text = faculties[fac].Name; //"i=" + i.ToString();
                        facuc.Level = 2;
                        //if level has more elements display else don't

                        if (lev < levels.Count() - 1)
                            s += "1,";
                        else s += "0,";
                        facuc.NoOfVertBars = s;
                        leveluc.AddNode(facuc);

                        var programs = faculties[fac].Programs.ToList();

                        for (var pro = 0; pro < programs.Count(); pro++)
                        {
                            //.Where(x => x.ProgramId == programs[pro].Id).Distinct().ToList();
                            TreeNodeUC proguc =
                                (TreeNodeUC)Page
                                    .LoadControl("~/Views/AcademicPlacement/Master/ListingUserControls/TreeNodeUC.ascx");

                            proguc.ExpandButtonVisibility = true;
                            //proguc.ExpandButtonImageUrl = StaticCollapsedButtonUrl;
                            proguc.FontBold = true;
                            proguc.BorderVisibility = true;
                            proguc.ChildPanelVisibility = false;
                            proguc.Text = programs[pro].Name; //"i=" + i.ToString();
                            proguc.Level = 3;

                            if (fac < faculties.Count() - 1)
                                s += "1,";
                            else s += "0,";
                            proguc.NoOfVertBars = s;

                            facuc.AddNode(proguc);

                            var years = programs[pro].Year.OrderBy(y => y.Position).ToList();

                            var withSubYear = years.Where(x => x.SubYears.Count > 0); // subyear bhayeko year dinxa
                            //var withoutSubYear = years.Where(x => x.SubYears.Count == 0);//subyear nabhako year dinxa..

                            if (IsSessionSelected() && !withSubYear.Any())
                            {
                                TreeNodeUC msgUc =
                                        (TreeNodeUC)Page
                                            .LoadControl(
                                                "~/Views/AcademicPlacement/Master/ListingUserControls/TreeNodeUC.ascx");
                                msgUc.Text = "Doesn't have Subyear.Deselect Session.";
                                msgUc.CheckBoxVisibility = false;
                                //msgUc.BorderColor = Color.LightSalmon;
                                msgUc.Level = 4;

                                //if (pro < programs.Count - 1)
                                //    s += "1,";
                                //else 
                                s += "0,";
                                msgUc.NoOfVertBars = s;
                                msgUc.StudentButtonVisibility = false;
                                msgUc.IsMessage = true;
                                msgUc.ClearBorder();
                                msgUc.TextForeColor = Color.DeepPink;
                                proguc.AddNode(msgUc);
                                s = s.Substring(0, s.Length - 2);


                            }
                            else if (!IsSessionSelected() && withSubYear.Count() == years.Count)
                            {
                                TreeNodeUC msgUc =
                                        (TreeNodeUC)Page
                                            .LoadControl(
                                                "~/Views/AcademicPlacement/Master/ListingUserControls/TreeNodeUC.ascx");
                                msgUc.Text = "Has subyears. Select a session.";
                                msgUc.CheckBoxVisibility = false;
                                //msgUc.BorderColor = Color.LightSalmon;
                                msgUc.Level = 4;
                                msgUc.ClearBorder();
                                msgUc.TextForeColor = Color.DeepPink;
                                //if (pro < programs.Count - 1)
                                //    s += "1,";
                                //else
                                s += "0,";
                                msgUc.NoOfVertBars = s;
                                msgUc.StudentButtonVisibility = false;
                                msgUc.IsMessage = true;

                                proguc.AddNode(msgUc);
                                s = s.Substring(0, s.Length - 2);
                            }

                            else
                                for (var ye = 0; ye < years.Count; ye++)
                                {
                                    TreeNodeUC yearuc =
                                        (TreeNodeUC)Page
                                            .LoadControl(
                                                "~/Views/AcademicPlacement/Master/ListingUserControls/TreeNodeUC.ascx");

                                    yearuc.Text = years[ye].Name; //"i=" + i.ToString();
                                    //yearuc.IndentImageUrl = StaticSquareDot;
                                    yearuc.Level = 4;
                                    yearuc.Type = "year";
                                    yearuc.NodeBorderVisibility = true;
                                    yearuc.Value = years[ye].Id.ToString();
                                    yearuc.ProgramId = programs[pro].Id;
                                    yearuc.StudentsButtonClick += uc_StudentsButtonClick;
                                    if (savedYears.Contains(years[ye].Id))//!IsPostBack && 
                                    {

                                        yearuc.ForceCheck = _forceCheck;
                                        var rcId = runningClasses
                                            .FirstOrDefault(x => x.AcademicYearId == AcademicYearId
                                                                 && (x.SessionId ?? 0) == SessionId
                                                                 && (x.IsActive ?? true)

                                                                 && x.YearId == years[ye].Id);//&& !(x.Void ?? false)
                                        //&& (x.SubYearId ?? 0) == 0);
                                        //if (rcId != null)
                                        if (rcId != null)
                                        {
                                            yearuc.RunningClassId = rcId.Id;
                                            yearuc.Checked = !(rcId.Void ?? false);
                                            yearuc.ProgramBatchId = rcId.ProgramBatchId ?? 0;
                                            yearuc.ProgramBatchName = rcId.ProgramBatch == null ? "" : rcId.ProgramBatch.NameFromBatch;
                                        }
                                    }


                                    if (pro < programs.Count - 1)
                                        s += "1,";
                                    else s += "0,";
                                    yearuc.NoOfVertBars = s;

                                    proguc.AddNode(yearuc);


                                    var subyears = years[ye].SubYears.Where(x => x.ParentId == null).OrderBy(y => y.Position).ToList();
                                    //.Select(y => y.SubYear).Where(x => x.YearId == year.Id).Distinct();


                                    //below commented code works perfectly to display all subyears
                                    //But we need only one subyear based on cmbSubYearSwitch selected value
                                    /*    for (var sub = 0; sub < subyears.Count; sub++)
                                        {
                                            TreeNodeUC subyearuc =
                                                (TreeNodeUC)Page
                                                    .LoadControl(
                                                        "~/Views/AcademicPlacement/RunningClass/CheckBoxOnly/TreeNodeUC.ascx");

                                            subyearuc.Text = subyears[sub].Name; //"i=" + i.ToString();
                                            subyearuc.Value = subyears[sub].Id.ToString();
                                            subyearuc.Level = 5;
                                            subyearuc.YearId = years[ye].Id;
                                            subyearuc.Type = "subyear";
                                            subyearuc.StudentsButtonClick += uc_StudentsButtonClick;

                                            if (savedsubyears.Contains(subyears[sub].Id))
                                            {
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
                                            }


                                            if (ye < years.Count - 1)
                                                s += "1,";
                                            else s += "0,";
                                            subyearuc.NoOfVertBars = s;

                                            yearuc.AddNode(subyearuc);
                                            s = s.Substring(0, s.Length - 2);
                                        }
                                        */

                                    //Instead we display only one sub year as follows:
                                    if (subyears.Count > 0 && IsSessionSelected())
                                    {
                                        TreeNodeUC subuc =
                                            (TreeNodeUC)Page
                                                .LoadControl(
                                                    "~/Views/AcademicPlacement/Master/ListingUserControls/TreeNodeUC.ascx");
                                        subuc.Text = subyears[subYearPos].Name; //"i=" + i.ToString();
                                        //subuc.IndentImageUrl = StaticCircleDot;
                                        subuc.Value = subyears[subYearPos].Id.ToString();
                                        subuc.Level = 5;
                                        subuc.YearId = years[ye].Id;
                                        subuc.Type = "subyear";
                                        subuc.NodeBorderVisibility = true;
                                        subuc.ProgramId = programs[pro].Id;
                                        subuc.StudentsButtonClick += uc_StudentsButtonClick;

                                        if (savedsubyears.Contains(subyears[subYearPos].Id))
                                        {

                                            //subuc.BorderColor = Color.LimeGreen;
                                            var rc = runningClasses
                                                .FirstOrDefault(x => x.AcademicYearId == AcademicYearId
                                                                     && (SessionId == 0)
                                                    ? true
                                                    : ((x.SessionId ?? 0) == SessionId)
                                                      && (x.IsActive ?? true)

                                                      && x.YearId == years[ye].Id
                                                      && (x.SubYearId ?? 0) != 0);//&& !(x.Void ?? false)
                                            //if (rcId != null)
                                            if (rc != null)
                                            {
                                                subuc.RunningClassId = rc.Id;
                                                //may be needed if items don't get checked even specified
                                                //subuc.ForceCheck = _forceCheck;
                                                subuc.Checked = !(rc.Void ?? false);
                                                subuc.ProgramBatchId = rc.ProgramBatchId ?? 0;
                                                subuc.ProgramBatchName = rc.ProgramBatch == null ? "" : rc.ProgramBatch.NameFromBatch;
                                            }
                                        }


                                        if (ye < years.Count - 1)
                                            s += "1,";
                                        else s += "0,";
                                        subuc.NoOfVertBars = s;

                                        yearuc.AddNode(subuc);
                                        s = s.Substring(0, s.Length - 2);
                                    }
                                    s = s.Substring(0, s.Length - 2); //(s.Length-3<0?2:3));
                                }
                            s = s.Substring(0, s.Length - 2); //(s.Length - 3 < 0 ? 2 : 3));
                        }
                        s = s.Substring(0, s.Length - 2); //(s.Length - 3 < 0 ? 2 : 3));
                    }
                    //s = s.Substring(0, s.Length - 2); // (s.Length - 3 < 0 ? 2 : 3));
                    //Root.AddNode(leveluc);
                }
            }



            string root = "";
            List<Academic.DbEntities.AcacemicPlacements.RunningClass> classes = null;

            using (var helper = new DbHelper.AcademicPlacement())
            {
                if (cmbSession.SelectedValue != "" && cmbSession.SelectedValue != "0")
                {
                    root = cmbSession.SelectedItem.Text;
                    classes = helper.GetClassesOfAcademicYear(AcademicYearId,
                        Convert.ToInt32(cmbSession.SelectedValue ?? "0"));
                }
                else if (cmbAcademicYear.SelectedValue != "" && cmbAcademicYear.SelectedValue != "0")
                {
                    root = cmbAcademicYear.SelectedItem.Text;
                    classes = helper.GetClassesOfAcademicYear(Convert.ToInt32(cmbAcademicYear.SelectedValue ?? "0"));
                }
            }
        }
        private void LoadMaximumNoOfSubYears()
        {
            //using (var helper = new DbHelper.Structure())
            //{
            //    var cnt = helper.GetMaximumNoOfSubyears(SchoolId: Session.GetSchool(Session));
            //    List<ListItem> switchItems = new List<ListItem>();
            //    if (cnt >= 1) { switchItems.Add(new ListItem("1st", "0")); }
            //    if (cnt >= 2) { switchItems.Add(new ListItem("2nd", "1")); }
            //    if (cnt >= 3) { switchItems.Add(new ListItem("3rd", "2")); }
            //    if (cnt >= 4) { switchItems.Add(new ListItem("4th", "3")); }
            //    if (cnt >= 5) { switchItems.Add(new ListItem("5th", "4")); }

            //    cmbSubYearSwitch.Items.AddRange(switchItems.ToArray());
            //}
        }

        #endregion

        #region Events

        protected void cmbAcademicYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_forceCheck = true;
            hidAcademicYear.Value = cmbAcademicYear.SelectedValue;

            LoadSession();
            //LoadTree();
        }
        protected void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            hidSessionId.Value = cmbSession.SelectedValue;
            var sessionSelected = IsSessionSelected();
            pnlSwitchSubYear.Enabled = sessionSelected;
            if (sessionSelected)
            {
                cmbSubYearSwitch.Items.Clear();
                LoadMaximumNoOfSubYears();
            }
            else
            {
                cmbSubYearSwitch.Items.Clear();
            }
            Root.ClearChildNodes();
            LoadTree();
        }

        protected void cmbSubYearSwitch_SelectedIndexChanged(object sender, EventArgs e)
        {

            //ClearChildViewState();
            //ClearChildState();

            Root.ClearChildNodes();
            LoadTree();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var saved = AddOrUpdateRunningClasses(ref Root,
                    Convert.ToInt32(cmbAcademicYear.SelectedValue)
                    , Convert.ToInt32(cmbSession.SelectedValue));
            }
        }
        //======================Student Group Dialog ========================//

        public TreeNodeUC NodeClicked { get; set; }
        void uc_StudentsButtonClick(object sender, RunningClassEventArgs e)
        {
            TreeNodeUC node = (TreeNodeUC)sender;
            pnlStudentEntry.Visible = true;
            //lbl1.Text = node.Text;
            //PnlBatchSelectVisible = true;
            //pnlBatchSelect.Visible = true;
            if (e.Type == "year")
            {
                StudentEntry1.LoadStudentGroup(e, AcademicYearId, e.ProgramId, e.YearId, programBatchId: e.ProgramBatchId);
            }
            else if (e.Type == "subyear")
            {
                StudentEntry1.LoadStudentGroup(e, AcademicYearId, e.ProgramId, e.YearId, SessionId, e.SubYearId, e.ProgramBatchId);
            }
            //Context.Items["node_clicked"] = node;
            Session["node_clicked"] = node;
            NodeClicked = node;
            //ViewState["node_clicked"] = node;

        }
        void StudentEntry1_CloseClicked(object sender, MessageEventArgs e)
        {
            pnlStudentEntry.Visible = false;
        }

        void StudentEntry1_SaveClicked(object sender, RunningClassEventArgs e)
        {
            //TreeNodeUC node = (TreeNodeUC) Context.Items["node_clicked"];// ViewState["node_clicked"];
            TreeNodeUC node = (TreeNodeUC)Session["node_clicked"];
            TreeNodeUC clickedNode = NodeClicked;
            if (node != null)
            {
                node.ProgramBatchId = e.ProgramBatchId;
            }
            Root.SetProgramBatchIdInNode(Root, node, e.ProgramBatchId.ToString(), e.ProgramBatchName);
            //Root.FindChildControl(Root,node);
            StudentEntry1_CloseClicked(sender, new MessageEventArgs());
        }

        //======================Student Group Dialog END ========================//

        #endregion

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
                                if (year.Type == "year")//&& year.Checked
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
                                            Void = !year.Checked
                                            ,
                                        };
                                        //if (sessionId > 0)
                                        //    cls.SessionId = sessionId;
                                        if (year.ProgramBatchId != 0)
                                            cls.ProgramBatchId = year.ProgramBatchId;
                                        classes.Add(cls);
                                    }
                                }
                                foreach (var subyear in year.ChildNodes)
                                {
                                    if (subyear.Type == "subyear")//&& subyear.Checked
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
                                            ,
                                            Void = !subyear.Checked
                                            ,
                                            
                                        };
                                        if (sessionId > 0)
                                            cls.SessionId = sessionId;
                                        if (subyear.ProgramBatchId != 0)
                                            cls.ProgramBatchId = subyear.ProgramBatchId;
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

        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{
        //    CheckBox1.Checked = !CheckBox1.Checked;
        //}




        /*    public object GetClassStructureInTreeView(int schoolId, int academicYearId, int sessionId = 0)
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
    }*/


    }
}