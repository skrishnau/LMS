using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Subjects
{
    //will be used ... it is used to override the default grouping of students in a course
    // so the grouping of students will be as per this setting.
   public class SubjectUserGroup
    {
       public int Id { get; set; }
       public string Name { get; set; }
       
       public int SubjectId { get; set; }
       public virtual Subjects.Subject Subject { get; set; }



    }
}
