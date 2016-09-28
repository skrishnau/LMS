using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values;

namespace One.Views.Academy.ProgramSelection.OnlyListing
{
    public partial class YearU : System.Web.UI.UserControl
    {

        public event EventHandler<RunningClassEventArgs> BatchSelectClicked;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetIds(int levelId, int facultyId, int programId, int yearId, int subyearId)
        {
            hidLevelId.Value = levelId.ToString();
            hidFacultyId.Value = facultyId.ToString();
            ProgramId = programId;

            YearId = yearId;
            //SubYearId = subyearId;
        }

        public void SetName(string programeName, string yearName, string subyearName)
        {
            //this.hidStructureId.Value = id.ToString();

            hidProgrameName.Value = programeName;
            hidYearName.Value = yearName;
            hidSubYearName.Value = subyearName;
            lblYearName.Text = yearName;
            //this.lblName.NavigateUrl = url;
        }

        //public void SetName(int id, string name, int programId, string url = "")
        //{
        //    hidId.Value = id.ToString();
        //    chkBox.Text = name;
        //    ProgramId = programId;
        //}



        //public bool ImageVisibility
        //{
        //    set
        //    {
        //        //lnkBatchSelect.Visible = value;
        //        imgBtn.Visible = value;
        //    }
        //}

        //public void SetImageUrl()
        //{
        //    imgBtn.ImageUrl = "~/Content/Icons/Users/users-icon.png";
        //}

        protected void chkBox_CheckedChanged(object sender, EventArgs e)
        {
            //var cntrl = pnlSubControls.FindControl("yearControl" + hidId.Value + chkBox.Text)
            //    as ProgramCheckBoxAndLabel;
            //if (cntrl != null)
            //{

            //}
        }

        public void AddControl(ListSubYearUC uc)
        {
            uc.CheckChanged += uc_CheckChanged;
            this.pnlSubControls.Controls.Add(uc);
        }

        void uc_CheckChanged(object sender, RunningClassEventArgs e)
        {
            var alreadySelected = Session["AlreadySelectedProgramBatches"] as Dictionary<int, List<int>>;
            if (alreadySelected == null)
            {
                Response.Redirect("~" + Request.Url.PathAndQuery, true);
            }
            else
            {
                foreach (ListSubYearUC uc in pnlSubControls.Controls)
                {
                    uc.Checked = false;
                    alreadySelected[e.ProgramId].Remove(uc.SelectedProgramBatchId);
                    uc.ClearProgramBatch();
                }
                var send = sender as ListSubYearUC;
                if (send != null)
                {
                    //send.SelectedProgramBatchId = e.ProgramBatchId;
                    send.SetSelectedBatch(e.ProgramBatchId, e.ProgramBatchName, e.RunningClassId);
                    send.Checked = true;
                }
            }

        }



        public void AddControl(ProgramCheckBoxAndLabel uc)
        {
            this.pnlSubControls.Controls.Add(uc);
        }

        public void AddControl(RadioButtonList rdList)
        {
            this.pnlSubControls.Controls.Add(rdList);
        }

        public void AddControl(UserControl uc)
        {
            this.pnlSubControls.Controls.Add(uc);
        }

        public void Check(bool check)
        {
            chkBox.Checked = check;
        }
        //RadioButtonList

        //public List<RadioButtonList> GetControls()
        //{
        //    //var list = new List<RadioButtonList>();
        //    //foreach (RadioButtonList uc in pnlSubControls.Controls)
        //    //{
        //    //    list.Add(uc);
        //    //}
        //    //return list;
        //}

        public bool Checked
        {
            get { return chkBox.Checked; }
            set { chkBox.Checked = value; }
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
            get { return Convert.ToInt32(hidId.Value); }
            set { hidId.Value = value.ToString(); }
        }

        public int SelectedProgramBatchId
        {
            get { return Convert.ToInt32(hidSelectedProgramBatchId.Value); }
            set { hidSelectedProgramBatchId.Value = value.ToString(); }
        }


        public int RunningClassId
        {
            get { return Convert.ToInt32(hidRunningClassId.Value); }
            set { hidRunningClassId.Value = value.ToString(); }
        }

        public int ExamOfClassId
        {
            get { return Convert.ToInt32(hidExamOfClassId.Value); }
            set { hidExamOfClassId.Value = value.ToString(); }
        }


        protected void lnkBtn_Click(object sender, EventArgs e)
        {
            if (BatchSelectClicked != null)
            {
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
                    SubYearId = 0
                    ,
                    RunningClassId = RunningClassId
                    ,
                    ProgrameName = hidProgrameName.Value
                    ,
                    YearName = hidYearName.Value
                    ,
                    SubYearName = hidSubYearName.Value
                    ,
                    ProgramBatchId = SelectedProgramBatchId
                });
            }
        }

        //protected void imgBtn_Click(object sender, ImageClickEventArgs e)
        //{
        //    if (BatchSelectClicked != null)
        //    {
        //        BatchSelectClicked(this,new RunningClassEventArgs()
        //        {
        //            YearId = YearId
        //            ,ProgramId = ProgramId
        //            ,SubYearId = 0
        //            ,RunningClassId = RunningClassId

        //            ,ProgrameName = hidProgrameName.Value
        //            ,YearName = hidYearName.Value
        //            ,SubYearName = hidSubYearName.Value
        //        });
        //    }
        //}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="programBatchId">used to pass Id of selected programBatch</param>
        /// <param name="programBatchName">used to pass Name of selected programBatch</param>
        /// <param name="exc">Exam of ClassId</param> 
        /// <param name="runningClassId">
        /// Its used to pass Id of saved runningClass table row, --> to update database when programbatch is changed.
        /// By default, already stored running class results inn atuo select of programbatch.
        /// </param>
        public void SetSelectedBatch(int programBatchId, string programBatchName, int runningClassId = 0
            ,Academic.DbEntities.Exams.ExamOfClass exc=null)
        {
            hidSelectedProgramBatchId.Value = programBatchId.ToString();
            lblBatchName.Text =" | "+ programBatchName;// == "" ? null : programBatchName;
            //imgBtn.Visible = (programBatchName == "");
            RunningClassId = runningClassId;
            if (exc != null)
            {
                ExamOfClassId = exc.Id;
                chkBox.Checked = !(exc.Void ?? false);
            }
        }


        public Control FindCustomControl(string id)
        {
            return pnlSubControls.FindControl(id);
        }

        public List<SubYearUC> GetControls()
        {
            var list = new List<SubYearUC>();
            foreach (SubYearUC uc in pnlSubControls.Controls)
            {
                list.Add(uc);
            }
            return list;
        }
    }
}