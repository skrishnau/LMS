using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.Database;

namespace Academic.DbHelper
{
    public partial class DbHelper
    {
        public class Report:IDisposable
        {
            private Academic.Database.AcademicContext Context;

            public Report()
            {
                Context = new AcademicContext();
            }

            public void Dispose()
            {
                Context.Dispose();
            }

            public bool SaveReport(DbEntities.Subjects.Report report)
            {
                try
                {
                    var earlier = Context.Report.FirstOrDefault(x => x.SubjectClassId == report.SubjectClassId);
                    if (earlier == null)
                    {
                        //add
                        Context.Report.Add(report);
                        Context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        //update
                        earlier.ShowActivityResourceIds = report.ShowActivityResourceIds;
                        earlier.ShowCRN = report.ShowCRN;
                        earlier.ShowImage = report.ShowImage;
                        earlier.ShowName = report.ShowName;
                        earlier.ShowTotal = report.ShowTotal;
                        Context.SaveChanges();
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }


            public Academic.DbEntities.Subjects.Report GetReport(int classId)
            {
                return Context.Report.FirstOrDefault(x => x.SubjectClassId == classId);
            }
        }
    }
}
