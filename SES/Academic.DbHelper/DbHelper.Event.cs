using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.Database;

namespace Academic.DbHelper
{
    public partial class DbHelper
    {
        public class Event : IDisposable
        {
            AcademicContext Context;

            public Event()
            {
                Context = new AcademicContext();
            }

            public DbEntities.Events.Event GetEvent(int eventId)
            {
                return Context.Event.Find(eventId);
            }

            public DbEntities.Events.Event GetEvent(int eventId,bool manager, int userId)
            {
                if(manager)
                    return Context.Event.Find(eventId);
                else
                {
                    return Context.Event.FirstOrDefault(x => x.Id == eventId && !x.PostToPublic && x.PostedById==userId);
                }
            }

            //--used --after github
            public List<DbEntities.Events.Event> ListEvents(int schoolId, int userId, DateTime date)
            {
                return Context.Event.Where(x => ((x.SchoolId == schoolId && x.PostToPublic)
                                                    || x.PostedById == userId) && x.Date == date).ToList();
            }

            //userd --after github
            public List<DbEntities.Events.Event> ListEvents(int schoolId, int userId)
            {
                return Context.Event.Where(x => (x.SchoolId == schoolId && x.PostToPublic)
                                                    || x.PostedById == userId)
                    .OrderByDescending(x => x.Date)
                    .ThenByDescending(x=>x.Id)
                    .ToList();
            }

            public void Dispose()
            {
                Context.Dispose();
            }

            public List<DateTime> ListEventDatesForTheMonth(int schoolId, int userId, DateTime dateTime)
            {
                var month = dateTime.Month;
                var list = new List<DateTime>();
                var evts = Context.Event.Where(x => (x.SchoolId == schoolId && x.PostToPublic)
                                                    || x.PostedById == userId);
                foreach (var ev in evts)
                {
                    if (ev.Date.Month >= month - 2 && ev.Date.Month <= month + 2)
                        list.Add(ev.Date.Date);
                }
                return list.Distinct().ToList();
            }

            public DbEntities.Events.Event AddOrUpdateEvent(DbEntities.Events.Event evnt)
            {
                var found = Context.Event.Find(evnt.Id);
                if (found == null)
                {
                    found = Context.Event.Add(evnt);
                    Context.SaveChanges();
                }
                else
                {
                    found.Date = evnt.Date;
                    found.Description = evnt.Description;
                    found.Location = evnt.Location;
                    found.Title = evnt.Title;
                    found.Time = evnt.Time;
                    found.Latitude = evnt.Latitude;
                    found.Longitude = evnt.Longitude;
                    Context.SaveChanges();
                }
                return found;
            }
        }
    }
}
