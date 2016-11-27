using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.AcacemicPlacements;
using Academic.DbEntities.Exams;
using Academic.DbHelper;
using One.Values;
using One.Values.MemberShip;

namespace One.Views.Academy.ProgramSelection.OnlyListing
{
    public partial class ProgramSelection : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BatchSelect.DoneClicked += BatchSelect_DoneClicked;
            BatchSelect.BatchSelected += BatchSelect_BatchSelected;

            /* if (!IsPostBack)
             {
                 //here key is program id and value is list <programbatch id>
                 Session["AlreadySelectedProgramBatches"] = new Dictionary<int, List<int>>();

                 Session["RunningClassYear"] = new RunningClassEventArgs();
                 var aId = Request.QueryString["aId"];
                 var sId = Request.QueryString["sId"];
                 if (aId != null)
                 {
                     try
                     {
                         AcademicYearId = Convert.ToInt32(aId);
                         if (sId != null)
                         {
                             // then its for session, so display only those years whose subyears are present
                             SessionId = Convert.ToInt32(sId);
                         }
                     }
                     catch
                     {
                         Response.Redirect("../List.aspx");
                     }
                 }
                 else
                 {
                     Response.Redirect("../List.aspx");
                 }
             }*/
            //var user = Page.User as CustomPrincipal;
            //if (user != null)
            //{
            //    //LoadStructure(user.SchoolId);
            //}

        }

        void BatchSelect_BatchSelected(object sender, ProgramBatchEventArgs e)
        {
            var sessionId = SessionId;
            var rc = Session["RunningClassYear"] as RunningClassEventArgs;
            if (rc != null)
            {
                var pCntrl =
                            pnlProgramListing.FindControl("programControl" + rc.ProgramId) as ProgramUC;
                if (pCntrl != null)
                {
                    var yCntrl = pCntrl.FindCustomControl("yearControl" + rc.YearId) as YearU;
                    if (yCntrl != null)
                    {
                        if (sessionId > 0)
                        {
                            var sCntrl =
                                yCntrl.FindCustomControl("subyearControl" + rc.SubYearId) as SubYearUC;
                            if (sCntrl != null)
                            {
                                sCntrl.SetSelectedBatch(e.ProgramBatchId
                                    , (e.ProgramBatchName == "None") ? "" : e.ProgramBatchName
                                    , rc.RunningClassId);
                            }
                        }
                        else
                        {
                            yCntrl.SetSelectedBatch(e.ProgramBatchId
                                , (e.ProgramBatchName == "None") ? "" : e.ProgramBatchName
                                , rc.RunningClassId);
                        }
                    }
                }
                //var lCntrl = pnlProgramListing.FindControl("levelControl" + rc.LevelId) as ListLevelUC;
                //if (lCntrl != null)
                //{
                //    var fCntrl = lCntrl.FindCustomControl("facultyControl" + rc.FacultyId) as ListFacultyUC;
                //    if (fCntrl != null)
                //    {
                        
                //    }
                //}
            }

        }

        void BatchSelect_DoneClicked(object sender, EventArgs e)
        {
            pnlBatchSelect.Visible = false;
        }

        public int AcademicYearId
        {
            get { return Convert.ToInt32(hidAcademicYearId.Value); }
            set { hidAcademicYearId.Value = value.ToString(); }
        }
        public int SessionId
        {
            get { return Convert.ToInt32(hidSessionId.Value); }
            set { hidSessionId.Value = value.ToString(); }
        }
        public int ExamId
        {
            get { return Convert.ToInt32(hidExamId.Value); }
            set { hidExamId.Value = value.ToString(); }
        }


        //public void LoadStructure(List<RunningClass> rList, int academicYearId, int sessionId, int examId)
        //{
        //    AcademicYearId = academicYearId;
        //    SessionId = sessionId;
        //    ExamId = examId;
        //    var progs = rList.GroupBy(x => x.Year.Program);
        //    using (var exHelper = new DbHelper.Exam())
        //    {
        //        //var progs = f.GroupBy(x => x.Year.Program);
        //        foreach (var p in progs)
        //        {
        //            //only those running class is present whose program Id = p
        //            var puc = (ProgramUC)
        //                                        Page.LoadControl("~/Views/Academy/ProgramSelection/OnlyListing/ProgramUC.ascx");
        //            puc.SetName(p.Key.Id, p.Key.Name, "");
        //            puc.ID = "programControl" + p.Key.Id;
        //            puc.ClientIDMode = ClientIDMode.Static;
        //            pnlProgramListing.Controls.Add(puc);

        //            var years = p.GroupBy(x => x.Year);
        //            foreach (var y in years)
        //            {
        //                //year post to view//each year
        //                //add uc of year but don't add checkbox here; chkbox will be added in if clause below

        //                foreach (var ry in y)
        //                {
        //                    var yuc = (YearU)
        //                                                Page.LoadControl(
        //                                                "~/Views/Academy/ProgramSelection/OnlyListing/YearU.ascx");
        //                    yuc.ClientIDMode = ClientIDMode.Static;
        //                    yuc.ID = "yearControl" + y.Key.Id;
        //                    yuc.SetIds( p.Key.Id, y.Key.Id, 0);
        //                    yuc.SetName(p.Key.Name, y.Key.Name, "");//y.Id, y.Name, p.Id, "");

        //                    yuc.BatchSelectClicked += yuc_BatchSelectClicked;
        //                    puc.AddControl(yuc);

        //                    var sub = rList.Where(x => x.YearId == y.Key.Id && (x.SubYearId ?? 0) != 0).ToList();
        //                    if (!sub.Any())
        //                    {
        //                        //then it has only year so add check box to this year
        //                        //yuc.SetImageUrl();
        //                        //yuc.ImageVisibility = true;

        //                        var ex = exHelper.GetExamOfClass(ry.Id, examId);
        //                        yuc.SetSelectedBatch(ry.ProgramBatchId ?? 0
        //                            , ry.ProgramBatch.NameFromBatch
        //                            , ry.Id
        //                            , ex);
        //                        //yuc.Checked = true;

        //                    }
        //                    else
        //                    {
        //                        //it has subyear so don't add check box to the year but add chkbox to subyear
        //                        //yuc.ImageVisibility = false;
        //                        foreach (var s in sub)
        //                        {
        //                            var suc = (SubYearUC)Page
        //                                                .LoadControl("~/Views/Academy/ProgramSelection/OnlyListing/SubYearUC.ascx");
        //                            suc.ClientIDMode = ClientIDMode.Static;
        //                            suc.ID = "subyearControl" + s.Id;
        //                            suc.SetIds(l.Key.Id, f.Key.Id, p.Key.Id, y.Key.Id, s.Id);
        //                            suc.SetName(p.Key.Name, y.Key.Name, s.SubYear.Name);
        //                            suc.BatchSelectClicked += suc_BatchSelectClicked;

        //                            var ex = exHelper.GetExamOfClass(s.Id, examId);
        //                            suc.SetSelectedBatch(s.ProgramBatchId ?? 0
        //                                , s.ProgramBatch.NameFromBatch
        //                                , s.Id
        //                                , ex);

        //                            yuc.Checked = (ex == null) ? false : !(ex.Void ?? false);

        //                            yuc.AddControl(suc);


        //                        }

        //                    }

        //                }
        //            }

        //        }

        //        //foreach (var l in levels)
        //        //{
        //        //    //each level 
        //        //    var luc = (ListLevelUC)Page
        //        //                .LoadControl("~/Views/Academy/ProgramSelection/ListLevelUC.ascx");
        //        //    luc.SetName(l.Key.Id, "", "");//l.Key.Name

        //        //    luc.ID = "levelControl" + l.Key.Id;
        //        //    luc.ClientIDMode = ClientIDMode.Static;
        //        //    pnlProgramListing.Controls.Add(luc);


        //        //    var facs = l.GroupBy(x => x.Year.Program.Faculty);
        //        //    foreach (var f in facs)
        //        //    {

        //        //        var fuc = (ListFacultyUC)Page
        //        //                     .LoadControl("~/Views/Academy/ProgramSelection/ListFacultyUC.ascx");
        //        //        fuc.ID = "facultyControl" + f.Key.Id;
        //        //        fuc.ClientIDMode = ClientIDMode.Static;
        //        //        fuc.SetName(f.Key.Id, f.Key.Name, "");
        //        //        luc.AddControl(fuc);


                      
        //        //    }
        //        //}
        //    }

        //}

        //public void LoadStructure(int schoolId, int academicYearId, int sessionId)
        //{
        //    AcademicYearId = academicYearId;
        //    SessionId = sessionId;

        //    // key: program, Value: list of programBatch
        //    var alreadySelected = Session["AlreadySelectedProgramBatches"] as Dictionary<int, List<int>>;

        //    if (alreadySelected != null)
        //        using (var pbHelper = new DbHelper.AcademicPlacement())
        //        using (var helper = new DbHelper.Structure())
        //        {
        //            //int sessionId = SessionId;
        //            //int academicYearId = AcademicYearId;
        //            helper.GetLevels(schoolId).ForEach(l =>
        //            {
        //                var luc = (ListLevelUC)Page
        //                    .LoadControl("~/Views/Academy/ProgramSelection/ListLevelUC.ascx");
        //                luc.SetName(l.Id, l.Name, "");

        //                luc.ID = "levelControl" + l.Id;
        //                luc.ClientIDMode = ClientIDMode.Static;

        //                var faculties = helper.GetFaculties(l.Id);
        //                var anyFaculty = false;

        //                if (faculties.Any())
        //                {
        //                    anyFaculty = true;
        //                    faculties.ForEach(f =>
        //                    {
        //                        var anyPrograms = false;
        //                        var anyYears = false;

        //                        var programs = helper.GetPrograms(f.Id);
        //                        var fuc = (ListFacultyUC)Page
        //                           .LoadControl("~/Views/Academy/ProgramSelection/ListFacultyUC.ascx");

        //                        fuc.ID = "facultyControl" + f.Id;
        //                        fuc.ClientIDMode = ClientIDMode.Static;

        //                        if (programs.Any())
        //                        {
        //                            anyPrograms = true;
        //                        }

        //                        programs.ForEach(p =>
        //                        {
        //                            //var puc = (ListUC)Page
        //                            //    .LoadControl("~/Views/Structure/All/UserControls/ListUC.ascx")
        //                            //      ;
        //                            var years = helper.GetYears(p.Id);
        //                            var puc = (ProgramUC)
        //                                            Page.LoadControl("~/Views/Academy/ProgramSelection/OnlyListing/ProgramUC.ascx");

        //                            if (years.Any())
        //                            {
        //                                puc.SetName(p.Id, p.Name, "");
        //                                puc.ID = "programControl" + p.Id;
        //                                puc.ClientIDMode = ClientIDMode.Static;
        //                                fuc.AddControl(puc);

        //                                //add these programs to the dictionary key values
        //                                var key = alreadySelected.Keys.FirstOrDefault(q => q == p.Id);
        //                                //if (alreadySelected[p.Id] == null)
        //                                if (key <= 0)
        //                                {
        //                                    alreadySelected[p.Id] = new List<int>();
        //                                }

        //                            }


        //                            years.ForEach(y =>
        //                            {
        //                                var subyears = helper.GetSubYears(y.Id, true);

        //                                if (!subyears.Any())
        //                                {
        //                                    if (sessionId <= 0)
        //                                    {
        //                                        var yuc = (YearU)
        //                                                Page.LoadControl(
        //                                                "~/Views/Academy/ProgramSelection/OnlyListing/YearU.ascx");

        //                                        //yuc.CourseClicked+=subYear_CourseClicked;
        //                                        yuc.SetIds(l.Id, f.Id, p.Id, y.Id, 0);
        //                                        yuc.SetName(p.Name, y.Name, "");//y.Id, y.Name, p.Id, "");

        //                                        yuc.ClientIDMode = ClientIDMode.Static;
        //                                        yuc.ID = "yearControl" + y.Id;

        //                                        puc.AddControl(yuc);
        //                                        anyYears = true;

        //                                        //yuc.SetImageUrl();
        //                                        //yuc.ImageVisibility = true;
        //                                        yuc.BatchSelectClicked += yuc_BatchSelectClicked;

        //                                        //work remain:
        //                                        //get programbatchId for this year and then add it to the 
        //                                        // alreadySelected session list
        //                                        //    also populate the selected batch for this year
        //                                        //        this task is to be done for subyears too

        //                                        //Get ProgramBatchId for this year
        //                                        var rcls = pbHelper.GetRunningClassInAcademicYear(academicYearId,
        //                                            y.Id, sessionId, 0);
        //                                        if (rcls != null)
        //                                        {
        //                                            if (!(rcls.Void ?? false))
        //                                            {
        //                                                if (!alreadySelected[p.Id].Contains(rcls.ProgramBatchId ?? 0)
        //                                                                                                        && !IsPostBack)
        //                                                {
        //                                                    alreadySelected[p.Id].Add(rcls.ProgramBatchId ?? 0);
        //                                                }
        //                                                //Now display 
        //                                                yuc.SetSelectedBatch(rcls.ProgramBatchId ?? 0,
        //                                                    rcls.ProgramBatch.NameFromBatch, rcls.Id);
        //                                                yuc.Checked = true;
        //                                            }
        //                                            else
        //                                            {
        //                                                //this is done to unvoid the previously voided data..
        //                                                // so that no duplicate data(one with void and next with no-void)
        //                                                //is made in running class
        //                                                yuc.SetSelectedBatch(0, "", rcls.Id);
        //                                            }

        //                                        }

        //                                    }
        //                                    //display course info in this year since no subyear
        //                                    //course info is only in subyearUC
        //                                    //var yuc = (SubYearUC)Page
        //                                    //        .LoadControl("~/Views/Structure/All/UserControls/SubYearUC.ascx");
        //                                    //var yuc = (YearU)
        //                                    //            Page.LoadControl(
        //                                    //            "~/Views/Academy/ProgramSelection/OnlyListing/YearU.ascx");

        //                                }
        //                                else
        //                                {
        //                                    if (sessionId > 0)
        //                                    {
        //                                        anyYears = true;
        //                                        var yuc = (YearU)
        //                                                     Page.LoadControl(
        //                                                     "~/Views/Academy/ProgramSelection/OnlyListing/YearU.ascx");

        //                                        yuc.ClientIDMode = ClientIDMode.Static;
        //                                        yuc.ID = "yearControl" + y.Id;

        //                                        yuc.SetIds(l.Id, f.Id, p.Id, y.Id, 0);
        //                                        yuc.SetName(p.Name, y.Name, "");
        //                                        //yuc.ImageVisibility = false;
        //                                        yuc.BatchSelectClicked += yuc_BatchSelectClicked;
        //                                        puc.AddControl(yuc);


        //                                        //Get ProgramBatchId for this year
        //                                        //var pbatch = pbHelper.GetProgramBatchInAcademicYear(academicYearId,
        //                                        //    y.Id, sessionId, 0);
        //                                        //if (pbatch != null)
        //                                        //{
        //                                        //    alreadySelected[p.Id].Add(pbatch.Id);
        //                                        //    //Now display 
        //                                        //    yuc.SetSelectedBatch(pbatch.Id, pbatch.NameFromBatch);
        //                                        //}


        //                                        //get subyears
        //                                        subyears.ForEach(s =>
        //                                        {
        //                                            //rdList.Items.Add(new ListItem(s.Name, s.Id.ToString()));

        //                                            var suc = (SubYearUC)Page
        //                                                .LoadControl("~/Views/Academy/ProgramSelection/OnlyListing/SubYearUC.ascx");
        //                                            //suc.CourseClicked += subYear_CourseClicked;

        //                                            suc.ClientIDMode = ClientIDMode.Static;
        //                                            suc.ID = "subyearControl" + s.Id;
        //                                            suc.SetIds(l.Id, f.Id, p.Id, y.Id, s.Id);
        //                                            suc.SetName(p.Name, y.Name, s.Name);
        //                                            //suc.SetName(y.Id, s.Id, s.Name, p.Id);
        //                                            suc.BatchSelectClicked += suc_BatchSelectClicked;
        //                                            yuc.AddControl(suc);


        //                                            //Get ProgramBatchId for this subyear
        //                                            var rcls = pbHelper.GetRunningClassInAcademicYear(academicYearId,
        //                                                           y.Id, sessionId, s.Id);
        //                                            if (rcls != null)
        //                                            {
        //                                                if (!(rcls.Void ?? false))
        //                                                {
        //                                                    if (!alreadySelected[p.Id].Contains(rcls.ProgramBatchId ?? 0)
        //                                                                                                                && !IsPostBack)
        //                                                    {
        //                                                        alreadySelected[p.Id].Add(rcls.ProgramBatchId ?? 0);
        //                                                    }
        //                                                    //Now display 

        //                                                    suc.SetSelectedBatch(rcls.ProgramBatchId ?? 0, rcls.ProgramBatch.NameFromBatch, rcls.Id);
        //                                                    //suc.Checked = true;
        //                                                    yuc.Checked = true;
        //                                                }
        //                                                else
        //                                                {
        //                                                    //runnning class is void
        //                                                    //this is done to unvoid the previously voided data..
        //                                                    // so that no duplicate data(one with void and next with no-void)
        //                                                    //is made in running class
        //                                                    suc.SetSelectedBatch(0, "", rcls.Id);
        //                                                }

        //                                            }


        //                                        });
        //                                        //yuc.AddControl(rdList);
        //                                    }

        //                                }
        //                            });
        //                        });
        //                        if (anyPrograms && anyYears)
        //                        {
        //                            //years xa bhane matra faculty print garne
        //                            fuc.SetName(f.Id, f.Name, "");
        //                            luc.AddControl(fuc);
        //                        }
        //                    });
        //                }
        //                if (anyFaculty)
        //                {
        //                    pnlProgramListing.Controls.Add(luc);
        //                }
        //            });
        //        }
        //}

        void suc_BatchSelectClicked(object sender, RunningClassEventArgs e)
        {
            Session["RunningClassYear"] = e;
            lblBatchSelectionHeading.Text = "Batch selection for: " + e.ProgrameName + ">" + e.YearName +
                                            ((e.SubYearName == "") ? "" : ">" + e.SubYearName);
            BatchSelect.LoadBatches(e.ProgramId, AcademicYearId, SessionId, e.ProgramBatchId);
            pnlBatchSelect.Visible = true;
        }

        void yuc_BatchSelectClicked(object sender, RunningClassEventArgs e)
        {
            Session["RunningClassYear"] = e;
            lblBatchSelectionHeading.Text = "Batch selection for: " + e.ProgrameName + ">" + e.YearName +
                                            ((e.SubYearName == "") ? "" : ">" + e.SubYearName);
            BatchSelect.LoadBatches(e.ProgramId, AcademicYearId, SessionId, e.ProgramBatchId);
            pnlBatchSelect.Visible = true;
        }

        public void btnCancel_Click(object sender, EventArgs args)
        {
            Response.Redirect("~/Views/Academy/List.aspx");
        }

        public void btnSave_Click(object sender, EventArgs args)
        {
            //Save();
        }


        /*
        void Save()
        {

            //var rc = Session["RunningClassYear"] as RunningClassEventArgs;
            //if (rc != null)
            int sessionId = SessionId;
            int academicYearId = AcademicYearId;
            var list = new List<RunningClass>();

            //var lCntrl = pnlProgramListing.FindControl("levelControl" + rc.LevelId) as ListLevelUC;
            foreach (ListLevelUC l in pnlProgramListing.Controls)
            {
                foreach (var f in l.GetControls())
                {
                    foreach (var p in f.GetControls())
                    {
                        foreach (var y in p.GetControls())
                        {
                            if (SessionId > 0)
                            {
                                //year and subyear both must be included
                                foreach (var s in y.GetControls())
                                {
                                    //if no data was previously saved and no batch assinged then don't add to list
                                    if (s.Checked || s.RunningClassId > 0)
                                        if (s.SelectedProgramBatchId > 0 || s.RunningClassId > 0)
                                        {
                                            var rc = new RunningClass()
                                            {
                                                Id = s.RunningClassId
                                                ,
                                                AcademicYearId = academicYearId
                                                ,
                                                YearId = s.YearId
                                                ,
                                                SubYearId = s.SubYearId
                                                ,
                                                SessionId = sessionId
                                                ,
                                                Void = !(s.Checked)
                                            };
                                            if (s.SelectedProgramBatchId > 0)
                                            {
                                                rc.ProgramBatchId = s.SelectedProgramBatchId;
                                            }
                                            list.Add(rc);
                                        }

                                }
                            }
                            else
                            {
                                //only year, no subyear
                                //if no data was previously saved and no batch assinged then don't add to list
                                if (y.Checked || y.RunningClassId > 0)
                                    if (y.SelectedProgramBatchId > 0 || y.RunningClassId > 0)
                                    {
                                        var rc = new RunningClass()
                                        {
                                            Id = y.RunningClassId
                                            ,
                                            AcademicYearId = academicYearId
                                            ,
                                            YearId = y.YearId
                                            ,
                                            Void = (!y.Checked)
                                        };
                                        if (y.SelectedProgramBatchId > 0)
                                        {
                                            rc.ProgramBatchId = y.SelectedProgramBatchId;
                                        }
                                        list.Add(rc);
                                    }
                            }

                        }
                    }
                }
            }
            //save
            if (list.Any())
            {
                using (var helper = new DbHelper.AcademicPlacement())
                {
                    var saved = helper.AddRunningClass(list);
                    if (saved)
                    {
                        if (sessionId > 0)
                        {
                            Response.Redirect("~/Views/Academy/AcademicYear/AcademicYearDetail.aspx?aId=" +
                                              academicYearId + "&sId=" + sessionId);
                        }
                        else
                        {
                            Response.Redirect("~/Views/Academy/AcademicYear/AcademicYearDetail.aspx?aId=" +
                                              academicYearId);
                        }
                    }
                    //if (saved) Response.Redirect("~/Views/Academy/List.aspx");
                }
            }
        }
        */
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("~" + Request.Url.PathAndQuery, true);
        }


        //All get functions
        //public List<RunningClass> GetStructures()
        //{

        //    //var rc = Session["RunningClassYear"] as RunningClassEventArgs;
        //    //if (rc != null)
        //    int sessionId = SessionId;
        //    int academicYearId = AcademicYearId;
        //    var list = new List<RunningClass>();

        //    //var lCntrl = pnlProgramListing.FindControl("levelControl" + rc.LevelId) as ListLevelUC;
        //    foreach (ListLevelUC l in pnlProgramListing.Controls)
        //    {
        //        foreach (var f in l.GetControls())
        //        {
        //            foreach (var p in f.GetControls())
        //            {
        //                foreach (var y in p.GetControls())
        //                {
        //                    if (SessionId > 0)
        //                    {
        //                        //year and subyear both must be included
        //                        foreach (var s in y.GetControls())
        //                        {
        //                            //if no data was previously saved and no batch assinged then don't add to list
        //                            if (y.Checked || s.RunningClassId > 0)
        //                            // if (s.SelectedProgramBatchId > 0 || s.RunningClassId > 0)
        //                            {
        //                                var rc = new RunningClass()
        //                                {
        //                                    Id = s.RunningClassId
        //                                    ,
        //                                    AcademicYearId = academicYearId
        //                                    ,
        //                                    YearId = s.YearId
        //                                    ,
        //                                    SubYearId = s.SubYearId
        //                                    ,
        //                                    SessionId = sessionId
        //                                    ,
        //                                    Void = !(s.Checked)
        //                                };
        //                                if (s.SelectedProgramBatchId > 0)
        //                                {
        //                                    rc.ProgramBatchId = s.SelectedProgramBatchId;
        //                                }
        //                                list.Add(rc);
        //                            }

        //                        }
        //                    }
        //                    else
        //                    {
        //                        //only year, no subyear
        //                        //if no data was previously saved and no batch assinged then don't add to list
        //                        if (y.Checked || y.RunningClassId > 0)
        //                        // if (y.SelectedProgramBatchId > 0 || y.RunningClassId > 0)
        //                        {
        //                            var rc = new RunningClass()
        //                            {
        //                                Id = y.RunningClassId
        //                                ,
        //                                AcademicYearId = academicYearId
        //                                ,
        //                                YearId = y.YearId
        //                                ,
        //                                Void = (!y.Checked)
        //                            };
        //                            if (y.SelectedProgramBatchId > 0)
        //                            {
        //                                rc.ProgramBatchId = y.SelectedProgramBatchId;
        //                            }
        //                            list.Add(rc);
        //                        }
        //                    }

        //                }
        //            }
        //        }
        //    }
        //    return list;
        //    //save
        //    //if (list.Any())
        //    //{
        //    //    using (var helper = new DbHelper.AcademicPlacement())
        //    //    {
        //    //        var saved = helper.AddRunningClass(list);
        //    //        if (saved)
        //    //        {
        //    //            if (sessionId > 0)
        //    //            {
        //    //                Response.Redirect("~/Views/Academy/AcademicYear/AcademicYearDetail.aspx?aId=" +
        //    //                                  academicYearId + "&sId=" + sessionId);
        //    //            }
        //    //            else
        //    //            {
        //    //                Response.Redirect("~/Views/Academy/AcademicYear/AcademicYearDetail.aspx?aId=" +
        //    //                                  academicYearId);
        //    //            }
        //    //        }
        //    //        //if (saved) Response.Redirect("~/Views/Academy/List.aspx");
        //    //    }
        //    //}

        //    //return null;
        //}

        //public List<Academic.DbEntities.Exams.ExamOfClass> GetData()
        //{

        //    //var rc = Session["RunningClassYear"] as RunningClassEventArgs;
        //    //if (rc != null)
        //    var user = Page.User as CustomPrincipal;
        //    int sessionId = SessionId;
        //    int academicYearId = AcademicYearId;
        //    var list = new List<Academic.DbEntities.Exams.ExamOfClass>();

        //    //var lCntrl = pnlProgramListing.FindControl("levelControl" + rc.LevelId) as ListLevelUC;
        //    foreach (ListLevelUC l in pnlProgramListing.Controls)
        //    {
        //        foreach (var f in l.GetControls())
        //        {
        //            foreach (var p in f.GetControlsOfListing())
        //            {
        //                foreach (var y in p.GetControlsOfListing())
        //                {
        //                    if (SessionId > 0)
        //                    {
        //                        //year and subyear both must be included
        //                        foreach (var s in y.GetControls())
        //                        {
        //                            //if no data was previously saved and no batch assinged then don't add to list
        //                            if (y.Checked || s.ExamOfClassId > 0)
        //                            // if (s.SelectedProgramBatchId > 0 || s.RunningClassId > 0)
        //                            {
        //                                var eoc = new Academic.DbEntities.Exams.ExamOfClass()
        //                                {
        //                                    Id = s.ExamOfClassId
        //                                    ,
        //                                    RunningClassId = s.RunningClassId
        //                                    ,
        //                                    Void = !(y.Checked)
                                            
        //                                };
        //                                //if (s.SelectedProgramBatchId > 0)
        //                                //{
        //                                //    rc.ProgramBatchId = s.SelectedProgramBatchId;
        //                                //}
        //                                list.Add(eoc);
        //                            }

        //                        }
        //                    }
        //                    else
        //                    {
        //                        //only year, no subyear
        //                        //if no data was previously saved and no batch assinged then don't add to list
        //                        if (y.Checked || y.ExamOfClassId > 0)
        //                        // if (y.SelectedProgramBatchId > 0 || y.RunningClassId > 0)
        //                        {
        //                            var eoc = new Academic.DbEntities.Exams.ExamOfClass()
        //                                {
        //                                    Id = y.ExamOfClassId
        //                                    ,
        //                                    RunningClassId = y.RunningClassId
        //                                    ,
        //                                    Void = !(y.Checked)
        //                                    ,
        //                                };
                                    
        //                            //if (y.SelectedProgramBatchId > 0)
        //                            //{
        //                            //    y.ProgramBatchId = y.SelectedProgramBatchId;
        //                            //}
        //                            list.Add(eoc);
        //                        }
        //                    }

        //                }
        //            }
        //        }
        //    }
        //    return list;
        //    //save
        //    //if (list.Any())
        //    //{
        //    //    using (var helper = new DbHelper.AcademicPlacement())
        //    //    {
        //    //        var saved = helper.AddRunningClass(list);
        //    //        if (saved)
        //    //        {
        //    //            if (sessionId > 0)
        //    //            {
        //    //                Response.Redirect("~/Views/Academy/AcademicYear/AcademicYearDetail.aspx?aId=" +
        //    //                                  academicYearId + "&sId=" + sessionId);
        //    //            }
        //    //            else
        //    //            {
        //    //                Response.Redirect("~/Views/Academy/AcademicYear/AcademicYearDetail.aspx?aId=" +
        //    //                                  academicYearId);
        //    //            }
        //    //        }
        //    //        //if (saved) Response.Redirect("~/Views/Academy/List.aspx");
        //    //    }
        //    //}

        //    //return null;
        //}


    }
}