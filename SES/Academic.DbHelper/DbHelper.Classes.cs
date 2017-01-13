using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Academic.Database;
using Academic.DbEntities.Class;
using Academic.DbEntities.User;
using Academic.ViewModel;
using Academic.ViewModel.ActivityResource;

namespace Academic.DbHelper
{
    public partial class DbHelper
    {
        public class Classes : IDisposable
        {
            AcademicContext Context;

            public Classes()
            {
                Context = new AcademicContext();
            }


            #region Get functions i.e. which returns single value, not a List

            public Academic.DbEntities.Class.SubjectClass GetSubjectSession(int subjectSessionId)
            {
                return Context.SubjectClass.Find(subjectSessionId);
            }

            //used
            public Academic.DbEntities.Class.SubjectClass GetSubjectClassReport(int subjectClassId,
                out List<StudentReportViewModel> studentReports, out List<IdAndName> activityNames )
            {
                using (var gradeHelper = new DbHelper.Grade())
                {
                    
                studentReports = new List<StudentReportViewModel>();
                activityNames = new List<IdAndName>();
                var cls = Context.SubjectClass.Find(subjectClassId);
                if (cls != null)
                {
                    var actreses = cls.ActivityClasses.Select(x => x.ActivityResource).ToList();
                    var userClses = cls.ClassUsers.Where(x => !(x.Void ?? false) && !(x.Suspended ?? false)).ToList();
                    for (var a=0;a<actreses.Count;a++)
                    {
                       activityNames.Add(new IdAndName()
                       {
                           Id = actreses[a].Id
                           ,Name = actreses[a].Name
                           ,IdInString = (actreses[a].ActivityResourceId).ToString()
                           ,Value=(actreses[a].WeightInGradeSheet??0).ToString("F")
                       });
                    }

                    foreach (var usrcls in userClses)
                    {
                        var std = new StudentReportViewModel()
                        {
                            StudentId = usrcls.User.Id,
                            StudentName = (string.IsNullOrEmpty(usrcls.User.FirstName) ? "" : usrcls.User.FirstName)
                                            + (string.IsNullOrEmpty(usrcls.User.MiddleName) ? "" : usrcls.User.MiddleName)
                                            + (string.IsNullOrEmpty(usrcls.User.LastName) ? "" : usrcls.User.LastName)
                                            ,
                        };

                        var image = usrcls.User.UserImage;
                        if (image!= null)
                        {
                            std.ImageUrl = image.FileDirectory + image.FileName;
                        }
                        var st =usrcls.User.Student.FirstOrDefault();
                        std.CRN = st != null ? st.CRN : "";
                        var activities = new List<ActivityViewModel>();
                        std.ActivityViewModels = activities;
                        var total = (float) 0.0;
                        for(var b=0;b<actreses.Count;b++)
                        {
                            var ar = actreses[b];
                            var actVm = new ActivityViewModel()
                            {
                                Id = ar.Id
                                ,Name=ar.Name
                                
                                //,ActivityResourceId = ar.ActivityResourceId
                            };
                            var grade = ar.ActivityGradings.FirstOrDefault(x => x.UserClassId == usrcls.Id);
                            if (grade != null)
                            {
                                if (grade.ObtainedGradeId != null)
                                {
                                    if (grade.ObtainedGrade.Grade.GradeValueIsInPercentOrPostition ?? false)
                                    {
                                        //percent
                                        var obtRelative = (float)((1.0 * (grade.ObtainedGrade.EquivalentPercentOrPostition ?? 0) / 100.00)*(1.0 * ar.WeightInGradeSheet ?? 0));
                                        actVm.ObtainedMarks = obtRelative.ToString("F");
                                        total += obtRelative;
                                    }
                                    else
                                    {
                                        //position
                                        var obt=
                                            (gradeHelper.ConvertPositionToPercent(grade.ObtainedGrade.Grade,
                                               (int)(grade.ObtainedGrade.EquivalentPercentOrPostition??0)));
                                        var obtRelative = (float)((1.0 * (obt) / 100.00) * (1.0 * ar.WeightInGradeSheet ?? 0));
                                        actVm.ObtainedMarks = obtRelative.ToString("F");
                                        total += obtRelative;
                                    }

                                }
                                else
                                {
                                    var obtRelative = (float)((1.0 * (grade.ObtainedGradeMarks ?? 0) / 100.00) * (1.0 * ar.WeightInGradeSheet ?? 0));

                                    actVm.ObtainedMarks = obtRelative.ToString("F");
                                    total += obtRelative;
                                }
                            }
                            else
                            {
                                actVm.ObtainedMarks = "-";
                            }
                            
                            activities.Add(actVm);
                        }
                        std.TotalMarks = total.ToString("F");
                        studentReports.Add(std);
                    }
                    return cls;
                }
                studentReports = null;
                return null;
                }
            }

