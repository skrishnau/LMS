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

        public int ExamOfClassId { get; set; }
        public virtual ExamOfClass ExamOfClass { get; set; }

        //indicates whether the setting is used from ExamOfClass or it has its own setting
        public bool SettingsUsedFromExam { get; set; }

        //these four parameters are used to store settings of this class
        //if SettingsUsedFromExam = true then these four values are null
        public bool? IsPercent { get; set; }
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

        public bool? Void { get; set; }

        public virtual  ICollection<ExamStudent>  ExamStudents { get; set; }
        public virtual ICollection<ExamSubjectExaminer> ExamSubjectExaminers { get; set; }

        /*
        public bool IsLab { get; set; }
        public bool IsTheory { get; set; }
        public bool IsPractical { get; set; }
        public bool IsProject { get; set; }
        */
    }
}
