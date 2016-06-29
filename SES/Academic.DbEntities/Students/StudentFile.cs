using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Students
{
    public class StudentFile : DbEntities.File
    {
        //public int Id { get; set; }
        //public string DisplayName { get; set; }
        //public string FileName { get; set; }
        //public string FileDirectory { get; set; }
        //public int? SubjectId { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public DateTime ModifiedDate { get; set; }
        //public int ModifiedBy { get; set; }
        //public bool IsTemporary { get; set; }
        /// <summary>
        /// Sent to Recycle bin.
        /// </summary>
        //public bool IsDeleted { get; set; }
        //public int AccessPermissionId { get; set; }
        /// <summary>
        /// Owner of the file
        /// </summary>
        public int StudentId { get; set; }
        public bool RequiresPassword { get; set; }
        public string Password { get; set; }

        //public virtual Subjects.Subject Subject { get; set; }//coz its nullable
        //public virtual AccessPermission AccessPermission { get; set; }
        public virtual Student Student { get; set; }

        public virtual ICollection<Resources.Resource> Resources { get; set; }


    }
}
