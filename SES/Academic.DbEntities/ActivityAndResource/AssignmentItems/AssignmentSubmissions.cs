using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.Class;

namespace Academic.DbEntities.ActivityAndResource.AssignmentItems
{
    public class AssignmentSubmissions
    {
        public int Id { get; set; }
        public string SubmissionText { get; set; }

        public DateTime SubmittedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        
        public int UserClassId { get; set; }
        public virtual UserClass UserClass { get; set; }

        public int AssignmentId { get; set; }
        public virtual ActivityAndResource.Assignment Assignment { get; set; }

        public virtual ICollection<AssignmentSubmissionFiles> AssignmentSubmissionFiles { get; set; }
    }
}
