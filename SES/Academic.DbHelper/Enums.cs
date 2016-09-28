using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbHelper
{
    public static class Enums
    {
        

        public enum UserCapabilities
        {
            UserCreate,

        }

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

        #region Activitiy and Resources

        //Activities
        public enum Activities
        {
            Assignment
            ,
            Chat
           ,
            Forum
 ,
            Lession
                //,Survey
                ,
            Wiki
                ,
            Workshop
            ,
        }

        public static List<string> ActivityImagePath = new List<string>()
        {
            ""
            ,""
            ,""
            ,""
            ,""
            ,""
        };
        public static List<string> ActivityUrl = new List<string>()
        {
            "~/Views/ActivityResource/Assignments/AssignmentCreate.aspx"
            ,""
            ,""
            ,""
            ,""
            ,""
        };
        public static List<string> ResourceUrl = new List<string>()
        {
            "~/Views/ActivityResource/Book/BookCreate.aspx"
            ,"~/Views/ActivityResource/FileResource/FileResourceCreate.aspx"
            ,""
            ,""
            ,""
            ,"~/Views/ActivityResource/Url/UrlCreate.aspx"
        };


        public static List<ActivityClass> GetActivities()
        {
            var list = new List<ActivityClass>();
            int i = 0;
            foreach (String suit in Enum.GetNames(typeof(Enums.Activities)))
            {

                var ac = new ActivityClass()
                {
                    Name = suit
                    ,ImagePath = ActivityImagePath[i]
                    ,Url = ActivityUrl[i]
                };
                list.Add(ac);
                i++;
            }
            return list;
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
                , Url
        }
        public static List<ActivityClass> GetResources()
        {
            var list = new List<ActivityClass>();
            int i = 0;
            foreach (String suit in Enum.GetNames(typeof(Enums.Resources)))
            {

                var ac = new ActivityClass()
                {
                    Name = suit
                    ,
                    ImagePath = ActivityImagePath[i]
                    ,Url = ResourceUrl[i]
                };
                list.Add(ac);
                i++;
            }
            return list;
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


    }
}
   