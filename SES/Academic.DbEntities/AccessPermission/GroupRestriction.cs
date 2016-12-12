using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.AccessPermission
{

    /// <summary>
    /// Students 'OF' 'CLASS' ________ in 'GROUP' ______ .
    /// Students 'OF' 'GROUP' ________ 
    /// </summary>
    public class GroupRestriction
    {
        public int Id { get; set; }

       // /// <summary>
       // /// true: Class so there may or may not be Group, since Class has Grouping
       // /// false: Group, so there will not be any Class, Group will be taken from Subject
       // /// </summary>
       //[Obsolete]
       // public bool ClassOrGroup { get; set; }

        /// <summary>
        /// 
        /// ClassId is optional. If ClassId is present then Group will be choosen from Class
        /// </summary>
        public int? SubjectClassId { get; set; }
        public virtual Class.SubjectClass SubjectClass { get; set; }

        /// <summary>
        /// Group can be choosen from the subject's Grouping or Class Grouping
        /// . If Subject Grouping then no ClassId.
        /// If Class Grouping then ClassId must also be present.
        /// </summary>
        public int? GroupId { get; set; }


        public int RestrictionId { get; set; }
        public AccessPermission.Restriction Restriction { get; set; }

    }
}
