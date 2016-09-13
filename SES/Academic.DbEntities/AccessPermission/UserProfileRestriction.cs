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

        /// <summary>
        ///  The Values are--> 
        /// '=':is equal to, '+': contain, '-': does not contain, '^': starts with, '$': ends with,
        ///  '~': is empty, '#': is not empty
        /// </summary>
        public char Constraint { get; set; }

        public string Value { get; set; }


    }
}
