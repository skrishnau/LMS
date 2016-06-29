using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Teachers
{
    public class Appointment
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public DateTime AppointedDate { get; set; }

        public int SchoolId { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
