using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.ViewModel.Enums
{
    //public class NotificationType
    //{
    //}
   public enum NotificationTypes
    {
        FILESHARE,
        MESSAGE,
        NOTICE,
        SYSTEM,
        RESULT,
        EXAM,
        ASSIGNMENT,
        REPLY,

        SEARCHED,
        ALARM,
        OTHERS
    }

    public class LinkAndTextViewModel
    {
        public string DisplayText { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
    }
     
}
