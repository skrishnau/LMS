using Academic.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.UI;
using Academic.DbEntities;
using Academic.DbEntities.AcacemicPlacements;
using Academic.DbEntities.Structure;
using Academic.ViewModel;

namespace Academic.DbHelper
{
    public partial class DbHelper
    {
        public class AcademicYear : IDisposable
        {
            AcademicContext Context;

            public AcademicYear()
            {
                Context = new AcademicContext();
            }

            public void Dispose()
            {
                Context.Dispose();
            }


            #region Earlier -- Get Previous and current academic and session,;; completion mark

            //(Version-2) -- Used in SchoolCreate, Account-Login, Account-Register
            /// <summary>
            /// Returns currnt active session (Version-2)
            /// </summary>
            /// <returns></returns>
            public DbEntities.Session GetCurrentSession()
            {
                var date = DateTime.Now;
                var sess = Context.Session.FirstOrDefault(x => (x.StartDate <= date && x.EndDate >= date) || x.IsActive);

                return sess;
            }

            // not used in V-2 but is useful
            public DbEntities.AcademicYear GetPreviousAcademicYear(int acadeicYearId)
            {
                try
                {
                    var aca1 = Context.AcademicYear.Where(x => !(x.Void ?? false))
                    .OrderByDescending(x => x.Position).ToList();
                    if (aca1.Count >= 2)
                    {
                        //second one is the previous academic year
                        return aca1[1];
                    }
                    return null;
                }
                catch (Exception exe)
                {
                    return null;
                }
            }

            //used
            public string MarkCompleteAcademicYearSession(int userId, int aId, int sId)
            {
                try
                {
                    var date = DateTime.Now;
                    using (var scope = new TransactionScope())
                    {
                        var a = Context.AcademicYear.Find(aId);
                        var s = Context.Session.Find(sId);

                        if (a != null)
                        {
                            var rc = Context.RunningClass.Where(x => x.AcademicYearId == a.Id);
                            foreach (var r in rc)
                            {
                                r.Completed = true;
                                foreach (var sc in Context.SubjectClass.Where(w => w.RunningClassId == r.Id))
                                {
                                    sc.SessionComplete = true;
                                    sc.CompleteMarkedByUserId = userId;
                                    sc.CompletionMarkedDate = date;
                                    Context.SaveChanges();
                                }
                            }
                            a.Completed = true;
                            a.IsActive = false;

                            foreach (var se in a.Sessions.Where(x => x.IsActive))
                            {
                                se.IsActive = false;
                                se.Completed = true;
                            }

                            Context.SaveChanges();
                        }
                        else if (s != null)
                        {
                            var rc = Context.RunningClass.Where(x => x.SessionId == s.Id);
                            foreach (var r in rc)
                            {
                                r.Completed = true;
                                foreach (var sc in Context.SubjectClass.Where(w => w.RunningClassId == r.Id))
                                {
                                    sc.SessionComplete = true;
                                    sc.CompleteMarkedByUserId = userId;
                                    sc.CompletionMarkedDate = date;
                                    Context.SaveChanges();
                                }
                            }
                            s.Completed = true;
                            s.IsActive = false;
                            Context.SaveChanges();
                        }
                        else
                        {
                            return "Go to List.";
                        }


                        scope.Complete();
                        return "success";
                    }
                }
                catch
                {
                    return "Error while saving.";
                }

            }

