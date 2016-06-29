using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Attendances
{
    public class Attendance
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int PresenceStatusId { get; set; }
        public int AttendanceDayId { get; set; }

        public virtual Students.Student Student { get; set; }
        public virtual PresenceStatus PresenceStatus { get; set; }
        public virtual AttendanceDay AttendanceDay { get; set; }
    }
}
