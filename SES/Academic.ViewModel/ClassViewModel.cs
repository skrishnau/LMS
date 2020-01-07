using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.ViewModel
{
    public class ClassViewModel
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ProgramName { get; set; }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        public int RunningClassId { get; set; }

        public string OpenTillDate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public bool IsRegular { get; set; }

        public string IconUrl { get; set; }
    }
}
