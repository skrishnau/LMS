using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.ActivityAndResource
{
    public class ForumActivity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool DisplayDescriptionOnCoursePage { get; set; }

        //public int ActivityResourceId { get; set; }
        //public virtual ActivityResource ActivityResource { get; set; }
        /// <summary>
        //There are 5 forum types:
        //0: A single simple discussion - A single discussion topic which everyone can reply to (cannot be used with separate groups)
        //1: Each person posts one discussion - Each student can post exactly one new discussion topic, which everyone can then reply to
        //2: Q and A forum - Students must first post their perspectives before viewing other students' posts
        //3: Standard forum displayed in a blog-like format - An open forum where anyone can start a new discussion at any time, and in which discussion topics are displayed on one page with "Discuss this topic" links
        //4: Standard forum for general use - An open forum where anyone can start a new discussion at any time
        /// </summary>
        public byte ForumType { get; set; }

        //==============Attachments and Word Count

        /// <summary>
        /// In KB
        /// </summary>
        public int MaximumAttachmentSize { get; set; }
        public int MaximumNoOfAttachments { get; set; }
        public bool DisplayWordCount { get; set; }


        //==============Subscription and Tracking===========//


        /// <summary>
        //    When a participant is subscribed to a forum it means they will receive forum post notifications. There are 4 subscription mode options:
        //  0.  Optional subscription - Participants can choose whether to be subscribed
        //  1.  Forced subscription - Everyone is subscribed and cannot unsubscribe
        //  2.  Auto subscription - Everyone is subscribed initially but can choose to unsubscribe at any time
        //  3.  Subscription disabled - Subscriptions are not allowed
        //Note: Any subscription mode changes will only affect users who enrol in the course in the future, and not existing users.
        /// </summary>
        public byte SubscriptionMode { get; set; }
        /// <summary>
        /// True: Optional,  False: Off
        /// </summary>
        public bool ReadTracking { get; set; }


        //======================== Post Threshold for Blocking =================//

        /// <summary>
        /// 0: "Don't block",  1-6: "__ Days",   7: "1 Week"
        /// Students can be blocked from posting more than a given number of posts in a given time period. Users with the capability mod/forum:postwithoutthrottling are exempt from post limits.
        /// </summary>
        public byte TimePeriodForBlocking { get; set; }
        /// <summary>
        /// This setting specifies the maximum number of posts which a user can post in the given time period. Users with the capability mod/forum:postwithoutthrottling are exempt from post limits.
        /// </summary>
        public int PostThresholdForBlocking { get; set; }
        /// <summary>
        /// Students can be warned as they approach the maximum number of posts allowed in a given period. This setting specifies after how many posts they are warned. Users with the capability mod/forum:postwithoutthrottling are exempt from post limits.
        /// </summary>
        public int PostThresholdForWarning { get; set; }

        //================= Grade --not now ================//

        //================ Ratings -- not now ===========//


        //=========== Restriction ====================//
        //public int RestrictionId { get; set; }
        //public virtual AccessPermission.Restriction Restriction { get; set; }



    }
}
