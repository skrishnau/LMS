using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.SystemModules
{
    public class Module
    {
        public int Id { get; set; }
        public string ModuleName { get; set; }
        //public byte Priority { get; set; }
        public string ModuleDirectory { get; set; }

        public int? ParentModuleId { get; set; }
        public virtual Module ParentModule { get; set; }

        public virtual ICollection<ModuleAccess> ModuleAccess { get; set; }
    }
}
