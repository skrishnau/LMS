using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.User;

namespace Academic.DbEntities.ActivityAndResource.ChoiceItems
{
    public class ChoiceUser
    {
        public int Id { get; set; }

        public int ChoiceActivityId { get; set; }
        public virtual ChoiceActivity ChoiceActivity { get; set; }

        public int ChoiceOptionsId { get; set; }
        public virtual ChoiceOptions ChoiceOptions { get; set; }

        public int UserId { get; set; }
        public virtual Users User { get; set; }
    }
}
