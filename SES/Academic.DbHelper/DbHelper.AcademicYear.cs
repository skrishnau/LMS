using Academic.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Academic.DbEntities;
using Academic.DbEntities.AcacemicPlacements;
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

            //only add for now
            public bool Add(ViewModel.AcademicViewModel model)
            {
                var AYentity = new DbEntities.AcademicYear()
                {

                    Name = model.AcademicYearName,
                    StartDate = model.StartDateAY,
                    EndDate = model.EndDateAV,
                    IsActive = true,
                    SchoolId = model.SchoolId
                };
                var ay = Context.AcademicYear.Add(AYentity);

                Context.SaveChanges();
                var list = new List<ViewModel.SessionViewModel>();
                if (model.Sessions != null)
                    if (model.Sessions.Count > 0)
                        foreach (var m in model.Sessions)
                        {
                            var Sentity = new DbEntities.Session()
                            {
                                Name = m.Name,
                                StartDate = m.StartDate,
                                EndDate = m.EndDate,
                                IsActive = true,
                                //SessionType = m.SessionType,
                                AcademicYearId = ay.Id
                            };
                            var sess = Context.Session.Add(Sentity);
                            Context.SaveChanges();
                        }

                return true;
            }


            public void Dispose()
            {
                Context.Dispose();
            }

            public bool AddAcademicAndSession(ViewModel.AcademicAndSessionViewModel model)
            {
                try
                {
                    DbEntities.AcademicYear entity = new DbEntities.AcademicYear()
                    {

                        Name = model.AcademicYearName,
                        SchoolId = model.SchoolId,
                        StartDate = new DateTime(model.YearAs, (int)model.MonthAs, model.DateAs),
                        EndDate = new DateTime(model.YearAe, (int)model.MonthAe, model.DateAe),

                        IsActive = true
                    };
                    var saved = Context.AcademicYear.Add(entity);
                    Context.SaveChanges();
                    DbEntities.Session session = new DbEntities.Session()
                    {
                        Name = model.SessionName,
                        StartDate = new DateTime(model.YearSs, (model.MonthSs + 1), model.DateSs),
                        EndDate = new DateTime(model.YearSe, model.MonthSe + 1, model.DateSe),
                        IsActive = true,
                        AcademicYearId = saved.Id,
                        //SessionType = model.SessionType,

                    };
                    Context.Session.Add(session);
                    Context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            public DbEntities.AcademicYear GetCurrentAcademicYear(int schoolId)
            {
                var date = DateTime.Now;
                var ay = Context.AcademicYear.FirstOrDefault(x => (x.SchoolId == schoolId && x.StartDate < date && x.EndDate > date) || x.IsActive);
                if (ay == null)
                    return null;
                return ay;
            }

            public DbEntities.Session GetCurrentSession(int academicYearId)
            {
                var date = DateTime.Now;
                var ay = Context.Session.FirstOrDefault(x => (x.AcademicYearId == academicYearId && x.StartDate < date && x.EndDate > date) || x.IsActive);
                if (ay == null)
                    return null;
                return ay;
            }

            public DbEntities.AcademicYear AddOrUpdateAcademicYear(int schoolId, DbEntities.AcademicYear entity)
            {
                //bool saveSuccess = false;
                var ent = Context.AcademicYear.Find(entity.Id);
                try
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        if (ent == null)
                        {
                            //add
                            var max = 0;
                            try
                            {
                                max = Context.AcademicYear.Where(x => x.SchoolId == schoolId).Max(m => m.Position);
                            }
                            catch { }
                            entity.Position = max + 1;
                            ent = Context.AcademicYear.Add(entity);
                            Context.SaveChanges();
                            //saveSuccess = true;
                        }
                        else
                        {
                            //update
                            ent.IsActive = entity.IsActive;
                            ent.Name = entity.Name;
                            ent.EndDate = entity.EndDate;
                            ent.SchoolId = entity.SchoolId;
                            ent.StartDate = entity.StartDate;
                            Context.SaveChanges();
                            //saveSuccess = true;
                        }
                        var prev = Context.AcademicYear.Where(x => x.SchoolId == ent.SchoolId && x.Id != ent.Id);
                        foreach (var academicYear in prev)
                        {
                            academicYear.IsActive = false;
                        }
                        Context.SaveChanges();
                        scope.Complete();
                        return ent;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }

            public List<DbEntities.AcademicYear> GetAcademicYearListForSchool(int schoolId)
            {
                var date = DateTime.Now;
                var aca = Context.AcademicYear
                    .Where(x => x.SchoolId == schoolId && !(x.Void ?? false))
                    .Include(x => x.Sessions)
                    .OrderByDescending(y => y.StartDate)
                    .Take(10);

                return aca.ToList();
            }

            public bool AddOrUpdateSession(int academicYearId, DbEntities.Session session)
            {
                try
                {
                    var a = Context.AcademicYear.Find(academicYearId);
                    if (a != null)
                    {
                        var max = 0;
                        try
                        {
                            max = a.Sessions.Max(x => x.Position);
                        }
                        catch { }

                        var sess = Context.Session.Find(session.Id);
                        if (sess == null)
                        {
                            session.Position = max + 1;
                            Context.Session.Add(session);
                            Context.SaveChanges();
                        }
                        else
                        {
                            sess.EndDate = session.EndDate;
                            //sess.SessionType = session.SessionType;
                            sess.IsActive = session.IsActive;
                            sess.Name = session.Name;
                            sess.StartDate = session.StartDate;

                            Context.SaveChanges();
                        }
                        return true;
                    }
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            public List<DbEntities.Session> GetSessionListForAcademicYear(int academicYearId)
            {
                return Context.Session.Where(x => x.AcademicYearId == academicYearId && (x.ParentId == null || x.ParentId == 0)
                    && x.IsActive == true
                    && x.EndDate >= DateTime.Now).ToList();
            }

            public List<DbEntities.Session> GetTopSessionListForAcademicYear(int academicYearId)
            {
                return Context.Session.Where(x => x.AcademicYearId == academicYearId && x.ParentId == null
                     && x.EndDate >= DateTime.Now).OrderBy(x => x.EndDate).ToList();//&& x.IsActive == true
            }

            public DbEntities.AcademicYear GetPreviousAcademicYear(int acadeicYearId)
            {
                try
                {
                    return CalculatePreviousAcademicYear(acadeicYearId);
                }
                catch (Exception exe)
                {
                    return null;
                }
            }

            private DbEntities.AcademicYear CalculatePreviousAcademicYear(int acadeicYearId)
            {
                try
                {

                    var thisAcaYear = Context.AcademicYear.Find(acadeicYearId);
                    var prev = Context.AcademicYear.Where(x => x.EndDate < thisAcaYear.EndDate && !(x.Void ?? false)).OrderByDescending(y => y.EndDate);

                    foreach (var aca in prev)
                    {
                        if (Context.RunningClass.Any(x => x.AcademicYearId == aca.Id))
                        {
                            return aca;
                        }
                    }
                    return null;

                }
                catch (Exception exe)
                {
                    return null;
                }
            }

            public DbEntities.Session GetPreviousSession(int acadeicYearId, int sessionId)
            {
                try
                {
                    return CalculatePreviousSession(acadeicYearId, sessionId);
                }
                catch (Exception exe)
                {
                    return null;
                }
            }

            private DbEntities.Session CalculatePreviousSession(int acadeicYearId, int sessionId = 0)
            {
                try
                {

                    var thisSession = Context.Session.Find(sessionId);
                    var prevSession = thisSession.AcademicYear.Sessions.Where(x => x.EndDate < thisSession.EndDate
                                                                            && (x.Void ?? false))
                        .OrderByDescending(x => x.EndDate).First();


                    if (prevSession == null)
                    {
                        var prevAcaYear = GetPreviousAcademicYear(thisSession.AcademicYearId);
                        if (prevAcaYear != null)
                        {
                            var newPrevSession = prevAcaYear.Sessions.Where(x => !(x.Void ?? false)).OrderByDescending(x => x.EndDate).First();
                            if (Context.RunningClass.Any(x => x.SessionId == newPrevSession.Id))
                            {
                                return newPrevSession;
                            }
                            else
                            {
                                return CalculatePreviousSession(prevAcaYear.Id, newPrevSession.Id);
                            }
                        }

                    }
                    else
                    {
                        if (Context.RunningClass.Any(x => x.SessionId == prevSession.Id))
                        {
                            return prevSession;
                        }
                        else
                        {
                            return CalculatePreviousSession(prevSession.AcademicYearId, prevSession.Id);
                        }

                    }
                    return null;

                }
                catch (Exception exe)
                {
                    return null;
                }
            }

            public bool IsThisActiveAcademicYearSession(int academicYearId, int? sessionId)
            {
                try
                {
                    if ((sessionId ?? 0) > 0)
                    {
                        return Context.Session.Any(x => x.IsActive && x.Id == sessionId);
                    }
                    else
                    {
                        return Context.AcademicYear.Any(x => x.IsActive && x.Id == academicYearId);
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }

            //used
            public DbEntities.AcademicYear GetAcademicYear(int academicYearId)
            {
                return Context.AcademicYear.Find(academicYearId);
            }
            //used
            public DbEntities.Session GetSession(int sessionId)
            {
                return Context.Session.Find(sessionId);
            }

            //used--> after github
            public Academic.DbEntities.Session GetNextSessionToActivate(int schoolId)
            {
                try
                {
                    var a = Context.AcademicYear.Where(x => x.IsActive && x.SchoolId == schoolId).ToList();
                    if (a.Any())
                    {
                        var maxStartDate = a.Max(x => x.StartDate);

                        var latestStart = a.Where(x => x.StartDate == maxStartDate).ToList();
                        var maxEndDate = latestStart.Max(x => x.EndDate);
                        var latestEnd = latestStart.FirstOrDefault(x => x.EndDate == maxEndDate);
                        if (latestEnd != null)
                        {
                            var sess = latestEnd.Sessions.FirstOrDefault(x => x.IsActive);
                            if (sess != null)
                            {
                                var nextSess = Context.Session
                                    .Where(
                                        x =>
                                            x.AcademicYearId == latestEnd.Id && x.Position > sess.Position &&
                                            !(x.Void ?? false))
                                    .OrderBy(x => x.Position).FirstOrDefault();
                                return nextSess
                                    ??
                                    new Session()
                                    {
                                        Id = 0
                                        ,
                                        AcademicYearId = latestEnd.Id
                                        ,
                                        AcademicYear = latestEnd
                                    ,
                                    };

                            }
                        }
                    }
                    else
                    {
                        var notactive = Context.AcademicYear.Where(x => x.SchoolId == schoolId &&
                                                                        !(x.Void ?? false)).ToList();
                        var latest = notactive.FirstOrDefault(x => x.Position == (notactive.Max(m => m.Position)));
                        if (latest != null)
                            return latest.Sessions.FirstOrDefault(x => x.Position == (latest.Sessions.Min(m => m.Position)));
                    }
                    return null;
                }
                catch
                {
                    return null;
                    throw;
                }
            }

            //used ==> after github
            public Academic.DbEntities.AcademicYear GetNextAcademicYearToActivate(int schoolId)
            {
                try
                {
                    var a = Context.AcademicYear.Where(x => x.SchoolId == schoolId && x.IsActive).ToList();
                    if (a.Any())
                    {
                        //var lateset = a.Where(x => x.Position == (a.Max(y => y.Position)));
                        return Context.AcademicYear.Where(x => x.SchoolId == schoolId && x.Position > a.Max(m => m.Position))
                            .OrderBy(o => o.Position).FirstOrDefault();
                    }
                    var max = Context.AcademicYear.Where(x => !(x.Void ?? false) && x.SchoolId == schoolId).Max(x => x.Position);
                    return Context.AcademicYear.FirstOrDefault(x => x.SchoolId == schoolId && x.Position == max);
                }
                catch
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
                            if (!a.IsActive)
                            {
                                //var other = Context.AcademicYear.Where(x => x.SchoolId == a.SchoolId && x.IsActive);
                                //foreach (var o in other)
                                //{
                                //    o.IsActive = false;
                                //}
                                var rc = Context.RunningClass.Where(x => x.AcademicYearId == a.Id && (x.SessionId ?? 0) == 0);

                                foreach (var r in rc)
                                {
                                    if(r.ProgramBatchId!=null)
                                    {

                                        var earlierNotComplete = r.ProgramBatch.RunningClasses.Any(x => !(x.Completed ?? false));
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
                        }
                        var s = Context.Session.Find(sId);
                        if (s != null)
                        {
                            if (!s.IsActive)
                            {
                                if (s.AcademicYear.IsActive)
                                {
                                    //var other =
                                    //    Context.Session.Where(x => x.AcademicYearId == s.AcademicYearId && s.IsActive);
                                    //foreach (var o in other)
                                    //{
                                    //    o.IsActive = false;
                                    //}
                                    var rc = Context.RunningClass.Where(x => (x.SessionId ?? 0) == s.Id);

                                    foreach (var r in rc)
                                    {
                                        var earlierNotComplete = r.ProgramBatch.RunningClasses.Any(x => !(x.Completed ?? false));
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
                                }
                                else return "Please, first activate the Academic year.";
                            }
                            else return "Already active.";
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


            //Used
            public List<Academic.DbEntities.AcademicYear> ListEarlierActiveAcademicYearsForChoose(int schoolId)
            {
                return Context.AcademicYear.Where(x => x.SchoolId == schoolId && (x.IsActive || !(x.Completed ?? false)))
                    .OrderByDescending(x => !x.IsActive)
                     .ThenBy(x => x.StartDate).ThenBy(x => x.EndDate).ThenBy(x => x.Position).ToList();
            }

            //public void AutoUpdateAcademicYear(int userId,int schoolId, int academicYearId)
            //{
            //    ActivateAcademicYearSession(userId, academicYearId, 0);

            //}

            public DbEntities.AcademicYear GetLatestCompletedAcademicYear(int schoolId)
            {
                DateTime? date = null;
                try
                {
                    var recentComplete =
                         Context.AcademicYear.Where(x => ((x.Completed ?? false) || x.IsActive) && x.SchoolId == schoolId)
                        .OrderBy(x => x.IsActive).ThenByDescending(x => x.CompleteMarkedDate).FirstOrDefault();
                    return recentComplete;
                }
                catch
                {
                    return null;
                }
            }

            public bool AutoUpdateAcademicYear(int aId, int userId)
            {
                using (var scope = new TransactionScope())
                using (var helper = new DbHelper.AcademicPlacement())
                {
                    var aca = Context.AcademicYear.Find(aId);
                    if (aca != null)
                    {
                        aca.IsActive = true;
                        if (!aca.IsActive)
                        {
                            #region Save Sessions

                            var j = 0;
                            var savedSessionId = 0;
                            foreach (var s in aca.Sessions.Where(x => !(x.Void ?? false)).OrderBy(x => x.Position))
                            {
                                var ses = new Session()
                                {
                                    AcademicYearId = aca.Id,
                                    EndDate = new DateTime(aca.EndDate.Year, s.EndDate.Month, s.EndDate.Day)
                                    ,
                                    StartDate = new DateTime(aca.StartDate.Year, s.StartDate.Month, s.StartDate.Day)
                                    ,
                                    Name = s.Name
                                    ,
                                    Position = s.Position
                                    ,
                                    RemindWhenEndDate = true
                                };
                                if (j == 0)
                                {
                                    ses.IsActive = true;
                                }
                                var savedSes = Context.Session.Add(ses);
                                Context.SaveChanges();
                                savedSessionId = savedSes.Id;
                                j++;
                            }

                            #endregion

                            var latestAca = GetLatestCompletedAcademicYear(aca.SchoolId);
                            if (latestAca != null)
                            {
                                var list = new List<RunningClass>();

                                #region Academic year

                                //var rcOfAca = Context.RunningClass.Where(x => x.AcademicYearId == latestAca.Id
                                //                                              && (x.SessionId ?? 0) == 0);

                                foreach (var rc in latestAca.RunningClasses.Where(x => (x.SessionId ?? 0) == 0))
                                {
                                    var curPos = rc.Year.Position;
                                    var nextYear = rc.Year.Program.Year.OrderBy(x => x.Position)
                                        .FirstOrDefault(x => x.Position > curPos);
                                    if (nextYear != null)
                                    {
                                        var newRc = new RunningClass()
                                        {
                                            AcademicYearId = aca.Id
                                            ,
                                            YearId = nextYear.Id
                                            ,
                                            ProgramBatchId = rc.ProgramBatchId
                                        };
                                        list.Add(newRc);
                                    }
                                }

                                #endregion

                                #region Session

                                var latestSession = latestAca.Sessions.Where(x => ((x.Completed ?? false) || x.IsActive))
                                    .OrderBy(x => x.IsActive).ThenByDescending(x => x.CompleteMarkedDate).FirstOrDefault();

                                var i = 0;
                                if (latestSession != null)

                                    foreach (var s in aca.Sessions.OrderBy(x => x.Position))
                                    {
                                        var rcSess = Context.RunningClass.Where(x => x.AcademicYearId == latestAca.Id
                                                                                     && x.SessionId == latestSession.Id);
                                        foreach (var sesRC in rcSess)
                                        {
                                            var nextYear = sesRC.Year.Program.Year.OrderBy(x => x.Position)
                                                .FirstOrDefault(x => x.Position > sesRC.Year.Position);

                                            if (nextYear != null)
                                            {
                                                var nextSubyear =
                                                    nextYear.SubYears.Where(x => !(x.Void ?? false))
                                                        .OrderBy(x => x.Position)
                                                        .FirstOrDefault();
                                                if (nextSubyear != null)
                                                {
                                                    var newRc = new RunningClass()
                                                    {
                                                        AcademicYearId = aca.Id
                                                        ,
                                                        SessionId = savedSessionId
                                                        ,
                                                        ProgramBatchId = sesRC.ProgramBatchId
                                                        ,
                                                        IsActive = true
                                                        ,
                                                        YearId = nextYear.Id
                                                        ,
                                                        SubYearId = nextSubyear.Id
                                                    };
                                                    list.Add(newRc);
                                                }

                                            }
                                        }

                                    }

                                #endregion

                                var savedaca = helper.AddOrUpdateRunningClass(list);
                                scope.Complete();
                                return true;
                            }
                            else
                            {
                                ActivateAcademicYearSession(userId, aca.Id, 0);
                                return true;
                            }
                        }
                    }
                }
                return false;
            }

            //public void AutoUpdateAcademicYear(int userId, int academicYearId, int sessionId)
            //{
            //    using (var scope = new TransactionScope())
            //    using (var helper = new DbHelper.AcademicPlacement())
            //    {
            //        var aca = Context.AcademicYear.Find(academicYearId);
            //        if (aca != null)
            //        {
            //            var latest = GetLatestCompletedAcademicYear(aca.SchoolId);
            //            if (latest != null)
            //            {
            //                var rca = Context.RunningClass.Where(x => x.AcademicYearId == latest.Id);
            //                var list = new List<RunningClass>();

            //                //only academic year 
            //                foreach (var aonly in rca.Where(x => (x.SessionId ?? 0) == 0))
            //                {
            //                    var curPos = aonly.Year.Position;
            //                    var ney = aonly.Year.Program.Year.OrderBy(x => x.Position)
            //                            .FirstOrDefault(x => x.Position > aonly.Year.Position);
            //                    if (ney != null)
            //                    {
            //                        var newRc = new RunningClass()
            //                        {
            //                            AcademicYearId = aca.Id
            //                            ,
            //                            YearId = ney.Id
            //                            ,
            //                            ProgramBatchId = aonly.ProgramBatchId
            //                        };
            //                        list.Add(newRc);
            //                        //var savedRc = Context.RunningClass.Add(newRc);
            //                        //Context.SaveChanges();
            //                    }
            //                }
            //                var savedaca = helper.AddRunningClass(list);


            //                //only session
            //                var session = Context.Session.Find(sessionId);
            //                if (session != null)
            //                {
            //                    //var latestSubYear = 
            //                    foreach (var sonly in rca.Where(x => (x.SessionId ?? 0) > 0))
            //                    {
            //                        var curPos = sonly.SubYear.Position;
            //                        var ney =
            //                            sonly.SubYear.Year.SubYears.OrderBy(x => x.Position)
            //                                .FirstOrDefault(x => x.Position > curPos);

            //                        if (ney != null)
            //                        {
            //                            //then next subyear in same year
            //                            var newRc = new RunningClass()
            //                            {
            //                                AcademicYearId = aca.Id
            //                                ,
            //                                YearId = ney.YearId ?? 0
            //                                ,
            //                                SubYearId = ney.Id
            //                                ,

            //                                ProgramBatchId = sonly.ProgramBatchId
            //                                ,
            //                                SessionId = session.Id
            //                            };
            //                            list.Add(newRc);
            //                            //var savedRc = Context.RunningClass.Add(newRc);
            //                            //Context.SaveChanges();
            //                        }
            //                        else
            //                        {
            //                            //then subyear is finished so next year
            //                        }
            //                    }
            //                    var savedses = helper.AddRunningClass(list);
            //                }
            //            }
            //            else
            //            {
            //                ActivateAcademicYearSession(userId, academicYearId, 0);
            //            }
            //            var ses = Context.Session.Find(sessionId);
            //            if (ses != null)
            //            {

            //            }
            //        }
            //    }
            //}

            public bool DeleteAcademicYear(int acaId)
            {
                try
                {
                    var academic = Context.AcademicYear.Find(acaId);
                    if (academic != null)
                    {
                        academic.Void = true;
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

            public bool DeleteSession(int sessionId)
            {
                try
                {
                    var session = Context.Session.Find(sessionId);
                    if (session != null)
                    {
                        session.Void = true;
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
        }
    }
}
