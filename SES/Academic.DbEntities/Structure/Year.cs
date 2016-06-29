using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Structure
{
    public class Year
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int Position { get; set; }

        public string Description { get; set; }

        public int ProgramId { get; set; }

        public virtual Program Program { get; set; }
        public virtual ICollection<SubYear> SubYears { get; set; }

        public virtual ICollection<Subjects.SubjectGroup> SubjectGroups { get; set; }


        public bool? IsActive { get; set; }
        public bool? Void { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
