using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.AcacemicPlacements
{
    [Serializable]
    public class StudentClass
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int? StudentGroupId { get; set; }

        public int RunningClassId { get; set; }

        public virtual Students.Student Student { get; set; }
        public virtual Students.StudentGroup StudentGroup { get; set; }

        public virtual RunningClass RunningClass { get; set; }

        //next version
        //create next table to store student information about suspension from date, to date, reason, by, rank of punishment etc.
        public bool? Suspended { get; set; }
        public bool? Void { get; set; }

        public virtual ICollection<Exams.ExamStudent> ExamStudents { get; set; }

    }
}
