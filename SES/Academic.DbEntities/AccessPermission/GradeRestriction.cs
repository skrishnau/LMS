using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.AccessPermission
{
    //used
    public class GradeRestriction
    {
        public int Id { get; set; }
        
        public int RestrictionId { get; set; }
        public virtual Restriction Restriction { get; set; }
        
        /// <summary>
        /// It holds id of Activity only. Check before accessing ActivityResource for only Activity
        /// </summary>
        public int ActivityResourceId { get; set; }
        public virtual ActivityAndResource.ActivityResource ActivityResource { get; set; }

        public bool MustBeGreaterThanOrEqualTo { get; set; }
        public float? GreaterThanOrEqualToValue { get; set; }

        public bool MustBeLessThan { get; set; }
        public float? LessThanValue { get; set; }

    }
}
