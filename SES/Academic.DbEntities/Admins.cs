using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities
{
    public class Admins
    {
        public int Id { get; set; }
        public int AcademicYearId { get; set; }
        public DateTime ChoosenDate { get; set; }
        public byte EstimatedEndTime { get; set; }//in year

        public int CEOId { get; set; }
        public int PrincipalId { get; set; }
        public int AdministratorId { get; set; }
        //public int Others { get; set; }

        public virtual AcademicYear AcademicYear { get; set; }

        //public virtual Users CEO { get; set; }
        //public virtual Users Principal { get; set; }
        //public virtual Users Administrator { get; set; }

    }
}
