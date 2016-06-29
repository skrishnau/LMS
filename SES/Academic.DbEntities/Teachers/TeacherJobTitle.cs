using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.Office;

namespace Academic.DbEntities.Teachers
{
    public class TeacherJobTitle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int InstitutionId { get; set; }

        public virtual  Institution Institution { get; set; }
        //public decimal AverageSalary { get; set; }
    }
}
