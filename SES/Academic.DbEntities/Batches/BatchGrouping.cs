using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Batches
{
    public class BatchGrouping : Group.StudentGrouping
    {
        public int BatchId { get; set; }
        public virtual Batch Batch { get; set; }
    }
}
