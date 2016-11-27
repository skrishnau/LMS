using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.User;

namespace Academic.DbEntities.Exams
{
    //used
    public class ExamStudent
    {
        public int Id { get; set; }

        public int ExamSubjectId { get; set; }
        public virtual ExamSubject ExamSubject { get; set; }

        //for regular only
        public int UserClassId { get; set; }
        public virtual Class.UserClass UserClass { get; set; }

        //------------------------- Marking -----------------------//

        //null means true in this case but value will be present if marks is inserted
        public bool? IsGrade { get; set; }

        public int? ObtainedGradeId { get; set; }
        public virtual Grades.GradeValue ObtainedGrade { get; set; }

        public bool? IsPercent { get; set; }
        public float? ObtainedMarks { get; set; }

        public DateTime? PostedDate { get; set; }

        public int? ExamSubjectExaminerId { get; set; }
        public virtual ExamSubjectExaminer ExamSubjectExaminer { get; set; }

        //------------------------- Marking End -----------------------//

        public bool? Void { get; set; }
    }
}
