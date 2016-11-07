using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.AccessPermission
{
    //used
    public class DateRestriction
    {
        public int Id { get; set; }
        
        public int RestrictionId { get; set; }
        public virtual Restriction Restriction { get; set; }

        /// <summary>
        /// until= true;  from= false; 
        /// </summary>
        public bool Constraint { get; set; }

        public DateTime Date { get; set; }
        //in fomat _:_ 24 hour format
        public string Time { get; set; }

    }
}
