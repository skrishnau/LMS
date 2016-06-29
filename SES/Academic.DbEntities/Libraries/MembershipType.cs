using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Libraries
{
    public class MembershipType
    {
        public int id { get; set; }
        public int LibraryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MemberShip> MemberShips { get; set; }
    }
}
