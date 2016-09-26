using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.ActivityAndResource.BookItems
{
    public class BookChapter
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        //position of chapter within its parent
        public int Position { get; set; }

        public int BookId { get; set; }
        public virtual BookResource Book { get; set; }

        public int? ParentChapterId { get; set; }
        public virtual BookChapter ParentChapter { get; set; }
    }
}
