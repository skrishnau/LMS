using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Events
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Location { get; set; }


        public DateTime Date { get; set; }

        public string Time { get; set; }
        //float(10,6) That will let the fields store 6 digits after the decimal, 
        //plus up to 4 digits before the decimal, e.g. -123.456789 degrees. 
        public float? Latitude { get; set; }

        public float? Longitude { get; set; }

        public string  Description { get; set; }

        public int SchoolId { get; set; }
    }
}
