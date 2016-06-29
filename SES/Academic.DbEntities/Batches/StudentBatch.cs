using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Batches
{
    public class StudentBatch
    {
        public int Id { get; set; }
        public int ProgramBatchId { get; set; }
        public int StudentId { get; set; }

        public virtual ProgramBatch ProgramBatch { get; set; }
        public virtual Students.Student Student{ get; set; }

        public bool? InActive { get; set; }
        /// <summary>
        /// if void then the student is not considered to be in this programBatch
        /// </summary>
        public bool? Void { get; set; }

        public DateTime AddedDate { get; set; }
    }
}
