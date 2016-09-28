using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.ActivityAndResource.FileItems
{
    public class FileResourceFiles
    {
        public int Id { get; set; }
        public int FileResourceId { get; set; }
        public virtual  FileResource FileResource { get; set; }

        //this is file id
        //public int FileId { get; set; }
        //public virtual UserFile File { get; set; }

        public int SubFileId { get; set; }
        public virtual Subjects.SubjectFile SubFile { get; set; }
    }
}
