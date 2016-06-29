using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Structure
{
    public class SubYear
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public string Description { get; set; }

        public int Position { get; set; }

        public int? ParentId { get; set; }
        public virtual SubYear Parent { get; set; }

        //public int LevelId { get; set; }
        //public int? FacultyId { get; set; }
        //public int? ProgramId { get; set; }
        public int? YearId { get; set; }

        public virtual Year Year { get; set; }

        public bool? IsActive { get; set; }
        public bool? Void { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}
