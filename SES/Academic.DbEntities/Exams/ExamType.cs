using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.Office;

namespace Academic.DbEntities.Exams
{
    public class ExamType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int SchoolId { get; set; }

        public bool? Void { get; set; }

        public virtual School School { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }

    }
}
