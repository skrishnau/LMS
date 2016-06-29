using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Students
{
    public class StudentPreviousStudies
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string InstitutionName { get; set; }
        public String InstitutionAddress { get; set; }
        public String University { get; set; }
        //public String CharacterComment { get; set; }
        //public String ReasonOfLeave { get; set; }
        public String Qualificaiton { get; set; }
        public bool IsGradingSystem { get; set; }
        public char[] Grade { get; set; }
        public float? Percent { get; set; }
        public DateTime CertificateIssueYear { get; set; }

        public virtual Student Student { get; set; } 
    }
}
