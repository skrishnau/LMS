using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.ViewModel.Teachers;

namespace Academic.ViewModel.Student
{
   public class StudentViewModel:UserViewModel, IImageViewModel
    {
         [Required]
        public string CRN { get; set; }
        public string ExamRollNoGlobal { get; set; }

        public string GuardianName { get; set; }
        public string GuardianEmail { get; set; }
        public string GuardianContactNo { get; set; }

        public System.Web.HttpPostedFileBase Image { get; set; }
    }
}
