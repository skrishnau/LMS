using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Class
{
    public class UserClassGrouping
    {
        public int Id { get; set; }

        public int UserClassId { get; set; }
        public virtual UserClass UserClass { get; set; }

        public int GroupingId { get; set; }
        public virtual SubjectClassGrouping Grouping{ get; set; }
    }
}