            //Used
            public string ActivateAcademicYearSession(int userId, int aId, int sId)
            {
                try
                {
                    var date = DateTime.Now;
                    using (var scope = new TransactionScope())
                    {
                        var a = Context.AcademicYear.Find(aId);
                        if (a != null)
                        {
                            #region Academic year

                            if (!a.IsActive)
                            {
                                //var other = Context.AcademicYear.Where(x => x.SchoolId == a.SchoolId && x.IsActive);
                                //foreach (var o in other)
                                //{
                                //    o.IsActive = false;
                                //}
                                var rc =
                                    Context.RunningClass.Where(x => x.AcademicYearId == a.Id && (x.SessionId ?? 0) == 0);

                                foreach (var r in rc)
                                {
                                    if (r.ProgramBatchId != null)
                                    {

                                        var earlierNotComplete =
                                            r.ProgramBatch.RunningClasses.Any(x => !(x.Completed ?? false));
                                        if (earlierNotComplete)
                                        {
                                            continue;
                                        }
                                    }
                                    r.Completed = false;
                                    foreach (var sc in Context.SubjectClass.Where(w => w.RunningClassId == r.Id))
                                    {
                                        sc.SessionComplete = false;
                                        sc.CompleteMarkedByUserId = userId;
                                        sc.CompletionMarkedDate = date;
                                        Context.SaveChanges();
                                    }
                                }

                                a.IsActive = true;

                                var anyActive = a.Sessions.Any(x => x.IsActive);
                                if (!anyActive)
                                {
                                    var min = 0;
                                    var error = false;
                                    try
                                    {
                                        min = a.Sessions.Where(x => !(x.Completed ?? false)).Min(x => x.Position);
                                    }
                                    catch
                                    {
                                        error = true;
                                    }
                                    if (!error)
                                    {
                                        var se = a.Sessions.FirstOrDefault(x => x.Position == min);
                                        if (se != null)
                                            se.IsActive = true;
                                    }
                                }

                                //a.Completed = false;
                                Context.SaveChanges();
                            }
                            else return "Already active";

                            #endregion

                        }
                        var s = Context.Session.Find(sId);
                        if (s != null)
                        {
                            #region Session

                            if (!s.IsActive)
                            {
                                //if (s.AcademicYear.IsActive)
                                //{
                                //var other =
                                //    Context.Session.Where(x => x.AcademicYearId == s.AcademicYearId && s.IsActive);
                                //foreach (var o in other)
                                //{
                                //    o.IsActive = false;
                                //}
                                var rc = Context.RunningClass.Where(x => (x.SessionId ?? 0) == s.Id);

                                foreach (var r in rc)
                                {
                                    var earlierNotComplete =
                                        r.ProgramBatch.RunningClasses.Any(x => !(x.Completed ?? false));
                                    if (earlierNotComplete)
                                    {
                                        continue;
                                    }
                                    r.Completed = false;
                                    foreach (var sc in Context.SubjectClass.Where(w => w.RunningClassId == r.Id))
                                    {
                                        sc.SessionComplete = false;
                                        sc.CompleteMarkedByUserId = userId;
                                        sc.CompletionMarkedDate = date;
                                        Context.SaveChanges();
                                    }
                                }
                                s.IsActive = true;
                                //s.Completed = false;
                                Context.SaveChanges();
                                //}
                                //else return "Please, first activate the Academic year.";
                            }
                            else return "Already active.";


                            #endregion

                        }
                        scope.Complete();
                        return "success";
                    }
                }
                catch
                {
                    return "Error while updating.";
                }

            }

            #endregion



            #region To be Delete later

