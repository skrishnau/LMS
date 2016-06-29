using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.Database;
using Academic.DbEntities.Batches;
using Academic.DbEntities.Students;
using Academic.DbEntities.Subjects;
using Academic.ViewModel;
using Academic.ViewModel.AcademicPlacement;

namespace Academic.DbHelper
{
    public partial class DbHelper
    {
        public class Subject : IDisposable
        {
            private AcademicContext Context;

            public Subject()
            {
                Context = new AcademicContext();
            }

            public List<IdAndName> ListSubjects(int levelId)
            {
                //return Context.Subject.Where(x => x.LevelId == levelId).Select(x => new IdAndName() { Id = x.Id, Name = x.Name }).ToList();
                return
                null;
            }

            public List<IdAndName> ListAllSubjects(int schoolId)
            {
                var subs = from c in Context.SubjectCategory
                           join s in Context.Subject on c.Id equals s.SubjectCategoryId
                           where c.SchoolId == schoolId
                           select s
                ;
                //return subs.ToList();

                return subs.Select(x => new IdAndName()
                {
                    Id = x.Id
                    ,
                    Name = x.Name
                }).ToList();
            }

            public int AddIfNotExists(ViewModel.Subject.Subject subject)
            {

                //var entity = Context.Subject.FirstOrDefault(x => x.Name == subject.Name && x.LevelId == subject.LevelId);
                //if (entity == null)
                //{
                //    var sub = new DbEntities.Subjects.Subject()
                //      {
                //          Name = subject.Name,
                //          LevelId = subject.LevelId
                //      };
                //    var su = Context.Subject.Add(sub);
                //    Context.SaveChanges();
                //    return su.Id;
                //}
                //else
                //{
                //    return entity.Id;
                //}
                return 0;
            }

            public void Dispose()
            {
                Context.Dispose();
            }

            public List<IdAndName> ListSubjectsOfYearForCombo(int YearId)
            {
                List<IdAndName> sub = new List<IdAndName>();

                //var subjects = Context.Subject.Where(x => x.YearId == YearId && (x.IsNotInSyllabus==false || x.IsNotInSyllabus==null) ).ToList();
                //subjects.ForEach(x =>
                //{
                //    sub.Add(new IdAndName(){Id=x.Id, Name = x.Name});
                //});
                return sub;
            }


            //=========================WebForm ===============New ==========//

            public DbEntities.Subjects.SubjectCategory AddOrUpdateSubjectCategory(DbEntities.Subjects.SubjectCategory cat)
            {
                try
                {
                    var c = Context.SubjectCategory.Find(cat.Id);
                    if (c == null)
                    {
                        var category = Context.SubjectCategory.Add(cat);
                        Context.SaveChanges();
                        return category;
                    }
                    else
                    {
                        c.Description = cat.Description;
                        c.IsActive = cat.IsActive;
                        c.IsVoid = cat.IsVoid;
                        c.Name = cat.Name;
                        c.ParentId = cat.ParentId;
                    }
                    Context.SaveChanges();
                    return c;
                }
                catch (Exception)
                {
                    return null;
                }
            }

            public List<SubjectCategory> GetCategories(int schoolId)
            {
                return Context.SubjectCategory.Where(x => x.SchoolId == schoolId).ToList();
            }

