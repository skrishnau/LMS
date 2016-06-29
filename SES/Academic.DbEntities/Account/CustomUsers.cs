using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Account
{
    public class CustomUsers
    {

        public int ID { get; set; } //PKID Guid NOT NULL PRIMARY KEY,
        public string Username { get; set; }//Username Text (255) NOT NULL,
        public string ApplicationName { get; set; }//ApplicationName Text (255) NOT NULL,
        public string Email { get; set; }//Email Text (128) NOT NULL,
        public string Comment { get; set; }//Comment Text (255),
        public string Password { get; set; }//Password Text (128) NOT NULL,
        public string PasswordQuestion { get; set; }//PasswordQuestion Text (255),
        public string PasswordAnswer { get; set; }//PasswordAnswer Text (255),
        public bool? IsApproved { get; set; }//IsApproved YesNo, 
        public DateTime? LastActivityDate { get; set; }//LastActivityDate DateTime,
        public DateTime? LastLoginDate { get; set; }//LastLoginDate DateTime,
        public DateTime? LastPasswordChangedDate { get; set; }//LastPasswordChangedDate DateTime,
        public DateTime? CreationDate { get; set; }//CreationDate DateTime, 
        public bool? IsOnLine { get; set; }// IsOnLine YesNo,
        public bool? IsLockedOut { get; set; }//IsLockedOut YesNo,
        public DateTime? LastLockedOutDate { get; set; }//LastLockedOutDate DateTime,
        public int? FailedPasswordAttemptCount { get; set; }//FailedPasswordAttemptCount Integer,
        public DateTime? FailedPasswordAttemptWindowStart { get; set; }//FailedPasswordAttemptWindowStart DateTime,
        public int? FailedPasswordAnswerAttemptCount { get; set; }//FailedPasswordAnswerAttemptCount Integer,
        public DateTime? FailedPasswordAnswerAttemptWindowStart { get; set; }//FailedPasswordAnswerAttemptWindowStart DateTime,
  
        //custom
        public int SchoolId { get; set; }
        public int? AcademicYearId { get; set; }
        public int? SessionId { get; set; }
        public int? UserId { get; set; }
        public List<string> UserRoles { get; set; }

    }
}
