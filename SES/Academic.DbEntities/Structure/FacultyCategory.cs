using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Structure
{
    public class FacultyCategory
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public virtual ICollection<Faculty> Faculties { get; set; }

        public bool? IsActive { get; set; }
        public bool? Void { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
