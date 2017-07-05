using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.Structure;

namespace One.Views.Structure
{
    public partial class YearInfoUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadProgram(Program program)
        {
            lblProgramName.Text = program.Name;
            foreach (var year in program.Year.Where(x=>!(x.Void??false)).OrderBy(x=>x.Position))
            {
                LoadYear(year);

                tblYear.Rows.Add(new TableRow());
            }
        }

        private void LoadYear(Year year)
        {

            var subyears = year.SubYears.Where(x => !(x.Void ?? false)).OrderBy(x=>x.Position).ToList();

            var yearNameDisplayed = false;

            var subYearCnt = 0;
            foreach (var sub in subyears)
            {
                var subjects = sub.SubjectStructures.Where(x => !(x.Void ?? false)
                                    && !(x.Subject.Void ?? false)
                                        )
                                        .OrderBy(x=>x.Subject.FullName)
                                        .ToList();
                var thisSubyear = 0;

                foreach (var subj in subjects)
                {
                    var row = new TableRow();

                    //year 
                    var yearCell = new TableCell()
                    {
                        Text = !yearNameDisplayed ? year.Name : ""
                    };
                    yearNameDisplayed = true;
                    row.Cells.Add(yearCell);

                    //subyear
                    var subyearCell = new TableCell()
                    {
                        Text = thisSubyear == 0 ? sub.Name : ""
                    };
                    row.Cells.Add(subyearCell);

                    //subject 
                    var subjCell = new TableCell()
                    {
                        Text = subj.Subject.FullName
                    };
                    row.Cells.Add(subjCell);

                    thisSubyear++;
                    tblYear.Rows.Add(row);
                }
                subYearCnt++;
            }
        }

        //private void LoadSubject(Year year, SubYear subyear, Subject subject)
        //{
            
        //}
    }
}