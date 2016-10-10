using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbHelper
{
    public static class ActivityResourceValues
    {
        //---------------Get method----------------//
        /// <summary>
        /// Either only methodName is given or (actOrRes & actResType combined) is given
        /// </summary>
        /// <param name="methodName">name of method to search for. Used in loops where exact type is difficult to get</param>
        /// <param name="actOrRes"> used with actResType. Directly calls for the method w/0 searching. </param>
        /// <param name="actResType">used with actOrRes. Directly calls for the method w/0 searching. Used
        /// where actREsType is known.</param>
        /// <returns></returns>
        public static ActivityResourceClass RetriveMethod(string methodName="", bool? actOrRes = null, byte actResType = 0)
        {
            try
            {
                //if function to call is provided in the values: actOrRes and actResType
                if (actOrRes != null && actResType != 0)
                {
                    
                    if (actOrRes ?? false)//activity
                    {
                        switch (actResType)
                        {
                            case 0:
                                //never 0
                                break;
                            case (int)Enums.Activities.Assignment+1:
                                return AssignmentActivity();
                                break;
                            case (int)Enums.Activities.Forum+1:
                                return ForumActivity();
                                break;
                            case (int) Enums.Activities.Choice+1:
                                return ChoiceActivity();
                                break;
                            
                            case 5:
                                break;
                            case 6:
                                break;
                            case 7:
                                break;

                        }
                    }
                    else//resource
                    {
                        switch (actResType)
                        {
                            case 0:
                                //never 0
                                break;
                            case (int)Enums.Resources.Book+1:
                                return BookResource();
                                break;
                            case (int)Enums.Resources.File+1:
                                return FileResource();
                                break;
                            case (int)Enums.Resources.Folder+1:
                                return FolderResource();
                                break;
                            case (int)Enums.Resources.Label+1:
                                return LabelResource();
                                break;
                            case (int)Enums.Resources.Page+1:
                                return PageResource();
                                break;
                            case (int)Enums.Resources.Url+1:
                                return UrlResource();
                                break;
                        }
                    }
                }
                else if(methodName!="")
                {
                    Type type = typeof(ActivityResourceValues);
                    MethodInfo m = type.GetMethod(methodName);
                    if (m != null)
                    {
                        return m.Invoke(type, null) as ActivityResourceClass;
                    }
                }


                return null;
            }
            catch (AmbiguousMatchException)
            {
                return null;
            }
        }

        //---------------------Activities--------------------------//

        public static ActivityResourceClass AssignmentActivity()// = new ActivityResourceClass()
        {
            var ar = new ActivityResourceClass()
            {
                Name = Enums.Activities.Assignment.ToString()
                ,
                CreateUrl = "~/Views/ActivityResource/Assignments/AssignmentCreate.aspx"
                ,
                ViewUrl = "~/Views/ActivityResource/Assignments/AssignmentView.aspx"
                ,
                IconPath = "~/Content/Icons/ActivityResource/Assignment/document-icon.png"
                ,
                TypePosition = (int)Enums.Activities.Assignment + 1

            };
            return ar;
        }

        public static ActivityResourceClass ForumActivity()// = new ActivityResourceClass()
        {
            var ar = new ActivityResourceClass()
            {
                Name = Enums.Activities.Forum.ToString()
                ,
                CreateUrl = "~/Views/ActivityResource/Forum/ForumCreate.aspx"
                ,
                ViewUrl = "~/Views/ActivityResource/Forum/ForumView.aspx"
                ,
                IconPath = "~/Content/Icons/ActivityResource/Forum/forum_icon.png"
                ,
                TypePosition = (int)Enums.Activities.Forum + 1

            };
            return ar;
        }

        public static ActivityResourceClass ChoiceActivity()// = new ActivityResourceClass()
        {
            var ar = new ActivityResourceClass()
            {
                Name = Enums.Activities.Choice.ToString()
                ,
                CreateUrl = "~/Views/ActivityResource/Choice/ChoiceCreate.aspx"
                ,
                ViewUrl = "~/Views/ActivityResource/Choice/ChoiceView.aspx"
                ,
                IconPath = "~/Content/Icons/ActivityResource/Choice/choice_icon.png"
                ,
                TypePosition = (int)Enums.Activities.Choice + 1

            };
            return ar;
        }


        //--------------------- Resources -------------------------//

        public static ActivityResourceClass BookResource()// = new ActivityResourceClass()
        {
            var ar = new ActivityResourceClass()
            {
                Name = Enums.Resources.Book.ToString(),
                CreateUrl = "~/Views/ActivityResource/Book/BookCreate.aspx",
                ViewUrl = "~/Views/ActivityResource/Book/BookView.aspx",
                IconPath = "~/Content/Icons/ActivityResource/Book/book.png",
                TypePosition = (int)Enums.Resources.Book + 1
            };
            return ar;
        }

        public static ActivityResourceClass FileResource()// = new ActivityResourceClass()
        {
            var ar = new ActivityResourceClass()
            {
                Name = Enums.Resources.File.ToString(),
                CreateUrl = "~/Views/ActivityResource/FileResource/FileResourceCreate.aspx",
                ViewUrl = "~/Views/ActivityResource/FileResource/FileResourceView.aspx",
                IconPath = "~/Content/Icons/ActivityResource/File/any_file_icon.png",
                TypePosition = (int)Enums.Resources.File + 1
            };
            return ar;
        }

        public static ActivityResourceClass FolderResource()// = new ActivityResourceClass()
        {
            var ar = new ActivityResourceClass()
            {
                Name = Enums.Resources.Folder.ToString(),
                CreateUrl = "~/Views/ActivityResource/Folder/FolderCreate.aspx",
                ViewUrl = "~/Views/ActivityResource/Folder/FolderView.aspx",
                IconPath = "~/Content/Icons/ActivityResource/Folder/folder_icon_plain.png",
                TypePosition = (int)Enums.Resources.Folder + 1
            };
            return ar;
        }

        public static ActivityResourceClass LabelResource()// = new ActivityResourceClass()
        {
            var ar = new ActivityResourceClass()
            {
                Name = Enums.Resources.Label.ToString(),
                CreateUrl = "~/Views/ActivityResource/Label/LabelCreate.aspx",
                ViewUrl = "~/Views/ActivityResource/Label/LabelView.aspx",
                IconPath = "~/Content/Icons/ActivityResource/Label/label_icon.png",
                TypePosition = (int)Enums.Resources.Label + 1
            };
            return ar;
        }

        public static ActivityResourceClass PageResource() // = new ActivityResourceClass()
        {
            var ar = new ActivityResourceClass()
            {
                Name = Enums.Resources.Page.ToString(),
                CreateUrl = "~/Views/ActivityResource/Page/PageCreate.aspx",
                ViewUrl = "~/Views/ActivityResource/Page/PageView.aspx",
                IconPath = "~/Content/Icons/ActivityResource/Page/page_icon.png",
                TypePosition = (int)Enums.Resources.Page + 1
            };
            return ar;
        }

        public static ActivityResourceClass UrlResource() // = new ActivityResourceClass()
        {
            var ar = new ActivityResourceClass()
            {
                Name = Enums.Resources.Url.ToString(),
                CreateUrl = "~/Views/ActivityResource/Url/UrlCreate.aspx",
                ViewUrl = "~/Views/ActivityResource/Url/UrlView.aspx",
                IconPath = "~/Content/Icons/ActivityResource/Url/url_with_text.png",
                TypePosition = (int)Enums.Resources.Url + 1
            };
            return ar;
        }

    }
}
