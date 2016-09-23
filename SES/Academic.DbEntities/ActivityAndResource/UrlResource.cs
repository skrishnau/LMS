using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.ActivityAndResource
{
    public class UrlResource
    {
        public int Id { get; set; }

        public string Url { get; set; }
        public string Description { get; set; }

        public int RestrictionId { get; set; }
        public virtual DbEntities.AccessPermission.Restriction Restriction { get; set; }
    }
}
