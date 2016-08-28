using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.AcacemicPlacements
{
    /// <summary>
    /// Obsolete. It will be used in another way, in the module Subject (not in this module)
    /// </summary>
    [Obsolete]
    public class StudentsOpinionAboutSubject
    {
        public int Id { get; set; }
        public int SubjectSubscriptionId { get; set; }

        public virtual SubjectSubscription SubjectSubscription { get; set; }
        public byte? Rating { get; set; }
        public string Opinion { get; set; }
    }
}
