using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.ActivityAndResource
{
    /// <summary>
    /// It stores the class and Activity_Resource, so as to define the class only for which the activity
    /// is published.
    /// </summary>
    public class ActivityClass
    {
        public int Id { get; set; }

        public int ActivityResourceId { get; set; }
        public virtual ActivityResource ActivityResource { get; set; }

        public int SubjectClassId { get; set; }
        public virtual Class.SubjectClass SubjectClass { get; set; }

        public virtual ICollection<ActivityResourceView> ActivityResourceViews { get; set; }

    }
}
