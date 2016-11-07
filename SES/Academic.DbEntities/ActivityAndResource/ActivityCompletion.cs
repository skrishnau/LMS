using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.User;

namespace Academic.DbEntities.ActivityAndResource
{
    public class ActivityCompletion
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public virtual Users User { get; set; }

        public int ActivityResourceId { get; set; }
        public virtual ActivityResource ActivityResource { get; set; }

        public DateTime CompletionMarkedDate { get; set; }

        /// <summary>
        /// when null, this completion is marked by system (auto)
        /// </summary>
        public int? CompletionMarkedById { get; set; }
        public virtual Users CompletionMarkedBy { get; set; }
    }
}
