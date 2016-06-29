using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.ViewModel.User
{
    public class UserNotificationViewModel
    {
        public int Id { get; set; }

        public int SenderId { get; set; }
        public Account.UserInfoModel Sender { get; set; }
        
        public Enums.NotificationTypes NotificationType { get; set; }
        public byte[] IconImage { get; set; }
        public byte[] LinkImage { get; set; }
        public string Title { get; set; }
        public string body { get; set; }
        public string Link { get; set; }

        /// <summary>
        /// title is same for all subnotifications; 
        ///  notification type is all same for all subnotifications
        /// </summary>
        public IEnumerable<UserNotificationViewModel> SubNotificaions { get; set; }
        //public int NotificationId { get; set; }
        //public object Notification { get; set; }
    }
    public class StudentNotification
    {

    }
}
