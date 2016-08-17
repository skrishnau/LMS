using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.Structure;

namespace Academic.DbEntities.Batches
{
    /// <summary>
    /// Its same as Student Group for regular classes
    /// </summary>
    public class ProgramBatch
    {
        public int Id { get; set; }

        public int BatchId { get; set; }
        public int ProgramId { get; set; }
      
        public bool? Void { get; set; }

        public virtual Batch Batch { get; set; }
        public virtual Program Program { get; set; }

        public int? CurrentYearId { get; set; }
        public int? CurrentSubYearId { get; set; }

        public virtual Year CurrentYear { get; set; }
        public virtual SubYear  CurrentSubYear{ get; set; }
         

        public bool? StartedStudying { get; set; }// new or already started studying
        public bool? StudyCompleted { get; set; }


        public string NameFromBatch
        {
            get
            {
                if (this.Batch != null && this.Program!=null)
                {
                    
                        return Batch.Name + "-" + Program.Name;
                }
                return "";
            }
        }

    }
}
