using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.SystemModules
{
    public class ModuleAccess
    {
        public int Id { get; set; }

        public int SchoolId { get; set; }

        /// <summary>
        /// 0: none, 1: View only, 2:  Edit and view , 4: both , 
        /// </summary>
        public byte PermissionType { get; set; }

        public int ModuleId { get; set; }
        public virtual Module Module { get; set; }

        public int RoleId { get; set; }
        public virtual User.Role Role { get; set; }
    }
}
