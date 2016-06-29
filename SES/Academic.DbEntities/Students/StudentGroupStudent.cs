using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Students
{
    public class StudentGroupStudent
    {
        public int Id { get; set; }
        public DateTime AssignedDate { get; set; }
        public int StudentId { get; set; }
        public int StudentGroupId { get; set; }

        public virtual Student  Student{ get; set; }
        public virtual StudentGroup StudentGroup { get; set; }

        public bool? Void { get; set; }

        public int? AssignedBy { get; set; }
        
    }
}