            //used in Exam listing.. to create selectable academic and session list
            //so we need to pass both these classes as same class i.e.
            //The view model is 
            public List<ViewModel.AcademicAndSessionCombinedViewModel> ListAcademicAndSessionAsViewModel(
                int schoolId, bool manager, bool teacher)
            {
                var list = new List<ViewModel.AcademicAndSessionCombinedViewModel>();
                Context.AcademicYear.Where(a => a.SchoolId == schoolId && !(a.Void ?? false))
                    .OrderByDescending(o => o.Position)
                    .ToList().ForEach(a =>
                    {
                        if (manager)
                        {
                            #region if manager or exam-head

                            list.Add(new AcademicAndSessionCombinedViewModel()
                            {
                                Id = a.Id
                                ,
                                AcademicYearId = a.Id
                                ,
                                SessionId = 0
                                ,
                                Completed = a.Completed ?? false
                                ,
                                Name = a.Name
                                ,
                                BothNameCombined = a.Name
                            });
                            foreach (var s in a.Sessions.OrderByDescending(o => o.Position))
                            {
                                list.Add(new AcademicAndSessionCombinedViewModel()
                                {
                                    Id = s.Id
                                    ,
                                    AcademicYearId = a.Id
                                    ,
                                    SessionId = s.Id
                                    ,
                                    Completed = s.Completed ?? false
                                    ,
                                    Name = s.Name
                                    ,
                                    BothNameCombined = a.Name + " > " + s.Name

                                });
                            }

                            #endregion
                        }
                        else if (teacher)
                        {
                            #region if teacher

                            var activeSes = a.Sessions.Where(x => x.IsActive && !(x.Completed ?? false)).ToList();

                            if (activeSes.Any() || (a.IsActive && !(a.Completed ?? false)))
                            {
                                list.Add(new AcademicAndSessionCombinedViewModel()
                                {
                                    Id = a.Id
                                    ,
                                    AcademicYearId = a.Id
                                    ,
                                    SessionId = 0
                                    ,
                                    Completed = a.Completed ?? false
                                    ,
                                    Name = a.Name
                                    ,
                                    BothNameCombined = a.Name
                                });
                                foreach (var s in activeSes.OrderByDescending(o => o.Position))
                                {
                                    list.Add(new AcademicAndSessionCombinedViewModel()
                                    {
                                        Id = s.Id
                                        ,
                                        AcademicYearId = a.Id
                                        ,
                                        SessionId = s.Id
                                        ,
                                        Completed = s.Completed ?? false
                                        ,
                                        Name = s.Name
                                        ,
                                        BothNameCombined = a.Name + " > " + s.Name

                                    });
                                }
                            }

                            #endregion
                        }
                    });
                return list;
            }

            //will be deleted soon
            public List<DbEntities.Session> GetTopSessionListForAcademicYear(int academicYearId)
            {
                return Context.Session.Where(x => x.AcademicYearId == academicYearId && x.ParentId == null
                                                  && x.EndDate >= DateTime.Now).OrderBy(x => x.EndDate).ToList();
                //&& x.IsActive == true
            }

            #endregion



            #region Get functions... academicYear and session get

            //used v-2
            public DbEntities.AcademicYear GetAcademicYear(int academicYearId)
            {
                return Context.AcademicYear.Find(academicYearId);
            }

            //used v-2
            public DbEntities.Session GetSession(int sessionId)
            {
                return Context.Session.Find(sessionId);
            }

            //used v-2
            public List<DbEntities.AcademicYear> ListAcademicYears(int schoolId)
            {
                var aca = Context.AcademicYear
                    .Where(x => x.SchoolId == schoolId && !(x.Void ?? false))
                    .Include(x => x.Sessions)
                    .OrderByDescending(y => y.StartDate)
                    .Take(10);

                return aca.ToList();
            }

            //Used v-2
            public List<DbEntities.SessionDefault> ListDefaultSessions(int schoolId)
            {
                return Context.SessionDefault.OrderBy(x => x.Position).ToList();
            }



            #endregion



            #region Add or update functions

