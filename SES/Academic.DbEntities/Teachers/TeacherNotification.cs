using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Teachers
{
    public class TeacherNotification
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }

        public byte NotificationType { get; set; }//enum
        public int NotificationId { get; set; }

        public bool Seen { get; set; }
        public DateTime SeenDate { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
