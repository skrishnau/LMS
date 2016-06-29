using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Teachers
{
   public class TeacherQualification
    {
       public int Id { get; set; }
       public int TeacherId { get; set; }
       public String Degree { get; set; }
       public string FieldOfStudy { get; set; }
       public String UniversityName { get; set; }
       public string Country { get; set; }
       public String CompletionYear { get; set; }

       public virtual Teacher Teacher { get; set; }
    }
}
