using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.ViewModel.Resources
{
    public class ResourceViewModel
    {
        public int Id { get; set; }
       [Required]
        public string Name { get; set; }
        public int SubjectId { get; set; }
        public int OwnerId { get; set; }
        public int AccessPermissionId { get; set; }

        //next version
        //public bool RequiresPassword { get; set; }
        //public string Password { get; set; }


        public string Category { get; set; }//may be linked to ResourcesCategory table
        public DateTime CreatedDate { get; set; }
        //public DateTime ModifiedDate { get; set; }
        //public int ModifiedBy { get; set; }

        public virtual ResourceFileViewModel File1 { get; set; }
        public virtual ResourceFileViewModel File2 { get; set; }
        public virtual ResourceFileViewModel File3 { get; set; }
        //public virtual ICollection<ResourceFileViewModel> Files { get; set; }
        public virtual String Links { get; set; }
        //public virtual ICollection<Assignments.Assignment> Assignments { get; set; }

        public string Note { get; set; }
    }
}
