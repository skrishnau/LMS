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
            /// <param name="courseCompletionType"> It specifies the type of classes to return. 1=currently running,
            ///  2=Due, 3=not started yet, 4=completed
            /// </param>
            /// <returns></returns>
            public List<Academic.DbEntities.Class.SubjectClass> ListSessionsOfSubject(
                int subjectId, string courseCompletionType)
            {
                var regular = new List<Academic.DbEntities.Class.SubjectClass>();
                //Context.SubjectSession.Where(s => s.IsRegular).Where(x => x.SubjectStructure.SubjectId == subjectId);

                var notRegular = new List<Academic.DbEntities.Class.SubjectClass>();
                //Context.SubjectSession.Where(s => (!s.IsRegular)).Where(x => x.SubjectId == subjectId);
                var now = DateTime.Now.Date;
                var min = DateTime.MinValue.Date;
                var max = DateTime.MaxValue.Date;
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
                regular.AddRange(notRegular);
                return regular;
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

            public List<Academic.DbEntities.User.Users> ListUsersNotInSubjectSession(int subjectSessionId, List<int> asignedList)
            {
                var subsession = Context.SubjectClass.Find(subjectSessionId);
                if (subsession != null)
                {
                    var users = Context.Users.Where(x => !asignedList.Contains(x.Id))
                        .OrderBy(y => y.FirstName)
                        .ThenBy(t => t.MiddleName)
                        .ThenBy(y => y.LastName);
                    return users.Take(50).ToList();
                }
                return Context.Users
                    .OrderBy(y => y.FirstName)
                    .ThenBy(t => t.MiddleName)
                    .ThenBy(y => y.LastName).Take(50).ToList();
            }


            public List<UserClass> ListSessionUsers(int subjectSessionId)
            {
                var subsession = Context.SubjectClass.Find(subjectSessionId);
                if (subsession != null)
                {
                    return subsession.ClassUsers.Where(x => !(x.Void ?? false)).ToList();
                }
                return new List<UserClass>();
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
                    ent.UseDefaultGrouping = subjectSession.UseDefaultGrouping;
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

        }
    }
}