            #endregion


            #region List Functions i.e. which returns List<>

            public List<Academic.DbEntities.Class.SubjectClass> ListSessionsOfSubject(
                           int subjectId)
            {
                var regular =
                    Context.SubjectClass.Where(s => s.IsRegular).Where(x => x.SubjectStructure.SubjectId == subjectId);

                var notRegular = Context.SubjectClass.Where(s => (!s.IsRegular)).Where(x => x.SubjectId == subjectId);
                var list = regular.ToList();
                list.AddRange(notRegular);
                return list;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="subjectId"></param>
            /// <param name="courseCompletionType"> It specifies the type of classes to return. 
            /// 1=currently running,
            ///  2=Due, 3=not started yet, 4=completed, 5=all
            /// </param>
            /// <returns></returns>
            public List<Academic.DbEntities.Class.SubjectClass> ListClassesOfSubject(
                int subjectId, string courseCompletionType)
            {
                var regular = new List<Academic.DbEntities.Class.SubjectClass>();
                //Context.SubjectSession.Where(s => s.IsRegular).Where(x => x.SubjectStructure.SubjectId == subjectId);

                var notRegular = new List<Academic.DbEntities.Class.SubjectClass>();
                //Context.SubjectSession.Where(s => (!s.IsRegular)).Where(x => x.SubjectId == subjectId);
                var now = DateTime.Now.Date;
                var min = DateTime.MinValue.Date;
                var max = DateTime.MaxValue.Date;

                #region Switch string

                switch (courseCompletionType)
                {
                    case "btnCurrentlyRunning":
                        regular = Context.SubjectClass
                            .Where(s => s.IsRegular
                                && (s.StartDate ?? min) <= now
                                && (s.EndDate ?? max) >= now
                                && !(s.SessionComplete ?? false))
                            .Where(x => x.SubjectStructure.SubjectId == subjectId)
                            .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.RunningClass.ProgramBatch.Batch.Name)
                            .ThenBy(t => t.RunningClass.ProgramBatch.Program.Name)
                            .ToList();

                        notRegular = Context.SubjectClass
                            .Where(s => (!s.IsRegular)
                                && (s.StartDate ?? min) <= now
                                && (s.EndDate ?? max) >= now
                                && !(s.SessionComplete ?? false))
                            .Where(x => x.SubjectId == subjectId)
                            .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.Name)
                            .ToList();
                        break;
                    case "btnDue":
                        regular = Context.SubjectClass
                            .Where(s => s.IsRegular
                               && (s.EndDate ?? max) < now
                                && !(s.SessionComplete ?? false))
                            .Where(x => x.SubjectStructure.SubjectId == subjectId)
                            .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.RunningClass.ProgramBatch.Batch.Name).ThenBy(t => t.RunningClass.ProgramBatch.Program.Name)
                            .ToList();

                        notRegular = Context.SubjectClass
                            .Where(s => (!s.IsRegular)
                                && (s.EndDate ?? max) < now
                                && !(s.SessionComplete ?? false))
                            .Where(x => x.SubjectId == subjectId)
                            .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.Name)
                            .ToList();
                        //ApplyFilterAndLoadData(2);
                        break;
                    case "btnNotStartedYet":
                        regular = Context.SubjectClass
                            .Where(s => s.IsRegular
                                && (s.StartDate ?? min) > now
                                && !(s.SessionComplete ?? false))
                            .Where(x => x.SubjectStructure.SubjectId == subjectId)
                            .OrderByDescending(o => o.CreatedDate)
                            .ThenBy(t => t.RunningClass.ProgramBatch.Batch.Name)
                            .ThenBy(t => t.RunningClass.ProgramBatch.Program.Name)
                            .ToList();

