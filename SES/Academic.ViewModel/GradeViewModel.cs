using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.ViewModel
{
    [Serializable]
    public class GradeViewModel
    {
        public int GradeValueId { get; set; }
        public int LocalId { get; set; }
        public string Value { get; set; }
        public float Equivalent { get; set; }
        public bool Fail { get; set; }

        public bool Void { get; set; }
    }

    public class GradeInActResViewModel
    {
        public int GradeTypeId { get; set; }
        public int GradeValueId { get; set; }

        public float? MaximumGradeInFloat { get; set; }
        public float? MinimumGradeInFloat { get; set; }
        public float? GradeToPassInFloat { get; set; }
        public float? WeightInGradeSheetInFloat { get; set; }


        public string MaximumGradeInString { get; set; }
        public string MinimumGradeInString { get; set; }
        public string GradeToPassInString { get; set; }
        public string WeightInGradeSheetInString { get; set; }

        public float? ObtainedGradeInFloat { get; set; }
        public string ObtainedGradeInString { get; set; }

        public bool ShowGradeToStudents { get; set; }
    }
}
