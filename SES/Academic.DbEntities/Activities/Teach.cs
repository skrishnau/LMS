using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Activities
{
    public class Teach
    {
        public int Id { get; set; }

        public int AcademicYearId { get; set; }
        public int? SessionId { get; set; }

        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
        //public int StudentGroupId { get; set; }

        public virtual AcademicYear AcademicYear { get; set; }
        public virtual Session Session { get; set; }
        public virtual Teachers.Teacher Teacher { get; set; }
        public virtual Subjects.Subject Subject { get; set; }

        public DateTime AssignedDate { get; set; }
        public DateTime StartDate { get; set; }

        public int? EstimatedCompletionHours { get; set; }
        public bool? Void { get; set; }

        public string Remarks { get; set; }

        //public virtual Students.StudentGroup StudentGroup { get; set; }

    }
}
