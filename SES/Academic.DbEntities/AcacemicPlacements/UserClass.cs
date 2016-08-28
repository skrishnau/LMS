using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.AcacemicPlacements
{
    /// <summary>
    /// Obsolete. Since link between User and Subject Class is done by 
    /// SubjectSessionUser(or SubjectClassUser)
    /// </summary>
    [Obsolete]
    public class UserClass
    {

        public int Id { get; set; }

        //public int RegularSubjectClassId { get; set; }
        //public virtual RegularSubjectClass RegularSubjectClass { get; set; }

        public int SubjectClassId { get; set; }
        public virtual SubjectClass SubjectClass { get; set; }

        public int UserId { get; set; }
        public virtual User.Users User { get; set; }

        public bool? Void { get; set; }

        public DateTime? JoinedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? LeftDate { get; set; }

    }
}
