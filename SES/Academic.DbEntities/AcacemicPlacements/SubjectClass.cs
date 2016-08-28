using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.AcacemicPlacements
{
    /// <summary>
    /// Obsolete. It links Subjects to the Running Class. 
    /// But this is already done by SubjectSession (or Subject Class
    /// --> one of them as the name might change as per confort of use)
    /// 
    /// </summary>
    [Obsolete]
    public class SubjectClass
    {
        public int Id { get; set; }

        public int SubjectId { get; set; }
        public virtual Subjects.Subject Subject { get; set; }


        public int? SubjectGroupId { get; set; }
        public virtual Subjects.SubjectGroup SubjectGroup { get; set; }

        public int RunningClassId { get; set; }
        public virtual RunningClass RunningClass { get; set; }

        public bool? NotSubscribale { get; set; }
        public bool? SubscriptionPermissionRequired { get; set; }//from teacher
        //is it optional to avoid the subject or requires compulsion subscription
        public bool? SubscriptionOptional { get; set; } //subscribe garnu naparne
        public bool? Void { get; set; }


        public virtual ICollection<SubjectSubscription> SubjectSubscriptions { get; set; }
    }
}
