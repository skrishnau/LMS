using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbHelper
{
    //public partial class DbHelper
    //{
    public static class Enums
    {
        public enum StructureType
        {
            Level, Faculty, Program, Year, Subyear
        }

        public enum LongMonth
        {
            January, February, March, April, May, June, July, August, September, October, November, December
        }

        public enum ShortMonth
        {
            Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec
        }

        /// <summary>
        /// Return month list
        /// </summary>
        /// <param name="type">"short" - for short month name, e.g. Jan.  "long" for long Month name, e.g. January</param>
        /// <returns></returns>
        public static List<string> GetMonth(string type)
        {
            var lst = new List<string>();
            switch (type)
            {
                case "short":
                    foreach (var month in Enum.GetValues(typeof(Enums.ShortMonth)))
                    {
                        lst.Add(month.ToString());
                    }
                    break;
                default:
                    foreach (var month in Enum.GetValues(typeof(Enums.LongMonth)))
                    {
                        lst.Add(month.ToString());
                    }
                    break;
            }
            return lst;
        }

       

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
        //during uploading of files.. if multiple files are to be saved in file picker dialog  or only single file 
        public enum FileAcquireMode
        {
            Single, Multiple
        }

        public enum UserCapabilities
        {
            UserCreate,

        }

        #region Modes(editmode, displaymode)

        public enum EditMode
        {
            New//new user registration
                ,
            Create // craeating other user
                ,
            ProfileEdit
                , Update
        }

        public enum DisplayMode
        {
            Global
            ,
            Public
                , Private
        }
        public static List<string> GetDisplayModes()
        {
            var list = new List<String>();
            foreach (String suit in Enum.GetNames(typeof(Enums.DisplayMode)))
            {
                list.Add(suit);
            }
            return list;
        }

        #endregion


        #region Activitiy and Resources

        //Activities
        /// <summary>
        /// Always increment by 1 for assigning type position. type position is used in database to indicate 
        /// the type of Actvity/Resource, and it starts from 1.
        /// </summary>
        public enum Activities
        {
            Assignment
            ,
            Chat
            ,
            Forum
            ,
            Choice,
            Lession
                //,Survey
            ,
            Wiki
            ,
            Workshop
            ,
        }
        //Resources
        public enum Resources
        {
            Book
            ,
            File
            ,
            Folder
            ,
            Label
            ,
            Page
            ,
            Url
        }

        //public static List<string> ActivityUrl = new List<string>()
        //{
        //    "~/Views/ActivityResource/Assignments/AssignmentCreate.aspx"
        //    ,""
        //    ,""
        //    ,""
        //    ,""
        //    ,""
        //    ,""
        //    ,""
        //    ,""
        //};

        //public static List<string> ResourceUrl = new List<string>()
        //{
        //    "~/Views/ActivityResource/Book/BookCreate.aspx"
        //    ,"~/Views/ActivityResource/FileResource/FileResourceCreate.aspx"
        //    ,"~/Views/ActivityResource/Folder/FolderCreate.aspx"
        //    ,"~/Views/ActivityResource/Label/LabelCreate.aspx"
        //    ,"~/Views/ActivityResource/Page/PageCreate.aspx"
        //    ,"~/Views/ActivityResource/Url/UrlCreate.aspx"
        //};

        public static List<ActivityResourceClass> GetActivities()
        {
            var list = new List<ActivityResourceClass>();
            int i = 0;
            foreach (String suit in Enum.GetNames(typeof(Enums.Activities)))
            {
                var value = ActivityResourceValues.RetriveMethod(suit + "Activity");
                if (value != null)
                {
                    list.Add(value);
                }

                //var ac = new ActivityResourceClass()
                //{
                //    Name = suit
                //    ,
                //    IconPath = DbHelper.StaticValues.ActivityImages[i+1]
                //    ,
                //    CreateUrl = ActivityUrl[i]
                //};
                //list.Add(ac);
                //i++;
            }
            return list;
        }

        public static List<ActivityResourceClass> GetResources()
        {
            var list = new List<ActivityResourceClass>();
            int i = 0;
            Type type = typeof(ActivityResourceValues);
            foreach (String suit in Enum.GetNames(typeof(Enums.Resources)))
            {
                var value = ActivityResourceValues.RetriveMethod(suit + "Resource");
                if (value != null)
                {
                    list.Add(value);
                }
                //var ac = new ActivityResourceClass()
                //{
                //    Name = suit
                //    ,
                //    IconPath = DbHelper.StaticValues.ResourceImages[i +1]
                //    ,
                //    CreateUrl = ResourceUrl[i]
                //};
                //list.Add(ac);
                //i++;
            }
            return list;
        }



        public enum GradeTypes
        {
            Range, Value
        }
        #endregion



        ////all in small letters
        //public enum UserTypes
        //{
        //    teacher,student,
        //}

        ////public enum Roles
        ////{
        ////    teacher,student,manager,course-editor
        ////}

        //}


    }
}
