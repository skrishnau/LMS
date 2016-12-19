using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.Structure;
using Academic.ViewModel;

namespace One.Views.Academy.ClassAssign.UserControls
{
    public partial class YearItemUc : System.Web.UI.UserControl
    {
        public event EventHandler<IdAndNameEventArgs> ProgramBatchSelectionChanged;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        #region Properties

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

        public int ProgramBatchId
        {
            get { return Convert.ToInt32(ddlStudentGrps.SelectedValue); }
            set { try { ddlStudentGrps.SelectedValue = value.ToString(); } catch { } }
        }

        public int RunningClassId
        {
            get { return Convert.ToInt32(hidRunningClassId.Value); }
            set { hidRunningClassId.Value = value.ToString(); }
        }


        public string ErrorMessage
        {
            set
            {
                lblError.Visible = true;
                lblError.Text = value;
            }
        }

        public bool Checked
        {
            get { return chkBox.Checked; }
            set { chkBox.Checked = value; }
        }

        public int YearId
        {
            get { return Convert.ToInt32(hidYearId.Value); }
            set { hidYearId.Value = value.ToString(); }
        }

        public int SubYearId
        {
            get { return Convert.ToInt32(ddlStructure.SelectedValue); }
            set { ddlStructure.SelectedValue = value.ToString(); }
        }

        #endregion

        protected void ddlStudentGrps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProgramBatchSelectionChanged != null)
            {
                ProgramBatchSelectionChanged(this, new IdAndNameEventArgs()
                {
                    Id = ProgramBatchId,
                    Name = ddlStudentGrps.Text
                });
            }
        }

        public void SetData(int yearId, string name, int acaId, int sesId)
        {
            YearId = yearId;
            chkBox.Text = " " + name;
            //chkBox.Checked = check;
            AcademicYearId = acaId;
            SessionId = sesId;

            //RunningClassId = runningClassId;
            //ProgramBatchId = programBatchId;
            //SubYearId = SubYearId;
        }

        //,List<Academic.DbEntities.AcacemicPlacements.RunningClass> runningClasses)
        public void SetSubYears(List<Academic.DbEntities.Structure.SubYear> subyears
                                    , List<IdAndName> programBatches
            , int runningClassId, int programBatchId, int subYearId, bool voided)
        {
            if (subyears.Count == 0)
            {
                pnlStructure.Visible = false;
            }
            else
            {
                pnlStructure.Visible = true;
                subyears.Insert(0, new SubYear() { Id = 0, Name = "--Select--" });
                ddlStructure.DataSource = subyears;
                ddlStructure.DataBind();
            }

            ddlStudentGrps.DataSource = programBatches;
            ddlStudentGrps.DataBind();

            if (programBatchId > 0)
            {
                SubYearId = subYearId;
                ProgramBatchId = programBatchId;
                chkBox.Checked = !voided;
            }
            else
            {
                chkBox.Checked = false;
            }
            RunningClassId = runningClassId;
            //if (subyearId > 0 && SessionId > 0)
            //{
            //    ddlStructure.SelectedValue = subyearId.ToString();
            //}
            //var programBatchId = ProgramBatchId;
            //if(programBatchId>0)
            //ddlStudentGrps.SelectedValue = ProgramBatchId.ToString();
        }


        public Academic.DbEntities.AcacemicPlacements.RunningClass GetRunningClass()
        {
            var subYearId = SubYearId;
            var sesId = SessionId;
            var r = new Academic.DbEntities.AcacemicPlacements.RunningClass()
            {
                Id = RunningClassId
                ,
                AcademicYearId = AcademicYearId
                ,
                Void = !chkBox.Checked
                ,
                YearId = YearId
                ,
            };

            if (chkBox.Checked)
            {
                if ((subYearId == 0 && sesId > 0) || ProgramBatchId == 0)
                {
                    ErrorMessage = "Select or uncheck";
                    return null;
                }
                if (sesId > 0)
                {
                    r.SessionId = sesId;
                    if (subYearId > 0)
                        r.SubYearId = subYearId;

                }
                var pbId = ProgramBatchId;
                if (pbId > 0)
                {
                    r.ProgramBatchId = pbId;
                }
            }
            return r;
        }



    }
}