using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.Database;

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
                                &&!(s.SessionComplete??false))
                            .Where(x => x.SubjectStructure.SubjectId == subjectId)
                            .OrderByDescending(o=>o.CreatedDate).ThenBy(t => t.ProgramBatch.Batch.Name).ThenBy(t=>t.ProgramBatch.Program.Name)
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
                                && !(s.SessionComplete??false))
                            .Where(x => x.SubjectStructure.SubjectId == subjectId)
                            .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.ProgramBatch.Batch.Name).ThenBy(t=>t.ProgramBatch.Program.Name)
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
                                && !(s.SessionComplete??false))
                            .Where(x => x.SubjectStructure.SubjectId == subjectId)
                            .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.ProgramBatch.Batch.Name).ThenBy(t => t.ProgramBatch.Program.Name)
                            .ToList();

                        notRegular = Context.SubjectSession
                            .Where(s => (!s.IsRegular)
                                && (s.StartDate ?? min) >now
                                && !(s.SessionComplete ?? false))
                            .Where(x => x.SubjectId == subjectId)
                            .OrderByDescending(o => o.CreatedDate).ThenBy(t => t.Name)
                            .ToList();
                        //ApplyFilterAndLoadData(3);
                        break;
                    case "btnCompleted":
                        regular = Context.SubjectSession
                            .Where(s => s.IsRegular
                                && (s.SessionComplete??false))
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
        }
    }
}
