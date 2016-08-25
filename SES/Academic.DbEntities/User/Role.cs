using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.Office;

namespace Academic.DbEntities.User
{
    public class Role
    {
        public int Id { get; set; }

        [Required]
        public string DisplayName { get; set; }

        [Required]
        public string RoleName { get; set; }



        public int? SchoolId { get; set; }
        public virtual School School { get; set; }

        public string Description { get; set; }

        //next version
        //public string ShortName { get; set; }

        //public bool IsActive { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }

        public virtual ICollection<RoleCapability> RoleCapabilities { get; set; }

        //delete garyo bhane void hunxa
        public bool? Void { get; set; }
    }
}
