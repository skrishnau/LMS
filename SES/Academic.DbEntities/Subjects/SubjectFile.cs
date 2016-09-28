using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Subjects
{
    public class SubjectFile:UserFile
    {
        public int? SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

    }
}
