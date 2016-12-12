using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.AccessPermission
{
    public class UserProfileRestriction
    {
        public int Id { get; set; }

        public string FieldName { get; set; }

        /*
            ///  The Values are--> 
            /// '=':is equal to, '+': contain, '-': does not contain, '^': starts with, '$': ends with,
            ///  '~': is empty, '#': is not empty
         */

        /// <summary>
        ///  0:equals to , 1:contains, 2:doesn't contain, 3:starts with, 4:ends with
        /// </summary>
        public byte Constraint { get; set; }

        public string Value { get; set; }

        public int RestrictionId { get; set; }
        public AccessPermission.Restriction Restriction { get; set; }
    }
}
