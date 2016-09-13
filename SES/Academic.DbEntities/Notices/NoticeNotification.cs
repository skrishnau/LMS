using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Notices
{

    /// <summary>
    /// If NoticeNotification is not found for a user then the analysis would be that
    /// the user has not viewed the notice yet.
    /// </summary>
    public class NoticeNotification
    {
        public int Id { get; set; }
        public int NoticeId { get; set; }
        public virtual Notice Notice { get; set; }

        public int UserId { get; set; }
        public virtual User.Users User { get; set; }

        public bool? Viewed { get; set; }
    }
}
