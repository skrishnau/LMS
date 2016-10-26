using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.ActivityAndResource.AssignmentItems
{
    public class AssignmentSubmissionFiles
    {
        public int Id { get; set; }

        public int AssignmentSubmissionsId { get; set; }
        public virtual AssignmentSubmissions AssignmentSubmissions { get; set; }

        public int UserFileId { get; set; }
        public virtual UserFile UserFile { get; set; }

        public DateTime FileSubmittedDate { get; set; }



    }
}
