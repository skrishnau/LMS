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

        public int ExamId{ get; set; }
        public virtual Exam Exam { get; set; }

        public int RunningClassId { get; set; }
        public virtual RunningClass RunningClass { get; set; }

        public bool? Void { get; set; }

    }
}
