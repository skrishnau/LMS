using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Exams
{
    //used
    /// <summary>
    /// Only Examiner is allowed to enter marks of students for 'the' ExamSubject 
    /// </summary>
    public class ExamSubjectExaminer
    {

        public int Id { get; set; }

        public int ExamSubjectId { get; set; }
        public virtual Exams.ExamSubject ExamSubject { get; set; }

        public int ExaminerId { get; set; }
        public virtual User.Users Examiner { get; set; }

    }
}
