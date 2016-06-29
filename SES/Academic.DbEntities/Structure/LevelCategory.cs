using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Structure
{
    public class LevelCategory
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Rank { get; set; }

        public virtual ICollection<Level> Levels { get; set; }
    }
}