            public bool AddOrUpdateSubject(DbEntities.Subjects.Subject subject, int subjectGroupId = 0)
            {
                try
                {
                    var s = Context.Subject.Find(subject.Id);
                    if (s == null)
                    {
                        var sub = Context.Subject.Add(subject);
                        Context.SaveChanges();
                        if (sub != null && subjectGroupId > 0)
                        {
                            Context.SubjectGroupSubject.Add(new SubjectGroupSubject()
                            {
                                AssignedDate = DateTime.Now
                                ,
                                SubjectGroupId = subjectGroupId
                                ,
                                SubjectId = sub.Id
                            });
                            Context.SaveChanges();
                        }
                        return true;
                    }
                    //else
                    {
                        s.Code = subject.Code;
                        s.CompletionHours = subject.CompletionHours;
                        s.Credit = subject.Credit;
                        s.FullMarks = subject.FullMarks;
                        s.HasLab = subject.HasLab;
                        s.HasProject = subject.HasProject;
                        s.HasTheory = subject.HasTheory;
                        s.HasTutorial = subject.HasTutorial;
                        s.IsActive = subject.IsActive;
                        s.Void = subject.Void;
                        s.IsElective = subject.IsElective;
                        s.IsOutOfSyllabus = subject.IsOutOfSyllabus;
                        s.SubjectCategoryId = subject.SubjectCategoryId;
                        s.PassPercentage = subject.PassPercentage;
                        s.Name = subject.Name;
                        Context.SaveChanges();

                        return true;
                    }

                }
                catch (Exception)
                {
                    return false;
                }
            }
            public bool AddOrUpdateRegularSubject(DbEntities.Subjects.Subject subject, int yearId, int subYearId = 0)
            {
                try
                {
                    var s = Context.Subject.Find(subject.Id);
                    if (s == null)
                    {
                        var sub = Context.Subject.Add(subject);
                        Context.SaveChanges();
                        if (sub != null)
                        {
                            var rsg = new RegularSubject()
                            {
                                AssignedDate = DateTime.Now
                                ,
                                YearId = yearId
                                ,
                                SubjectId = sub.Id
                            };
                            if (subYearId > 0)
                            {
                                rsg.SubYearId = subYearId;
                            }
                            Context.RegularSubjectsGrouping.Add(rsg);
                            Context.SaveChanges();
                        }
                        return true;
                    }
                    //else
                    {
                        s.Code = subject.Code;
                        s.CompletionHours = subject.CompletionHours;
                        s.Credit = subject.Credit;
                        s.FullMarks = subject.FullMarks;
                        s.HasLab = subject.HasLab;
                        s.HasProject = subject.HasProject;
                        s.HasTheory = subject.HasTheory;
                        s.HasTutorial = subject.HasTutorial;
                        s.IsActive = subject.IsActive;
                        s.Void = subject.Void;
                        s.IsElective = subject.IsElective;
                        s.IsOutOfSyllabus = subject.IsOutOfSyllabus;
                        s.SubjectCategoryId = subject.SubjectCategoryId;
                        s.PassPercentage = subject.PassPercentage;
                        s.Name = subject.Name;
                        Context.SaveChanges();

                        return true;
                    }

                }
                catch (Exception)
                {
                    return false;
                }
            }


            public List<DbEntities.Subjects.Subject> GetSubjectList(int schoolId)
            {
                return Context.Subject.Where(x => x.SubjectCategory.SchoolId == schoolId
                    && x.IsActive == true).ToList();

            }

            public DbEntities.Subjects.Subject Find(int id)
            {
                var sub = Context.Subject.Include(x => x.SubjectSections).FirstOrDefault(y => y.Id == id);
                return sub;
            }



            #region SubjectGroup

