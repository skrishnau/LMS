using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.User
{
    public class Relation
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsGuardian { get; set; }
    }
}
