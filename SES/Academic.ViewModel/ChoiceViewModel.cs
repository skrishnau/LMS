using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.ViewModel
{
    [Serializable]
    public class ChoiceViewModel
    {
        public int Id { get; set; }
        public string Option { get; set; }
        public long? Limit { get; set; }

        public string OptionName { get; set; }
        public string LimitName { get; set; }

        public int ChoiceActivityId { get; set; }


        public int Position { get; set; }

        public bool Visible { get; set; }
    }

    public class ChoiceResultViewModel
    {
        public int Id { get; set; }

        public string ChoiceOption { get; set; }

        public int NumberOfResponses { get; set; }

        public string PercentageOfResponses { get; set; }
    }
}
