using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.Batches;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One.Views.Academy
{
    public partial class Create : System.Web.UI.Page
    {
        #region PageLoad

        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            SetToDefaults();
            txtName.Focus();
            try
            {
                if (!IsPostBack)
                {
                    if (SiteMap.CurrentNode != null)
                    {
                        var list = new List<IdAndName>()
                        {
                           new IdAndName(){
                                        Name=SiteMap.RootNode.Title
                                        ,Value =  SiteMap.RootNode.Url
                                        ,Void=true
                                    },
                            new IdAndName(){
                                Name = SiteMap.CurrentNode.ParentNode.Title
                                ,Value = SiteMap.CurrentNode.ParentNode.Url+"?edit=1"
                                ,Void=true
                            },
                            new IdAndName()
                            {
                                Name = SiteMap.CurrentNode.Title
                            }
                        };
                        SiteMapUc.SetData(list);
                    }
                    LoadData();
                }
            }
            catch { }
        }

        private void SetToDefaults()
        {
            valiAcademicStart.ErrorMessage = "Required";
            valiAcademicEnd.ErrorMessage = "Required";
            valiSession1Start.ErrorMessage = "Required";
            valiSession1End.ErrorMessage = "Required";
            valiSession2Start.ErrorMessage = "Required";
            valiSession2End.ErrorMessage = "Required";
        }


        #endregion


        #region Properties

        public int AcademicYearId
        {
            get { return Convert.ToInt32(hidAcademicYearId.Value); }
            set { hidAcademicYearId.Value = value.ToString(); }
        }

        public int BatchId
        {
            get { return Convert.ToInt32(hidBatchId.Value); }
            set
            {
                hidBatchId.Value = value.ToString();
            }
        }

        public int Session1Id
        {
            get { return Convert.ToInt32(hidSession1Id.Value); }
            set { hidSession1Id.Value = value.ToString(); }
        }

        public int Session2Id
        {
            get { return Convert.ToInt32(hidSession2Id.Value); }
            set { hidSession2Id.Value = value.ToString(); }
        }

        #endregion


        #region  functions

        private void SetStructure(DbHelper.Structure sHelper, CustomPrincipal user)
        {
            var programs = sHelper.ListPrograms(user.SchoolId);
            programs.ForEach(p =>
            {
                var litem = new ListItem() { Text = " " + p.Name, Value = p.Id.ToString() };
                var pbs = p.ProgramBatches.FirstOrDefault(x => x.BatchId == BatchId);
                if (pbs != null)
                {
                    litem.Value += "_" + pbs.Id;
                    litem.Selected = !(pbs.Void ?? false);
                }
                else
                {
                    litem.Value += "_0";
                    litem.Selected = false;
                }
                CheckBoxList1.Items.Add(litem);
            });
        }

        private void LoadData()
        {
            var user = Page.User as CustomPrincipal;
            var aId = Request.QueryString["aId"];

            if (user != null)
                using (var aHelper = new DbHelper.AcademicYear())
                using (var bHelper = new DbHelper.Batch())
                using (var sHelper = new DbHelper.Structure())
                {
                    var fromSession = Request.QueryString["from"];
                    if (fromSession == "startSession")
                    {
                        lblFromSessionNotice.Visible = true;
                    }

                    if (aId == null)
                    {
                        var sessionsDefault = aHelper.ListDefaultSessions(user.SchoolId);
                        if (sessionsDefault.Count >= 2)
                        {
                            txtSession1Name.Text = sessionsDefault[0].Name;
                            txtSession2Name.Text = sessionsDefault[1].Name;
                        }
                    }
                    else
                    {
                        //btnSaveAndAddSessions.Visible = false;
                        var batch = bHelper.GetBatchByAcademicYearId(Convert.ToInt32(aId));

                        if (batch != null)
                        {

                            BatchId = batch.Id;
                            var acad = batch.AcademicYear;
                            if (acad != null)
                            {
                                //=========================Academic year, batch
                                AcademicYearId = acad.Id;

                                txtName.Text = acad.Name;
                                txtAcademicStart.Text = acad.StartDate.ToShortDateString();
                                txtAcademicEnd.Text = acad.EndDate.ToShortDateString();
                                txtBatchName.Text = batch.Name;

                                //========================Sessions
                                var sessions = acad.Sessions.Where(x => !(x.Void ?? false)).ToList();
                                if (sessions.Count >= 2)
                                {
                                    // enable disable session1
                                    txtSession1Name.Text = sessions[0].Name;
                                    Session1Id = sessions[0].Id;
                                    txtSession1Start.Text = sessions[0].StartDate.ToShortDateString();
                                    txtSession1End.Text = sessions[0].EndDate.ToShortDateString();

                                    var session1Enabled = !(sessions[0].IsActive || (sessions[0].Completed ?? false));
                                    txtSession1Name.Enabled = session1Enabled;
                                    txtSession1Start.Enabled = session1Enabled;
                                    txtSession1End.Enabled = session1Enabled;

                                    //enable , disable session2
                                    txtSession2Name.Text = sessions[1].Name;
                                    Session2Id = sessions[1].Id;
                                    txtSession2Start.Text = sessions[1].StartDate.ToShortDateString();
                                    txtSession2End.Text = sessions[1].EndDate.ToShortDateString();

                                    var session2Enabled = !(sessions[1].IsActive || (sessions[1].Completed ?? false));
                                    txtSession2Name.Enabled = session2Enabled;
                                    txtSession2Start.Enabled = session2Enabled;
                                    txtSession2End.Enabled = session2Enabled;

                                    //enable , disable -- academic year
                                    if (batch.AcademicYear.IsActive || (batch.AcademicYear.Completed ?? false)
                                        || !session2Enabled || !session1Enabled)
                                    {
                                        txtName.Enabled = false;
                                        txtAcademicEnd.Enabled = false;
                                        txtAcademicStart.Enabled = false;
                                        CheckBoxList1.Enabled = false;
                                        //earlier working
                                        //chkSelectAll.Enabled = false;


                                        txtName.Enabled = false;
                                        txtBatchName.Enabled = false;
                                        btnSave.Enabled = false;

                                        CheckBoxList1.Enabled = false;
                                        //earlier working
                                        //chkSelectAll.Enabled = false;
                                    }
                                }
                            }
                        }
                    }
                    //============================ Structure
                    SetStructure(sHelper, user);
                }
        }

        //public void LoadStructure(int schoolId)
        //{
        //    var user = Page.User as CustomPrincipal;

        //    if (user != null)
        //        using (var helper = new DbHelper.Structure())
        //        {
        //            var programs = helper.ListPrograms(schoolId);
        //            programs.ForEach(p =>
        //            {
        //                var litem = new ListItem() { Text = " " + p.Name, Value = p.Id.ToString() };
        //                var pbs = p.ProgramBatches.FirstOrDefault(x => x.BatchId == BatchId);
        //                if (pbs != null)
        //                {
        //                    litem.Value += "_" + pbs.Id;
        //                    litem.Selected = !(pbs.Void ?? false);
        //                }
        //                else
        //                {
        //                    litem.Value += "_0";
        //                    litem.Selected = false;
        //                }
        //                CheckBoxList1.Items.Add(litem);
        //            });
        //        }
        //}



        //public void SetDatasForEdit(int batchId)
        //{
        //    using (var helper = new DbHelper.Batch())
        //    {
        //        var batch = helper.GetBatch(batchId);
        //        if (batch != null)
        //        {
        //            BatchId = batch.Id;
        //            //txtName.Text = batch.Name;
        //            //txtDescription.Text = batch.Description;
        //            //ddlAcademicYear.SelectedValue = batch.AcademicYearId.ToString();
        //            //txtCommenceDate.Text = batch.ClassCommenceDate == null ? "" : batch.ClassCommenceDate.Value.ToShortDateString();
        //        }
        //        // program batches
        //    }
        //}


        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (var helper = new DbHelper.AcademicYear())
            {
                var user = Page.User as CustomPrincipal;
                if (user != null)
                {
                    //academic year
                    var academicYear = GetAcademicYear(helper, user);
                    if (academicYear == null)
                        return;
                    //batch
                    List<Academic.DbEntities.Batches.ProgramBatch> list = new List<ProgramBatch>();
                    var batch = GetBatch(user, ref list);
                    if (batch == null)
                        return;
                    var sessions = GetSessions(academicYear);
                    if (sessions == null)
                        return;



                    var saved = helper.AddOrUpdateAcademicYearAndBatch(user.SchoolId, academicYear, sessions, batch, list);
                    if (saved != null)
                    {
                        lblFromSessionNotice.Visible = true;
                        if (lblFromSessionNotice.Visible)
                        {
                            Response.Redirect("~/Views/Student/Batch/?Id=" + saved.Id + "&from=startSession");
                            //Response.Redirect("~/Views/Academy/StartSession.aspx");
                        }
                        else
                        {
                            Response.Redirect("~/Views/Academy/");
                        }
                    }
                    else lblError.Visible = true;
                }
            }
        }



        private Academic.DbEntities.AcademicYear GetAcademicYear(DbHelper.AcademicYear helper, CustomPrincipal user)
        {
            DateTime start = DateTime.MinValue, end = DateTime.MaxValue;
            try
            {
                start = Convert.ToDateTime(txtAcademicStart.Text);
                var earlierAca = helper.GetEarlierAcademicYear(user.SchoolId);

                if (earlierAca != null)
                    if (start.Date <= earlierAca.EndDate.Date)
                    {
                        valiAcademicStart.ErrorMessage = "Must be greater than end-date of earlier academic year (" + earlierAca.EndDate.ToShortDateString() + ")";
                        valiAcademicStart.IsValid = false;
                    }
            }
            catch
            {
                valiAcademicStart.ErrorMessage = "Incorrect format.";
                valiAcademicStart.IsValid = false;
            }
            try
            {
                end = Convert.ToDateTime(txtAcademicEnd.Text);
                if (end <= start)
                {
                    valiAcademicEnd.ErrorMessage = "End date must be greater than start date";
                    valiAcademicEnd.IsValid = false;
                }

            }
            catch
            {
                valiAcademicEnd.ErrorMessage = "Incorrect format.";
                valiAcademicEnd.IsValid = false;
            }

            if (Page.IsValid)
            {
                var entity = new Academic.DbEntities.AcademicYear()
                {
                    Id = AcademicYearId
                    ,
                    Name = txtName.Text
                    ,
                    EndDate = end
                    ,
                    StartDate = start
                    ,
                    SchoolId = user.SchoolId
                    ,
                    Position = start.Year * 10000 + start.Month * 100 + start.Day,
                };
                return entity;
            }
            return null;
        }

        private Academic.DbEntities.Batches.Batch GetBatch(CustomPrincipal user, ref List<Academic.DbEntities.Batches.ProgramBatch> list)
        {
            var batchId = BatchId;
            if (Page.IsValid)
            {
                //var lst = new List<Academic.DbEntities.Batches.ProgramBatch>();
                foreach (ListItem item in CheckBoxList1.Items)
                {
                    var ids = item.Value.Split(new char[] { '_' });
                    if (ids.Length >= 2)
                    {
                        var pb = new Academic.DbEntities.Batches.ProgramBatch()
                        {
                            Id = Convert.ToInt32(ids[1])
                            ,
                            ProgramId = Convert.ToInt32(ids[0])
                            ,
                            Void = !item.Selected
                            ,
                            BatchId = batchId

                        };
                        list.Add(pb);
                    }
                }
                var batch = new Academic.DbEntities.Batches.Batch()
                {
                    Id = batchId,

                    Name = txtBatchName.Text
                    ,
                    SchoolId = user.SchoolId
                    ,
                    AcademicYearId = AcademicYearId
                };
                if (batchId <= 0)
                {
                    batch.CreatedDate = DateTime.Now;
                }
                return batch;

            }
            return null;
        }

        private List<Academic.DbEntities.Session> GetSessions(Academic.DbEntities.AcademicYear academicYear)
        {
            DateTime ses1Start, ses1End, ses2Start, ses2End;

            if (!DateTime.TryParse(txtSession1Start.Text, out ses1Start))
            {
                valiSession1Start.IsValid = false;
                valiSession1Start.ErrorMessage = "Incorrect format";
            }
            if (!DateTime.TryParse(txtSession1End.Text, out ses1End))
            {
                valiSession1End.IsValid = false;
                valiSession1End.ErrorMessage = "Incorrect format";
            }

            if (!DateTime.TryParse(txtSession2Start.Text, out ses2Start))
            {
                valiSession2Start.IsValid = false;
                valiSession2Start.ErrorMessage = "Incorrect format";
            }
            if (!DateTime.TryParse(txtSession2End.Text, out ses2End))
            {
                valiSession2End.IsValid = false;
                valiSession2End.ErrorMessage = "Incorrect format";
            }

            if (Page.IsValid)
            {
                if (ses1Start < academicYear.StartDate)
                {
                    valiSession1Start.IsValid = false;
                    valiSession1Start.ErrorMessage = "Session start-date can't be less than start-date of academic year";
                }
                if (ses1End > academicYear.EndDate)
                {
                    valiSession1End.IsValid = false;
                    valiSession1End.ErrorMessage = "Session end-date can't be greater than end-date of academic year";
                }
                else if (ses1End <= ses1Start)
                {
                    valiSession1End.IsValid = false;
                    valiSession1End.ErrorMessage = "Session end-date can't be less than start-date";
                }

                if (ses2Start <= ses1End)
                {
                    valiSession2Start.IsValid = false;
                    valiSession2Start.ErrorMessage = "Session-2 start-date can't be less than end-date of Session-1";
                }
                if (ses2End > academicYear.EndDate)
                {
                    valiSession2End.IsValid = false;
                    valiSession2End.ErrorMessage = "Session end-date can't be greater than end-date of academic year";
                }
                else if (ses2End <= ses2Start)
                {
                    valiSession2End.IsValid = false;
                    valiSession2End.ErrorMessage = "Session end-date can't be less than start-date";
                }

                if (Page.IsValid)
                {
                    var session1 = new Academic.DbEntities.Session()
                    {
                        Id = Session1Id,
                        Name = txtSession1Name.Text,
                        StartDate = ses1Start,
                        EndDate = ses1End,
                        Position = 1,
                        AcademicYearId = AcademicYearId,
                        IsActive = false,
                        Void = false,
                        Completed = false,

                    };

                    var session2 = new Academic.DbEntities.Session()
                    {
                        Id = Session2Id,
                        Name = txtSession2Name.Text,
                        StartDate = ses2Start,
                        EndDate = ses2End,
                        Position = 2,
                        AcademicYearId = AcademicYearId,
                        IsActive = false,
                        Void = false,
                        Completed = false,

                    };
                    return new List<Academic.DbEntities.Session>()
                    {
                        session1,
                        session2
                    };
                }
            }
            return null;
        }


        protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            //foreach (ListItem li in CheckBoxList1.Items)
            //{
            //    li.Selected = chkSelectAll.Checked;
            //}
        }


        #endregion

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Academy/");
        }
    }
}