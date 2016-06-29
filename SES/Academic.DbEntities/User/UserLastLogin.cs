using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.User
{
    public class UserLastLogin
    {
        public int Id { get; set; }
        public int  UserId { get; set; }
        public string AccessedFrom { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime? LastLogoutTime { get; set; }

        public virtual User.Users User { get; set; }
    }
}
