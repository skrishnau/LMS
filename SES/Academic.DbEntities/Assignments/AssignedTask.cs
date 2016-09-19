using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Assignments
{
    public class AssignedTask
    {
        public int Id { get; set; }
        public int TeachId { get; set; }
        public int AssignmentId { get; set; }
        public DateTime AssignedDate { get; set; }
        public String DueDate { get; set; }
        public string Remarks { get; set; }
        public int SessionId { get; set; }
        public bool CarriesMarks { get; set; }
        public short? TotalMarks { get; set; }
        public short? PassMarks { get; set; }

        public virtual Activities.Teach Teach { get; set; }
        public virtual ActivityAndResource.Assignment Assignment { get; set; }
        public virtual Session Session { get; set; }
    }
}
