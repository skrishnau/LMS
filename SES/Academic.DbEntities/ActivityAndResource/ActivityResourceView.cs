using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.ActivityAndResource
{
    public class ActivityResourceView
    {
        public int Id { get; set; }

        public int UserClassId { get; set; }
        public virtual Class.UserClass UserClass { get; set; }

        public int ActivityClassId { get; set; }
        public virtual ActivityClass ActivityClass { get; set; }

        public DateTime ViewedDate { get; set; }

    }
}