            //Used v-2
            public DbEntities.Batches.Batch AddOrUpdateAcademicYearAndBatch(int schoolId,
                DbEntities.AcademicYear academicY, List<Session> sessions,
                DbEntities.Batches.Batch batch, List<DbEntities.Batches.ProgramBatch> progBatchList)
            {
                var acaEntity = Context.AcademicYear.Find(academicY.Id);
                var batchEnt = Context.Batch.Find(batch.Id);
                try
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        if (acaEntity == null)
                        {
                            //add

                            #region Academic year

                            //var max = academicY.StartDate.Year+academicY.StartDate.Month+academicY.StartDate.Day;
                            //try
                            //{
                            //    max = Context.AcademicYear.Where(x => x.SchoolId == schoolId).Max(m => m.Position);
                            //}
                            //catch { }
                            //academicY.Position = max ;
                            acaEntity = Context.AcademicYear.Add(academicY);
                            Context.SaveChanges();

                            foreach (var session in sessions)
                            {
                                session.AcademicYearId = acaEntity.Id;
                                Context.Session.Add(session);
                                Context.SaveChanges();
                            }

                            #endregion

                            #region Batch

                            batch.AcademicYearId = acaEntity.Id;
                            batchEnt = Context.Batch.Add(batch);
                            Context.SaveChanges();
                            foreach (var pb in progBatchList)
                            {
                                pb.BatchId = batchEnt.Id;
                                Context.ProgramBatch.Add(pb);
                                Context.SaveChanges();
                            }

                            #endregion

                            //saveSuccess = true;
                        }
                        else
                        {
                            //update

                            #region Academic year

                            acaEntity.IsActive = academicY.IsActive;
                            acaEntity.Name = academicY.Name;
                            acaEntity.EndDate = academicY.EndDate;
                            acaEntity.SchoolId = academicY.SchoolId;
                            acaEntity.StartDate = academicY.StartDate;
                            acaEntity.Position = academicY.Position;
                            Context.SaveChanges();

                            foreach (var session in sessions)
                            {
                                var foundSession = Context.Session.Find(session.Id);
                                if (foundSession == null)
                                {
                                    Context.Session.Add(session);
                                }
                                else
                                {
                                    foundSession.Name = session.Name;
                                    foundSession.StartDate = session.StartDate;
                                    foundSession.EndDate = session.EndDate;
                                }
                                Context.SaveChanges();
                            }


                            #endregion


                            #region Batch

                            if (batchEnt != null)
                            {
                                batchEnt.Name = batch.Name;
                                batchEnt.Description = batch.Description;

                                Context.SaveChanges();
                                foreach (var pb in progBatchList)
                                {
                                    var found = Context.ProgramBatch.Find(pb.Id);
                                    if (found == null)
                                    {
                                        Context.ProgramBatch.Add(pb);
                                        Context.SaveChanges();
                                    }
                                    else
                                    {
                                        found.Void = pb.Void;
                                        Context.SaveChanges();
                                    }
                                }
                                batchEnt.AcademicYear = acaEntity;
                            }


                            #endregion

                            //saveSuccess = true;
                        }
                        //var prev = Context.AcademicYear.Where(x => x.SchoolId == acaEntity.SchoolId && x.Id != acaEntity.Id);
                        //foreach (var academicYear in prev)
                        //{
                        //    academicYear.IsActive = false;
                        //}
                        //Context.SaveChanges();



                        scope.Complete();
                        return batchEnt;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }

            //Used v-2
            public bool AddOrUpdateSessionDefault(List<SessionDefault> list)
            {
                using (var scope = new TransactionScope())
                {
                    foreach (var sessionDefault in list)
                    {
                        var found = Context.SessionDefault.Find(sessionDefault.Id);
                        if (found == null)
                        {
                            Context.SessionDefault.Add(sessionDefault);
                            Context.SaveChanges();
                        }
                        else
                        {
                            found.Name = sessionDefault.Name;
                            Context.SaveChanges();
                        }
                    }
                    scope.Complete();
                    return true;
                }
                return false;
            }

            #endregion



            #region Delete functions

