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

        public int UserId { get; set; }
        public virtual User.Users User { get; set; }

        public int ActivityResourceId { get; set; }
        public virtual ActivityResource ActivityResource { get; set; }



    }
}
