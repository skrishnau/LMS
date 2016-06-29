using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Notices
{
    public class NoticeTo
    {
        public int Id { get; set; }

        public int NoticeId { get; set; }
        public virtual Notice Notice { get; set; }

        public int UserId { get; set; }
        public virtual User.Users User { get; set; }


    }
}
