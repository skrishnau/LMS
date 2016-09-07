using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.AcacemicPlacements;
using Academic.DbEntities.Subjects;

namespace Academic.DbEntities.Class
{
    //Used
    public class SubjectClass
    {
        public int Id { get; set; }

        public string GetName
        {
            get
            {
                if (RunningClass != null)
                    if (RunningClass.ProgramBatchId != null)
                    {
                        return RunningClass.ProgramBatch.NameFromBatch;
                    }
                    else
                    {
                        return Name;
                    }
                else
                    return Name;
            }
        }
        /// <summary>
        /// indicates if this is regular subject of students
        /// false: means that all the values of subjectStructureId, ProgramBatchId, AcademicYearId
        /// , SessionId are null
        /// If IsRegular then the enrolment mehtod has Auto enrolment for sure and other method as per 
        /// entry
        /// Also IsRegular=false then subjectId != null
        /// </summary>
        public bool IsRegular { get; set; }

        public int? RunningClassId { get; set; }
        public virtual RunningClass RunningClass { get; set; }


        public int? SubjectStructureId { get; set; }
        public virtual SubjectStructure SubjectStructure { get; set; }

        //these six are covered by RunningClass, so we just need to add RunningClassId
        //public int? ProgramBatchId { get; set; }
        //public virtual Batches.ProgramBatch ProgramBatch { get; set; }  

        //public int? AcademicYearId { get; set; }
        //public virtual AcademicYear AcademicYear { get; set; }

        //public int? SessionId { get; set; }
        //public virtual Session Session { get; set; }



        //IsRegular means if this class is from regualr class i.e. if this row is auto added by the software 
        //IsRegular = false means --> this class is added manually..
        //IsRegular false case: i.e. if IsRegular=false then SubjectId != null and others all Id are null
        //Name is given if the course is independent of above ids i.e. above Ids are null
        public int? SubjectId { get; set; }
        public virtual Subjects.Subject Subject { get; set; }

        public string Name { get; set; }

        //overall Part.
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        //grouping of students
        //if false: then use the subject's grouping to group students
        //if hasGrouping = true then this class uses goruping of students else no grouping of  students
        public bool HasGrouping { get; set; }
        public bool? UseDefaultGrouping { get; set; }



        public bool? Void { get; set; }
        public int? VoidBy { get; set; }
        public DateTime? VoidDate { get; set; }

        public bool? SessionComplete { get; set; }

        //Its the date in which this class-subjectt is opened.
        //i.e the date of create
        public DateTime CreatedDate { get; set; }
        public string CreatedTime { get; set; }
        public int? CreatedBy { get; set; }

        public DateTime? CompletionMarkedDate { get; set; }
        public int? CompleteMarkedByUserId { get; set; }

        //gives all the users for this session of the course.
        public virtual ICollection<UserClass> ClassUsers { get; set; }
    }
}
