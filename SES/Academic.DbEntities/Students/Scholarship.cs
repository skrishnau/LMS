using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Students
{
    public class Scholarship
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public float ScholarshipPercent { get; set; }
        public DateTime ProvidedDate { get; set; }
        public DateTime? EndingDate { get; set; }

        public int AcademicYearId { get; set; }
        public int? SessionId { get; set; }

        public double InitialFee { get; set; }
        public double FinalFee { get; set; }

        public string Remarks { get; set; }
        //public int? CourseId { get; set; }
    }
}
