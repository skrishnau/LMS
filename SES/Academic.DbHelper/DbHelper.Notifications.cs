using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.Database;
using Academic.DbEntities.Class;

namespace Academic.DbHelper
{
    public partial class DbHelper
    {
        public class Notifications : IDisposable
        {
            Academic.Database.AcademicContext Context;

            public Notifications()
            {
                Context = new AcademicContext();
            }

            public void Dispose()
            {
                Context.Dispose();
            }


            public List<Academic.DbEntities.Class.SubjectClass> GetDueClassesNotification(int schoolId)
            {
                var now = DateTime.Now.Date;
                var min = DateTime.MinValue.Date;
                var max = DateTime.MaxValue.Date;

                var regular = Context.SubjectClass
                            .Where(s => !(s.Void ?? false)
                                //&& (s.StartDate ?? min) <= now
                               && (s.EndDate ?? max) < now
                                && !(s.SessionComplete ?? false)
                                && ((s.IsRegular && !(s.SubjectStructure.Void ?? false)
                                            && !(s.SubjectStructure.Subject.Void ?? false) && s.SubjectStructure.Subject.SubjectCategory.SchoolId == schoolId)
                                     || (!s.IsRegular && !(s.Subject.Void ?? false) && s.Subject.SubjectCategory.SchoolId == schoolId))
                                )
                                .OrderByDescending(o => o.CreatedDate)
                                .ThenBy(t => (t.IsRegular ? t.RunningClass.ProgramBatch.Batch.Name : t.Name))
                                .ThenBy(t => (t.IsRegular ? t.RunningClass.ProgramBatch.Program.Name : ""))
                            .ToList();
                return regular;
            }


            public List<Academic.DbEntities.Class.SubjectClass> GetNoTeacherInClassNotification(int schoolId)
            {
                var teachRole = Context.Role.FirstOrDefault(x => x.RoleName == StaticValues.Roles.Teacher);
                if (teachRole != null)
                {
                    var now = DateTime.Now.Date;
                    var sss = Context.SubjectClass.Where(x => !x.ClassUsers.Any(y => y.RoleId == teachRole.Id)
                                                            && x.StartDate >= now
                                                            && x.IsRegular
                                                    ? x.SubjectStructure.Subject.SubjectCategory.SchoolId == schoolId
                                                    : x.Subject.SubjectCategory.SchoolId == schoolId).ToList();
                    return sss;
                }
                return new List<SubjectClass>();
            }

            //public void GetElectivesNotChoosenNotification(int schoolId, int academicYearId, int sessionId)
            //{
            //    var rc = Context.RunningClass.Where(q => q.AcademicYearId == academicYearId && q.SessionId == sessionId
            //                                             && !(q.Completed ?? false) && !(q.Void ?? false) &&
            //                                             (q.IsActive ?? false));
            //    var sc = 
            //}

        }
    }
}
