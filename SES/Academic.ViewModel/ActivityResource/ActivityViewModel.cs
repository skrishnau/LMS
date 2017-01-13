using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.ViewModel.ActivityResource
{
    public class ActivityViewModel
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int ActivityId { get; set; }
        public string  ActivityName { get; set; }
        public string Name { get; set; }

        //public float ObtaiedMarks { get; set; }

        public string ObtainedMarks { get; set; }

        public bool IsFail { get; set; }


    }
}
