using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.User;

namespace Academic.DbEntities.ActivityAndResource.ForumItems
{
    public class ForumDiscussion
    {
        public int Id { get; set; }
        public string Subject { get; set; }

        public string Message { get; set; }

        public int? ParentDiscussionId { get; set; }
        public virtual ForumDiscussion ParentDiscussion { get; set; }

        public int ForumActivityId { get; set; }
        public virtual ForumActivity ForumActivity { get; set; }

        /// <summary>
        /// it gives the last posting in this discussion
        /// </summary>
        public int LastPostById { get; set; }
        public virtual Users LastPostBy { get; set; }


        public int PostedById { get; set; }
        public virtual Users PostedBy { get; set; }

        public DateTime PostedDate { get; set; }

        public bool? Closed { get; set; }

        public DateTime? LastUpdateDate { get; set; }
        public int? UpdatedBy { get; set; }



        public DateTime LastPostDate { get; set; }

        public virtual ICollection<ForumDiscussion> Replies { get; set; }

        public bool Pinned { get; set; }

        public bool SubscribeToDiscussion { get; set; }
    }
}
