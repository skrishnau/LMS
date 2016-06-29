using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.User;

namespace Academic.DbEntities.Office
{
    /// <summary>
    /// It denotes the place or virtual stall or in which Studying and Teaching activity occur
    /// </summary>
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public int InstitutionId { get; set; }
       // public int? BranchId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        [Required(ErrorMessage = "please choose one of the types.")]
        public Int32 SchoolTypeId { get; set; }
        public String Code { get; set; }
        public String Country { get; set; }
        public String City { get; set; }
        public String Street { get; set; }
        public String Phone { get; set; }
        public String RegNo { get; set; }
        public String Fax { get; set; }
        public String Email { get; set; }
        public String Website { get; set; }
        public DateTime? CreatedDate { get; set; }

        public int? UserId { get; set; }
        //public virtual Users User { get; set; }

        public Byte[] Image { get; set; }
        public string ImageType { get; set; }
        //i think its not needed
        //public Int32? ParentId { get; set; }

        //public virtual Office Parent { get; set; }

        //foreign next version
        //public virtual Institution Institution { get; set; }
       // public virtual Branch Branch { get; set; }
        //next version
        public virtual SchoolType SchoolType { get; set; }
    }
}
