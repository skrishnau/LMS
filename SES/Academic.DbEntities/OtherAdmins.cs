
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities
{
    public class OtherAdmins
    {
        public int Id { get; set; }
        public int AdminsId { get; set; }
        public int UserId { get; set; }
        public string Position { get; set; }
        public string Task { get; set; }

        //foreign
        public virtual Admins Admins { get; set; }
        //public Users User { get; set; }
    }
}
