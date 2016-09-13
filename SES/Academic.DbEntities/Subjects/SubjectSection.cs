using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.Resources;
using Academic.DbEntities.Subjects.Detail;

namespace Academic.DbEntities.Subjects
{
    public class SubjectSection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }

        public bool? ShowSummary { get; set; }

        /// <summary>
        /// Position in UI (webpage)
        /// </summary>
        public int Position { get; set; }

        public int SubjectId { get; set; }
        public virtual Subjects.Subject Subject { get; set; }
        
        public bool? Void { get; set; }


        public virtual ICollection<AccessPermission.Restriction> Restrictions{ get; set; }
        public virtual ICollection<SubjectActivityAndResource> SubjectActivityAndResource { get; set; }
        public virtual ICollection<Assignments.Assignment> Assignments { get; set; } 

    }
}
