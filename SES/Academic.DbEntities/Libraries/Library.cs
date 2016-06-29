using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Libraries
{
    public class Library
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public String Name { get; set; }
        public String Location { get; set; }
        public string Telephone { get; set; }

        public bool IsActive { get; set; }

        public int ChiefId { get; set; }
    }
}
