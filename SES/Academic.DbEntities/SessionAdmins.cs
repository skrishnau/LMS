using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities
{
    public class SessionAdmins
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public int UserId { get; set; }
        public int TitleId { get; set; }
        public string Task { get; set; }

        public AdminTitle Title { get; set; }

        public virtual Session Session { get; set; }

    }
}
