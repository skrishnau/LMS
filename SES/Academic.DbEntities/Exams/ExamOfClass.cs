using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.AcacemicPlacements;

namespace Academic.DbEntities.Exams
{
    public class ExamOfClass
    {
        public int Id { get; set; }

        public int ExamId { get; set; }
        public virtual Exam Exam { get; set; }

        public int RunningClassId { get; set; }
        public virtual RunningClass RunningClass { get; set; }

        /*
        //indicated whether the settings are used form Exam or it has its own settings
        public bool SettingsUsedFromExam { get; set; }
        //these four parameters are used to store settings of this class
        //if SettingsUsedFromExam = true then these four values are null
        public bool? IsPercent { get; set; }
        public float? Weight { get; set; }

        public int? FullMarks { get; set; }
        public int? PassMarks { get; set; }
        */

        public bool? Void { get; set; }

        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
