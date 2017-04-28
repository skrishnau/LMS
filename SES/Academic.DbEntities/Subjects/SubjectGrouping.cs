using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Subjects
{
    /// <summary>
    /// Its inner grouping for a subject.. i.e. Group A and Group B
    /// </summary>
    public class SubjectGrouping : Group.StudentGrouping
    {
        public int SubjectId { get; set; }
        public virtual Subjects.Subject Subject { get; set; }
    }
}
