using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Libraries
{
    public class BookCategory
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public bool IsActive { get; set; }
        public int LibraryId { get; set; }

        public virtual Library Library { get; set; }

        public virtual ICollection<Book> Books { get; set; }

    }
}
