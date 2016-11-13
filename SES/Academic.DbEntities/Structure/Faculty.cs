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

        public String Description { get; set; }

        public int LevelId { get; set; }
        public virtual Level Level { get; set; }

        public bool? Void { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<Program> Programs { get; set; }
    }
}
