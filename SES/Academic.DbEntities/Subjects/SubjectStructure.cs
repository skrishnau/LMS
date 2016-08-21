using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.Structure;

namespace Academic.DbEntities.Subjects
{
    /// <summary>
    /// Used: its gives the subjects linked to each year/subyear
    /// Its just the setting part and is static 
    /// 
    /// </summary>
    public class SubjectStructure
    {
        //[Key(), Column(Order=1)]
        public int Id { get; set; }
        //public string Name { get; set; }
        //public string Description { get; set; }

        public int YearId { get; set; }
        public int? SubYearId { get; set; }

        public virtual Year Year { get; set; }
        public virtual SubYear SubYear { get; set; }

        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public bool? Obsolete { get; set; }

        public bool? Void { get; set; }

        public int CreatedBy { get; set; }
        public int? VoidBy { get; set; }
        public int? UpdatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? VoidDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public int? RemovedInAcademicYearId { get; set; }
        public int? LastActiveInAcademicYearId { get; set; }
        public int? WillNotBeActiveFromAcademicYearId { get; set; }

        public virtual AcademicYear RemovedInAcademicYear { get; set; }
        public virtual AcademicYear LastActiveInAcademicYear { get; set; }
        public virtual AcademicYear WillNotBeActiveFromAcademicYear { get; set; }

    }
}
