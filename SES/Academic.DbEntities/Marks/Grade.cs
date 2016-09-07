using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Marks
{
    //used
    public class Grade
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// this & above this mark is considered to be in this grade
        /// </summary>
        public float? EquivalentPercent { get; set; }
    }
}
