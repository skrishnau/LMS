using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.ViewModel.Structure
{
    //used
    public class StructureViewModel
    {
        public int Id { get; set; }
        public int YearId { get; set; }
        public string YearName { get; set; }
        public int SubYearId { get; set; }
        public string SubYearName { get; set; }

        public int ProgramId { get; set; }
        public string ProgramName { get; set; }

        public bool Complete { get; set; }

    }

    public class SubjectAndStructureViewModel
    {

        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string ShortName { get; set; }

        public int RunningClassId { get; set; }
        public int YearId { get; set; }
        public string YearName { get; set; }
        public int SubYearId { get; set; }
        public string SubYearName { get; set; }

        public int ProgramId { get; set; }
        public string ProgramName { get; set; }

        public bool Complete { get; set; }

    }
}
