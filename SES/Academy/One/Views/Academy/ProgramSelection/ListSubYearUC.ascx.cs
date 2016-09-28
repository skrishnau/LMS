using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values;

namespace One.Views.Academy.ProgramSelection
{
    public partial class ListSubYearUC : System.Web.UI.UserControl
    {
        public event EventHandler<RunningClassEventArgs> CheckChanged;
        public event EventHandler<RunningClassEventArgs> BatchSelectClicked;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int LevelId
        {
            get { return Convert.ToInt32(hidLevelId.Value); }
            set { hidLevelId.Value = value.ToString(); }
        }

        public int FacultyId
        {
            get { return Convert.ToInt32(hidFacultyId.Value); }
            set { hidFacultyId.Value = value.ToString(); }
        }

        public int ProgramId
        {
            get { return Convert.ToInt32(hidProgramId.Value); }
            set { this.hidProgramId.Value = value.ToString(); }
        }

        public int YearId
        {
            get { return Convert.ToInt32(hidYearId.Value); }
            set { hidYearId.Value = value.ToString(); }
        }

        public int SubYearId
        {
            get { return Convert.ToInt32(hidSubYearId.Value); }
            set { this.hidSubYearId.Value = value.ToString(); }
        }

        public int SelectedProgramBatchId
        {
            get { return Convert.ToInt32(hidSelectedProgramBatchId.Value); }
            set { this.hidSelectedProgramBatchId.Value = value.ToString(); }
        }

        public int RunningClassId
        {
            get { return Convert.ToInt32(hidRunningClassId.Value); }
            set { hidRunningClassId.Value = value.ToString(); }
        }

        public void SetIds(int levelId, int facultyId, int programId, int yearId, int subyearId)
        {
            hidLevelId.Value = levelId.ToString();
            hidFacultyId.Value = facultyId.ToString();
            ProgramId = programId;
            YearId = yearId;
            SubYearId = subyearId;
        }

        public void SetName(string programeName, string yearName, string subyearName)
        {
            //this.hidStructureId.Value = id.ToString();
            hidProgrameName.Value = programeName;
            hidYearName.Value = yearName;
            hidSubYearName.Value = subyearName;
            this.rdbtn.Text = subyearName;
            //this.lblName.NavigateUrl = url;
        }

        protected void lnkCoursesList_Click(object sender, EventArgs e)
        {
            //ViewState["yearId"] = YearId;
            //ViewState["subYearId"] = SubYearId;
            Response.Redirect("~/Views/Structure/All/Master/CoursesList.aspx" + "?yId=" + YearId + "&sId=" + SubYearId);
            //if (CourseClicked != null)
            //{
            //    CourseClicked(this,new StructureEventArgs()
            //    {
            //        YearId = this.YearId
            //        ,SubYearId = this.SubYearId
            //    });
            //}
        }

        //protected void rdbtn_CheckedChanged(object sender, EventArgs e)
        //{
        //    var t = this;
        //    //checkChanged event call
        //    if (CheckChanged != null)
        //    {
        //        var arg = new RunningClassEventArgs()
        //        {
        //            SubYearId = SubYearId
        //            ,
        //            YearId = YearId
        //            ,
        //            ProgramBatchId = SelectedProgramBatchId
        //            ,
        //            ProgramId = ProgramId
        //            ,
        //        };
        //        CheckChanged(this, arg);
        //    }
        //}

        public bool Checked
        {
            get { return rdbtn.Checked; }
            set { rdbtn.Checked = value; }
        }

        public int EarlierSelectedBatchId
        {
            get { return Convert.ToInt32(hidEarlierSelectedBatchId.Value); }
            set { hidEarlierSelectedBatchId.Value = value.ToString(); }
        }

     

        protected void lnkBtn_Click(object sender, EventArgs e)
        {
           

            if (CheckChanged != null)
            {
                var arg = new RunningClassEventArgs()
                {
                    SubYearId = SubYearId
                    ,
                    YearId = YearId
                    ,
                    ProgramBatchId = SelectedProgramBatchId
                    ,
                    ProgramId = ProgramId
                    ,
                    RunningClassId = RunningClassId
                    ,
                    ProgramBatchName = lblBatchName.Text

                };
                CheckChanged(this, arg);
            }
            if (BatchSelectClicked != null)
            {

                //earlier selected programBatch
                if (SelectedProgramBatchId <= 0)
                {
                    if (EarlierSelectedBatchId > 0)
                    {
                        SelectedProgramBatchId = EarlierSelectedBatchId;
                        var alreadySelected = Session["AlreadySelectedProgramBatches"] as Dictionary<int, List<int>>;
                        if (alreadySelected == null)
                        {
                            Response.Redirect("~" + Request.Url.PathAndQuery, true);
                        }
                        else
                        {
                            alreadySelected[ProgramId].Add(EarlierSelectedBatchId);
                            SetSelectedBatch(EarlierSelectedBatchId,hidEarlierSelectedBatchName.Value,RunningClassId);
                        }
                    }
                }
                //end

                BatchSelectClicked(this, new RunningClassEventArgs()
                {
                    LevelId = LevelId
                    ,
                    FacultyId = FacultyId
                    ,
                    ProgramId = ProgramId
                    ,
                    YearId = YearId
                    ,
                    SubYearId = SubYearId
                    ,
                    ProgrameName = hidProgrameName.Value
                    ,
                    YearName = hidYearName.Value
                    ,
                    SubYearName = hidSubYearName.Value
                    ,
                    ProgramBatchId = SelectedProgramBatchId
                    ,
                    RunningClassId = RunningClassId

                });
            }
        }

        //protected void imgBtn_Click(object sender, ImageClickEventArgs e)
        //{
        //    if (BatchSelectClicked != null)
        //    {
        //        BatchSelectClicked(this, new RunningClassEventArgs()
        //        {
        //            YearId = YearId
        //            ,
        //            ProgramId = ProgramId
        //            ,
        //            SubYearId = SubYearId
        //            ,
        //            ProgrameName = hidProgrameName.Value
        //            ,
        //            YearName = hidYearName.Value
        //            ,
        //            SubYearName = hidSubYearName.Value
        //        });
        //    }
        //}
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="programBatchId"></param>
        /// <param name="programBatchName"></param>
        /// <param name="runningClassId"></param>
        /// <param name="overrideEarlier">To set EarlierSelectedBatchId = 0, this parameter 
        /// must be true else earlierSelectedBatchId can never be set to zero </param>
        public void SetSelectedBatch(int programBatchId, string programBatchName, int runningClassId = 0, bool overrideEarlier=false)
        {
            hidSelectedProgramBatchId.Value = programBatchId.ToString();

            lblBatchName.Text = programBatchName;// == "" ? null : programBatchName;
            imgBtn.Visible = (programBatchName == "");
            RunningClassId = runningClassId;
            if (programBatchId > 0 || overrideEarlier)
            {
                hidEarlierSelectedBatchId.Value = programBatchId.ToString();
                hidEarlierSelectedBatchName.Value = programBatchName;
            }
        }
        public void ClearProgramBatch()
        {
            hidSelectedProgramBatchId.Value = "0";// programBatchId.ToString();

            lblBatchName.Text = "";// programBatchName;// == "" ? null : programBatchName;
            imgBtn.Visible = true;// (programBatchName == "");
            //RunningClassId = runningClassId;
        }
    }
}