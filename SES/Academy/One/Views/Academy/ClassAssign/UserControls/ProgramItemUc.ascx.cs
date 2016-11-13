using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.AcacemicPlacements;
using Academic.DbHelper;
using Academic.ViewModel;

namespace One.Views.Academy.ClassAssign.UserControls
{
    public partial class ProgramItemUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

        public int ProgramId
        {
            get { return Convert.ToInt32(hidProgramId.Value); }
            set { hidProgramId.Value = value.ToString(); }
        }


        public void AddControl(UserControl uc)
        {
            pnlYears.Controls.Add(uc);
        }

        public void SetData(int programId, string name, bool check, int acaId, int sesId)
        {
            hidProgramId.Value = programId.ToString();
            chkBox.Text = " " + name;
            chkBox.Checked = check;
            AcademicYearId = acaId;
            SessionId = sesId;
        }

        public bool SetYears(List<Academic.DbEntities.Structure.Year> years)
        {
            var acaId = AcademicYearId;
            var sesId = SessionId;
            var programId = ProgramId;
            var retValue = true;
            List<bool> listBool = new List<bool>();
            using (var rhelper = new DbHelper.AcademicPlacement())
            using (var helper = new DbHelper.Batch())
            {
                var rcs = rhelper.ListRunningClasses(acaId, sesId);
                var pbList = helper.ListCurrentProgramBatches(programId);
                pbList.Insert(0, new IdAndName() { Id = 0, Name = "--Select--" });
                years.ForEach(y =>
                {
                    
                    var subyears =
                        y.SubYears.Where(x => !(x.Void ?? false)).OrderBy(x => x.Position)
                        .ThenBy(x => x.Id).ToList();

                    if ((sesId == 0 && subyears.Count == 0) || (sesId > 0 && subyears.Count > 0))
                    {
                        var yuc = (UserControls.YearItemUc)
                        Page.LoadControl("~/Views/Academy/ClassAssign/UserControls/YearItemUc.ascx");

                        var rc = rcs.FirstOrDefault(x => x.AcademicYearId == AcademicYearId && (x.SessionId ?? 0) == SessionId
                                      && x.YearId == y.Id)
                                      ?? new RunningClass() { Id = 0, Void=true };

                        yuc.SetData(y.Id, y.Name, acaId, sesId);
                        yuc.ID = "yearUc" + y.Id;
                        pnlYears.Controls.Add(yuc);

                        yuc.SetSubYears(subyears, pbList, rc.Id, rc.ProgramBatchId ?? 0, rc.SubYearId ?? 0, rc.Void??false);
                        listBool.Add(true);
                        yuc.ProgramBatchSelectionChanged += yuc_ProgramBatchSelectionChanged;
                    }
                    else
                    {
                        listBool.Add(false);
                    }
                });
                return listBool.Contains(true);
            }
        }

        void yuc_ProgramBatchSelectionChanged(object sender, IdAndNameEventArgs e)
        {
            var sent = sender as YearItemUc;
            if (sent != null)
            {
                foreach (var cnt in pnlYears.Controls)
                {
                    var yuc = cnt as YearItemUc;
                    if (yuc != null)
                    {
                        if (yuc.ID != sent.ID && sent.ProgramBatchId != 0)
                        {
                            if (yuc.ProgramBatchId == sent.ProgramBatchId)
                            {
                                sent.ErrorMessage = "Already Selected";
                                sent.ProgramBatchId = 0;
                                break;
                            }
                        }
                    }
                }
            }
        }

        protected void chkBox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var cnt in pnlYears.Controls)
            {
                var yuc = cnt as YearItemUc;
                if (yuc != null)
                {
                    yuc.Checked = chkBox.Checked;
                }
            }
        }

        public List<Academic.DbEntities.AcacemicPlacements.RunningClass> GetRunningClasses()
        {
            var lst = new List<Academic.DbEntities.AcacemicPlacements.RunningClass>();
            var foundnull = false;
            foreach (var cnt in pnlYears.Controls)
            {
                var yuc = cnt as YearItemUc;
                if (yuc != null)
                {
                    var rc = yuc.GetRunningClass();
                    foundnull = (rc == null);
                    lst.Add(rc);
                }
            }
            if (foundnull) return null;
            return lst;
        }
    }
}