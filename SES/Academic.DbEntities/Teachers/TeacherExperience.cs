using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Teachers
{
    public class TeacherExperience
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public byte ExperienceYears { get; set; }
        public byte ExperienceMonths { get; set; }
        public string ExperienceCompanyName { get; set; }
        public string ExperienceCompanyAddress { get; set; }
        public string ExperienceCompanyEmail { get; set; }


    }
}
