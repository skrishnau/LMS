using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.Office;

namespace Academic.DbEntities.User
{
    public class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public string EmailDisplay { get; set; } //global public private

        public string Phone { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public string Description { get; set; }

        public DateTime? DOB { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public int? GenderId { get; set; }
        public virtual Gender Gender { get; set; }


        public int? SchoolId { get; set; }
        public virtual School School { get; set; }

        //public byte[] Image { get; set; }
        //public string ImageType { get; set; }
        public int? UserImageId { get; set; }
        public UserFile UserImage { get; set; }


        public DateTime? CreatedDate { get; set; }
        public DateTime? LastOnline { get; set; }

        //public virtual ICollection<UserDivision> UserDivisions { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; } 

        public string FullName
        {
            get { return (FirstName ?? "") +((MiddleName==null)?"":" "+MiddleName+" ")+ " "+LastName ?? ""; }
        }

        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }


        public virtual ICollection<Class.UserClass> Classes { get; set; }
    }
}
