using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Libraries
{
    public class TextBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Publication { get; set; }
        public string ISBN { get; set; }
        //public string IsTextBook { get; set; }

        //public int LibraryId { get; set; }
        public string BookCode { get; set; }

        public string Edition { get; set; }

        //public int BookCategoryId { get; set; }
        //public int BookReturnCategoryId { get; set; }
        //public string CategoryOfUsefulness { get; set; }

        public float Price { get; set; }

        public int SubjectId { get; set; }
        public virtual Subjects.Subject Subject { get; set; }

        //public virtual BookCategory BookCategory { get; set; }
        //public virtual BookReturnCategory BookReturnCategory { get; set; }
        //public virtual Library Library { get; set; }
        //public virtual ICollection<BookCategory> BookCategories { get; set; }

        public bool? Void { get; set; }
    }
}
