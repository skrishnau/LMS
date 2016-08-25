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

            //used
            public List<Academic.DbEntities.Class.SubjectSession> ListSessionsOfSubject(int subjectId)
            {
                var regular =
                    Context.SubjectSession.Where(s => s.IsRegular).Where(x => x.SubjectStructure.SubjectId == subjectId);

                var notRegular = Context.SubjectSession.Where(s => (!s.IsRegular)).Where(x => x.SubjectId == subjectId);
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
            public List<Academic.DbEntities.Class.SubjectSession> ListSessionsOfSubject(int subjectId, string courseCompletionType)
            {
                var regular = new List<Academic.DbEntities.Class.SubjectSession>();
                //Context.SubjectSession.Where(s => s.IsRegular).Where(x => x.SubjectStructure.SubjectId == subjectId);

                var notRegular = new List<Academic.DbEntities.Class.SubjectSession>();
                //Context.SubjectSession.Where(s => (!s.IsRegular)).Where(x => x.SubjectId == subjectId);
                var now = DateTime.Now.Date;
                var min = DateTime.MinValue.Date;
                var max = DateTime.MaxValue.Date;
                switch (courseCompletionType)
                {
                    case "btnCurrentlyRunning":
                        regular = Context.SubjectSession
                            .Where(s => s.IsRegular
                                && (s.StartDate ?? min) <= now
                                && (s.EndDate ?? max) >= now
                                && !(s.SessionComplete ?? false))
                            .Where(x => x.SubjectStructure.SubjectId == subjectId)
                            .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.ProgramBatch.Batch.Name).ThenBy(t => t.ProgramBatch.Program.Name)
                            .ToList();

                        notRegular = Context.SubjectSession
                            .Where(s => (!s.IsRegular)
                                && (s.StartDate ?? min) <= now
                                && (s.EndDate ?? max) >= now
                                && !(s.SessionComplete ?? false))
                            .Where(x => x.SubjectId == subjectId)
                            .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.Name)
                            .ToList();
                        break;
                    case "btnDue":
                        regular = Context.SubjectSession
                            .Where(s => s.IsRegular
                               && (s.EndDate ?? max) < now
                                && !(s.SessionComplete ?? false))
                            .Where(x => x.SubjectStructure.SubjectId == subjectId)
                            .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.ProgramBatch.Batch.Name).ThenBy(t => t.ProgramBatch.Program.Name)
                            .ToList();

                        notRegular = Context.SubjectSession
                            .Where(s => (!s.IsRegular)
                                && (s.EndDate ?? max) < now
                                && !(s.SessionComplete ?? false))
                            .Where(x => x.SubjectId == subjectId)
                            .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.Name)
                            .ToList();
                        //ApplyFilterAndLoadData(2);
                        break;
                    case "btnNotStartedYet":
                        regular = Context.SubjectSession
                            .Where(s => s.IsRegular
                                && (s.StartDate ?? min) > now
                                && !(s.SessionComplete ?? false))
                            .Where(x => x.SubjectStructure.SubjectId == subjectId)
                            .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.ProgramBatch.Batch.Name).ThenBy(t => t.ProgramBatch.Program.Name)
                            .ToList();

                        notRegular = Context.SubjectSession
                            .Where(s => (!s.IsRegular)
                                && (s.StartDate ?? min) > now
                                && !(s.SessionComplete ?? false))
                            .Where(x => x.SubjectId == subjectId)
                            .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.Name)
                            .ToList();
                        //ApplyFilterAndLoadData(3);
                        break;
                    case "btnCompleted":
                        regular = Context.SubjectSession
                            .Where(s => s.IsRegular
                                && (s.SessionComplete ?? false))
                            .Where(x => x.SubjectStructure.SubjectId == subjectId)
                            .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.ProgramBatch.Batch.Name).ThenBy(t => t.ProgramBatch.Program.Name)
                            .ToList();

                        notRegular = Context.SubjectSession
                            .Where(s => (!s.IsRegular)
                                && (s.SessionComplete ?? false))
                            .Where(x => x.SubjectId == subjectId)
                            .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.Name)
                            .ToList();
                        break;
                    default:
                        regular = Context.SubjectSession
                            .Where(s => s.IsRegular)
                            .Where(x => x.SubjectStructure.SubjectId == subjectId)
                            .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.ProgramBatch.Batch.Name).ThenBy(t => t.ProgramBatch.Program.Name)
                            .ToList();

                        notRegular = Context.SubjectSession
                            .Where(s => (!s.IsRegular))
                            .Where(x => x.SubjectId == subjectId)
                            .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.Name)
                            .ToList();
                        break;
                }
                regular.AddRange(notRegular);
                return regular;
            }

            public void Dispose()
            {
                Context.Dispose();
            }

            public bool AddOrUpdateSubjectSession(DbEntities.Class.SubjectSession subjectSession)
            {
                var ent = Context.SubjectSession.Find(subjectSession.Id);
                if (ent == null)
                {
                    Context.SubjectSession.Add(subjectSession);
                    Context.SaveChanges();
                }
                else
                {
                    ent.Name = subjectSession.Name;
                    ent.UseDefaultGrouping = subjectSession.UseDefaultGrouping;
                    Context.SaveChanges();
                }
                return false;
            }

            public List<Academic.DbEntities.User.Users> ListUsersOfSubjectSession(int subjectSessionId)
            {
                var subsession = Context.SubjectSession.Find(subjectSessionId);
                if (subsession != null)
                {
                    return subsession.ClassUsers.Select(x => x.User).ToList();
                }
                return new List<Users>();
            }

            public List<Academic.DbEntities.User.Users> ListUsersNotInSubjectSession(int subjectSessionId, List<int> asignedList)
            {
                var subsession = Context.SubjectSession.Find(subjectSessionId);
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

            public bool AddOrUpdateUsersList(List<Academic.DbEntities.Class.SubjectSessionUser> userList)
            {
                try
                {
                    using (var scope = new TransactionScope())
                    {
                        foreach (var sessUser in userList)
                        {
                            var userFound = Context.SubjectSessionUser.Find(sessUser.Id);
                            if (userFound == null)
                            {
                                Context.SubjectSessionUser.Add(sessUser);
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
                var subsession = Context.SubjectSession.Find(subjectSessionId);
                if (subsession != null)
                {
                    foreach (var i in userList)
                    {
                        var userFound =
                            Context.SubjectSessionUser.FirstOrDefault(x => x.UserId == i && !(x.Void ?? false));
                        if (userFound == null)
                        {
                            Context.SubjectSessionUser.Add(new SubjectSessionUser()
                            {
                                UserId = i
                                    //,JoinedDate = 
                                ,
                            });

                        }
                    }
                }
            }

            public List<SubjectSessionUser> GetSessionUsers(int subjectSessionId)
            {
                var subsession = Context.SubjectSession.Find(subjectSessionId);
                if (subsession != null)
                {
                    return subsession.ClassUsers.ToList();
                }
                return new List<SubjectSessionUser>();
            }
        }
    }
}
