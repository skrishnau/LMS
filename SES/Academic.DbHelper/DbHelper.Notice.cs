using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Academic.DbHelper
{
    public partial class DbHelper
    {
        public class Notice:IDisposable
        {
            private Academic.Database.AcademicContext Context;

            public Notice()
            {
                Context =new Academic.Database.AcademicContext();
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
                    noti.Description = notice.Description;
                    noti.UpdatedDate = DateTime.Now;
                    noti.Headiing = notice.Headiing;
                    noti.ViewerLimited = notice.ViewerLimited;
                    Context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            public bool DeleteNotices(int id)
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

            public List<DbEntities.Notices.Notice> GetNotices(int userId)
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

                var n =  (from noti in  Context.Notice.Where(x=>!(x.Void??false))
                              .OrderByDescending(x=>x.CreatedDate)
                              .ThenByDescending(x=>x.UpdatedDate)
                              .ToList()
                             select new DbEntities.Notices.Notice()
                          {
                              Id = noti.Id
                              ,
                              CreatedDate = noti.CreatedDate
                              ,
                              Description = (noti.Description.Length > 150) ? noti.Description.Substring(0, 149) + "..." : noti.Description
                              ,
                              UpdatedDate = noti.UpdatedDate
                              ,
                              //for now viewer limited is used as notice seen or not seen indication
                              //ViewerLimited = noti.ViewerLimited
                              ViewerLimited = !Context.NoticeNotification.Any(x=>x.UserId==userId && x.NoticeId==noti.Id)
                              ,
                              CreatedBy = noti.CreatedBy
                              ,
                              CreatedById = noti.CreatedById
                              ,
                              Headiing = noti.Headiing
                              
                          }).ToList()  ;

                var count = n.Count();
                if (count <= 10) count = 0;
                else if (count < 20) count = count%10;
                else count = count - 10;
                //count = (count%10)*(count/10);
                var s = n.Skip(count);
                return s.ToList();
            }


            public void Dispose()
            {
                Context.Dispose();
            }
        }
    }
}
