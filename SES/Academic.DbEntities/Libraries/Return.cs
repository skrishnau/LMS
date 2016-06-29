using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Libraries
{
    public class Return
    {
        public int Id { get; set; }
        public int issueId { get; set; }
        public DateTime ReturnDate { get; set; }

        public bool IsFine { get; set; }
        public float? Amount { get; set; }
        public virtual Issue Issue { get; set; }
    }
}
