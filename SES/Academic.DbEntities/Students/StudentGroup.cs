using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.Office;

namespace Academic.DbEntities.Students
{
    public class StudentGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int? SchoolId { get; set; }


        public int? ParentId { get; set; }
        public virtual StudentGroup Parent { get; set; }

        //public int AcademicYearId { get; set; }
        //public int? SessionId { get; set; }

        //public virtual AcademicYear AcademicYear { get; set; }
        //public virtual Session Session { get; set; }

        public bool? IsActive { get; set; }
        public bool? Void { get; set; }

        /// <summary>
        /// Its an indication if the student group is included in StudentClass table at least once
        /// </summary>
        public bool? StartedStudying { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual School School { get; set; }

        public virtual ICollection<StudentGroupStudent> StudentGroupStudents { get; set; }
        public virtual ICollection<Activities.Study> Study { get; set; }

        public bool? IsFromBatch { get; set; }
        public int? ProgramBatchId { get; set; }
        public virtual Batches.ProgramBatch ProgramBatch { get; set; }

        public string NameFromBatch
        {
            get
            {
                if (ProgramBatch != null)
                {
                    var batch = ProgramBatch.Batch;
                    var program = ProgramBatch.Program;
                    if (batch != null && program != null)
                    {
                        return batch.Name + "-" + program.Name;
                    }
                }
                return "";
            }
        }
    }
}
