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
        
        public DateTime CreatedDate { get; set; }
        // user enroll to the course start date
        public DateTime? StartDate { get; set; }
        //user enroll to the course end date
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// will be in days:: 0=unlimited, 1 day, 2 days, 3 days ... unlimited
        /// </summary>
        public int EnrollmentDuration { get; set; }

        public bool? Suspended { get; set; }

        //This is the gorup id that this user belongs to 
        //if UseDefaultGrouping is true in SubjectSession then its value is null
        public int? SubjectUserGroupId { get; set; }
        public virtual Subjects.SubjectUserGroup SubjectUserGroup { get; set; }
    }
}
