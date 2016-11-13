using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.Batches;

namespace Academic.DbEntities.AcacemicPlacements
{
    public class RunningClass
    {
        public int Id { get; set; }


        public int AcademicYearId { get; set; }
        public virtual AcademicYear AcademicYear { get; set; }

        public int? SessionId { get; set; }
        public virtual Session Session { get; set; }

        public int YearId { get; set; }
        public virtual Structure.Year Year { get; set; }

        public int? SubYearId { get; set; }
        public virtual Structure.SubYear SubYear { get; set; }

        public int? ProgramBatchId { get; set; }
        public virtual ProgramBatch ProgramBatch { get; set; }

        public bool? Void { get; set; }
        public bool? IsActive { get; set; }
        public bool? Completed { get; set; }

        public virtual ICollection<Class.SubjectClass> SubjectClasses { get; set; }

        //obsolete
        //[Obsolete]

        //[Obsolete]
        //public virtual ICollection<SubjectClass> SubjectClasses { get; set; }
        //apply next table to store students' opinion about the course
    }
}
