using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.ActivityAndResource
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //public int SectionId { get; set; }
        //public virtual Subjects.SubjectSection Section { get; set; }

        public bool? DispalyDescriptionOnPage { get; set; }

        public DateTime? SubmissionFrom { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CutOffDate { get; set; }
        //next version see moodle orange
        //public bool? AlwaysShowDescription { get; set; }

        //Submission Types-----
        public bool FileSubmission { get; set; }
        public int? MaximumNoOfUploadedFiles { get; set; }
        public int? MaximumSubmissionSize { get; set; } //1 MB

        public bool OnlineText { get; set; }
        public int? WordLimit { get; set; }

        //next version
        //Feedback
        //Maximum attempts
        //group submission
        //next version : settings for notifactation to student and teacher


        /// <summary>
        /// Grading: types: None, Point, and Scale
        /// </summary>
        //public string GradeType { get; set; }


        public int GradeTypeId { get; set; }
        public virtual Grades.GradeType GradeType { get; set; }

        //they contain value in case of Range, and contain id of gradeValue class incase  of Value
        public string MaximumGrade { get; set; }
        public string GradeToPass { get; set; }
        //next version: blind marking

        //Restriction
        //for now restriction on current students


        //next version: activity completion

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }

        //Student Group for whom the assignment is given


        //public virtual Subjects.Subject Subject { get; set; }
        //public virtual ICollection<Resources.Resource> Resources { get; set; }
        //public virtual ICollection<DbEntities.Assignments.AssignmentAnswer> AssignmentAnswers { get; set; }
        //public virtual ICollection<Task> Tasks { get; set; }

        //public int? RestrictionId { get; set; }
        //public AccessPermission.Restriction Restriction { get; set; }
    }
}
