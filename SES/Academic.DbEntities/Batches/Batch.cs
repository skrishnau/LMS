using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.Office;

namespace Academic.DbEntities.Batches
{
    public class Batch
    {
        public int Id { get; set; }
        /// <summary>
        /// Display Name
        /// </summary>
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }   

        public DateTime? ClassCommenceDate { get; set; }

        public int SchoolId { get; set; }
        public School School { get; set; }

        public bool? Void { get; set; }

        public virtual ICollection<ProgramBatch> ProgramBatches { get; set; }

    }
}
