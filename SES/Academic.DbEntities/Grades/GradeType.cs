using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Grades
{
    public class GradeType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// to show in tool tip
        /// </summary>
        public string Description { get; set; }

        

        /// <summary>
        /// Range or Value, in range--> max and min values are present 
        /// in Values --> gradeValues table contain data (values)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// For 'Values' type, PercentOrPosition states whether the equivlent value will be in 
        /// Percent or Postion: Percent--> >= given value, position: rank
        /// </summary>
        public bool? GradeValueIsInPercentOrPostition { get; set; }

        public float? TotalMaxValue { get; set; }
        public float? TotalMinValue { get; set; }
        public float? MinimumPassValue { get; set; }


        public int? SchoolId { get; set; }
        public virtual DbEntities.Office.School School { get; set; }

    }
}
