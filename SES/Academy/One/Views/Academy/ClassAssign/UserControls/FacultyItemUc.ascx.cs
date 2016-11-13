using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Academy.ClassAssign.UserControls
{
    public partial class FacultyItemUc : System.Web.UI.UserControl
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


        public void SetData(int id, string name, int acaId, int sesId)
        {
            hidId.Value = id.ToString();
            lblName.Text = name;
            SessionId = sesId;
            AcademicYearId = acaId;
        }



        public void SetPrograms(List<Academic.DbEntities.Structure.Program> programs)
        {
            var acaId = AcademicYearId;
            var sesId = SessionId;
            var retValue = false;
            programs.ForEach(p =>
            {
                #region PROGRAM Uc init

                var puc = (UserControls.ProgramItemUc)
                    Page.LoadControl("~/Views/Academy/ClassAssign/UserControls/ProgramItemUc.ascx");
                puc.SetData(p.Id, p.Name, false, acaId, sesId);
                puc.ID = "programUc_" + p.Id;

                #endregion

                var years = p.Year.Where(x => !(x.Void ?? false)).OrderBy(x => x.Position)
                    .ThenBy(x => x.Id).ToList();
                if (puc.SetYears(years))
                {
                    pnlPrograms.Controls.Add(puc);
                }


            });
        }

        public List<Academic.DbEntities.AcacemicPlacements.RunningClass> GetRunningClasses()
        {
            var foundnull = false;
            var lst = new List<Academic.DbEntities.AcacemicPlacements.RunningClass>();
            foreach (var cnt in pnlPrograms.Controls)
            {
                var yuc = cnt as ProgramItemUc;
                if (yuc != null)
                {
                    var rc = yuc.GetRunningClasses();
                    if (rc == null)
                        foundnull = true;
                    else
                        lst.AddRange(rc);
                }
            }
            if (foundnull) return null;
            return lst;
        }
    }
}