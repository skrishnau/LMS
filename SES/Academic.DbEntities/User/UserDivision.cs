using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.User
{
    public class UserDivision
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        public int DivisionId { get; set; }
        public DateTime AssignDate { get; set; }
        public bool? Void { get; set; }

        public virtual Users Users { get; set; }
        public virtual Division Division { get; set; }

    }
}
