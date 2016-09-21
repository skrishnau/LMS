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
        public class Event:IDisposable
        {
            AcademicContext Context;

            public Event()
            {
                Context = new AcademicContext();
            }

            public List<DbEntities.Events.Event> GetEvent(int schoolId, DateTime date)
            {
                return Context.Event.Where(x => x.SchoolId == schoolId && x.Date == date).ToList();
            }

            public void Dispose()
            {
                Context.Dispose();
            }

            public List<DateTime> ListEventDatesForTheMonth(int schoolId,DateTime dateTime)
            {
                var month = dateTime.Month;
                var list = new  List<DateTime>();
                var evts =  Context.Event.Where(x => x.SchoolId== schoolId );
                foreach (var ev in evts)
                {
                    if (ev.Date.Month >= month-2 && ev.Date.Month<=month+2 )
                        list.Add(ev.Date.Date);
                }
                return list.Distinct().ToList();
            }
        }
    }
}
