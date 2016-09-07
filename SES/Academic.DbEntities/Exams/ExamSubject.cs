using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.Marks;

namespace Academic.DbEntities.Exams
{
    //used after github
    public class ExamSubject
    {
        public int Id { get; set; }

        public int SubjectClassId { get; set; }
        public virtual Academic.DbEntities.Class.SubjectClass SubjectClass { get; set; }

        public int ExamId { get; set; }
        public virtual Exam Exam { get; set; }

        //public bool IsGradingSystem { get; set; }
        //public int? GradeId { get; set; }
        //public virtual Grade Grade { get; set; }
        public bool IsPercent { get; set; }
        public float? Weight { get; set; }

        public int? FullMarks { get; set; }
        public int? PassMarks { get; set; }
        /// <summary>
        /// Hours and minutes are the Time period of exam
        /// </summary>
        public DateTime? SubjectExamDate { get; set; }

        /// <summary>
        /// In 24 hour format
        /// </summary>
        public string Time { get; set; }

        public virtual  ICollection<ExamStudent>  ExamStudents { get; set; }
        public virtual ICollection<ExamSubjectExaminer> ExamSubjectTeachers { get; set; }


        /*
        public bool IsLab { get; set; }
        public bool IsTheory { get; set; }
        public bool IsPractical { get; set; }
        public bool IsProject { get; set; }
        */
    }
}
