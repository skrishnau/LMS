using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace One.Values.MemberShip
{
    public class CustomMembershipUser:System.Web.Security.MembershipUser
    {
          private int _schoolId;
        private int _acdemicYearId;
        private int _sessionId;
        private int _userId;
        private List<string> _userRoles;

        public int SchoolId
        {
            get { return _schoolId; }
            set { _schoolId = value; }
        }

        public int AcademicYearId
        {
            get { return _acdemicYearId; }
            set { _acdemicYearId = value; }
        }

        public int SessionId
        {
            get { return _sessionId; }
            set { _sessionId = value; }
        }

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public List<string> UserRoles
        {
            get { return _userRoles; }
            set { _userRoles = value; }
        }





        public CustomMembershipUser(string providername,
                                  string username,
                                  object providerUserKey,
                                  string email,
                                  string passwordQuestion,
                                  string comment,
                                  bool isApproved,
                                  bool isLockedOut,
                                  DateTime creationDate,
                                  DateTime lastLoginDate,
                                  DateTime lastActivityDate,
                                  DateTime lastPasswordChangedDate,
                                  DateTime lastLockedOutDate,
                                  int schoolId,
                                  int academicYearId,
                                    int sessionId,
                                    int userId,
                                    List<string> roles
            ) :
            base(providername,
                                       username,
                                       providerUserKey,
                                       email,
                                       passwordQuestion,
                                       comment,
                                       isApproved,
                                       isLockedOut,
                                       creationDate,
                                       lastLoginDate,
                                       lastActivityDate,
                                       lastPasswordChangedDate,
                                       lastLockedOutDate)
        {
            this.SchoolId = schoolId;
            this.AcademicYearId = academicYearId;
            this.SessionId = sessionId;
            this.UserId = userId;
            this.UserRoles = roles;
        }
    }
}