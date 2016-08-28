using Academic.DbEntities.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.AcacemicPlacements
{

    /// <summary>
    /// Obsolete. since link between class and subject is done by
    ///  SubjectSession(or SubjectClass). 
    /// Earlier Note: 
    /// RegularSubjectClass and UserClass are closely related...
    /// </summary>
    [Obsolete]
    public class RegularSubjectClass
    {
        public int Id { get; set; }

        public int RunningClassId { get; set; }
        public virtual RunningClass RunningClass { get; set; }

        public int RegularSubjId { get; set; }
        public virtual RegularSubject RegularSubj { get; set; }

        public bool? Void { get; set; }


        //public virtual Teachers.Teacher Teacher { get; set; }
        //public virtual Subject Subject { get; set; }

        //public bool? Void { get; set; }


        
    }
}
