using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.ViewModel
{
    public class MessageViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }
        public string SentDate { get; set; }
        public bool Viewed { get; set; }
        public string ViewedDate { get; set; }

        public bool VoidBySender { get; set; }
        public bool VoidByReceiver { get; set; }

        public int RepliedToId { get; set; }
        //public virtual Message RepliedTo { get; set; }

        public int SenderId { get; set; }
        public string SenderName { get; set; }

        public int ReceiverId { get; set; }
        public string ReceiverName { get; set; }
    }
}
