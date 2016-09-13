using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Students
{
    [Obsolete]
    public class StudentSubject
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public DateTime AssignedDate { get; set; }
        public int AcademicYearId { get; set; }
        public int? SessionId { get; set; }

        public bool IsActive { get; set; }


    }
}
