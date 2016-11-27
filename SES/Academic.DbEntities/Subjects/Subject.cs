using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Academic.DbEntities.Activities;
using Academic.DbEntities.Office;
using Academic.DbEntities.Structure;
//using Academic.DbEntities.Subjects.Detail;

namespace Academic.DbEntities.Subjects
{

    public class Subject
    {
        public int Id { get; set; }

        /// <summary>
        /// It is FullName
        /// </summary>
        public string FullName { get; set; }

        public string ShortName { get; set; }

        public string Summary { get; set; }

        public int Credit { get; set; }
        //enrolment methods in subject 
        //================????? ============================//
        //Enrolmment method

        public string Code { get; set; }
        //public byte? Credit { get; set; }


        public int SubjectCategoryId { get; set; }
        public virtual SubjectCategory SubjectCategory { get; set; }

        //public short? CompletionHours { get; set; }

        //public int? FullMarks { get; set; }
        //public byte? PassPercentage { get; set; }

        //public bool? IsActive { get; set; }
        public bool? Void { get; set; }//void if this course is no longer in use.


        //public int PassMarks { get; set; }
        //not needed
        //public byte InternalPercent { get; set; }//not needed
        //public byte ExternalPercent { get; set; }//not needed

        //public bool? HasLab { get; set; }
        //public bool? HasTheory { get; set; }
        //public bool? HasProject { get; set; }
        //public bool? HasTutorial { get; set; }

        //public bool? IsElective { get; set; }
        //public bool? IsOutOfSyllabus { get; set; }

        public DateTime CreatedDate { get; set; }
        public int CreatedById { get; set; }
        //public bool? Vocational { get; set; }

        //public virtual ICollection<SubjectGroupSubject> SubjectGroupSubjects { get; set; }

        //public virtual ICollection<Activities.Teach> Teach { get; set; }
        //public virtual ICollection<Exams.Exam> Exams { get; set; }

        public virtual ICollection<SubjectSection> SubjectSections { get; set; }



    }
}
