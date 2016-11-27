using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.Structure;

namespace Academic.DbEntities.Subjects
{
    ///// <summary>
    ///// Obsolete. Since link between Subject and Year/Subyear is done by
    ///// SubjectStructure class.
    ///// </summary>
    //[Obsolete]
    //public class RegularSubject
    //{
    //    public int Id { get; set; }

    //    //subject part
    //    public int SubjectId { get; set; }
    //    public virtual Subject Subject { get; set; }


    //    //structrue mapping part
    //    //public int ProgramId { get; set; }
    //    public int YearId { get; set; }
    //    public int? SubYearId { get; set; }

    //    //public virtual Program Program { get; set; }
    //    public virtual Year Year { get; set; }
    //    public virtual SubYear SubYear { get; set; }

    //    public DateTime? AssignedDate { get; set; }
    //    public bool? Void { get; set; }
    //}
}
