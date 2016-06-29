using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Students
{
    public class StudentNotification
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public byte NotificationType { get; set; }//enum

        public bool IsGroupNotification { get; set; }
        public int NotificationId { get; set; }

        public bool Seen { get; set; }
        public DateTime SeenDate { get; set; }

        public virtual Student Student { get; set; }
    }
}
