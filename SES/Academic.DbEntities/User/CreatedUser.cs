using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.Office;

namespace Academic.DbEntities.User
{
    public class CreatedUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public int UserTypeId { get; set; }
        public string Country { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Citizenship { get; set; }
        public DateTime? CreatedDate { get; set; }

        public byte GenderId { get; set; }
        public DateTime? DOB { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        //public int SchoolId { get; set; }
        public byte[] Image { get; set; }
        public string ImageType { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        //foreign
        //public UserType UserType { get; set; }

        //public int InstitutionId { get; set; }
        public int SchoolId { get; set; }

        public string Religion { get; set; }
        public string Nationality { get; set; }

        public string BarcodeNo { get; set; }


       // public virtual School School { get; set; }
      

        public string FullName
        {
            get { return FirstName ?? "" + " " + MiddleName ?? "" + " " + LastName ?? ""; }
        }

    }
}
