using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.User;

namespace Academic.DbEntities.Messages
{
    public class Message
    {
        public int Id { get; set; }

        public string Content { get; set; }
        public DateTime SentDate { get; set; }
        public bool Viewed { get; set; }
        public DateTime? ViewedDate { get; set; }

        public bool? VoidBySender { get; set; }
        public bool? VoidByReceiver { get; set; }

        public int? RepliedToId { get; set; }
        public virtual Message RepliedTo { get; set; }

        public int SenderId { get; set; }
        public virtual Users Sender { get; set; }

        public int ReceiverId { get; set; }
        public virtual Users Receiver { get; set; }

    }
}
