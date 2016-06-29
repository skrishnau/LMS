
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities
{
    public class AcademicYear
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool? RemindWhenEndDate { get; set; }//setting to check ; true -- remind about the nearing of end date

        //foreign
        public bool IsActive { get; set; }
        public int SchoolId { get; set; }


        public bool? Void { get; set; }
        //public virtual School  School { get; set; }

        public virtual ICollection<Session> Sessions { get; set; } 
        public virtual ICollection<Exams.Exam> Exams { get; set; }
    }
}
