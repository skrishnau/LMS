using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Libraries
{
    public  class UsefulnessCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public byte Rating { get; set; }//next version: multiple rating and average of rating : from student and teacher vote
    }
}
