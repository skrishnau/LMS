using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.ViewModel.SystemControl.Office
{
    class OfficeViewModel
    {
    }

    public class SchoolViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int InstitutionId { get; set; }
        public Int32 SchoolTypeId { get; set; }
        public virtual InstitutionViewModel Institution { get; set; }
        // public virtual Branch Branch { get; set; }
        public virtual SchoolTypeViewModel SchoolType { get; set; }
    }

    public class InstitutionViewModel
    {
        
    }
    public class SchoolTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int InstitutionId { get; set; }
        public InstitutionViewModel Institution { get; set; }
    }
}
