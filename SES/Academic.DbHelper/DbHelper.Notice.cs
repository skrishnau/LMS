using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Academic.DbHelper
{
    public partial class DbHelper
    {
        public class Notice : IDisposable
        {
            private Academic.Database.AcademicContext Context;

            public Notice()
            {
                Context = new Academic.Database.AcademicContext();
            }

            public bool AddOrUpdateNotices(DbEntities.Notices.Notice notice)
            {
                try
                {
                    var noti = Context.Notice.Find(notice.Id);
                    if (noti == null)
                    {
                        Context.Notice.Add(notice);
                        Context.SaveChanges();
                        return true;
                    }

                    noti.Content = notice.Content;
                    noti.PublishNoticeToNoticeBoard = notice.PublishNoticeToNoticeBoard;
                    noti.UpdatedDate = DateTime.Now;
                    noti.Title = notice.Title;
                    noti.NoticePublishTo = notice.NoticePublishTo;
                    noti.PublishedDate = notice.PublishedDate;
                    noti.UpdatedBy = notice.UpdatedBy;
                    noti.UpdatedDate = notice.UpdatedDate;
                    noti.Void = notice.Void;

                    Context.SaveChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            public bool DeleteNotice(int id)
            {
                try
                {
                    var notice = Context.Notice.Find(id);
                    if (notice != null)
                    {
                        notice.Void = true;
                        Context.SaveChanges();
                        return true;
                    }
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            public List<DbEntities.Notices.Notice> ListNotices(int schoolId, int userId, bool displayAll)
            {
                var notices = Context.Notice.Where(x => (x.SchoolId == schoolId && !(x.Void ?? false)))
                    .OrderByDescending(x => x.PublishedDate)
                    .ThenByDescending(x => x.UpdatedDate)
                    .ThenByDescending(x => x.CreatedDate)
                    .Take(20)
                    .ToList();
                if (displayAll)
                {
                    return notices;
                }
                return notices.Where(x => x.PublishNoticeToNoticeBoard).ToList();
            }

            public List<DbEntities.Notices.Notice> GetNotices(int schoolId, int userId)
            {
                //this commented code will be used in next version where notification could be given to individuals.. 
                //for now notification is given to all..
                //var n = from noti in (Context.Notice.Where(x => !(x.ViewerLimited ?? false) !(x.Void??false))
                //         .Union( Context.NoticeTo.Where(x=>x.UserId==userId && (x.Notice.ViewerLimited??false)).Select(x=>x.Notice) 
                //         ).Select(x=>x))
                //          select new DbEntities.Notices.Notice()
                //          {
                //              Id = noti.Id
                //              ,CreatedDate = noti.CreatedDate
                //              ,Description = (noti.Description.Length>150)?noti.Description.Substring(0,149)+"...":noti.Description
                //              ,UpdatedDate = noti.UpdatedDate
                //              ,ViewerLimited = noti.ViewerLimited
                //              ,CreatedBy = noti.CreatedBy
                //              ,CreatedById = noti.CreatedById
                //              ,Headiing = noti.Headiing
                //          }  ;


                var n = Context.Notice.Where(x => x.SchoolId == schoolId && !(x.Void ?? false) && x.PublishNoticeToNoticeBoard)
                    .OrderByDescending(x => x.PublishedDate)
                    .ThenByDescending(x => x.UpdatedDate)
                    .ThenByDescending(x => x.CreatedDate)
                    .ToList();

                //Used: after github
                //calculate all the viewed notifications
                //Here 'Void' column is used as Viewed--> so all viewed are represented by
                //Void= false and all unviewed by Void=true
                //since exclamation on notice is shown when not viewed , so Void = true for not viewed
                var notification = Context.NoticeNotification.Where(x => x.UserId == userId).Select(x => x.NoticeId);
                for (var i = 0; i < n.Count; i++)
                {
                    if (notification.Contains(n[i].Id))
                    {
                        //here void is used as viewed as 
                        n[i].Void = false;
                    }
                    else
                    {
                        n[i].Void = true;
                    }
                }
                //var count = n.Count();
                //if (count <= 10) count = 0;
                //else if (count < 20) count = count % 10;
                //else count = count - 10;
                ////count = (count%10)*(count/10);
                //var s = n.Skip(count);
                var s = n.Take(10);
                return s.ToList();
            }


            public void Dispose()
            {
                Context.Dispose();
            }

            public bool AddOrUpdateNoticeNotification(List<DbEntities.Notices.Notice> notices, int userId)
            {
                using (var scope = new TransactionScope())
                {
                    foreach (var n in notices)
                    {
                        var notiNotification = Context.NoticeNotification.FirstOrDefault(x => x.NoticeId == n.Id && x.UserId == userId);
                        if (notiNotification != null)
                        {
                            notiNotification.Viewed = true;
                        }
                        else
                        {
                            var nNf = new DbEntities.Notices.NoticeNotification()
                            {
                                UserId = userId
                                ,
                                NoticeId = n.Id
                                ,
                                Viewed = true
                            };
                            Context.NoticeNotification.Add(nNf);
                        }
                        Context.SaveChanges();
                    }
                    scope.Complete();

                }
                return true;
            }
            public bool AddOrUpdateNoticeNotification(int noticeId, int userId)
            {
                using (var scope = new TransactionScope())
                {
                    var notiNotification = Context.NoticeNotification.FirstOrDefault(x =>
                        x.NoticeId == noticeId && x.UserId == userId);
                    if (notiNotification != null)
                    {
                        notiNotification.Viewed = true;
                    }
                    else
                    {
                        var nNf = new DbEntities.Notices.NoticeNotification()
                        {
                            UserId = userId
                            ,
                            NoticeId = noticeId
                            ,
                            Viewed = true
                        };
                        Context.NoticeNotification.Add(nNf);
                    }
                    Context.SaveChanges();
                    scope.Complete();

                }
                return true;
            }

            public DbEntities.Notices.Notice GetNotice(int noticeId)
            {
                return Context.Notice.Find(noticeId);
            }
        }
    }
}
