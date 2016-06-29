using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Students
{
    public class StudentGroupResource
    {
        public int Id { get; set; }
        public int StudentGroupId { get; set; }
        public int ResourceId { get; set; }
        public int SenderId { get; set; }
        public DateTime SentDate { get; set; }
        public string Topic { get; set; }
        public string Remarks { get; set; }


        public virtual StudentGroup StudentGroup { get; set; }
        public virtual Resources.Resource Resource { get; set; }
        public virtual Teachers.Teacher Sender { get; set; }


    }
}
