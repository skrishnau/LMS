using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.Database;
using Academic.ViewModel;

namespace Academic.DbHelper
{
    public partial class DbHelper
    {
        public class MessageHelper : IDisposable
        {
            private AcademicContext Context;

            public void Dispose()
            {
                Context.Dispose();
            }

            public MessageHelper()
            {
                Context = new AcademicContext();
            }


            public List<MessageViewModel> ListAllMessagesThreads(int userId)
            {
                var msg = Context.Message.Where(x => x.ReceiverId == userId || x.SenderId == userId);
                var list = new List<MessageViewModel>();
                foreach (var x in msg)
                {
                    list.Add(new MessageViewModel()
                    {
                        Id = x.Id,
                        ReceiverId = x.ReceiverId,
                        Viewed = x.Viewed,
                        SenderId = x.SenderId,
                        SenderName = x.Sender.FullName,
                        Content = x.Content,
                        ReceiverName = x.Receiver.FullName,
                        RepliedToId = x.RepliedToId ?? 0,
                        SentDate = x.SentDate.ToShortDateString(),
                        ViewedDate = x.ViewedDate.HasValue ? x.ViewedDate.Value.ToShortDateString() : "",
                        VoidByReceiver = x.VoidByReceiver ?? false,
                        VoidBySender = x.VoidBySender ?? false
                    });
                }
                return list;
            }

            public List<MessageViewModel> ListNotViewMessages(int userId)
            {
                var msg = Context.Message.Where(x => x.ReceiverId == userId && !x.Viewed);

                var list = new List<MessageViewModel>();
                foreach (var x in msg)
                {
                    list.Add(new MessageViewModel()
                    {
                        Id = x.Id,
                        ReceiverId = x.ReceiverId,
                        Viewed = x.Viewed,
                        SenderId = x.SenderId,
                        SenderName = x.Sender.FullName,
                        Content = x.Content,
                        ReceiverName = x.Receiver.FullName,
                        RepliedToId = x.RepliedToId ?? 0,
                        SentDate = x.SentDate.ToShortDateString(),
                        ViewedDate = x.ViewedDate.HasValue ? x.ViewedDate.Value.ToShortDateString() : "",
                        VoidByReceiver = x.VoidByReceiver ?? false,
                        VoidBySender = x.VoidBySender ?? false
                    });
                }
                return list;
            }

            //public List



        }
    }
}
