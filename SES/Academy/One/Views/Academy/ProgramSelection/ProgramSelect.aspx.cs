using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.AcacemicPlacements;
using Academic.DbHelper;
using One.Values;
using One.Values.MemberShip;
using One.Views.Academy.ProgramSelection.OnlyListing;

namespace One.Views.Academy.ProgramSelection
{
    public partial class ProgramSelect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BatchSelect.DoneClicked += BatchSelect_DoneClicked;
            BatchSelect.BatchSelected += BatchSelect_BatchSelected;
            if (!IsPostBack)
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
            }



            var user = Page.User as CustomPrincipal;
            if (user != null)
            {
                LoadStructure(user.SchoolId);
            }

        }

        void BatchSelect_BatchSelected(object sender, ProgramBatchEventArgs e)
        {
            var rc = Session["RunningClassYear"] as RunningClassEventArgs;
            if (rc != null)
            {
                var pCntrl =
                            pnlProgramListing.FindControl("programControl" + rc.ProgramId) as ProgramCheckBoxAndLabel;
                if (pCntrl != null)
                {
                    var yCntrl = pCntrl.FindCustomControl("yearControl" + rc.YearId) as YearCheckBoxAndLabel;
                    if (yCntrl != null)
                    {
                        if (SessionId > 0)
                        {
                            var sCntrl =
                                yCntrl.FindCustomControl("subyearControl" + rc.SubYearId) as ListSubYearUC;
                            if (sCntrl != null)
                            {
                                sCntrl.SetSelectedBatch(e.ProgramBatchId
                                    , (e.ProgramBatchName == "None") ? "" : e.ProgramBatchName
                                    , rc.RunningClassId
                                    , e.ProgramBatchName == "None");
                                if (e.ProgramBatchId > 0)
                                {
                                    yCntrl.Checked = true;
                                }
                            }
                        }
                        else
                        {
                            yCntrl.SetSelectedBatch(e.ProgramBatchId
                                , (e.ProgramBatchName == "None") ? "" : e.ProgramBatchName
                                , rc.RunningClassId
                                , e.ProgramBatchName == "None");
                            if (e.ProgramBatchId > 0) yCntrl.Checked = true;
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

        private void LoadStructure(int schoolId)
        {
            // key: program, Value: list of programBatch
            var alreadySelected = Session["AlreadySelectedProgramBatches"] as Dictionary<int, List<int>>;

            if (alreadySelected != null)
                using (var pbHelper = new DbHelper.AcademicPlacement())
                using (var helper = new DbHelper.Structure())
                {
                    int sessionId = SessionId;
                    int academicYearId = AcademicYearId;

                    var anyPrograms = false;
                    var anyYears = false;

                    var programs = helper.ListPrograms(schoolId);
                    //var fuc = (ListFacultyUC)Page
                    //   .LoadControl("~/Views/Academy/ProgramSelection/ListFacultyUC.ascx");

                    //fuc.ID = "facultyControl" + f.Id;
                    //fuc.ClientIDMode = ClientIDMode.Static;

                    if (programs.Any())
                    {
                        anyPrograms = true;
                    }

                    programs.ForEach(p =>
                    {
                        //var puc = (ListUC)Page
                        //    .LoadControl("~/Views/Structure/All/UserControls/ListUC.ascx")
                        //      ;
                        var years = helper.GetYears(p.Id);
                        var puc = (ProgramCheckBoxAndLabel)
                                        Page.LoadControl("~/Views/Academy/ProgramSelection/ProgramCheckBoxAndLabel.ascx");

                        if (years.Any())
                        {
                            puc.SetName(p.Id, p.Name, "");
                            puc.ID = "programControl" + p.Id;
                            puc.ClientIDMode = ClientIDMode.Static;
                            pnlProgramListing.Controls.Add(puc);

                            //add these programs to the dictionary key values
                            if (!IsPostBack)
                            {
                                var key = alreadySelected.Keys.FirstOrDefault(q => q == p.Id);
                                //if (alreadySelected[p.Id] == null)
                                if (key <= 0)
                                {
                                    alreadySelected[p.Id] = new List<int>();
                                }
                            }
                        }


                        years.ForEach(y =>
                        {
                            var subyears = helper.GetSubYears(y.Id, true);

                            if (!subyears.Any())
                            {
                                #region No subYears

                                if (sessionId <= 0)
                                {
                                    var yuc = (YearCheckBoxAndLabel)
                                            Page.LoadControl(
                                            "~/Views/Academy/ProgramSelection/YearCheckBoxAndLabel.ascx");

                                    //yuc.CourseClicked+=subYear_CourseClicked;
                                    yuc.SetIds( p.Id, y.Id, 0);
                                    yuc.SetName(p.Name, y.Name, "");//y.Id, y.Name, p.Id, "");

                                    yuc.ClientIDMode = ClientIDMode.Static;
                                    yuc.ID = "yearControl" + y.Id;

                                    puc.AddControl(yuc);
                                    anyYears = true;

                                    yuc.SetImageUrl();
                                    yuc.ImageVisibility = true;
                                    yuc.BatchSelectClicked += yuc_BatchSelectClicked;

                                    //work remain:
                                    //get programbatchId for this year and then add it to the 
                                    // alreadySelected session list
                                    //    also populate the selected batch for this year
                                    //        this task is to be done for subyears too

                                    //Get ProgramBatchId for this year
                                    var rcls = pbHelper.GetRunningClassInAcademicYear(academicYearId,
                                        y.Id, sessionId, 0);
                                    if (rcls != null)
                                    {
                                        if (!(rcls.Void ?? false))
                                        {
                                            if (!alreadySelected[p.Id].Contains(rcls.ProgramBatchId ?? 0)
                                                                                                    && !IsPostBack)
                                            {
                                                alreadySelected[p.Id].Add(rcls.ProgramBatchId ?? 0);
                                            }
                                            //Now display 
                                            yuc.SetSelectedBatch(rcls.ProgramBatchId ?? 0,
                                                rcls.ProgramBatch.NameFromBatch, rcls.Id);
                                            yuc.Checked = true;
                                        }
                                        else
                                        {
                                            //this is done to unvoid the previously voided data..
                                            // so that no duplicate data(one with void and next with no-void)
                                            //is made in running class
                                            yuc.SetSelectedBatch(0, "", rcls.Id);
                                        }

                                    }

                                }

                                #endregion

                                //display course info in this year since no subyear
                                //course info is only in subyearUC
                                //var yuc = (ListSubYearUC)Page
                                //        .LoadControl("~/Views/Structure/All/UserControls/ListSubYearUC.ascx");
                                //var yuc = (YearCheckBoxAndLabel)
                                //            Page.LoadControl(
                                //            "~/Views/Academy/ProgramSelection/YearCheckBoxAndLabel.ascx");

                            }
                            else
                            {
                                if (sessionId > 0)
                                {
                                    #region There are subYears

                                    anyYears = true;
                                    var yuc = (YearCheckBoxAndLabel)
                                                 Page.LoadControl(
                                                 "~/Views/Academy/ProgramSelection/YearCheckBoxAndLabel.ascx");

                                    yuc.ClientIDMode = ClientIDMode.Static;
                                    yuc.ID = "yearControl" + y.Id;

                                    yuc.SetIds( p.Id, y.Id, 0);
                                    yuc.SetName(p.Name, y.Name, "");
                                    yuc.ImageVisibility = false;
                                    yuc.BatchSelectClicked += yuc_BatchSelectClicked;
                                    puc.AddControl(yuc);


                                    //Get ProgramBatchId for this year
                                    //var pbatch = pbHelper.GetProgramBatchInAcademicYear(academicYearId,
                                    //    y.Id, sessionId, 0);
                                    //if (pbatch != null)
                                    //{
                                    //    alreadySelected[p.Id].Add(pbatch.Id);
                                    //    //Now display 
                                    //    yuc.SetSelectedBatch(pbatch.Id, pbatch.NameFromBatch);
                                    //}


                                    //get subyears
                                    subyears.ForEach(s =>
                                    {
                                        //rdList.Items.Add(new ListItem(s.Name, s.Id.ToString()));

                                        var suc = (ListSubYearUC)Page
                                            .LoadControl("~/Views/Academy/ProgramSelection/ListSubYearUC.ascx");
                                        //suc.CourseClicked += subYear_CourseClicked;

                                        suc.ClientIDMode = ClientIDMode.Static;
                                        suc.ID = "subyearControl" + s.Id;
                                        suc.SetIds( p.Id, y.Id, s.Id);
                                        suc.SetName(p.Name, y.Name, s.Name);
                                        //suc.SetName(y.Id, s.Id, s.Name, p.Id);
                                        suc.BatchSelectClicked += suc_BatchSelectClicked;
                                        yuc.AddControl(suc);


                                        //Get ProgramBatchId for this subyear
                                        var rcls = pbHelper.GetRunningClassInAcademicYear(academicYearId,
                                                       y.Id, sessionId, s.Id);
                                        if (rcls != null)
                                        {
                                            if (!(rcls.Void ?? false))
                                            {
                                                if (!alreadySelected[p.Id].Contains(rcls.ProgramBatchId ?? 0)
                                                                                                            && !IsPostBack)
                                                {
                                                    alreadySelected[p.Id].Add(rcls.ProgramBatchId ?? 0);
                                                }
                                                //Now display 

                                                suc.SetSelectedBatch(rcls.ProgramBatchId ?? 0, rcls.ProgramBatch == null ? "" : rcls.ProgramBatch.NameFromBatch, rcls.Id);
                                                suc.Checked = true;
                                                yuc.Checked = true;
                                            }
                                            else
                                            {
                                                //runnning class is void
                                                //this is done to unvoid the previously voided data..
                                                // so that no duplicate data(one with void and next with no-void)
                                                //is made in running class
                                                suc.SetSelectedBatch(0, "", rcls.Id);
                                            }

                                        }


                                    });

                                    #endregion

                                    //yuc.AddControl(rdList);
                                }

                            }
                        });
                    });
                    //if (anyPrograms && anyYears)
                    //{
                    //    //years xa bhane matra faculty print garne
                    //    fuc.SetName(f.Id, f.Name, "");
                    //    luc.AddControl(fuc);
                    //}

                    //helper.GetLevels(schoolId).ForEach(l =>
                    //{
                    //    var luc = (ListLevelUC)Page
                    //        .LoadControl("~/Views/Academy/ProgramSelection/ListLevelUC.ascx");
                    //    luc.SetName(l.Id, l.Name, "");

                    //    luc.ID = "levelControl" + l.Id;
                    //    luc.ClientIDMode = ClientIDMode.Static;

                    //    var faculties = helper.GetFaculties(l.Id);
                    //    var anyFaculty = false;
                    //    if (faculties.Any())
                    //    {
                    //        anyFaculty = true;
                    //        faculties.ForEach(f =>
                    //         {
                                
                    //         });
                    //    }
                    //    if (anyFaculty)
                    //    {
                    //        pnlProgramListing.Controls.Add(luc);
                    //    }
                    //});
                }
        }

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
            Save();
        }

        void Save()
        {

            //var rc = Session["RunningClassYear"] as RunningClassEventArgs;
            //if (rc != null)
            int sessionId = SessionId;
            int academicYearId = AcademicYearId;
            var list = new List<RunningClass>();


            foreach (ProgramCheckBoxAndLabel p in pnlProgramListing.Controls)
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
                                        Void = !(s.Checked && y.Checked)
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
            //var lCntrl = pnlProgramListing.FindControl("levelControl" + rc.LevelId) as ListLevelUC;
            //foreach (ListLevelUC l in pnlProgramListing.Controls)
            //{
            //    foreach (var f in l.GetControls())
            //    {
                   
            //    }
            //}
            //save
            if (list.Any())
            {
                using (var helper = new DbHelper.AcademicPlacement())
                {
                    var saved = false;//helper.AddOrUpdateRunningClass(list);
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

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("~" + Request.Url.PathAndQuery, true);
        }
    }
}