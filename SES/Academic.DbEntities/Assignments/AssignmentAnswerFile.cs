using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Assignments
{
    public class AssignmentAnswerFile
    {
        public int Id { get; set; }
        public int AssignmentAnswerId { get; set; }
        public int FileId { get; set; }

        public virtual AssignmentAnswer AssignmentAnswer { get; set; }


    }
}