            //Used v-2
            public bool DeleteAcademicYear(int acaId)
            {
                try
                {
                    var academic = Context.AcademicYear.Find(acaId);
                    if (academic != null && !(academic.Completed??false))
                    {
                        
                        academic.Void = true;
                        academic.IsActive = false;

                        foreach (var batch in academic.Batches)
                        {
                            batch.Void = true;
                        }

                        foreach (var session in academic.Sessions)
                        {
                            session.Void = true;
                            session.IsActive = false;
                            foreach (var runningClass in session.RunningClasses)
                            {
                                runningClass.Void = true;
                                runningClass.IsActive = false;
                                foreach (var subjectClass in runningClass.SubjectClasses)
                                {
                                    subjectClass.Void = true;
                                    subjectClass.SessionComplete = false;
                                    foreach (var classUser in subjectClass.ClassUsers)
                                    {
                                        classUser.Void = true;
                                        classUser.Suspended = true;
                                    }
                                }
                            }
                        }
                        Context.SaveChanges();


                        return true;
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            }


            #endregion



            #region Activating Sessions all functions

            //Used v-2
            /// <summary>
            /// Direct call from asp-form "Academy/StartSession.aspx";
            /// </summary>
            /// <param name="schoolId"></param>
            /// <param name="currentlyActiveSession">It will give the id of the session that is currently active and needs to be marked as complete</param>
            /// <param name="nextToActivateSession">The session that will be activated next</param>
            /// <returns></returns>
            public DbEntities.AcademicYear GetNextSessionToActivate(int schoolId, ref Session currentlyActiveSession,
                ref Session nextToActivateSession)
            {
                try
                {
                    DbEntities.AcademicYear aca;
                    var latestActiveInactive = GetLatestActiveAndInactiveSession(schoolId);

                    // if activesession is not-null then we have to mark it as commplete
                    // if inActiveSession is not null then we have to mark it as active
                    // if inAcativeSession is null then we need to create new academic year and sessions then 
                    //      mark the first session as active

                    if (latestActiveInactive != null)
                    {
                        var active = latestActiveInactive[0];
                        var inactive = latestActiveInactive[1];

                        currentlyActiveSession = active;
                        nextToActivateSession = inactive;
                        aca = inactive == null ? null : inactive.AcademicYear;
                        //if (inactive != null)
                        //{
                        //    nextToActivateSession = inactive;
                        //    aca = inactive.AcademicYear;
                        //}
                        //else
                        //{
                        //    aca = GetNewAcademicYear();
                        //    nextToActivateSession = aca.Sessions.ToList()[0];
                        //}
                        return aca;
                    }
                    return null;
                }
                catch
                {
                    return null;
                }
            }

            //Used v-2
            /// <summary>
            /// Returns active session in 0-index and inactive session in 1-index
            /// </summary>
            /// <param name="schoolId"></param>
            /// <returns></returns>
            private Session[] GetLatestActiveAndInactiveSession(int schoolId)
            {
                var aYears = Context.AcademicYear.Where(x => !(x.Void ?? false) && x.SchoolId == schoolId)
                    .OrderByDescending(x => x.Position).ToList();

                var latestAca = aYears.FirstOrDefault();

                //check for active
                if (latestAca != null)
                {
                    var sessions = latestAca.Sessions.Where(x => !(x.Void ?? false))
                        .OrderBy(x => x.Position).ToList();

                    var activeSession = sessions.FirstOrDefault(x => x.IsActive && !(x.Completed ?? false));
                    var inActiveSession = sessions.FirstOrDefault(x => !x.IsActive && !(x.Completed ?? false));

                    if (activeSession == null)
                    {
                        if (aYears.Count >= 2)
                        {
                            var eAca = aYears[1];

                            var eSes = eAca.Sessions.Where(x => !(x.Void ?? false))
                                .OrderBy(x => x.Position).ToList();

                            activeSession = eSes.FirstOrDefault(x => x.IsActive && !(x.Completed ?? false));
                        }
                    }


                    return new Session[] { activeSession, inActiveSession };
                    // if activesession is not-null then we have to mark it as commplete
                    // if inActiveSession is not null then we have to mark it as active
                    // if inAcativeSession is null then we need to create new academic year and sessions then 
                    //      mark the first session as active
                }
                return null;

            }

            //Used v-2
            /// <summary>
            /// Returns List<runningClass/> for the upcoming Session.
            /// </summary>
            /// <param name="schoolId"></param>
            /// <param name="nextSessionRelativePosition">Position of  either sub-year or session wrt. their year or academic year respectively.
            ///  i.e. within the year the sub-year position is either 1 or 2 (if two subyears). don't provide its actual position,
            /// but the relative positions within the sub-years.
            /// </param>
            /// <param name="academicYearId"> pass id of next academic year.. only pass for getting rcls while saveing</param>
            /// <param name="sessionId"></param>
            public Dictionary<Program, List<RunningClass>> ListClassesForNextSession(int schoolId
                , int nextSessionRelativePosition, int academicYearId = 0, int sessionId = 0)
            {
                try
                {
                    Dictionary<Program, List<RunningClass>> dict = new Dictionary<Program, List<RunningClass>>();
                    // nextSessionRelativePosition is not 0-indexed so we make it 0-indexed by subtracting 1
                    var sessAndSubYearPosition = nextSessionRelativePosition - 1;

                    var aYears = Context.AcademicYear.Where(x => !(x.Void ?? false))
                        .OrderByDescending(x => x.Position).ToList();


                    //academic years loop
                    for (int a = 0; a < aYears.Count; a++)
                    {
                        var aca = aYears[a];


                        var progBatches = aca.Batches.First().ProgramBatches.Where(x => !(x.Void ?? false)).ToList();
                        //program batches loop
                        for (int pb = 0; pb < progBatches.Count; pb++)
                        {
                            var progBatch = progBatches[pb];
                            var years = progBatch.Program.Year.Where(x => !(x.Void ?? false))
                                .OrderBy(x => x.Position).ToList();


                            if (a < years.Count)
                            {
                                var runningClasses = new List<RunningClass>();
                                if (dict.ContainsKey(progBatch.Program))
                                    runningClasses = dict[progBatch.Program];
                                else
                                    dict.Add(progBatch.Program, runningClasses);


                                var year = years[a];

                                var subYears = year.SubYears.Where(x => !(x.Void ?? false))
                                    .OrderBy(x => x.Position).ToList(); //[sessAndSubYearPosition];

                                // if there's no sub-year then don't create running class
                                if (sessAndSubYearPosition < subYears.Count)
                                {
                                    //get sub-year at specified position
                                    var subYear = subYears[sessAndSubYearPosition];
                                    var runningClass = new RunningClass()
                                    {
                                        AcademicYearId = academicYearId,
                                        //AcademicYear = latestAca,
                                        Completed = false,
                                        IsActive = true,
                                        SessionId = sessionId,
                                        //Session = latestSession,
                                        ProgramBatchId = progBatch.Id,
                                        ProgramBatch = progBatch,
                                        YearId = year.Id,
                                        Year = year,
                                        Void = false,
                                        SubYearId = subYear.Id,
                                        SubYear = subYear,
                                    };
                                    runningClasses.Add(runningClass);
                                }
                            }
                        } //end of program batch loop

                    } //end of academic years loop
                    return dict;
                    //}
                }
                catch
                {
                    return null;
                }
                return null;
            }


            //Used v-2
            public DbEntities.AcademicYear GetLatestAcademicYear(int schoolId)
            {
                var ayears = Context.AcademicYear.Where(x => !(x.Void ?? false) && x.SchoolId == schoolId);
                if (ayears.Any())
                {
                    //var maxPosition = ayears.Max(x => x.Position);
                    var latestAca = ayears.FirstOrDefault(x => x.Position == (ayears.Max(m => m.Position)));
                    return latestAca;
                }
                else
                {
                    return null;
                }
            }


            //Used v-2
            /// <summary>
            /// Activates upcoming(next) session and saves its running-classes
            /// </summary>
            /// <param name="schoolId"></param>
            /// <param name="aId"></param>
            /// <param name="currActiveSessionId"></param>
            /// <param name="nextActivatingSessionId"></param>
            /// <returns></returns>
            public bool CreateNextActiveSession(int schoolId, int aId, int currActiveSessionId,
                int nextActivatingSessionId, int userId)
            {
                try
                {
                    using (var scope = new TransactionScope())
                    {
                        var date = DateTime.Now;
                        var currActiveSession = Context.Session.Find(currActiveSessionId);

                        // mark complete the current active session
                        if (currActiveSession != null)
                        {
                            currActiveSession.IsActive = false;
                            currActiveSession.Completed = true;
                            Context.SaveChanges();
                            //
                            var earlierRunningClasses = currActiveSession.RunningClasses.AsEnumerable();
                                //.Where(x => (x.IsActive ?? false) && !(x.Completed ?? false));
                            foreach (var rc in earlierRunningClasses)
                            {
                                rc.Completed = true;
                                rc.IsActive = false;

                                foreach (var subjectClass in rc.SubjectClasses)
                                {
                                    subjectClass.SessionComplete = true;
                                }
                            }
                            Context.SaveChanges();
                        }

                        int sessionPosition = 1;
                        var nextActive = Context.Session.Find(nextActivatingSessionId);
                        if (nextActive != null)
                        {
                            nextActive.IsActive = true;
                            var sessions = nextActive.AcademicYear.Sessions.OrderBy(x => x.Position).ToList();
                            //check for position of session
                            if (nextActivatingSessionId == sessions[0].Id)
                            {
                                sessionPosition = 1;
                            }
                            else if (nextActivatingSessionId == sessions[1].Id)
                            {
                                sessionPosition = 2;
                            }

                            // get roleId of student
                            var stdRole = Context.Role.FirstOrDefault(x => x.RoleName == StaticValues.Roles.Student);
                            if (stdRole == null)
                            {
                                stdRole = Context.Role.Add(new DbEntities.User.Role()
                                {
                                    DisplayName = StaticValues.Roles.Student,
                                    RoleName = StaticValues.Roles.Student,
                                    SchoolId = schoolId,

                                });
                                Context.SaveChanges();
                            }



                            //get running-classes for the upcoming session
                            var runClses = ListClassesForNextSession(schoolId, sessionPosition,
                                nextActive.AcademicYear.Id,
                                nextActive.Id);

                            foreach (var runCls in runClses.Values)
                            {
                                foreach (var rc in runCls)
                                {
                                    // for each runningClass add the runningClass
                                    var addedRc = Context.RunningClass.Add(rc);
                                    Context.SaveChanges();

                                    //get subjects of structure and create & save subjectClass
                                    var subjects =
                                        Context.SubjectStructure.Where(x => !(x.Obsolete ?? false)
                                                                            && !(x.Void ?? false) &&
                                                                            x.SubYearId == rc.SubYearId
                                                                            && x.YearId == rc.YearId
                                            );
                                    // each subjectClass save for each subject
                                    foreach (var sstr in subjects.Where(x => !x.IsElective))
                                    {
                                        //save subject class
                                        var sc = new DbEntities.Class.SubjectClass()
                                        {
                                            CreatedBy = userId,
                                            CreatedDate = date,
                                            EndDate = nextActive.EndDate,
                                            EnrollmentMethod = 0,
                                            IsRegular = true,
                                            RunningClassId = addedRc.Id,
                                            SessionComplete = false,
                                            StartDate = nextActive.StartDate,
                                            SubjectStructureId = sstr.Id,
                                            HasGrouping = true,
                                        };
                                        sc = Context.SubjectClass.Add(sc);
                                        Context.SaveChanges();

                                        //get students of the programBatch
                                        var stdBatches =
                                            rc.ProgramBatch.StudentBatches.Where(x => !(x.Void ?? false)).ToList();
                                        foreach (var stdBatch in stdBatches)
                                        {
                                            //add userclass for each student 
                                            var uc = new DbEntities.Class.UserClass()
                                            {
                                                CreatedDate = date,
                                                EndDate = nextActive.EndDate,
                                                EnrollmentDuration = 0,
                                                RoleId = stdRole.Id,
                                                StartDate = nextActive.StartDate,
                                                SubjectClassId = sc.Id,
                                                Suspended = false,
                                                UserId = stdBatch.Student.UserId,
                                                Void = false,

                                            };
                                            Context.UserClass.Add(uc);
                                            Context.SaveChanges();
                                        }

                                    }
                                }
                            }

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

            #endregion



            public DbEntities.AcademicYear GetEarlierAcademicYear(int schoolId)
            {
                return Context.AcademicYear.Where(x => !(x.Void ?? false)).OrderByDescending(x => x.Position).FirstOrDefault();
            }
        }
    }
}
