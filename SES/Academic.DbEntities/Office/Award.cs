using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Office //Entities.Office
{
    public class Award
    {
        public int Id { get; set; }
        public int InstitutionId { get; set; }
        public string By { get; set; }
        public string To { get; set; }
        public string For { get; set; }
        public DateTime ReceivedDate { get; set; }

        public virtual Institution Institution { get; set; }

    }
}
