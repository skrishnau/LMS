using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.ViewModel.Batch
{
    [Serializable]
    public class BatchViewModel
    {
        public int ProgramId { get; set; }
        public int ProgramBatchId { get; set; }

        public int BatchId { get; set; }
        public int RefId { get; set; }

        public string BatchName { get; set; }
        public string ProgramName { get; set; }
        public string ProgramBatchName { get; set; }

        public bool Check { get; set; }
    }
}
