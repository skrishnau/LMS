using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.ViewModel
{
    public class StudentReportViewModel
    {
        public int Id { get; set; }
        public int OtherId { get; set; }

        public int UserClassId { get; set; }
        public string ImageUrl { get; set; }


        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string CRN { get; set; }

        public string TotalMarks { get; set; }

        public int ActivityId { get; set; }
        public string ActivityName { get; set; }

        public List<ActivityResource.ActivityViewModel> ActivityViewModels { get; set; }
    }
}
