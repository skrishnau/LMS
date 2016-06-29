using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Activities
{
    public class Study
    {
        public int Id { get; set; }
        public int StudentGroupId { get; set; }
        public int YearId { get; set; }
        public int? SectionId { get; set; }

        //public int SubjectId { get; set; }

        public int AcademicYearId { get; set; }
        public int? SessionId { get; set; }

        public virtual Students.StudentGroup StudentGroup { get; set; }
        public virtual Structure.Year Year { get; set; }
        public virtual Structure.SubYear Section { get; set; }

        //public virtual Subjects.Subject Subject { get; set; }

        public virtual AcademicYear AcademicYear { get; set; }
        public virtual Session Session { get; set; }
    }
}
