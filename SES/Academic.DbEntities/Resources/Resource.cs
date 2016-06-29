using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Resources
{
    public class Resource
    {
        public int Id { get; set; }
        [Required()]
        public string Name { get; set; }
        public int SubjectId { get; set; }
        public int OwnerId { get; set; }
        public int AccessPermissionId { get; set; }


        //next version
        //public bool RequiresPassword { get; set; }
        //public string Password { get; set; }


        public string Category { get; set; }//may be linked to ResourcesCategory table
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }

        public virtual ICollection<ResourceFile> Files { get; set; }
        public virtual ICollection<Links> Links { get; set; }
        public virtual ICollection<Assignments.Assignment> Assignments { get; set; }

        public string Note { get; set; }
    }
}
