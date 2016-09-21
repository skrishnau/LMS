using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Notices
{
    public class Notice
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// True= publish to EVeryOne; False = Publish to Users Only.
        /// </summary>
        public bool? NoticePublishTo { get; set; }
        public bool? Void { get; set; }

        public bool PublishNoticeToNoticeBoard { get; set; }
        public DateTime? PublishedDate { get; set; }

        public int SchoolId { get; set; }
        //public virtual ICollection<NoticeFiles> NoticeFiles{ get; set; }

    }
}
