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

        public bool Check { get; set; }
    }
}
