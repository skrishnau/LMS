using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Class
{
    //Used
    public class UserClass
    {
        public int Id { get; set; }

        //SubjectClassId is required by both Regular and non-regular classes
        public int SubjectClassId { get; set; }
        public virtual Class.SubjectClass SubjectClass { get; set; }

        ////NOTE: if IsRegular= true then this class is from regualar subjects
        ////so we have to get students from StudentBatch table
        //public bool? IsRegular { get; set; }
        //public int? StudentBatchId { get; set; }
        //public virtual Batches.StudentBatch StudentBatch { get; set; }

        //Note: if IsRegular = true then this class is from irregular subjects
        //so we have to get users from Users table
        public int? UserId { get; set; }
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
        /// This is needed for only non-regular classes
        /// will be in days:: 0=unlimited, 1 day, 2 days, 3 days ... unlimited
        /// </summary>
        public int EnrollmentDuration { get; set; }

        //if the user/student is suspended from class
        public bool? Suspended { get; set; }

        //Its not required by the regular class, since regualar class students are grouped globally
        //This is the gorup id that this user belongs to 
        //if UseDefaultGrouping is true in SubjectSession then its value is null

        //public int? SubjectUserGroupId { get; set; }
        //public virtual Subjects.SubjectUserGroup SubjectUserGroup { get; set; }
        public virtual ICollection<UserClassGrouping> UserClassGroupings { get; set; }

        public virtual ICollection<ActivityAndResource.AssignmentItems.AssignmentSubmissions> AssignmentSubmissions { get; set; }
    }
}
