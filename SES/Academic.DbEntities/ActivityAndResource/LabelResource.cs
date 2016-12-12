using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.ActivityAndResource
{
    public class LabelResource
    {
        public int Id { get; set; }
        public string Text { get; set; }

        //public int ActivityResourceId { get; set; }
        //public virtual ActivityResource ActivityResource { get; set; }
        //public int RestrictionId { get; set; }
        //public virtual DbEntities.AccessPermission.Restriction Restriction { get; set; }
    }
}
