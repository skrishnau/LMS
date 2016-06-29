using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Structure
{
    public class Faculty
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int LevelId { get; set; }
        //public int FacultyCategoryId { get; set; }

        public String Description { get; set; }

        //public virtual FacultyCategory FacultyCategory { get; set; }
        public virtual Level Level { get; set; }
        public virtual ICollection<Program> Programs { get; set; }

        public bool? Void { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}
