using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Marks
{
    public class AssignmentMarks
    {
        public int Id { get; set; }
        public int AssignedTaskId { get; set; }
        public int StudentId { get; set; }
        public float Marks { get; set; }

        public bool IsGradeSystem { get; set; }
        public int GradeId { get; set; }

        //public virtual Assignments.AssignedTask AssignedTask { get; set; }
        public virtual Students.Student Student { get; set; }
        public virtual Grade Grade { get; set; }

    }

}
