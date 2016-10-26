using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.AccessPermission
{
    public class Restriction
    {
        public int Id { get; set; }

        /// <summary>
        /// Used in Restriction set where multiple restrictions are nested
        /// </summary>
        public int? ParentId { get; set; }
        public virtual Restriction Parent { get; set; }

        /// <summary>
        /// true: Student 'MUST' match ______ of the following. ( ___ ==> all/any)
        /// false: Student 'MUST NOT' match _____ of the following.  ( ___ ==> all/any)
        /// </summary>
        public bool MatchMust { get; set; }

        /// <summary>
        /// true= match all the child restrictions by And-ing them
        /// false = match any of the child restrictions by doing 'OR' on all child restrictions
        ///  e.g. Student _____ match 'all/any' of the following. ( ___ ==> must/must not)
        /// </summary>
        public bool MatchAllAny { get; set; }

        /// <summary>
        /// true: displayed greyed-out if user doesn't meet conditions. 
        /// false: Hidden if user doesn't meet conditions.
        /// </summary>
        public bool Visibility { get; set; }

        public virtual ICollection<DateRestriction> DateRestrictions { get; set; }
        public virtual ICollection<GradeRestriction> GradeRestrictions { get; set; }
        public virtual ICollection<GroupRestriction> GroupRestrictions { get; set; }
        public virtual ICollection<UserProfileRestriction> UserProfileRestrictions { get; set; }

        public virtual ICollection<Restriction> Restrictions { get; set; }

    }

    public enum RestrictionTypes
    {
        Date
        ,
        Grade
        ,
        UserProfile
        ,
        Group
        , 
        RestrictionSet
    }

}
