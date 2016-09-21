using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.ViewModel.ActivityResource
{
    public class ActivityResourceViewModel
    {
        public int Id { get; set; }

        public string   Name { get; set; }
        public string Description { get; set; }

        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }
        public DateTime Date3 { get; set; }
       
        /// <summary>
        /// true: Activity; false: Resource
        /// </summary>
        public bool ActivityOrResource { get; set; }

        /// <summary>
        /// 1:Assignment, 2:
        /// </summary>
        public byte ActivityResourceType { get; set; }

        //public string ActivityOrResourceType { get; set; }
        /// <summary>
        /// Ids of Assignment, .. , etc
        /// </summary>
        public int ActivityResourceId { get; set; }

        /// <summary>
        /// Position of this Activity/Resource in UI(wwebpage)
        /// </summary>
        public int Position { get; set; }
        

        public int SubjectSectionId { get; set; }
        //public virtual Subjects.SubjectSection SubjectSection { get; set; }

        public bool? Void { get; set; }

        public string IconUrl { get; set; }
        public string NavigateUrl { get; set; }
    
    }
}
