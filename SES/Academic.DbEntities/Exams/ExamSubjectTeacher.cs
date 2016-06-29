using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Exams
{
    public class ExamSubjectTeacher
    {
        public int Id { get; set; }

        public int ExamSubjectId { get; set; }
        public int TeacherClassId { get; set; }

        public virtual Exams.ExamSubject ExamSubject { get; set; }
        public virtual AcacemicPlacements.TeacherClass TeacherClass { get; set; }
    }
}
