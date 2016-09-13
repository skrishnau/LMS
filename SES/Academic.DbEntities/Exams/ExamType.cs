using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.Marks;
using Academic.DbEntities.Office;

namespace Academic.DbEntities.Exams
{
    //used
    public class ExamType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //public string PublicNotice { get; set; }

        //these four values can be changed for each subject
        //public bool IsGradingSystem { get; set; }

        public bool IsPercent { get; set; }
        public float? Weight { get; set; }



        public int? FullMarks { get; set; }
        public int? PassMarks { get; set; }
        //end

        public bool? Void { get; set; }


        public int SchoolId { get; set; }
        public virtual School School { get; set; }

        public string Notice { get; set; }
        /// <summary>
        /// It gives exams like: all 1st terminal, all 2nd terminal, etc.
        /// </summary>
        public virtual ICollection<Exam> Exams { get; set; }

    }
}
