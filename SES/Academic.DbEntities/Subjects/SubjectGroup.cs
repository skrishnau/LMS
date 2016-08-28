using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.Office;
using Academic.DbEntities.Structure;

//using System.ComponentModel

namespace Academic.DbEntities.Subjects
{
    /// <summary>
    /// Obsolete. Subject grouping is done either by 'Category' or 'SubjectStructure'
    /// . And its same as SubjectStructure
    /// </summary>
    [Obsolete]
    public class SubjectGroup
    {
        //[Key(), Column(Order=1)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int NoOfSubjects { get; set; }
        public string Desctiption { get; set; }

        //public int? LevelId { get; set; }
        //public int? FacultyId { get; set; }
        public int? ProgramId { get; set; }
        public int? YearId { get; set; }
        public int? SubYearId  { get; set; }

        //public virtual Level Level { get; set; }
        //public virtual Faculty Faculty { get; set; }
        public virtual Program Program { get; set; }
        public virtual Year Year { get; set; }
        public virtual SubYear SubYear { get; set; }

        //public int SchoolId { get; set; }
        //public virtual School School { get; set; }

        public bool? Void { get; set; }
        //public bool? IsActive { get; set; }

        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<SubjectGroupSubject> SubjectGroupSubjects { get; set; }
    }
}
