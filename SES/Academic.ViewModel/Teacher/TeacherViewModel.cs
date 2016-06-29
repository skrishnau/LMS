using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.Teachers;

namespace Academic.ViewModel.Teachers
{
    public class TeacherViewModel:UserViewModel, IImageViewModel
    {
        //public DateTime AppointedDate { get; set; }

        public int AppointedYear { get; set; }
        public int AppointedMonth { get; set; }
        public int AppointedDay { get; set; }

        public string Citizenship { get; set; }
        /// <summary>
        /// separate with commas for multiple entries
        /// </summary>
        public string ResearchInterest { get; set; }
        /// <summary>
        /// separate with commas for multiple entries
        /// </summary>
        public string Hobbies { get; set; }

        public System.Web.HttpPostedFileBase Image { get; set; }

        public string JobTitle { get; set; }
        public int JobId { get; set; }
    }

    public class TeacherVM
    {
        public TeacherViewModel Teacher { get; set; }
        public List<TeacherQualification> TeacherQualification { get; set; }
    }
}
