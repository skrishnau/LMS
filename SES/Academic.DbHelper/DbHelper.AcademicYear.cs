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
                            var max = Context.AcademicYear.Where(x => x.SchoolId == schoolId).Max(m => m.Position);
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
                    .OrderByDescending(y => y.StartDate);

                return aca.ToList();
            }

            public bool AddOrUpdateSession(int academicYearId, DbEntities.Session session)
            {
                try
                {
                    var a = Context.AcademicYear.Find(academicYearId);
                    if (a != null)
                    {
                        var max = a.Sessions.Max(x => x.Position);
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

            //Used
            public void ActivateAcademicYearSession(int aId, int sId)
            {
                using (var scope = new TransactionScope())
                {
                    var a = Context.AcademicYear.Find(aId);
                    if (a != null)
                    {
                        a.IsActive = true;
                        Context.SaveChanges();
                    }
                    var s = Context.Session.Find(sId);
                    if (s != null)
                    {
                        s.IsActive = true;
                        Context.SaveChanges();
                    }
                    scope.Complete();

                }
            }

            //used in Exam listing.. to create selectable academic and session list
            //so we need to pass both these classes as same class i.e.
            //The view model is 
            public List<ViewModel.AcademicAndSessionCombinedViewModel> ListAcademicAndSessionAsViewModel(int schoolId)
            {
                var list = new List<ViewModel.AcademicAndSessionCombinedViewModel>();
                Context.AcademicYear.Where(a => a.SchoolId == schoolId && !(a.Void??false))
                    .OrderByDescending(o=>o.Position)
                    .ToList().ForEach(a =>
                    {
                        list.Add(new AcademicAndSessionCombinedViewModel()
                        {
                            Id = a.Id
                            ,AcademicYearId = a.Id
                            ,SessionId = 0
                            ,Completed = a.Completed??false
                            ,Name = a.Name
                            ,BothNameCombined = a.Name
                        });
                        foreach (var s in a.Sessions.OrderByDescending(o=>o.Position))
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
                                ,BothNameCombined = a.Name+" > "+s.Name

                            });
                        }
                    });
                return list;
            }
        }
    }
}
