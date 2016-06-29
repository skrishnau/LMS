using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.User;

namespace Academic.DbEntities.Exams
{
    public class ExamStudent
    {
        public int Id { get; set; }

        public int ExamSubjectId { get; set; }
        public int StudentClassId { get; set; }

        public virtual ExamSubject ExamSubject { get; set; }
        public virtual AcacemicPlacements.StudentClass StudentClass { get; set; }


        public float ObtainedMarksInPercent { get; set; }
        public string ObtainedMarksInGrade { get; set; }

        public DateTime? PostedDate { get; set; }
        public int PostedById { get; set; }

        public virtual Users PostedBy { get; set; }


    }
}
