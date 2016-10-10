using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                var value = ActivityResourceValues.RetriveMethod( suit + "Activity");
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
                var value = ActivityResourceValues.RetriveMethod( suit + "Resource");
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
