using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace One.Values
{
    public static class StaticValues
    {
        #region Event Arguments

        public static MessageEventArgs ErrorSaveMessageEventArgs = new MessageEventArgs()
        {
            Message = "Error while saving."
            ,
            TrueFalse = false
            ,
            SaveSuccess = false
        };

        public static MessageEventArgs SuccessSaveMessageEventArgs = new MessageEventArgs()
        {
            Message = "Saving Success"
            ,
            TrueFalse = true
            ,
            SaveSuccess = true

        };
        public static MessageEventArgs EmptyMessageEventArgs = new MessageEventArgs()
        {
            Message = ""
            ,
            TrueFalse = true
        };

        public static MessageEventArgs CancelClickedMessageEventArgs = new MessageEventArgs()
        {
            Message = "Canceled"
            ,
            TrueFalse = false,
            CancelClicked = true
            ,
        };

        public static MessageEventArgs SuccessDeleteMessageEventArgs = new MessageEventArgs()
        {
            Message = "Delete Success"
            ,
            TrueFalse = true
        };

        public static MessageEventArgs ErrorDeleteMessageEventArgs = new MessageEventArgs()
        {
            Message = "Error while Deleting"
            ,
            TrueFalse = false
        };

        public static MessageEventArgs NewCreateMessageEventArgs = new MessageEventArgs()
        {
            Message = "New Clicked"


        };

        #endregion

        #region Expand Button Image Urls

        public static string CollapsedButtonUrl
        {
            get { return "~/Content/Icons/Arrow/arrow_right.png"; }
        }
        public static string ExpandedButtonUrl
        {
            get { return "~/Content/Icons/Arrow/arrow_down.png"; }
        }
        #endregion

        #region Indentation Image Urls

        public static string CircleDot
        {
            get { return "~/Content/Icons/Indent/circle_dot.png"; }
        }
        public static string SquareDot
        {
            get { return "~/Content/Icons/Indent/square_dot.png"; }
        }

        #endregion

        #region Roles

        public static class Roles
        {
            public static string Teacher { get { return "teacher"; } }
            public static string Manager { get { return "manager"; } }
            public static string Student { get { return "student"; } }
            public static string CourseEditor { get { return "course-editor"; } }
            public static string Notifier { get { return "notifier"; } }

            public static string Admin { get { return "admin"; } }
        }

        #endregion


        #region Activities and Resources

        //public TYPE Type { get; set; }

        #endregion

        #region Assignment : : --> GradeType and Submission type

        public static List<ListItem> GradeTypeList = new List<ListItem>()
                {
                    new ListItem("Point","Point"),
                    new ListItem("Scale","Scale")
                };

        public static List<ListItem> SubmissionTypeList = new List<ListItem>()
        {
              new ListItem("Online","Online"),
                    new ListItem("Files","Files")
        };
        #endregion

        public static List<string> TreeLinkImage = new List<string>()
        {
            "",
            "~/Content/Icons/TreeView/three_ends.png",
            "~/Content/Icons/TreeView/up_left.png",
            "~/Content/Icons/TreeView/left_down.png",
            "~/Content/Icons/TreeView/up_down.png"
        };
        public static List<string> TreeLinkImageBlack = new List<string>()
        {
            "",
            "~/Content/Icons/TreeView/three_ends_black.png",
            "~/Content/Icons/TreeView/up_left_black.png",
            "~/Content/Icons/TreeView/left_down_black.png",
            "~/Content/Icons/TreeView/up_down_black.png"
        };
        public static List<string> TreeLinkImageFull = new List<string>()
        {
             "",
            "~/Content/Icons/TreeView/three_ends_full.png",
            "~/Content/Icons/TreeView/up_left_full.png",
            "~/Content/Icons/TreeView/left_down_full.png",
            "~/Content/Icons/TreeView/up_down_full.png"
        };
    }
}