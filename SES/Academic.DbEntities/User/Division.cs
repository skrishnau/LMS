using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.Office;

namespace Academic.DbEntities.User
{
    public class Division
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentDivisionId { get; set; }//subdivision
        public int? SchoolId { get; set; }

        public bool? Void { get; set; }

        public virtual  School School { get; set; }
        public virtual  Division ParentDivision{ get; set; }
        public virtual ICollection<UserDivision> UserDivisions { get; set; }

    }
}
