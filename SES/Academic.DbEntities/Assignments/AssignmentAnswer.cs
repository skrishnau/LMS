using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Assignments
{
    public class AssignmentAnswer
    {
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public int StudentId { get; set; }
        public int? StudentGroupId { get; set; }

        public string Answer { get; set; }
        //public string Remarks { get; set; }

        public virtual Assignment Assignment { get; set; }
        public virtual DbEntities.Students.Student Student { get; set; }

        public virtual ICollection<AssignmentAnswerFile> Files { get; set; }
    }
}
