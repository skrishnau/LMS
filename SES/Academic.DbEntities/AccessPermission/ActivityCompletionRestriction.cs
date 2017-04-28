using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.AccessPermission
{
    public class ActivityCompletionRestriction
    {
        public int Id { get; set; }
        
        public int ActivityId { get; set; }
        public virtual ActivityAndResource.ActivityResource Activity { get; set; }

        public string Constraint { get; set; }

        public int RestrictionId { get; set; }
        public AccessPermission.Restriction Restriction { get; set; }

    }
}
