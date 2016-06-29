using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.AccessPermission
{
    public class Restriction
    {
        public int Id { get; set; }
        public string Type { get; set; }



        public int TypeId { get; set; }
        public string CheckParameter1 { get; set; }
        public string CheckParameter2 { get; set; }

        public string StringValue1 { get; set; }
        public string StringValue2 { get; set; }

        public int IntValue1 { get; set; }
        public int IntValue2 { get; set; }

        public int SubjectId { get; set; }
        public virtual Subjects.Subject Subject { get; set; }
        
    }

    public enum RestrictionTypes
    {
        Activity
        ,Date
        ,Grade
        ,Group
        ,Profile
    }

    public class GetTypeQuery
    {
        private Restriction _restriction;
        public GetTypeQuery(Restriction restriction)
        {
            _restriction = restriction;
        }

        public void Get()
        {
            switch (_restriction.Type)
            {
                case "Activity":

                    break;
                case "Date":
                    break;
                case "Grade":
                    break;
                case "Group":
                    break;
                case "Profile":
                    break;

            }
            {
                    
            }
        }

    }
    public class Activity
    {

    }
}
