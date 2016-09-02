using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.Office;

namespace Academic.DbEntities.Exams
{
    public class ExamType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //public string PublicNotice { get; set; }

        public bool IsPercent { get; set; }
        public float? WeightPercent { get; set; }
        public float? WeightMarks { get; set; }

        public bool? Void { get; set; }


        public int SchoolId { get; set; }
        public virtual School School { get; set; }

        /// <summary>
        /// It gives exams like: all 1st terminal, all 2nd terminal, etc.
        /// </summary>
        public virtual ICollection<Exam> Exams { get; set; }

    }
}
