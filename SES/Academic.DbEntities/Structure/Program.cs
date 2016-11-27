using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.Batches;

namespace Academic.DbEntities.Structure
{
    public class Program
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public String Description { get; set; }

        //public int FacultyId { get; set; }
        //public virtual Faculty Faculty { get; set; }

        public int SchoolId { get; set; }
        public virtual Office.School School { get; set; }


        public bool? Void { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<Year> Year { get; set; }
        public virtual ICollection<ProgramBatch> ProgramBatches { get; set; }

    }
}
