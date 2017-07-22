using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.Database;
using Academic.DbEntities.Class;
using Academic.ViewModel;

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


            public List<ClassViewModel> GetDueClassesNotification(int schoolId)
            {
                var now = DateTime.Now.Date;
                var min = DateTime.MinValue.Date;
                var max = DateTime.MaxValue.Date;

                var regular = Context.SubjectClass
                    .Where(s => !(s.Void ?? false)
                                && (s.EndDate ?? max) < now
                                && !(s.SessionComplete ?? false)
                                && ((s.IsRegular
                                     && !(s.SubjectStructure.Void ?? false)
                                     && !(s.SubjectStructure.Subject.Void ?? false)
                                     && s.SubjectStructure.Subject.SubjectCategory.SchoolId == schoolId)
                                    ||
                                    (!s.IsRegular && !(s.Subject.Void ?? false) &&
                                     s.Subject.SubjectCategory.SchoolId == schoolId)))
                    .OrderBy(x => x.IsRegular
                        ? x.SubjectStructure.Subject.FullName
                        : x.Subject.FullName)
                    .ToList();
                var list = new List<ClassViewModel>();
                foreach (var sc in regular)
                {
                    list.Add(new ClassViewModel()
                    {
                        IsRegular = sc.IsRegular,
                        StartDate = sc.StartDate.HasValue ? sc.StartDate.Value.ToString("D") : "",
                        EndDate = sc.EndDate.HasValue ? sc.EndDate.Value.ToString("D") : "",
                        SubjectId = sc.GetCourseId,
                        ClassId = sc.Id,
                        ClassName = sc.GetName,
                        OpenTillDate = sc.JoinLastDate.HasValue ? sc.JoinLastDate.Value.ToString("D") : "",
                        SubjectName = sc.GetCourseFullName,
                    });
                }

                return list;
            }


            public List<ClassViewModel> GetNoTeacherInClassNotification(int schoolId)
            {
                var teachRole = Context.Role.FirstOrDefault(x => x.RoleName == StaticValues.Roles.Teacher);
                if (teachRole != null)
                {
                    var now = DateTime.Now.Date;
                    var sss = Context.SubjectClass
                        .Where(x => !x.ClassUsers.Any(y => y.RoleId == teachRole.Id)
                                    && !(x.Void ?? false)
                                    && x.StartDate <= now
                                    && x.EndDate >= now
                                    && (x.SessionComplete == false)
                                    && (x.IsRegular
                                        ? x.SubjectStructure.Subject.SubjectCategory.SchoolId ==
                                          schoolId
                                        : x.Subject.SubjectCategory.SchoolId == schoolId))
                        .OrderBy(x => x.IsRegular
                            ? x.SubjectStructure.Subject.FullName
                            : x.Subject.FullName)
                        .ToList();
                    var list = new List<ClassViewModel>();
                    foreach (var sc in sss)
                    {
                        list.Add(new ClassViewModel()
                        {
                            IsRegular = sc.IsRegular,
                            StartDate = sc.StartDate.HasValue ? sc.StartDate.Value.ToString("D") : "",
                            EndDate = sc.EndDate.HasValue ? sc.EndDate.Value.ToString("D") : "",
                            SubjectId = sc.GetCourseId,
                            ClassId = sc.Id,
                            ClassName = sc.GetName,
                            OpenTillDate = sc.JoinLastDate.HasValue ? sc.JoinLastDate.Value.ToString("D") : "",
                            SubjectName = sc.GetCourseFullName,
                        });
                    }

                    return list;
                }
                return new List<ClassViewModel>();
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
