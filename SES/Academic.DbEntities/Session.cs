using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.AcacemicPlacements;

namespace Academic.DbEntities
{
    public class Session
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// the ordering of session to facilitate automatic session change
        /// </summary>
        public int Position { get; set; }
        //public string SessionType { get; set; }//e.g. Fall , Spring

        public int? ParentId { get; set; }
        public virtual Session Parent { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }
        public bool? Completed { get; set; }
        public DateTime? CompleteMarkedDate { get; set; }
        public int? CompleteMarkedById { get; set; }

        public bool? Void { get; set; }

        public bool? RemindWhenEndDate { get; set; }//setting to check ; true -- remind about the nearing of end date

        public int AcademicYearId { get; set; }
        public virtual AcademicYear AcademicYear { get; set; }

        public virtual ICollection<RunningClass> RunningClasses { get; set; }

    }
}
