using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.ActivityAndResource
{
    public class ActivityResource
    {
        public int Id { get; set; }

        /// <summary>
        /// true: Activity; false: Resource
        /// </summary>
        public bool ActivityOrResource { get; set; }

        /// <summary>
        /// 1:Assignment, 2:
        /// 1: Book, 2:File, 3:Folder
        /// </summary>
        public byte ActivityResourceType { get; set; }

        /// <summary>
        /// Ids of Assignment, .. , etc
        /// </summary>
        public int ActivityResourceId { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Position of this Activity/Resource in UI(wwebpage)
        /// </summary>
        public int Position { get; set; }

        public int SubjectSectionId { get; set; }
        public virtual Subjects.SubjectSection SubjectSection { get; set; }

        public bool? Void { get; set; }

        public int? RestrictionId { get; set; }
        public AccessPermission.Restriction Restriction { get; set; }
    }

}
