using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Class
{
    //Used
    public class SubjectSessionUser
    {
        public int Id { get; set; }

        public int SubjectSessionId { get; set; }
        public virtual Class.SubjectSession SubjectSession { get; set; }
        
        public int UserId { get; set; }
        public virtual User.Users User { get; set; }

        public int? RoleId { get; set; }
        public virtual User.Role Role { get; set; }

        public bool? Void { get; set; }

        public DateTime JoinedDate { get; set; }
        public DateTime? WithdrawDate { get; set; }

        //This is the gorup id that this user belongs to 
        //if UseDefaultGrouping is true in SubjectSession then its value is null
        public int? SubjectUserGroupId { get; set; }
        public virtual Subjects.SubjectUserGroup SubjectUserGroup { get; set; }
    }
}
