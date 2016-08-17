using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Resources
{
    public class ResourceFile : DbEntities.UserFile
    {
        public int? SubjectId { get; set; }
        
        public int OwnerId { get; set; }

        //next version
        //public int FileCategoryId { get; set; }
        //public virtual FileCategory FileCategory { get; set; }
       // public virtual Subjects.Subject Subject { get; set; }
        public virtual Teachers.Teacher Owner { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }


    }
}