                        notRegular = Context.SubjectClass
                            .Where(s => (!s.IsRegular)
                                && (s.StartDate ?? min) > now
                                && !(s.SessionComplete ?? false))
                            .Where(x => x.SubjectId == subjectId)
                            .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.Name)
                            .ToList();
                        //ApplyFilterAndLoadData(3);
                        break;
                    case "btnCompleted":
                        regular = Context.SubjectClass
                            .Where(s => s.IsRegular
                                && (s.SessionComplete ?? false))
                            .Where(x => x.SubjectStructure.SubjectId == subjectId)
                            .OrderByDescending(o => o.CreatedDate)
                            .ThenBy(t => t.RunningClass.ProgramBatch.Batch.Name)
                            .ThenBy(t => t.RunningClass.ProgramBatch.Program.Name)
                            .ToList();

                        notRegular = Context.SubjectClass
                            .Where(s => (!s.IsRegular)
                                && (s.SessionComplete ?? false))
                            .Where(x => x.SubjectId == subjectId)
                            .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.Name)
                            .ToList();
                        break;
                    default:
                        regular = Context.SubjectClass
                            .Where(s => s.IsRegular)
                            .Where(x => x.SubjectStructure.SubjectId == subjectId)
                            .OrderByDescending(o => o.CreatedDate)
                            .ThenBy(t => t.RunningClass.ProgramBatch.Batch.Name)
                            .ThenBy(t => t.RunningClass.ProgramBatch.Program.Name)
                            .ToList();

                        notRegular = Context.SubjectClass
                            .Where(s => (!s.IsRegular))
                            .Where(x => x.SubjectId == subjectId)
                            .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.Name)
                            .ToList();
                        break;
                }

                #endregion


                regular.AddRange(notRegular);
                return regular;
            }

            //used always
            public bool IsUserElligibleToViewSubjectSection(
               int subjectId, int userId)
            {
                //var regular = new List<Academic.DbEntities.Class.SubjectClass>();
                //Context.SubjectSession.Where(s => s.IsRegular).Where(x => x.SubjectStructure.SubjectId == subjectId);

                //var notRegular = new List<Academic.DbEntities.Class.SubjectClass>();
                //Context.SubjectSession.Where(s => (!s.IsRegular)).Where(x => x.SubjectId == subjectId);
                var now = DateTime.Now.Date;
                var min = DateTime.MinValue.Date;
                var max = DateTime.MaxValue.Date;
                var userclass = Context.UserClass.Where(x => !(x.Void ?? false)
                    && (x.UserId == userId)
                    && !(x.Suspended ?? false)).ToList();

                if (userclass.Select(x => x.SubjectClass)
                            .Where(s => s.IsRegular)
                            .Any(x => x.SubjectStructure.SubjectId == subjectId))
                    return true;

                if (userclass.Select(x => x.SubjectClass)
                         .Where(s => (!s.IsRegular))
                         .Any(x => x.SubjectId == subjectId))
                    return true;
                return false;
            }

            public List<Academic.DbEntities.Class.SubjectClass> ListCurrentClassesOfUser(
                int subjectId, int userId)
            {
                //var regular = new List<Academic.DbEntities.Class.SubjectClass>();
                //Context.SubjectSession.Where(s => s.IsRegular).Where(x => x.SubjectStructure.SubjectId == subjectId);

                //var notRegular = new List<Academic.DbEntities.Class.SubjectClass>();
                //Context.SubjectSession.Where(s => (!s.IsRegular)).Where(x => x.SubjectId == subjectId);
                var now = DateTime.Now.Date;
                var min = DateTime.MinValue.Date;
                var max = DateTime.MaxValue.Date;
                var userclass = Context.UserClass.Where(x => !(x.Void ?? false)
                    && (x.UserId == userId)
                    && !(x.Suspended ?? false)).ToList();

                //var re = userclass.Select(x => x.SubjectClass)// SubjectClass
                //        .Where(s =>  (s.StartDate ?? min) <= now
                //            && (s.EndDate ?? max) >= now
                //            && !(s.SessionComplete ?? false)
                //            &&((s.IsRegular)
                //            ?s.SubjectStructure.SubjectId == subjectId
                //            : s.SubjectId == subjectId)

                //            )
                ////.Where(x => x.SubjectStructure.SubjectId == subjectId)
                //.OrderByDescending(o => o.CreatedDate).ThenBy(t => t.RunningClass.ProgramBatch.Batch.Name)
                //.ThenBy(t => t.RunningClass.ProgramBatch.Program.Name)
                //.ToList();

                var regular = userclass.Select(x => x.SubjectClass)// SubjectClass
                         .Where(s => s.IsRegular
                             && (s.StartDate ?? min) <= now
                             && (s.EndDate ?? max) >= now
                             && !(s.SessionComplete ?? false))
                         .Where(x => x.SubjectStructure.SubjectId == subjectId)
                         .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.RunningClass.ProgramBatch.Batch.Name)
                         .ThenBy(t => t.RunningClass.ProgramBatch.Program.Name)
                         .ToList();

                var notRegular = userclass.Select(x => x.SubjectClass)//.SubjectClass
                         .Where(s => (!s.IsRegular)
                             && (s.StartDate ?? min) <= now
                             && (s.EndDate ?? max) >= now
                             && !(s.SessionComplete ?? false))
                         .Where(x => x.SubjectId == subjectId)
                         .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.Name)
                         .ToList();

                regular.AddRange(notRegular);
                return regular;
            }

            public List<Academic.DbEntities.Class.SubjectClass> ListCurrentClassesOfTeacher(
                int subjectId, int userId, List<string> roles, List<IdAndName> classesToIgnore = null)
            {
                //var regular = new List<Academic.DbEntities.Class.SubjectClass>();
                //Context.SubjectSession.Where(s => s.IsRegular).Where(x => x.SubjectStructure.SubjectId == subjectId);

                //var notRegular = new List<Academic.DbEntities.Class.SubjectClass>();
                //Context.SubjectSession.Where(s => (!s.IsRegular)).Where(x => x.SubjectId == subjectId);
                var now = DateTime.Now.Date;
                var min = DateTime.MinValue.Date;
                var max = DateTime.MaxValue.Date;

                if (roles.Contains(StaticValues.Roles.CourseEditor)
                    || roles.Contains(StaticValues.Roles.Manager))
                {
                    var regular = Context.SubjectClass
                        .Where(s => s.IsRegular
                                    && (s.StartDate ?? min) <= now
                                    && (s.EndDate ?? max) >= now
                                    && !(s.SessionComplete ?? false))
                        .Where(x => x.SubjectStructure.SubjectId == subjectId)
                        .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.RunningClass.ProgramBatch.Batch.Name)
                        .ThenBy(t => t.RunningClass.ProgramBatch.Program.Name)
                      .ToList();
                    for (var i = 0; i < regular.Count; i++)
                    {
                        regular[i].Name = regular[i].GetName;
                    }

                    var notRegular = Context.SubjectClass
                        .Where(s => (!s.IsRegular)
                                    && s.SubjectId == subjectId
                                    && (s.StartDate ?? min) <= now
                                    && (s.EndDate ?? max) >= now
                                    && !(s.SessionComplete ?? false))
                        .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.Name)
                        .ToList();
                    var rg = Context.SubjectClass.ToList();
                    var gg = Context.SubjectClass.Where(x => !x.IsRegular).OrderBy(x => x.CreatedDate).ToList();
                    var vgg = Context.SubjectClass.Where(x => !x.IsRegular)
                        .OrderBy(x => x.CreatedDate)
                        .ThenBy(x => x.Name).ToList();

                    regular.AddRange(notRegular);

                    if (classesToIgnore != null)
                    {
                        var cti = classesToIgnore.Select(x => x.Id).ToList();
                        foreach (var c in cti)
                        {
                            var found = regular.Find(x => x.Id == c);
                            if (found != null)
                            {
                                regular.Remove(found);
                            }
                        }
                    }
                    return regular;
                }
                else
                {
                    var userclass = Context.UserClass.Where(x => !(x.Void ?? false)

                                                                 && (x.UserId == userId)
                                                                 && !(x.Suspended ?? false)
                                                                 && (x.Role.RoleName == "teacher")

                        ).ToList();

                    var regular = userclass.Select(x => x.SubjectClass) // SubjectClass
                        .Where(s => s.IsRegular
                                    && (s.StartDate ?? min) <= now
                                    && (s.EndDate ?? max) >= now
                                    && !(s.SessionComplete ?? false))
                        .Where(x => x.SubjectStructure.SubjectId == subjectId)
                        .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.RunningClass.ProgramBatch.Batch.Name)
                        .ThenBy(t => t.RunningClass.ProgramBatch.Program.Name)
                        .ToList();
                    for (var i = 0; i < regular.Count; i++)
                    {
                        regular[i].Name = regular[i].GetName;
                    }
                    var notRegular = userclass.Select(x => x.SubjectClass) //.SubjectClass
                        .Where(s => (!s.IsRegular)
                                    && (s.StartDate ?? min) <= now
                                    && (s.EndDate ?? max) >= now
                                    && !(s.SessionComplete ?? false))
                        .Where(x => x.SubjectId == subjectId)
                        .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.Name)
                        .ToList();

                    regular.AddRange(notRegular);

                    if (classesToIgnore != null)
                    {
                        var cti = classesToIgnore.Select(x => x.Id).ToList();
                        foreach (var c in cti)
                        {
                            var found = regular.Find(x => x.Id == c);
                            if (found != null)
                            {
                                regular.Remove(found);
                            }
                        }
                    }
                    return regular;
                }
            }

            //used
            /// <summary>
            /// role is a string with roles separatted by commas and no spaces
            /// </summary>
            /// <param name="subjectId"></param>
            /// <param name="userId"></param>
            /// <param name="role">separated by comma and no spaces. </param>
            /// <returns></returns>
            public List<Academic.DbEntities.Class.SubjectClass> ListCurrentClassesOfTeacherForCombo(
              int subjectId, int userId, string role)
            {
                //var regular = new List<Academic.DbEntities.Class.SubjectClass>();
                //Context.SubjectSession.Where(s => s.IsRegular).Where(x => x.SubjectStructure.SubjectId == subjectId);

                //var notRegular = new List<Academic.DbEntities.Class.SubjectClass>();
                //Context.SubjectSession.Where(s => (!s.IsRegular)).Where(x => x.SubjectId == subjectId);
                var now = DateTime.Now.Date;
                var min = DateTime.MinValue.Date;
                var max = DateTime.MaxValue.Date;
                var roles = role.Split(new char[] { ',' });
                if (roles.Contains(StaticValues.Roles.CourseEditor)
                    || roles.Contains(StaticValues.Roles.Manager))
                {
                    var regular = Context.SubjectClass
                        .Where(s => s.IsRegular
                                    && (s.StartDate ?? min) <= now
                                    && (s.EndDate ?? max) >= now
                                    && !(s.SessionComplete ?? false))
                        .Where(x => x.SubjectStructure.SubjectId == subjectId)
                        .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.RunningClass.ProgramBatch.Batch.Name)
                        .ThenBy(t => t.RunningClass.ProgramBatch.Program.Name)
                        .ToList();
                    for (var i = 0; i < regular.Count; i++)
                    {
                        regular[i].Name = regular[i].GetName;
                    }

                    var notRegular = Context.SubjectClass
                        .Where(s => (!s.IsRegular)
                                    && s.SubjectId == subjectId
                                    && (s.StartDate ?? min) <= now
                                    && (s.EndDate ?? max) >= now
                                    && !(s.SessionComplete ?? false))
                        .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.Name)
                        .ToList();
                    var rg = Context.SubjectClass.ToList();
                    var gg = Context.SubjectClass.Where(x => !x.IsRegular).OrderBy(x => x.CreatedDate).ToList();
                    var vgg = Context.SubjectClass.Where(x => !x.IsRegular)
                        .OrderBy(x => x.CreatedDate)
                        .ThenBy(x => x.Name).ToList();

                    regular.AddRange(notRegular);

                    //if (classesToIgnore != null)
                    //{
                    //    var cti = classesToIgnore.Select(x => x.Id).ToList();
                    //    foreach (var c in cti)
                    //    {
                    //        var found = regular.Find(x => x.Id == c);
                    //        if (found != null)
                    //        {
                    //            regular.Remove(found);
                    //        }
                    //    }
                    //}
                    regular.Insert(0, new SubjectClass() { Name = "Choose", Id = 0 });
                    return regular;
                }
                else
                {
                    var userclass = Context.UserClass.Where(x => !(x.Void ?? false)

                                                                 && (x.UserId == userId)
                                                                 && !(x.Suspended ?? false)
                                                                 && (x.Role.RoleName == "teacher")

                        ).ToList();

                    var regular = userclass.Select(x => x.SubjectClass) // SubjectClass
                        .Where(s => s.IsRegular
                                    && (s.StartDate ?? min) <= now
                                    && (s.EndDate ?? max) >= now
                                    && !(s.SessionComplete ?? false))
                        .Where(x => x.SubjectStructure.SubjectId == subjectId)
                        .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.RunningClass.ProgramBatch.Batch.Name)
                        .ThenBy(t => t.RunningClass.ProgramBatch.Program.Name)
                        .ToList();
                    for (var i = 0; i < regular.Count; i++)
                    {
                        regular[i].Name = regular[i].GetName;
                    }
                    var notRegular = userclass.Select(x => x.SubjectClass) //.SubjectClass
                        .Where(s => (!s.IsRegular)
                                    && (s.StartDate ?? min) <= now
                                    && (s.EndDate ?? max) >= now
                                    && !(s.SessionComplete ?? false))
                        .Where(x => x.SubjectId == subjectId)
                        .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.Name)
                        .ToList();

                    regular.AddRange(notRegular);

                    //if (classesToIgnore != null)
                    //{
                    //    var cti = classesToIgnore.Select(x => x.Id).ToList();
                    //    foreach (var c in cti)
                    //    {
                    //        var found = regular.Find(x => x.Id == c);
                    //        if (found != null)
                    //        {
                    //            regular.Remove(found);
                    //        }
                    //    }
                    //}
                    regular.Insert(0, new SubjectClass() { Name = "Choose", Id = 0 });

                    return regular;
                }
            }



            public List<Academic.DbEntities.User.Users> ListUsersOfSubjectSession(int subjectSessionId)
            {
                var subsession = Context.SubjectClass.Find(subjectSessionId);
                if (subsession != null)
                {
                    return subsession.ClassUsers.Where(x => !(x.Void ?? false))
                        .Select(x => x.User).ToList();
                }
                return new List<Users>();
            }

            public List<Academic.DbEntities.User.Users> ListUsersNotInSubjectSession(int subjectSessionId, List<int> asignedList, int schoolId)
            {
                var subsession = Context.SubjectClass.Find(subjectSessionId);
                if (subsession != null)
                {
                    var users = Context.Users.Where(x => !asignedList.Contains(x.Id)
                        && x.SchoolId == schoolId)
                        .OrderBy(y => y.FirstName)
                        .ThenBy(t => t.MiddleName)
                        .ThenBy(y => y.LastName);
                    return users.Take(50).ToList();
                }
                return new List<Users>();
                //Context.Users
                //.OrderBy(y => y.FirstName)
                //.ThenBy(t => t.MiddleName)
                //.ThenBy(y => y.LastName).Take(50).ToList();
            }


            public List<ViewModel.UserClassViewModel> ListSessionUsers(int subjectSessionId)
            {
                var subsession = Context.SubjectClass.Find(subjectSessionId);
                if (subsession != null)
                {
                    var lst = new List<ViewModel.UserClassViewModel>();
                    var clsusers = subsession.ClassUsers.Where(x => !(x.Void ?? false))
                        .ToList();
                    foreach (var uvm in clsusers)
                    {
                        lst.Add(new ViewModel.UserClassViewModel()
                        {
                            Id = uvm.Id,
                            CreatedDate = uvm.CreatedDate
                            ,
                            EndDate = uvm.EndDate
                            ,
                            EnrollmentDuration = uvm.EnrollmentDuration
                            ,
                            RoleId = uvm.RoleId
                            ,
                            StartDate = uvm.StartDate
                            ,
                            SubjectClassId = uvm.SubjectClassId
                            ,
                            Suspended = uvm.Suspended
                            ,
                            UserId = uvm.UserId
                            ,
                            Void = uvm.Void
                            ,
                        });
                    }
                    return lst;
                }
                return new List<UserClassViewModel>();
            }

            public List<DbEntities.User.Users> ListSubjectSessionEnrolledUsers(int subjectSessionId)
            {
                var subsession = Context.SubjectClass.Find(subjectSessionId);
                if (subsession != null)
                {
                    return subsession.ClassUsers.Where(x => !(x.Void ?? false)).Select(x => x.User).ToList();
                }
                return new List<DbEntities.User.Users>();
            }

            //used after github
            public List<ViewModel.ActivityResource.UserSubmissionsViewModel> ListUserSubmissionses(
                int subjectClassId, string type)
            {
                var subsession = Context.SubjectClass.Find(subjectClassId);
                if (subsession != null)
                {
                    var lst = new List<UserSubmissionsViewModel>();
                    var cls = subsession.ClassUsers.Where(x => !(x.Void ?? false)).ToList();
                    foreach (var c in cls)
                    {
                        var ent = new UserSubmissionsViewModel()
                        {
                            UserId = c.UserId ?? 0
                            ,
                            UserName = c.User == null ? "" : c.User.UserName
                            ,
                            Email = c.User == null ? "" : c.User.Email

                        };
                        lst.Add(ent);
                    }
                    return lst;
                }
                return new List<UserSubmissionsViewModel>();
            }

            #endregion


            #region Add Or Update functions


            public bool AddOrUpdateSubjectSession(DbEntities.Class.SubjectClass subjectSession)
            {
                try
                {
                    var ent = Context.SubjectClass.Find(subjectSession.Id);
                    if (ent == null)
                    {
                        Context.SubjectClass.Add(subjectSession);
                        Context.SaveChanges();
                        return true;
                    }

                    ent.Name = subjectSession.Name;
                    //ent.UseDefaultGrouping = subjectSession.UseDefaultGrouping;
                    Context.SaveChanges();
                    return true;

                }
                catch { return false; }

            }

            public bool AddOrUpdateUsersList(List<Academic.DbEntities.Class.UserClass> userList)
            {
                try
                {
                    using (var scope = new TransactionScope())
                    {
                        foreach (var sessUser in userList)
                        {
                            var userFound = Context.UserClass.Find(sessUser.Id);
                            if (userFound == null)
                            {
                                Context.UserClass.Add(sessUser);
                            }
                            else
                            {
                                userFound.Void = sessUser.Void;
                            }
                            Context.SaveChanges();
                        }
                        scope.Complete();
                        return true;
                    }
                }
                catch
                {
                    return false;
                }

            }

            public void AddOrUpdateUsersList(List<int> userList, int subjectSessionId, int p)
            {
                var subsession = Context.SubjectClass.Find(subjectSessionId);
                if (subsession != null)
                {
                    foreach (var i in userList)
                    {
                        var userFound =
                            Context.UserClass.FirstOrDefault(x => x.UserId == i && !(x.Void ?? false));
                        if (userFound == null)
                        {
                            Context.UserClass.Add(new UserClass()
                            {
                                UserId = i
                                    //,JoinedDate = 
                                ,
                            });

                        }
                    }
                }
            }


            #endregion


            public void Dispose()
            {
                Context.Dispose();
            }


            public List<SubjectClassGrouping> ListGroupsOfClass(int classId)
            {
                var cls = Context.SubjectClass.Find(classId);
                if (cls != null)
                {
                    if (cls.HasGrouping)
                    {
                        return cls.SubjectClassGrouping.ToList();
                    }
                    else return null;
                }
                return null;
            }

            //used
            //public UserClass GetUserClassOfUser(int subjectId, int userId)
            //{
            //    return Context.UserClass.FirstOrDefault(
            //        x =>
            //            (x.SubjectClass.IsRegular
            //                ? (x.SubjectClass.SubjectStructure.SubjectId == subjectId):(x.SubjectClass.SubjectId==subjectId)) && x.UserId == userId);

            //}

            //used
            public List<UserClass> GetCurrentUserClassesOfUser(int subjectId, int userId)
            {
                var date = DateTime.Now;
                return Context.UserClass.Where(
                    x =>
                        (x.SubjectClass.IsRegular
                            ? (x.SubjectClass.SubjectStructure.SubjectId == subjectId)
                            : (x.SubjectClass.SubjectId == subjectId))
                            && x.UserId == userId
                            && !(x.Void ?? false)
                            && (!(x.SubjectClass.SessionComplete ?? false)
                                    || (x.SubjectClass.StartDate <= date && x.EndDate >= date)
                                )
                            && !(x.Suspended ?? false)

                            ).ToList();

            }



            public UserClass GetUserClass(int userClassId)
            {
                return Context.UserClass.Find(userClassId);
            }
        }
    }
}
