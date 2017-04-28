using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Class
{
    /// <summary>
    /// Its inner grouping -- i.e. for a class the inner group would be Group A and group B
    /// </summary>
    public class SubjectClassGrouping : Group.StudentGrouping
    {
        public int SubjectClassId { get; set; }
        public virtual Class.SubjectClass SubjectClass { get; set; }

        public virtual ICollection<UserClassGrouping> UserClassGroupings { get; set; }
    }
}
