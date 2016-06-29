using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.User
{
    public class Nation
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Nationality { get; set; }
        public string NationShortName { get; set; }
    }
}
