using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.AcacemicPlacements
{
    /// <summary>
    /// It is Obslete since both StudentClass and SubjectClass are obsolete and this class 
    /// is used to link those two.
    /// </summary>
    [Obsolete]
    public class SubjectSubscription
    {
        public int Id { get; set; }

        public int StudentClassId { get; set; }
        public int SubjectClassId { get; set; }


        public virtual StudentClass StudentClass { get; set; }
        public virtual SubjectClass SubjectClass { get; set; }

        //is student permitted to access  the course contents.

        public bool? Permitted { get; set; }
        public bool? Suspended { get; set; } // access by student to this subject

        public bool? Active { get; set; }

    }
}
