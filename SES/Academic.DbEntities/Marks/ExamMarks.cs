using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Marks
{
    public class ExamMarks
    {
        public int Id { get; set; }
        public int SubjectExamId { get; set; }
        public int StudentId { get; set; }
        public float? Marks { get; set; }

        public bool IsGradeSystem { get; set; }
        public string Grade { get; set; }

        public virtual Exams.ExamSubject SubjectExam { get; set; }
        public virtual Students.Student Student { get; set; }
    }
}
