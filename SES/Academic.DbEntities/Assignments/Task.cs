using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Assignments
{
    public class Task
    {
        public int Id { get; set; }
        //public string Name { get; set; }
        public string Question { get; set; }
        public string Hint { get; set; }
        public string Solution { get; set; }

        public int AssignmentId { get; set; }

        public virtual ActivityAndResource.Assignment Assignment { get; set; }
    }
}
