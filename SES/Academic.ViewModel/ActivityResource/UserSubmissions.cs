using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.ViewModel.ActivityResource
{
    public class UserSubmissionsViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Grade { get; set; }

        public string Submission { get; set; }

    }
}
