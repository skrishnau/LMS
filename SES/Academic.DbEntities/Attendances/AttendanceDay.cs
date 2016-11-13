using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Attendances
{
    public class AttendanceDay
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TeachId { get; set; }

        //public virtual Activities.Teach Teach { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
