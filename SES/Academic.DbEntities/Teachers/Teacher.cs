using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.User;

namespace Academic.DbEntities.Teachers
{
    [Serializable]
    public class Teacher
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public DateTime? AppointedDate { get; set; }
        /// <summary>
        /// separate with commas for multiple entries
        /// </summary>
        public string ResearchInterest { get; set; }
        /// <summary>
        /// separate with commas for multiple entries
        /// </summary>
        public string Hobbies { get; set; }

        public virtual Users User { get; set; }

        public virtual ICollection<Activities.Teach> Teach { get; set; }

        public int? TeacherJobTitleId { get; set; }
        public virtual TeacherJobTitle TeacherJobTitle { get; set; }

        public string JobTitle { get; set; }

        public string Name { get; set; }
        //[Required]
        //public string FirstName { get; set; }
        //public String MiddleName { get; set; }
        //public string LastName { get; set; }

        //public DateTime DOB { get; set; }
        //public byte GenderId { get; set; }
        //public int RoleId { get; set; } //

        //in next version
        //public String PermanentCountry { get; set; }
        //public String PermanentCity { get; set; }
        //public String PermanentStreet { get; set; }
        //public String TemporaryCountry { get; set; }
        //public String TemporaryCity { get; set; }
        //public String TemporaryStreet { get; set; }

        //public string Religion { get; set; }
        //public string Nationality { get; set; }
        //public string MobileNo { get; set; }
        //public string HomeNo { get; set; }
        //public string Email { get; set; }

        //public string BarcodeNo { get; set; }

        //public string OtherRollNo { get; set; }
        //public string OtherRollName { get; set; }

        //public int SchoolId { get; set; }
        //public School School { get; set; }

        //public string UserName { get; set; }
        //public string Password { get; set; }
        //public byte[] Image { get; set; }
        //public int ImageFileId { get; set; }
        //public virtual UserImage ImageFile { get; set; }

        //public DateTime? MembershipDate { get; set; }
        //public bool IsActive { get; set; }
        //public bool IsDeleted { get; set; }
        //==========================================//
        //specific
        //public string Citizenship { get; set; }
       

    }
}
