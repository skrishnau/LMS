using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Academic.ViewModel
{
    public class AcademicViewModel
    {
        public String AcademicYearName { get; set; }
        public DateTime StartDateAY { get; set; }
        public DateTime EndDateAV { get; set; }

        public int SchoolId { get; set; }
        public String SchoolName { get; set; }

        //now limited to 2
        public List<SessionViewModel> Sessions { get; set; }

    }

    public class SessionViewModel
    {
        public String Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public String SessionType { get; set; }
    }

    public class AcademicAndSessionCombinedViewModel
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public int AcademicYearId { get; set; }
        public int SessionId { get; set; }

        public bool Check { get; set; }

        public bool Completed { get; set; }

        public string BothNameCombined { get; set; }
    }

    public enum Month
    {
        Jan,Feb,Mar,Apr,May,June,July,Aug,Sep,Oct,Nov,Dec
    }

    public class MonthClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class AcademicAndSessionViewModel
    {
         public String AcademicYearName { get; set; }
        [Required]
        [Range(minimum:1999,maximum:2999)]
        public int YearAs { get; set; }
        
        public int MonthAs { get; set; }
        [Range(1,31)]
        public int DateAs { get; set; }

        [Required]
        [Range(minimum: 1999, maximum: 2999)]
        public int YearAe { get; set; }

        public int MonthAe { get; set; }
        [Range(1, 31)]
        public int DateAe { get; set; }
        //public DateTime StartDateAY { get; set; }
        //public DateTime EndDateAV { get; set; }

        public int SchoolId { get; set; }
        //public String SchoolName { get; set; }

        public String SessionName { get; set; }
        [Required]
        [Range(minimum: 1999, maximum: 2999)]
        public int YearSs { get; set; }

        public int MonthSs { get; set; }
        [Range(1, 31)]
        public int DateSs { get; set; }

        [Required]
        [Range(minimum: 1999, maximum: 2999)]
        public int YearSe { get; set; }

        public int MonthSe { get; set; }
        [Range(1, 31)]
        public int DateSe { get; set; }
        //public DateTime SessionStartDate { get; set; }
        //public DateTime SessionEndDate { get; set; }
        public String SessionType { get; set; }


        public String SessionName2 { get; set; }
        public DateTime SessionStartDate2 { get; set; }
        public DateTime SessionEndDate2 { get; set; }
        public String SessionType2 { get; set; }


    }
}
