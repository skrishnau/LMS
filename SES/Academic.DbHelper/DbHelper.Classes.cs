using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Academic.Database;
using Academic.DbEntities.Class;
using Academic.DbEntities.User;
using Academic.ViewModel;
using Academic.ViewModel.ActivityResource;
using Academic.ViewModel.Structure;

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
                out List<StudentReportViewModel> studentReports, out List<IdAndName> activityNames)
            {
                using (var actresHelper = new DbHelper.ActAndRes())
                using (var gradeHelper = new DbHelper.Grade())
                {

                    studentReports = new List<StudentReportViewModel>();
                    activityNames = new List<IdAndName>();
                    var cls = Context.SubjectClass.Find(subjectClassId);
                    if (cls != null)
                    {
                        var actreses = cls.ActivityClasses.Where(x => !(x.ActivityResource.Void ?? false)).Select(x => x.ActivityResource).ToList();

                        var stdRole = Context.Role.FirstOrDefault(x => x.RoleName == StaticValues.Roles.Student);
                        if (stdRole != null)
                        {
                            var userClses = cls.ClassUsers.Where(x => !(x.Void ?? false)
                                                                    && !(x.Suspended ?? false)
                                                                    && (x.RoleId ?? 0) == stdRole.Id)
                                                             .ToList();

                            for (var a = 0; a < actreses.Count; a++)
                            {
                                activityNames.Add(new IdAndName()
                                {
                                    Id = actreses[a].Id
                                    ,
                                    Name = actreses[a].Name
                                    ,
                                    IdInString = (actreses[a].ActivityResourceId).ToString()
                                    ,
                                    Value = (actreses[a].WeightInGradeSheet ?? 0).ToString("F")
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
                                if (image != null)
                                {
                                    std.ImageUrl = image.FileDirectory + image.FileName;
                                }
                                var st = usrcls.User.Student.FirstOrDefault();
                                std.CRN = st != null ? st.CRN : "";
                                var activities = new List<ActivityViewModel>();
                                std.ActivityViewModels = activities;
                                var total = (float)0.0;



                                for (var b = 0; b < actreses.Count; b++)
                                {
                                    var ar = actreses[b];
                                    var actVm = new ActivityViewModel()
                                    {
                                        Id = ar.Id
                                        ,
                                        Name = ar.Name

                                        //,ActivityResourceId = ar.ActivityResourceId
                                    };
                                    var grade = ar.ActivityGradings.FirstOrDefault(x => x.UserClassId == usrcls.Id);
                                    if (grade != null)
                                    {
                                        if (grade.ObtainedGradeId != null)//value type
                                        {
                                            if (grade.ObtainedGrade.Grade.GradeValueIsInPercentOrPostition ?? false)
                                            {
                                                //percent
                                                var obtRelative = (float)((1.0 * (grade.ObtainedGrade.EquivalentPercentOrPostition ?? 0) / 100.00) * (1.0 * ar.WeightInGradeSheet ?? 0));
                                                actVm.ObtainedMarks = obtRelative.ToString("F");
                                                total += obtRelative;
                                            }
                                            else
                                            {
                                                //position
                                                var obt =
                                                    (gradeHelper.ConvertPositionToPercent(grade.ObtainedGrade.Grade,
                                                       (int)(grade.ObtainedGrade.EquivalentPercentOrPostition ?? 0)));
                                                var obtRelative = (float)((1.0 * (obt) / 100.00) * (1.0 * ar.WeightInGradeSheet ?? 0));
                                                actVm.ObtainedMarks = obtRelative.ToString("F");
                                                total += obtRelative;
                                            }

                                        }
                                        else//range type
                                        {

                                            if (ar.ActivityResourceType == (byte)Enums.Activities.Assignment)
                                            {
                                                var ass = actresHelper.GetAssignment(ar.ActivityResourceId);
                                                if (ass != null)
                                                {
                                                    //var minValue = ass.MaximumGrade
                                                    if (!ass.GradeType.RangeOrValue)
                                                    {
                                                        //ass.GradeType.m
                                                    }
                                                }
                                            }
                                            var obtRelative =
                                                (float)((1.0 * (grade.ObtainedGradeMarks ?? 0) / 100.00) * (1.0 * ar.WeightInGradeSheet ?? 0));

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
            public List<ClassViewModel> ListClassesOfSubject(
                int subjectId, string courseCompletionType)
            {
                var regular = new List<Academic.DbEntities.Class.SubjectClass>();
                //Context.SubjectSession.Where(s => s.IsRegular).Where(x => x.SubjectStructure.SubjectId == subjectId);

                //var notRegular = new List<Academic.DbEntities.Class.SubjectClass>();
                //Context.SubjectSession.Where(s => (!s.IsRegular)).Where(x => x.SubjectId == subjectId);
                var now = DateTime.Now.Date;
                var min = DateTime.MinValue.Date;
                var max = DateTime.MaxValue.Date;

                #region Switch string

                switch (courseCompletionType)
                {
                    case "btnCurrentlyRunning":

                        regular = Context.SubjectClass
                            .Where(s => !(s.Void ?? false)
                                && (s.StartDate ?? min) <= now
                                && (s.EndDate ?? max) >= now
                                && !(s.SessionComplete ?? false)
                                && ((s.IsRegular && !(s.SubjectStructure.Void ?? false) && s.SubjectStructure.SubjectId == subjectId)
                                     || (!s.IsRegular && s.SubjectId == subjectId))
                                )
                                .OrderByDescending(o => o.CreatedDate)
                                .ThenBy(t => (t.IsRegular ? t.RunningClass.ProgramBatch.Batch.Name : t.Name))
                                .ThenBy(t => (t.IsRegular ? t.RunningClass.ProgramBatch.Program.Name : ""))
                            .ToList();

                        //regular = Context.SubjectClass
                        //    .Where(s => s.IsRegular
                        //        && !(s.Void??false)
                        //        && (s.StartDate ?? min) <= now
                        //        && (s.EndDate ?? max) >= now
                        //        && !(s.SessionComplete ?? false))
                        //    .Where(x => x.SubjectStructure.SubjectId == subjectId)
                        //    .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.RunningClass.ProgramBatch.Batch.Name)
                        //    .ThenBy(t => t.RunningClass.ProgramBatch.Program.Name)
                        //    .ToList();

                        //notRegular = Context.SubjectClass
                        //    .Where(s => (!s.IsRegular)
                        //        && !(s.Void ?? false)
                        //        && (s.StartDate ?? min) <= now
                        //        && (s.EndDate ?? max) >= now
                        //        && !(s.SessionComplete ?? false))
                        //    .Where(x => x.SubjectId == subjectId)
                        //    .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.Name)
                        //    .ToList();
                        break;
                    case "btnDue":

                        regular = Context.SubjectClass
                            .Where(s => !(s.Void ?? false)
                                //&& (s.StartDate ?? min) <= now
                               && (s.EndDate ?? max) < now
                                && !(s.SessionComplete ?? false)
                                && ((s.IsRegular && !(s.SubjectStructure.Void ?? false) && s.SubjectStructure.SubjectId == subjectId)
                                     || (!s.IsRegular && s.SubjectId == subjectId))
                                )
                                .OrderByDescending(o => o.CreatedDate)
                                .ThenBy(t => (t.IsRegular ? t.RunningClass.ProgramBatch.Batch.Name : t.Name))
                                .ThenBy(t => (t.IsRegular ? t.RunningClass.ProgramBatch.Program.Name : ""))
                            .ToList();

                        //regular = Context.SubjectClass
                        //    .Where(s => s.IsRegular
                        //        && !(s.Void ?? false)
                        //       && (s.EndDate ?? max) < now
                        //        && !(s.SessionComplete ?? false))
                        //    .Where(x => x.SubjectStructure.SubjectId == subjectId)
                        //    .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.RunningClass.ProgramBatch.Batch.Name).ThenBy(t => t.RunningClass.ProgramBatch.Program.Name)
                        //    .ToList();

                        //notRegular = Context.SubjectClass
                        //    .Where(s => (!s.IsRegular)
                        //        && !(s.Void ?? false)
                        //        && (s.EndDate ?? max) < now
                        //        && !(s.SessionComplete ?? false))
                        //    .Where(x => x.SubjectId == subjectId)
                        //    .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.Name)
                        //    .ToList();
                        //ApplyFilterAndLoadData(2);
                        break;
                    case "btnNotStartedYet":

                        regular = Context.SubjectClass
                           .Where(s => !(s.Void ?? false)
                                && (s.StartDate ?? min) > now
                               && !(s.SessionComplete ?? false)
                               && ((s.IsRegular && !(s.SubjectStructure.Void ?? false) && s.SubjectStructure.SubjectId == subjectId)
                                    || (!s.IsRegular && s.SubjectId == subjectId))
                               )
                               .OrderByDescending(o => o.CreatedDate)
                               .ThenBy(t => (t.IsRegular ? t.RunningClass.ProgramBatch.Batch.Name : t.Name))
                               .ThenBy(t => (t.IsRegular ? t.RunningClass.ProgramBatch.Program.Name : ""))
                           .ToList();

                        //regular = Context.SubjectClass
                        //    .Where(s => s.IsRegular
                        //        && !(s.Void ?? false)
                        //        && (s.StartDate ?? min) > now
                        //        && !(s.SessionComplete ?? false))
                        //    .Where(x => x.SubjectStructure.SubjectId == subjectId)
                        //    .OrderByDescending(o => o.CreatedDate)
                        //    .ThenBy(t => t.RunningClass.ProgramBatch.Batch.Name)
                        //    .ThenBy(t => t.RunningClass.ProgramBatch.Program.Name)
                        //    .ToList();

                        //notRegular = Context.SubjectClass
                        //    .Where(s => (!s.IsRegular)
                        //        && !(s.Void ?? false)
                        //        && (s.StartDate ?? min) > now
                        //        && !(s.SessionComplete ?? false))
                        //    .Where(x => x.SubjectId == subjectId)
                        //    .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.Name)
                        //    .ToList();
                        //ApplyFilterAndLoadData(3);
                        break;
                    case "btnCompleted":

                        regular = Context.SubjectClass
                           .Where(s => !(s.Void ?? false)
                               && (s.SessionComplete ?? false)
                               && ((s.IsRegular && !(s.SubjectStructure.Void ?? false) && s.SubjectStructure.SubjectId == subjectId)
                                    || (!s.IsRegular && s.SubjectId == subjectId))
                               )
                               .OrderByDescending(o => o.CreatedDate)
                               .ThenBy(t => (t.IsRegular ? t.RunningClass.ProgramBatch.Batch.Name : t.Name))
                               .ThenBy(t => (t.IsRegular ? t.RunningClass.ProgramBatch.Program.Name : ""))
                           .ToList();

                        //regular = Context.SubjectClass
                        //    .Where(s => s.IsRegular
                        //        && !(s.Void ?? false)
                        //        && (s.SessionComplete ?? false))
                        //    .Where(x => x.SubjectStructure.SubjectId == subjectId)
                        //    .OrderByDescending(o => o.CreatedDate)
                        //    .ThenBy(t => t.RunningClass.ProgramBatch.Batch.Name)
                        //    .ThenBy(t => t.RunningClass.ProgramBatch.Program.Name)
                        //    .ToList();

                        //notRegular = Context.SubjectClass
                        //    .Where(s => (!s.IsRegular)
                        //        && !(s.Void ?? false)
                        //        && (s.SessionComplete ?? false))
                        //    .Where(x => x.SubjectId == subjectId)
                        //    .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.Name)
                        //    .ToList();

                        break;
                    default:

                        regular = Context.SubjectClass
                            .Where(s => !(s.Void ?? false)
                                && ((s.IsRegular && !(s.SubjectStructure.Void ?? false) && s.SubjectStructure.SubjectId == subjectId)
                                     || (!s.IsRegular && s.SubjectId == subjectId))
                                )
                                .OrderByDescending(o => o.CreatedDate)
                                .ThenBy(t => (t.IsRegular ? t.RunningClass.ProgramBatch.Batch.Name : t.Name))
                                .ThenBy(t => (t.IsRegular ? t.RunningClass.ProgramBatch.Program.Name : ""))
                            .ToList();

                        //regular = Context.SubjectClass
                        //    .Where(s => s.IsRegular&& !(s.Void ?? false))
                        //    .Where(x => x.SubjectStructure.SubjectId == subjectId)
                        //    .OrderByDescending(o => o.CreatedDate)
                        //    .ThenBy(t => t.RunningClass.ProgramBatch.Batch.Name)
                        //    .ThenBy(t => t.RunningClass.ProgramBatch.Program.Name)
                        //    .ToList();

                        //notRegular = Context.SubjectClass
                        //    .Where(s => (!s.IsRegular)&& !(s.Void ?? false))
                        //    .Where(x => x.SubjectId == subjectId)
                        //    .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.Name)
                        //    .ToList();

                        break;
                }

                #endregion

                var date = DateTime.Now.Date;
                var list = new List<ClassViewModel>();
                foreach (var x in regular)
                {
                    var cv = new ClassViewModel()
                    {
                        EndDate = x.EndDate.HasValue ? x.EndDate.Value.ToString("D") : "",
                        ClassId = x.Id,
                        StartDate = x.StartDate.HasValue ? x.StartDate.Value.ToString("D") : "",
                        ClassName = x.IsRegular ? x.GetName : x.Name,
                        RunningClassId = x.RunningClassId ?? 0,
                        OpenTillDate = x.JoinLastDate.HasValue ? x.JoinLastDate.Value.ToString("D") : "",
                        SubjectId = x.IsRegular ? x.SubjectStructure.SubjectId : x.SubjectId ?? 0,
                        IsRegular = x.IsRegular
                    };
                    //var startD = (x.StartDate == null) ? DateTime.MinValue : Convert.ToDateTime(x.StartDate);
                    //var endD = (endDate == null) ? DateTime.MaxValue : Convert.ToDateTime(endDate.ToString());
                    if (x.SessionComplete ?? false)
                    {
                        cv.IconUrl = "~/Content/Icons/Stop/Stop_10px.png";
                    }
                    else
                    {
                        if (x.StartDate != null && x.StartDate.Value > date)
                        {
                            //not started yet
                            cv.IconUrl = "~/Content/Icons/Hourglass/schedule_14px.png";
                        }
                        else if (x.EndDate != null && x.EndDate.Value < date)
                        {
                            //due
                            cv.IconUrl = "~/Content/Icons/Watch/alarm_clock_14px.png";
                        }
                        else
                        {
                            cv.IconUrl = "~/Content/Icons/Start/active_icon_10px.png";
                        }
                    }
                    list.Add(cv);
                }

                //regular.AddRange(notRegular);
                //return regular;
                return list;
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
                            .Where(s => s.IsRegular && !(s.Void ?? false))
                            .Any(x => x.SubjectStructure.SubjectId == subjectId))
                    return true;

                if (userclass.Select(x => x.SubjectClass)
                         .Where(s => (!s.IsRegular) && !(s.Void ?? false))
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
                                && !(s.Void ?? false)
                             && (s.StartDate ?? min) <= now
                             && (s.EndDate ?? max) >= now
                             && !(s.SessionComplete ?? false))
                         .Where(x => x.SubjectStructure.SubjectId == subjectId)
                         .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.RunningClass.ProgramBatch.Batch.Name)
                         .ThenBy(t => t.RunningClass.ProgramBatch.Program.Name)
                         .ToList();

                var notRegular = userclass.Select(x => x.SubjectClass)//.SubjectClass
                         .Where(s => (!s.IsRegular)
                                && !(s.Void ?? false)
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
                int subjectId, int userId, bool isManager, List<IdAndName> classesToIgnore = null)
            {
                var now = DateTime.Now.Date;
                var min = DateTime.MinValue.Date;
                var max = DateTime.MaxValue.Date;
                var teachRole = Context.Role.FirstOrDefault(x => x.RoleName == StaticValues.Roles.Teacher);

                var reg = Context.SubjectClass
                       .Where(s => //s.IsRegular&& 
                                    !(s.Void ?? false)
                                   && (((s.StartDate ?? min) <= now && (s.EndDate ?? max) >= now)
                                                    || (s.SessionComplete == false))
                                   && (isManager || s.ClassUsers.Any(x => x.UserId == userId && x.RoleId == teachRole.Id))
                                   && (s.IsRegular
                                        ? (s.SubjectStructure.SubjectId == subjectId)
                                        : s.SubjectId == subjectId))
                       .OrderByDescending(o => o.StartDate)
                       .ThenBy(t => t.IsRegular ? t.RunningClass.ProgramBatch.Batch.Name : t.Name)
                     .ToList();

                for (var i = 0; i < reg.Count; i++)
                {
                    reg[i].Name = reg[i].GetName;
                }
                if (classesToIgnore != null)
                {
                    var cti = classesToIgnore.Select(x => x.Id).ToList();
                    foreach (var c in cti)
                    {
                        var found = reg.Find(x => x.Id == c);
                        if (found != null)
                        {
                            reg.Remove(found);
                        }
                    }
                }

                return reg;

                #region Earlier code commented--- long code

                //if (roles.Contains(StaticValues.Roles.CourseEditor)
                //    || roles.Contains(StaticValues.Roles.Manager))
                //{
                //    var regular = Context.SubjectClass
                //        .Where(s => s.IsRegular
                //                && !(s.Void ?? false)
                //                    && (s.StartDate ?? min) <= now
                //                    && (s.EndDate ?? max) >= now
                //                    && !(s.SessionComplete ?? false))
                //        .Where(x => x.SubjectStructure.SubjectId == subjectId)
                //        .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.RunningClass.ProgramBatch.Batch.Name)
                //        .ThenBy(t => t.RunningClass.ProgramBatch.Program.Name)
                //      .ToList();
                //    for (var i = 0; i < regular.Count; i++)
                //    {
                //        regular[i].Name = regular[i].GetName;
                //    }

                //    var notRegular = Context.SubjectClass
                //        .Where(s => (!s.IsRegular)
                //                && !(s.Void ?? false)
                //                    && s.SubjectId == subjectId
                //                    && (s.StartDate ?? min) <= now
                //                    && (s.EndDate ?? max) >= now
                //                    && !(s.SessionComplete ?? false))
                //        .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.Name)
                //        .ToList();
                //    var rg = Context.SubjectClass.ToList();
                //    var gg = Context.SubjectClass.Where(x => !x.IsRegular).OrderBy(x => x.CreatedDate).ToList();
                //    var vgg = Context.SubjectClass.Where(x => !x.IsRegular)
                //        .OrderBy(x => x.CreatedDate)
                //        .ThenBy(x => x.Name).ToList();

                //    regular.AddRange(notRegular);

                //    if (classesToIgnore != null)
                //    {
                //        var cti = classesToIgnore.Select(x => x.Id).ToList();
                //        foreach (var c in cti)
                //        {
                //            var found = regular.Find(x => x.Id == c);
                //            if (found != null)
                //            {
                //                regular.Remove(found);
                //            }
                //        }
                //    }
                //    return regular;
                //}
                //else
                //{
                //    var userclass = Context.UserClass.Where(x => !(x.Void ?? false)

                //                                                 && (x.UserId == userId)
                //                                                 && !(x.Suspended ?? false)
                //                                                 && (x.Role.RoleName == "teacher")

                //        ).ToList();

                //    var regular = userclass.Select(x => x.SubjectClass) // SubjectClass
                //        .Where(s => s.IsRegular
                //                && !(s.Void ?? false)
                //                    && (s.StartDate ?? min) <= now
                //                    && (s.EndDate ?? max) >= now
                //                    && !(s.SessionComplete ?? false))
                //        .Where(x => x.SubjectStructure.SubjectId == subjectId)
                //        .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.RunningClass.ProgramBatch.Batch.Name)
                //        .ThenBy(t => t.RunningClass.ProgramBatch.Program.Name)
                //        .ToList();
                //    for (var i = 0; i < regular.Count; i++)
                //    {
                //        regular[i].Name = regular[i].GetName;
                //    }
                //    var notRegular = userclass.Select(x => x.SubjectClass) //.SubjectClass
                //        .Where(s => (!s.IsRegular)
                //                && !(s.Void ?? false)
                //                    && (s.StartDate ?? min) <= now
                //                    && (s.EndDate ?? max) >= now
                //                    && !(s.SessionComplete ?? false))
                //        .Where(x => x.SubjectId == subjectId)
                //        .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.Name)
                //        .ToList();

                //    regular.AddRange(notRegular);

                //    if (classesToIgnore != null)
                //    {
                //        var cti = classesToIgnore.Select(x => x.Id).ToList();
                //        foreach (var c in cti)
                //        {
                //            var found = regular.Find(x => x.Id == c);
                //            if (found != null)
                //            {
                //                regular.Remove(found);
                //            }
                //        }
                //    }
                //    return regular;
                //}

                #endregion


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
                                && !(s.Void ?? false)
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
                                && !(s.Void ?? false)
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
                                && !(s.Void ?? false)
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
                                && !(s.Void ?? false)
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
                        .Select(x => x.User).OrderBy(x => x.FirstName).ToList();
                }
                return new List<Users>();
            }

            public List<Academic.DbEntities.User.Users> ListUsersNotInSubjectSession(int subjectSessionId,
                List<int> asignedList, int schoolId, bool teachersEnroll)
            {
                var roleId = Context.Role.FirstOrDefault(x => x.RoleName == "teacher");

                var subsession = Context.SubjectClass.Find(subjectSessionId);
                if (subsession != null)
                {
                    var users = Context.Users.Where(x => !asignedList.Contains(x.Id)
                        && x.SchoolId == schoolId && (x.IsActive ?? true)
                        && !(x.IsDeleted ?? false)
                        && ((teachersEnroll && !x.Student.Any()) || (!teachersEnroll && x.Student.Any()) ||
                                        (!teachersEnroll && x.UserRoles.Any(y => y.Role.RoleName == "student"))) //|| (!teachersOnly))
                        )

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

            //used. v 2.0 final
            public List<EnrolledUser> ListEnrolledUsers(int subjectClassId, string orderBy)
            {
                var subsession = Context.SubjectClass.Find(subjectClassId);
                if (subsession != null)
                {
                    var cnt = 1;
                    var ss = (from clsur in subsession.ClassUsers
                              join role in Context.Role on clsur.RoleId equals role.Id
                              join st in Context.Student on clsur.UserId equals st.UserId into student
                              from std in student.DefaultIfEmpty()
                              where !(clsur.Void ?? false)
                              //orderby (orderBy=="crn"? (std==null?clsur.User.FirstName:std.CRN)
                              //              :(orderBy=="name"?clsur.User.FirstName
                              //                  :clsur.User.UserName)) ascending 
                              select new Academic.ViewModel.EnrolledUser()
                              {
                                  //SN = "1",//(cnt++) + ".",
                                  Id = clsur.User.Id,
                                  CRN = std == null ? "" : std.CRN,
                                  Name = clsur.User.FullName,
                                  UserName = clsur.User.UserName,
                                  Role = role == null ? "" : role.DisplayName,
                                  Email = clsur.User.Email,
                                  LastOnline = (clsur.User.LastOnline == null ? "" : clsur.User.LastOnline.Value.ToShortDateString()),
                                  //Group = "",
                                  ImageUrl = clsur.User.UserImageId == null ? "" : clsur.User.UserImage.FileDirectory + clsur.User.UserImage.FileName
                              }).ToList();
                    if (orderBy == "crn")
                    {
                        ss = ss.OrderBy(x => x.CRN).ToList();

                    }
                    else if (orderBy == "name")
                    {
                        ss = ss.OrderBy(x => x.Name).ToList();
                    }
                    else if (orderBy == "username")
                    {
                        ss = ss.OrderBy(x => x.UserName).ToList();
                    }

                    foreach (var s in ss)
                    {
                        s.SN = (cnt++) + ".";
                    }

                    return ss;
                    //return subsession.ClassUsers.Where(x => !(x.Void ?? false)).Select(x => x.User).ToList();
                }
                //return new List<DbEntities.User.Users>();
                return new List<EnrolledUser>();
            }

            public List<EnrolledUser> ListEnrolledTeachers(int subjectClassId, string orderBy)
            {
                var subsession = Context.SubjectClass.Find(subjectClassId);
                if (subsession != null)
                {
                    using (var helper = new DbHelper.User())
                    {
                        var teachRole = helper.GetRole(StaticValues.Roles.Teacher);
                        var cnt = 1;
                        var ss = (from clsur in subsession.ClassUsers
                                  join role in Context.Role on clsur.RoleId equals role.Id
                                  //join st in Context.Student on clsur.UserId equals st.UserId into student
                                  //from std in student.DefaultIfEmpty()
                                  where !(clsur.Void ?? false) && role.Id == teachRole.Id
                                  orderby clsur.User.FirstName, clsur.User.MiddleName, clsur.User.LastName
                                  //orderby (orderBy=="crn"? (std==null?clsur.User.FirstName:std.CRN)
                                  //              :(orderBy=="name"?clsur.User.FirstName
                                  //                  :clsur.User.UserName)) ascending 
                                  select new Academic.ViewModel.EnrolledUser()
                                  {
                                      Id = clsur.User.Id,
                                      Name = clsur.User.FullName,
                                      UserName = clsur.User.UserName,
                                      Role = role == null ? "" : role.DisplayName,
                                      Email = clsur.User.Email,
                                      LastOnline =
                                          (clsur.User.LastOnline == null ? "" : clsur.User.LastOnline.Value.ToShortDateString()),
                                      ImageUrl =
                                          clsur.User.UserImageId == null
                                              ? ""
                                              : clsur.User.UserImage.FileDirectory + clsur.User.UserImage.FileName
                                  }).ToList();
                        return ss;
                    }
                }
                return new List<EnrolledUser>();
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
                    ent.EndDate = subjectSession.EndDate;
                    ent.StartDate = subjectSession.StartDate;
                    ent.EnrollmentMethod = subjectSession.EnrollmentMethod;
                    ent.JoinLastDate = subjectSession.JoinLastDate;
                    ent.SessionComplete = subjectSession.SessionComplete;
                    ent.Void = subjectSession.Void;
                    ent.VoidDate = subjectSession.VoidDate;
                    ent.HasGrouping = subjectSession.HasGrouping;
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


            /// <summary>
            /// Returns status of course w.r.t. the user.
            /// 'current'=studying, 'complete'=completed, 'open'=available For join, 'close'=not available to join
            /// </summary>
            /// <param name="userId"></param>
            /// <param name="subjectId"></param>
            /// <returns></returns>
            public string GetCourseClassesAvailabilityForUser(int userId, int subjectId)
            {
                var date = DateTime.Now;
                var user = Context.Users.Find(userId);
                if (user != null)
                {
                    var subjClasses = user.Classes
                        .Where(x => !(x.Void ?? false)
                            && !(x.Suspended ?? false)
                            && !(x.SubjectClass.Void ?? false)
                            && ((x.SubjectClass.IsRegular)
                                    ? (x.SubjectClass.SubjectStructure.SubjectId == subjectId)
                                    : (x.SubjectClass.SubjectId == subjectId))
                        ).ToList();







                    //var curr = subjClasses.Where(
                    //            x => !(x.SubjectClass.SessionComplete ?? false) &&
                    //            x.SubjectClass.EndDate != null &&
                    //            x.SubjectClass.EndDate.Value >= date);




                    var subSession = subjClasses.FirstOrDefault();




                    if (subSession != null)
                    {
                        var role = StaticValues.Roles.Student;
                        if (subjClasses.Any(x => x.Role.RoleName == StaticValues.Roles.Teacher))
                        {
                            role = StaticValues.Roles.Teacher;
                        }



                        if (!(subSession.SubjectClass.SessionComplete ?? false) &&
                            (subSession.SubjectClass.EndDate != null &&
                            subSession.SubjectClass.EndDate.Value >= DateTime.Now))
                        {
                            var clsId = "0";
                            if (subjClasses.Any())
                            {

                                var clses = subjClasses.Select(x => x.SubjectClass)
                                    .FirstOrDefault(x => !(x.SessionComplete ?? false) //|| (subSession.SubjectClass.EndDate != null && subSession.SubjectClass.EndDate.Value > DateTime.Now)
                                        && x.EnrollmentMethod == 2 && x.EndDate >= DateTime.Now);
                                if (clses != null)
                                {
                                    // show the View Enrolment 
                                    clsId = clses.Id.ToString();
                                }
                            }
                            return "current," + role + "," + clsId;//"You are currently enrolled in this course";
                        }
                        return "complete," + role; //"You have already completed this course.";


                    }
                    //get classes of the subject
                    var subject = Context.Subject.Find(subjectId);
                    if (subject != null)
                    {
                        var classes = subject.SubjectClasses.Where(x => !(x.SessionComplete ?? false) //|| (subSession.SubjectClass.EndDate != null && subSession.SubjectClass.EndDate.Value > DateTime.Now)
                            && x.EnrollmentMethod == 2 && x.EndDate >= DateTime.Now);
                        if (classes.Any())
                        {
                            // show the available classes
                            return "open";//"Open class(es) available. <a href='#'>Join here</a>.";
                        }
                        else
                        {
                            return "close";// "No open class(es) available for now";
                        }
                    }





                    //if(subSession.Where(x=>x.GetName))
                    //return subSession;
                }
                return "nothing";
                //return new List<DbEntities.Class.SubjectClass>();
            }

            public List<UserClass> GetClassesOfUser(int userId, int subjectId)
            {
                //Context.Subject.Where(x=>x.)
                var ss =
                    Context.UserClass.Where(
                        x => (
                            (x.SubjectClass.IsRegular
                            ? x.SubjectClass.SubjectStructure.SubjectId == subjectId
                            : x.SubjectClass.Subject.Id == subjectId) &&
                             x.UserId == userId
                            && !(x.Suspended ?? false)
                            && !(x.Void ?? false)
                            && !(x.SubjectClass.Void ?? false)
                            )).ToList();
                //var list = new List<UserClass>();
                //foreach (var s in ss)
                //{
                //    if (s.SubjectClass.IsRegular)
                //    {
                //        if (s.SubjectClass.SubjectStructure.SubjectId == subjectId)
                //        {
                //            list.Add(s);
                //        }
                //    }
                //    else
                //    {
                //        if (s.SubjectClass.SubjectId == subjectId)
                //        {
                //            list.Add(s);
                //        }
                //    }
                //}
                return ss;
            }



            public List<ClassViewModel> ListAllClassesOfUserOfSubject(int userId, int subjectId)
            {
                //Context.Subject.Where(x=>x.)
                var ss =
                    Context.UserClass.Where(
                        x => ((x.SubjectClass.IsRegular
                            ? x.SubjectClass.SubjectStructure.SubjectId == subjectId
                            : x.SubjectClass.Subject.Id == subjectId) &&
                              x.UserId == userId
                              && !(x.Suspended ?? false)
                              && !(x.Void ?? false)
                              && !(x.SubjectClass.Void ?? false)
                            ))
                        .OrderByDescending(x => x.StartDate).ThenByDescending(x => x.EndDate)
                        .ToList();
                var list = new List<ClassViewModel>();
                foreach (var x in ss)
                {
                    list.Add(new ClassViewModel()
                    {
                        IsRegular = x.SubjectClass.IsRegular,
                        StartDate =
                            x.SubjectClass.StartDate == null ? "" : x.SubjectClass.StartDate.Value.ToString("D"),
                        ClassName = x.SubjectClass.GetName,
                        EndDate = x.SubjectClass.EndDate == null ? "" : x.SubjectClass.EndDate.Value.ToString("D"),
                        SubjectId = x.SubjectClass.GetCourseId,
                        SubjectName = x.SubjectClass.GetCourseFullName,
                        ClassId = x.SubjectClassId,
                        OpenTillDate =
                            x.SubjectClass.JoinLastDate == null
                                ? ""
                                : x.SubjectClass.JoinLastDate.Value.ToString("D"),
                        IconUrl = "",
                        RunningClassId = x.SubjectClass.RunningClassId ?? 0,
                    });
                }
                return list;
            }

            public List<UserClass> GetActiveClassesOfUser(int userId, int subjectId)
            {
                var ss =
                    Context.UserClass.Where(
                        x => (
                            (x.SubjectClass.IsRegular
                            ? x.SubjectClass.SubjectStructure.SubjectId == subjectId
                            : x.SubjectClass.Subject.Id == subjectId) &&
                             x.UserId == userId
                            && !(x.Suspended ?? false)
                            && !(x.Void ?? false)
                            && !(x.SubjectClass.Void ?? false)
                            && !(x.SubjectClass.SessionComplete ?? false)
                            )).ToList();

                return ss;
            }

            public bool IsTheUserTeacher(int userId, int subjectId)
            {
                var teacherRole = Context.Role.FirstOrDefault(x => x.RoleName == "teacher");
                if (teacherRole != null)
                {
                    var classes = GetClassesOfUser(userId, subjectId);
                    return classes.Any(x => x.RoleId == teacherRole.Id);
                }
                return false;
            }

            public bool IsTheUserCurrentlyTeacher(int userId, int subjectId)
            {
                var teacherRole = Context.Role.FirstOrDefault(x => x.RoleName == "teacher");
                if (teacherRole != null)
                {
                    var classes = GetActiveClassesOfUser(userId, subjectId);
                    return classes.Any(x => x.RoleId == teacherRole.Id);
                }
                return false;
            }

            public UserClass GetUserClass(int userClassId)
            {
                return Context.UserClass.Find(userClassId);
            }

            public Academic.DbEntities.AcacemicPlacements.RunningClass GetRunningClass(int rcId)
            {
                return Context.RunningClass.Find(rcId);
            }

            public bool IsAnyTeacherAssignedInClass(int subjectClassId)
            {
                var sc = Context.SubjectClass.Find(subjectClassId);

                if (sc != null)
                {
                    using (var helper = new DbHelper.User())
                    {
                        var teacherRoleId = helper.GetRole(StaticValues.Roles.Teacher).Id;
                        return sc.ClassUsers.Any(x => x.RoleId == teacherRoleId && !(x.Void ?? false));
                    }
                }
                return false;
            }

            public List<ClassViewModel> ListOpenClasses(int schoolId)
            {
                var date = DateTime.Now.Date;
                var list = new List<ClassViewModel>();
                var clses = Context.SubjectClass.Where(x => x.EnrollmentMethod == 2 &&
                                                            !(x.Void ?? false) &&
                                                            (!(x.IsRegular
                                                                ? ((x.SubjectStructure.Subject.Void ?? false) &&
                                                                   !(x.SubjectStructure.Void ?? false) && x.SubjectStructure.Subject.SubjectCategory.SchoolId == schoolId)
                                                                : ((x.Subject.Void ?? false) && x.Subject.SubjectCategory.SchoolId == schoolId)))
                                                            && !(x.SessionComplete ?? false)
                                                            && (x.JoinLastDate == null || (x.JoinLastDate ?? DateTime.MinValue) >= date)
                    );

                var spanStart = "<span style='font-size:0.9em;'>";
                var spanEnd = "</span>";
                foreach (var cls in clses)
                {
                    list.Add(new ClassViewModel()
                    {
                        StartDate = cls.StartDate == null ? "" : cls.StartDate.Value.ToString("D"),
                        EndDate = cls.EndDate == null ? "" : cls.EndDate.Value.ToString("D"),
                        ClassId = cls.Id,
                        ClassName = cls.IsRegular
                                        ? cls.SubjectStructure.Subject.FullName + spanStart + " > " + spanEnd + cls.GetName
                                        : cls.Subject.FullName + spanStart + " > " + spanEnd + cls.Name,
                        OpenTillDate = cls.JoinLastDate == null ? "" : cls.JoinLastDate.Value.ToString("D"),
                    });
                }
                return list;

            }


            public bool DeleteSubjectClass(int subClsId, ref int subjectId)
            {
                var subCls = Context.SubjectClass.Find(subClsId);
                if (subCls != null && !subCls.IsRegular)
                {
                    subCls.Void = true;
                    Context.SaveChanges();
                    subjectId = subCls.IsRegular ? (subCls.SubjectStructure.SubjectId) : (subCls.SubjectId ?? 0);
                    return true;
                }
                return false;
            }

            public UserClass HasTheUserAlreadyJoinedThisClass(int userId, int subclsId)
            {
                return Context.UserClass.FirstOrDefault(x => x.UserId == userId && x.SubjectClassId == subclsId && !(x.Void ?? false));
            }

            public Academic.DbEntities.Subjects.Subject GetSubject(int subjectId)
            {
                return Context.Subject.Find(subjectId);
            }

            public bool MarkComplete(int subjectClassId, int userId)
            {
                var cls = Context.SubjectClass.Find(subjectClassId);
                if (cls != null)
                {
                    cls.SessionComplete = true;
                    cls.CompletionMarkedDate = DateTime.Now;
                    cls.CompleteMarkedByUserId = userId;
                    Context.SaveChanges();
                    return true;
                }
                return false;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="subjectClassId"></param>
            /// <param name="userId"></param>
            /// <param name="enrolled">what the outcome of this function will be. whether the user is enrolled or removed from enrollement</param>
            /// <returns></returns>
            public bool Enroll(int subjectClassId, int userId, ref bool enrolled)
            {
                enrolled = true;
                var cls = Context.SubjectClass.Find(subjectClassId);
                if (cls != null)
                {
                    var stdRole = Context.Role.FirstOrDefault(x => x.RoleName == StaticValues.Roles.Student);
                    if (stdRole != null)
                    {
                        var clsUsr = cls.ClassUsers.FirstOrDefault(x => x.UserId == userId);
                        if (clsUsr == null)
                        {
                            //enroll
                            var userclass = new UserClass()
                            {
                                SubjectClassId = subjectClassId,
                                CreatedDate = DateTime.Now,
                                EndDate = cls.EndDate,
                                RoleId = stdRole.Id,
                                EnrollmentDuration = 0,
                                StartDate = DateTime.Now,
                                Suspended = false,
                                UserId = userId,
                                Void = false,
                            };
                            Context.UserClass.Add(userclass);
                            Context.SaveChanges();
                        }
                        else
                        {
                            if (clsUsr.Void ?? false)
                            {
                                //earlier enrolment; so enroll again
                                clsUsr.Void = false;
                                clsUsr.RoleId = stdRole.Id;
                                clsUsr.StartDate = DateTime.Now;
                                Context.SaveChanges();
                            }
                            else
                            {
                                //remove enrollment
                                clsUsr.Void = true;
                                Context.SaveChanges();
                                enrolled = false;
                            }
                        }
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
