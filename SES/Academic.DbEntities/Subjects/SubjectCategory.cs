using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.Office;

namespace Academic.DbEntities.Subjects
{
   
    public class SubjectCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Code { get; set; }//required: it is initial of subject code-- subject derives from it

        public int? ParentId { get; set; }
        public string Description { get; set; }

        public int SchoolId { get; set; }
        public virtual School School { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsVoid { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }

        public DateTime? CreatedDate { get; set; }

    }
}
