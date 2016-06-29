using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Libraries
{
    public class BookReturnCategory
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public int LibraryId { get; set; }

        public byte ReturnYears { get; set; }
        public byte ReturnMonths { get; set; }
        public short ReturnDays { get; set; }

        public float FinePerMonth { get; set; }
        public float FinePerWeek { get; set; }
        public float FinePerDay { get; set; }
        public float FinePerHour { get; set; }

        public virtual Library Library { get; set; }
        
    }
}
