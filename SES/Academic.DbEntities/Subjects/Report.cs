using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.Class;

namespace Academic.DbEntities.Subjects
{
    public class Report
    {
        public int Id { get; set; }

        public bool ShowImage { get; set; }
        public bool ShowName { get; set; }
        public bool ShowCRN { get; set; }
        public bool ShowTotal { get; set; }

        public string ShowActivityResourceIds { get; set; }

        public int SubjectClassId { get; set; }
        public virtual SubjectClass SubjectClass { get; set; }

    }
}
