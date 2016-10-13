using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.ActivityAndResource.ChoiceItems
{
    public class ChoiceOptions
    {
        public int Id { get; set; }
        public string Option { get; set; }
        public long? Limit { get; set; }

        public int Position { get; set; }

        public int ChoiceActivityId { get; set; }
        public virtual ChoiceActivity ChoiceActivity{ get; set; }

        public virtual ICollection<ChoiceUser> ChoiceUsers { get; set; }
    }
}
