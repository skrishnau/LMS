using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Subjects
{
    /// <summary>
    /// since subject group is obsolete. its no use to link subject to subjectGroup
    /// </summary>
    [Obsolete]
   public class SubjectGroupSubject
    {
       public int Id { get; set; }
       public int SubjectId { get; set; }
       public int SubjectGroupId { get; set; }

       public virtual Subject Subject{ get; set; }
       public virtual SubjectGroup  SubjectGroup { get; set; }

       public DateTime? AssignedDate { get; set; }
       public bool? Void { get; set; }

    }
}
