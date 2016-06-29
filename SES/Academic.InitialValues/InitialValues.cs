using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.InitialValues
{
    
    public class InitialValues
    {
       public static Dictionary<string, int> CustomSession = new Dictionary<string, int>()
        {
           {"InstitutionId",4}
           ,{"SchoolId",15}
           ,{"UserId",5}
           ,{"AcademicYearId",1}
           ,{"SessionId",2}
        };

        public int InstitutionId { get { return 11; } }
        public int SchoolId { get { return 15; } }
        public int UserId { get { return 11; }}
        public int AcademicYearId { get { return 2; }}
        public int SessionId { get { return 2; }}
    }
}
