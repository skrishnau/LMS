using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using One.Values;

namespace One.Views.Academy.ProgramSelection
{
    public partial class YearCheckBoxAndLabel : System.Web.UI.UserControl
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
            this.chkBox.Text = yearName;
            //this.lblName.NavigateUrl = url;
        }

        //public void SetName(int id, string name, int programId, string url = "")
        //{
        //    hidId.Value = id.ToString();
        //    chkBox.Text = name;
        //    ProgramId = programId;
        //}



        public bool ImageVisibility
        {
            set
            {
                lnkBatchSelect.Visible = value;
                imgBtn.Visible = value;
            }
        }

        public void SetImageUrl()
        {
            imgBtn.ImageUrl = "~/Content/Icons/Users/users-icon.png";
        }

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

        void uc_CheckChanged(object sender, Values.RunningClassEventArgs e)
        {
            foreach (ListSubYearUC uc in pnlSubControls.Controls)
            {
                uc.Checked = false;
            }
            var send = sender as ListSubYearUC;
            if (send != null)
            {
                send.Checked = true;
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

        public List<RadioButtonList> GetControls()
        {
            var list = new List<RadioButtonList>();
            foreach (RadioButtonList uc in pnlSubControls.Controls)
            {
                list.Add(uc);
            }
            return list;
        }

        public bool Checked
        {
            get { return chkBox.Checked; }
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
                    ,ProgramBatchId = SelectedProgramBatchId
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



        public void SetSelectedBatch(int programBatchId, string programBatchName)
        {
            hidSelectedProgramBatchId.Value = programBatchId.ToString();
            lblBatchName.Text = programBatchName;// == "" ? null : programBatchName;
            imgBtn.Visible = (programBatchName == "");
        }


        public Control FindCustomControl(string id)
        {
            return pnlSubControls.FindControl(id);
        }
    }
}