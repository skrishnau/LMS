using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Libraries
{
    public class BookAuthor
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }

        public string AssociatedUniversity { get; set; }

        public int BookId { get; set; }
        public virtual TextBook Book { get; set; }
    }
}
