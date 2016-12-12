using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.ActivityAndResource
{
    public class ChoiceActivity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public bool DisplayDescriptionOnCoursePage { get; set; }

        /// <summary>
        /// false: horizontal, true: vertical
        /// </summary>
        public bool DisplayModeForOptions { get; set; }


        //=================Optoins=================//
        public bool AllowChoiceTobeUpdated { get; set; }
        public bool AllowMoreThanOneChoiceToBeSelected { get; set; }

        public bool LimitTheNumberOfResponsesAllowed { get; set; }


        //====================Availability=================//
        public bool RestrictTimePeriod { get; set; }

        public DateTime? OpenDate { get; set; }
        public DateTime? UntilDate { get; set; }
        public bool ShowPreview { get; set; }

        //======================Results=====================//
        /// <summary>
        /// 0: Do not publish results to students
        /// 1:Show results to students after they answer 
        /// 2: Show results to students only after the choice is closed.
        /// 3: Always show results to students
        /// </summary>
        public byte PublishResults { get; set; }

        /// <summary>
        /// false: publish anonymous results, do not show student names 
        /// true: publish full result, showing names and their choices
        /// </summary>
        public bool PrivacyOfResults { get; set; }

        public bool ShowColumnForUnAnswered { get; set; }

        public bool IncludeResponsesFromInactiveUsers { get; set; }


        //public int ActivityResourceId { get; set; }
        //public virtual ActivityResource ActivityResource { get; set; }

        //public int RestrictionId { get; set; }
        //public virtual AccessPermission.Restriction Restriction { get; set; }

        public virtual ICollection<ChoiceItems.ChoiceOptions> ChoiceOptions { get; set; }
        public virtual ICollection<ChoiceItems.ChoiceUser> ChoiceUsers { get; set; }
    }
}
