using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.Subjects;

namespace Academic.DbEntities.Class
{
    //Used
   public  class SubjectSession
    {
       public int Id { get; set; }

       /// <summary>
       /// indicates if this is regular subject of students
       /// false: means that all the values of subjectStructureId, ProgramBatchId, AcademicYearId
       /// , SessionId are null
       /// If IsRegular then the enrolment mehtod has Auto enrolment for sure and other method as per 
       /// entry
       /// Also IsRegular=false then subjectId != null
       /// </summary>
       public bool IsRegular { get; set; }

       public int? SubjectStructureId { get; set; }
       public virtual SubjectStructure SubjectStructure { get; set; }

       public int? ProgramBatchId { get; set; }
       public virtual Batches.ProgramBatch ProgramBatch { get; set; }   


       public int? AcademicYearId { get; set; }
       public virtual AcademicYear AcademicYear { get; set; }

       public int? SessionId { get; set; }
       public virtual Session Session { get; set; }

       //IsRegular false cases:
       public int? SubjectId { get; set; }


       //overall Part.
       public bool? Void { get; set; }
       public int? VoidBy { get; set; }
       public DateTime? VoidDate { get; set; }

       public bool? CompleteForThisTime { get; set; }

       //Its the date in which this class-subjectt is opened.
       //i.e the date of create
       public DateTime OpenedDate { get; set; }
       public DateTime? CompleteDate { get; set; }
       public int? CompleteMarkedByUserId { get; set; }

       //gives all the users for this session of the course.
       public virtual ICollection<SubjectSessionUser> ClassUsers { get; set; }
    }
}
