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

        //for regular
        public int StudentClassId { get; set; }
        public virtual Class.UserClass StudentClass { get; set; }


        public float ObtainedMarksInPercent { get; set; }
        public string ObtainedMarksInGrade { get; set; }

        public DateTime? PostedDate { get; set; }
        public int PostedById { get; set; }

        public virtual Users PostedBy { get; set; }


    }
}
