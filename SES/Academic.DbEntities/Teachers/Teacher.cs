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

        public DateTime? AppointedDate { get; set; }
        /// <summary>
        /// separate with commas for multiple entries
        /// </summary>
        public string ResearchInterest { get; set; }
        /// <summary>
        /// separate with commas for multiple entries
        /// </summary>
        public string Hobbies { get; set; }

        public int UserId { get; set; }
        public virtual Users User { get; set; }

        //public virtual ICollection<Activities.Teach> Teach { get; set; }

        public int? TeacherJobTitleId { get; set; }
        //public virtual TeacherJobTitle TeacherJobTitle { get; set; }

        public string JobTitle { get; set; }

        public string Name { get; set; }
    }
}
