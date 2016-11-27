using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Grades
{
    public class GradeValue
    {
        public int Id { get; set; }
        public string Value { get; set; }


        public bool? IsFailGrade { get; set; }

        public int GradeId { get; set; }
        public virtual Grade Grade { get; set; }

        /// <summary>
        /// this & above this mark is considered to be in this grade
        /// </summary>
        public float? EquivalentPercentOrPostition { get; set; }

        //public int? Postition { get; set; }


    }
}
