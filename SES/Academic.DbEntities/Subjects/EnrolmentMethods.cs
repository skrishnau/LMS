using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Subjects
{
    /// <summary>
    /// Self Enrolment
    /// :: This is not used now.. The enrollments are: Auto, Manual and Self
    ///  _ Auto: automatic enrollment--> for regular students
    /// _ Manual: enrollment done by manager/Teacher etc.
    /// _ Self: enrollment done by the user/student him/herself.
    /// </summary>
    public class EnrolmentMethods
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public bool AllowExistingEnrolments { get; set; }
        public bool AllowNewEnrolments { get; set; }

        public string EnrolmentKey { get; set; }

        public int DefaultAssignedRoleId { get; set; }
        public virtual User.Role DefaultAssignedRole { get; set; }

        //Length of time that the enrolment is valid
        public bool EnrolmentDurationEnabled { get; set; }
        public int EnrolmentDuration { get; set; }
        //weeks, days, hours, minutes and seconds.
        public string EnrolmentDurationType { get; set; }

        //Types: No, Enroller only , Enroller and enrolled user
        public string NotifyBeforeEnrolmentExpires { get; set; }

        public int NotificationThreshold { get; set; }
        public string NotificationThresholdType { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }


        //If users haven't accessed a course for a long time, then they are automatically unenrolled. This parameter specifies that time limit.
        public int EnrolInActiveAfter { get; set; }

        //cohort members//not used now 

        public bool SendCourseWelcomeMessage { get; set; }
        public string WelcomeMessage { get; set; }



    }
}
