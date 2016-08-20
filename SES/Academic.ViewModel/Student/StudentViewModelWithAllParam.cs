using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.ViewModel.Student
{
    public class StudentViewModelWithAllParam
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string CRN { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        public int UserId { get; set; }
        public string ImageUrl { get; set; }

        public string LastOnline { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