            public SubjectGroup AddOrUpdateSubjectGroup(SubjectGroup subGrp)
            {
                try
                {
                    var entity = Context.SubjectGroup.Find(subGrp.Id);
                    if (entity == null)
                    {
                        var saved = Context.SubjectGroup.Add(subGrp);
                        Context.SaveChanges();
                        return saved;
                    }
                    entity.YearId = subGrp.SubYearId;
                    entity.SubYearId = subGrp.SubYearId;
                    entity.ProgramId = subGrp.ProgramId;
                    entity.Name = subGrp.Name;
                    entity.Void = subGrp.Void;
                    entity.Desctiption = subGrp.Desctiption;
                    Context.SaveChanges();
                    return entity;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            public List<DbEntities.Subjects.SubjectGroup> GetSubjectGroups(int programId)
            {
                //var subgrps = from g in Context.SubjectGroup
                //    join sgs in Context.SubjectGroupSubject on g.Id equals sgs.SubjectGroupId
                //    join s in Context.Subject on sgs.SubjectId equals s.Id
                //    where (g.ProgramId ?? 0) == programId && !(g.Void ?? false)
                //          && !(sgs.Void ?? false) && !(s.Void ?? false)
                //    select g;

                try
                {
                    var grps = Context.SubjectGroup.Include(i => i.Year).Include(i => i.SubYear)
                   .Include(i => i.SubjectGroupSubjects)
                   .Where(x => (x.ProgramId ?? 0) == programId && !(x.Void ?? false))
                   .OrderBy(x => (x.Year == null) ? x.Id : x.Year.Position).ThenBy(u => u.Name)
                   .ThenBy(y => (y.SubYear == null) ? y.Id : y.SubYear.Position).ThenBy(u => u.Name)
                   .ToList();
                    return grps;
                }
                catch (Exception)
                {
                    return new List<SubjectGroup>();
                }
            }


            public List<DbEntities.Subjects.SubjectGroup> GetRegularSubjectGroups(int programId)
            {
                try
                {
                    var program = Context.Program.Find(programId);
                    if (program != null)
                    {
                        var years = Context.Year.Where(x => x.ProgramId == programId && !(x.Void ?? false))
                            .OrderBy(x => x.Position).ThenBy(u => u.Name);
                        //var firstTimeValueFound = false;
                        //var subyearExist = false;
                        var lst = new List<SubjectGroup>();
                        var min = years.Min(x => x.SubYears.Count);
                        var max = years.Max(x => x.SubYears.Count);
                        if (min != max)
                        {

                        }
                        else
                        {
                            if (max == 0)
                            {
                                //no subyears 
                                foreach (var year in years)
                                {
                                    var subGrp = new SubjectGroup()
                                    {
                                        //CreatedDate = DateTime.Now
                                        //,
                                        Desctiption = "Program: " + program.Name + ", Year: " + year.Name
                                        ,
                                        Name = year.Name
                                        ,
                                        ProgramId = program.Id
                                        ,
                                        YearId = year.Id
                                        ,
                                    };
                                    //var subjects = Context.RegularSubjectsGrouping.Where(
                                    //    x => x.YearId == year.Id && x.SubYearId == null).ToList();
                                    //subjects.ForEach(x =>
                                    //{
                                    //    subGrp.SubjectGroupSubjects
                                    //});
                                    lst.Add(subGrp);
                                }
                            }
                            else
                            {
                                //has subyears
                                foreach (var year in years)
                                {
                                    foreach (var subyear in year.SubYears.Where(x => !(x.Void ?? false)).OrderBy(x => x.Position).ThenBy(u => u.Name))
                                    {
                                        var subGrp = new SubjectGroup()
                                        {
                                            CreatedDate = DateTime.Now
                                            ,
                                            Desctiption = "Program: " + program.Name + ", Year: " + year.Name + ", Sem: " + subyear.Name
                                            ,
                                            Name = year.Name + " / " + subyear.Name
                                            ,
                                            ProgramId = program.Id
                                            ,
                                            YearId = year.Id
                                            ,
                                            SubYearId = subyear.Id
                                        };
                                        lst.Add(subGrp);
                                    }
                                }
                            }

                        }
                        return lst;

                    }
                    return new List<SubjectGroup>();
                }
                catch (Exception)
                {
                    return new List<SubjectGroup>();
                }
            }

            public int GetSubjectsCountInAGroup(int subjectGroupId)
            {
                try
                {
                    var s =
                   Context.SubjectGroup.Find(subjectGroupId)
                       .SubjectGroupSubjects.Count(x => !(x.Void ?? false) && !(x.Subject.Void ?? false));
                    return s;
                }
                catch (Exception)
                {
                    return 0;
                }
            }


            public List<DbEntities.Subjects.Subject> GetSubjectsOfAGroup(int subjectGroupId)
            {
                try
                {
                    var g =
                    Context.SubjectGroup.Find(subjectGroupId)
                        .SubjectGroupSubjects.Where(x => !(x.Void ?? false) && !(x.Subject.Void ?? false))
                        .Select(x => x.Subject).ToList();
                    return g;
                }
                catch { return new List<DbEntities.Subjects.Subject>(); }
            }
            #endregion

            public List<DbEntities.Subjects.Subject> GetRegularSubjectList(int yearId, int subYearId = 0)
            {
                var grps = Context.RegularSubjectsGrouping.Where(x => x.YearId == yearId && (x.SubYearId ?? 0) == subYearId
                    && !(x.Void ?? false));
                var subs = grps.Select(x => x.Subject).Include(i => i.SubjectSections).Where(x => !(x.Void ?? false)).ToList();
                return subs;
            }

            public List<StudentSubjectModel> GetCurrentRegularSubjectsOfUser(int userId)
            {
                var user = Context.Users.Find(userId);
                if (user != null)
                {
                    var roles = Context.UserRole.Where(x => x.UserId == userId).Select(x => x.Role.Name);
                    if (roles.Contains("teacher"))
                    {
                        //get running class and subjects, etc from RegularSubjectClass and UserClass
                        var tea = Context.Teacher.FirstOrDefault(x => x.UserId == user.Id);
                        if (tea != null)
                        {
                            //Context.TeacherClass.Where(x=>x.TeacherId ==tea.Id).Select(x=>x.SubjectClass).Where(x=>x.RunningClass)
                            var runningClasses = (from sb in Context.TeacherClass.Where(x => x.TeacherId == tea.Id)
                                                  join rc in Context.RunningClass on sb.SubjectClass.RunningClassId equals rc.Id
                                                  join a in Context.AcademicYear.Where(ay => ay.IsActive && !(ay.Void ?? false)) on rc.AcademicYearId equals a.Id
                                                  join sess in Context.Session on rc.SessionId equals sess.Id
                                                  where sess.IsActive && !(sess.Void ?? false)
                                                  select new StudentSubjectModel()
                                                  {
                                                      Complete = rc.Completed ?? false
                                                          //,StudentId = std.Id
                                                          //,SubjectGroupName = 
                                                      ,
                                                      SubjectName = sb.SubjectClass.Subject.Name
                                                      ,
                                                      SubjectId = sb.SubjectClass.SubjectId
                                                      //rsg.Subject
                                                  }).ToList();
                            return runningClasses;
                        }
                    }
                    else if (roles.Contains("student"))
                    {
                        var std = Context.Student.FirstOrDefault(x => x.UserId == user.Id);
                        if (std != null)
                        {
                            var runningClasses = (from sb in Context.StudentBatch.Where(x => x.StudentId == std.Id)
                                                  join pb in Context.ProgramBatch on sb.ProgramBatchId equals pb.Id
                                                  join rc in Context.RunningClass on pb.Id equals rc.ProgramBatchId
                                                  join ay in Context.AcademicYear on rc.AcademicYearId equals ay.Id
                                                  where ay.IsActive && !(ay.Void ?? false)
                                                  select rc).ToList();
                            if (runningClasses.Count > 1)
                            {
                                //there are subyears and we need to consider session
                                var subs = (from r in runningClasses
                                            join sess in Context.Session on r.SessionId equals sess.Id
                                            where sess.IsActive && !(sess.Void ?? false)
                                            join rsg in Context.RegularSubjectsGrouping on r.YearId equals rsg.YearId
                                            where r.SubYearId == rsg.SubYearId && !(rsg.Subject.Void ?? false)
                                            select new StudentSubjectModel()
                                            {
                                                Complete = r.Completed ?? false
                                                    //,StudentId = std.Id
                                                    //,SubjectGroupName = 
                                                ,
                                                SubjectName = rsg.Subject.Name
                                                ,
                                                SubjectId = rsg.SubjectId
                                                //rsg.Subject
                                            }).ToList();

                                //return subs;
                                // var teachers =
                                //Context.TeacherClass.Where(x => x.SubjectClassId == a.subc.Id).Select(y => y.Teacher).ToList();
                                return subs;

                            }
                            else
                            {
                                //there are no subyears and we only consider academic year.
                                var subs = (from r in runningClasses
                                            join rsg in Context.RegularSubjectsGrouping on r.YearId equals rsg.YearId
                                            where r.SubYearId == rsg.SubYearId
                                            select new StudentSubjectModel()
                                            {
                                                Complete = r.Completed ?? false
                                                    //,StudentId = std.Id
                                                    //,SubjectGroupName = 
                                                ,
                                                SubjectName = rsg.Subject.Name
                                                ,
                                                SubjectId = rsg.SubjectId
                                                //rsg.Subject
                                            }).ToList();
                                //select rsg.Subject);
                                return subs;
                            }

                        }
                    }

                }
                return new List<StudentSubjectModel>();
            }

            public List<StudentSubjectModel> GetExtraSubjectsOfUser(int userId)
            {
                return new List<StudentSubjectModel>();
            }
            public void GetEarlierRegularSubjectsOfUser(int userId)
            {

            }

            /// <summary>
            /// It is the union of GetRegularSubjectsOfUser() and GetExtraSubjectsOfUser()
            /// Extra is  not implemented yet...
            /// </summary>
            /// <param name="userId"></param>
            public List<StudentSubjectModel> GetAllSubjectsOfUser(int userId)
            {
                var regular = GetCurrentRegularSubjectsOfUser(userId);
                var extra = GetExtraSubjectsOfUser(userId);
                regular.AddRange(extra);
                return regular;
            }
        }
    }
}
