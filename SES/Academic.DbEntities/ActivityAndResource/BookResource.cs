using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.AccessPermission;
using Academic.DbEntities.ActivityAndResource.BookItems;

namespace Academic.DbEntities.ActivityAndResource
{
    public class BookResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool DisplayDescriptionOnCourePage { get; set; }

        //Appearance


        /// <summary>
        /// 0-none, 1-Numbers, 2-bullets, 3-indented
        /// </summary>

        public byte ChapterFormatting { get; set; }

        /// <summary>
        /// 0-TOC only, 1-Images, 2-Text
        /// </summary>
        public byte StyleOfNavigation { get; set; }

        public bool CustomTitles { get; set; }

        public virtual ICollection<BookChapter> Chapters { get; set; }

        //public int ActivityResourceId { get; set; }
        //public virtual ActivityResource ActivityResource { get; set; }


    }
}
