using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Exams
{
    public class ExamSubject
    {
        public int Id { get; set; }

        public int SubjectClassId { get; set; }

        public int ExamId { get; set; }
        public int? ExamSubTypeId { get; set; }

        public int FullMarks { get; set; }
        public int PassMarks { get; set; }
        /// <summary>
        /// Hours and minutes are the Time period of exam
        /// </summary>
        public DateTime? SubjectExamDate { get; set; }
        public TimeSpan StartTime { get; set; }

        public byte Hours { get; set; }
        public byte? Minutes { get; set; }


        public float? WeightPercent { get; set; }

        public virtual Academic.DbEntities.AcacemicPlacements.SubjectClass SubjectClass { get; set; }

        public virtual Exam Exam { get; set; }
        public virtual ExamSubType ExamSubType { get; set; }

        public virtual  ICollection<ExamStudent>  ExamStudents { get; set; }
        public virtual ICollection<ExamSubjectTeacher> ExamSubjectTeachers { get; set; }


        /*
        public bool IsLab { get; set; }
        public bool IsTheory { get; set; }
        public bool IsPractical { get; set; }
        public bool IsProject { get; set; }
        */
    }
}
