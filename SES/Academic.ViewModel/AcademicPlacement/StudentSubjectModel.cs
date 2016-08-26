using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.ViewModel.AcademicPlacement
{
    //previous class name = StudentSubjectModel
    [Serializable]
    public class StudentSubjectModel
    {
        public int StudentId { get; set; }
        public int AcademicYearId { get; set; }

        public int SubjectId { get; set; }

        //subjectclassId
        public int UserClassId { get; set; }
        public int SubjectClassId { get; set; }
        public int SubjectSubscriptionId { get; set; }

        public string SubjectName { get; set; }
        public string SubjectGroupName { get; set; }

        public string Year { get; set; }
        public string SubYear { get; set; }

        public bool Permitted { get; set; }

        public bool NotSubscribable { get; set; }

        public bool Complete { get; set; }
        public bool Suspended { get; set; }
        public bool Void { get; set; }
        public bool Subscribed { get; set; }
        public bool SubscriptionPermissionRequired { get; set; }//from teacher//subscribe garna milne ki namilne
        //is it optional to avoid the subject or requires compulsion subscription
        public bool SubscriptionOptional { get; set; } //doesn't need to subscribe
        public bool Active { get; set; }

        public List<DbEntities.Teachers.Teacher> Teachers { get; set; }
    }
}
