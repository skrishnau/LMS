using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Academic.ViewModel;

namespace Academic.DbHelper
{
    public partial class DbHelper
    {
        public static class StaticValues
        {
            //sitemap


            //Errors, always place new error on last of the list
            public static List<string> Error = new List<string>()
                                            {
                                                "",
                                                "You don't have permission to access the page.",


                                            };

            public static string GetEncodedError(int index)
            {
                return Encode(Error[index]);
            }

            //encoding and decoding
            public static string Encode(string text)
            {
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
            }

            public static string Decode(string text)
            {
                return Encoding.UTF8.GetString(Convert.FromBase64String(text));
            }


            public static List<string> ListUserFields()
            {
                return new List<string>()
                {
                    "Username"
                    ,"First name"
                    ,"Middle name"
                    ,"Last name"
                    ,"Email"
                };
            }

            public static List<IdAndName> ListUserFieldConstraints()
            {
                return new List<IdAndName>()
            {
                new IdAndName(){Id=0,Name = "equals to"},
                new IdAndName(){Id=1,Name = "contains"},
                new IdAndName(){Id=2,Name = "does not contain"},
                new IdAndName(){Id=3,Name = "starts with"},
                new IdAndName(){Id=4,Name = "ends with"},
            };
            }

            public static string UserImageDirectory = "~/Content/Images/UserImage/";
            public static string AssignmentDirectory = "~/Content/Images/AssignmentSubmission/";

            public static string FolderIconDirectory = "~/Content/Icons/Folder/folder-icon.png";
            //"~/Content/Icons/ActivityResource/Folder/folder-icon-40x40.png";
            public static string FolderIconLockedDirectory = "~/Content/Icons/Folder/folder-locked-icon.png";
            //"~/Content/Icons/ActivityResource/Folder/folder-icon-40x40-locked.png";

            public static string UserPhotoFolderName = "User Photos";


            //public static Dictionary<string, string> StructureType = new Dictionary<string, string>()
            //{
            //    {Enums.StructureType.Level.ToString(),"lev"}
            //    ,{Enums.StructureType.Faculty.ToString(),"fac"}
            //    ,{Enums.StructureType.Program.ToString(),"pro"}
            //    ,{Enums.StructureType.Year.ToString(),"yr"}
            //    ,{Enums.StructureType.Subyear.ToString(),"syr"}
            //};

            public static class StructureType
            {
                public static string Level { get { return "lev"; } }
                public static string Faculty { get { return "fac"; } }
                public static string Program { get { return "pro"; } }
                public static string Year { get { return "yr"; } }
                public static string Subyear { get { return "syr"; } }
            }



            public static List<string> SchoolType = new List<string>()
            {
                "Graduate",
                "Undergraduate",
                "Higher secondary",
                "Secondary"
            };



            #region File Formats

            public static List<string> VidoFormatList = new List<string>()
        {
            "3g2",
            "3gp",
            "asf",
            "amv",
            "avi",
            "drc"
            ,
            "flv",
            "f4v",
            "f4p",
            "f4a",
            "f4b",
            "gifv"
            ,
            "mp4",
            "m4p",
            "m4v",
            "mpg",
            "mp2",
            "mpeg"
            ,
            "mpe",
            "mpv",
            "mpg",
            "mpeg",
            "m2v",
            "m4v"
            ,
            "mxf",
            "mkv",
            "mng",
            "mov",
            "nsv"
            ,
            "ogv",
            "ogg",
            "qt"
            ,
            "roq",
            "rm",
            "rmvb",
            "svi"
            ,
            "vob",
            "webm",
            "wmv",
            "yuv"
        };

            public static List<string> ImageFormatList = new List<string>()
        {
            "tif",
            "tiff",
            "jpeg",
            "jpg",
            "jif",
            "jfif",
            "gif",
            "jp2",
            "jpx",
            "j2k",
            "j2c",
            "fpx",
            "pcd",
            "png",
        };

            public static string PdfFormat = "pdf";
            public static string TextFormat = "txt";

            public static List<string> WordFormatList = new List<string>()
        {
            "doc",
            "dot",
            "wbk",
            "docx",
            "docm",
            "dotx",
            "dotm",
            "docb"
        };

            public static List<string> ExcelFormatList = new List<string>()
        {
            "xml",
            "xls",
            "xlt",
            "xlm",
            "xlsx",
            "xlsm",
            "xltx",
            "xltm",
            "xlsb",
            "xla",
            "xlam",
            "xll",
            "xlw"
        };

            public static List<string> PowerPointFormatList = new List<string>()
        {
            "ppt",
            "pot",
            "pps",
            "pptx",
            "pptm",
            "potx",
            "ppam",
            "ppsx",
            "ppsm",
            "sldx",
            "sldm"
        };

            #endregion

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
                SaveSuccess = false
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

                public static string Admitter { get { return "admitter"; } }
                public static string Grader { get { return "grader"; } }
            }

            #endregion

            //    #region Activity and Resource Image Urls

            //    public static List<string> ActivityImages = new List<string>()
            //{
            //    "",
            //    "~/Content/Icons/ActivityResource/Assignment/document-icon.png",

            //    ""
            //};
            //    //"~/Content/Icons/ActivityResource/Assignment/assignment_with_yellow_pencil.png",

            //    #endregion

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

            #region Custom TreeView (current tree view, used in programs listing)

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
            public static List<string> IndentationImageFull = new List<string>()
            {
                "",
                "♦",
                "●",
            };

            #endregion

            #region JavaScripts

            /// <summary>
            /// Working script
            /// </summary>
            public static string ScriptRestriction
            {
                get
                {
                    return
                        "<script type=\"text/javascript\"> $(\"[id*=btnAddRestriction]\").on(\"click\", function () { var dlg = $(\"#restrictionchoosedialog\").dialog({ width: 450, minHeight: 10, minwidth: 10, modal: true, title: \"Add restriction\"}); dlg.parent().appendTo(jQuery(\"form:first\")); var parameter = Sys.WebForms.PageRequestManager.getInstance(); parameter.add_endRequest(function () { $(\"[id*=btnAddRestriction]\").on(\"click\", function () {var dlg = $(\"#restrictionchoosedialog\").dialog({width: 450,minHeight: 10,minwidth: 10,modal: true,title: \"Add restriction\"});dlg.parent().appendTo(jQuery(\"form:first\"));return false;});});return false;});var parameter1 = Sys.WebForms.PageRequestManager.getInstance();parameter1.add_endRequest(function () {$(\"[id*=btnAddRestriction]\").on(\"click\", function () {var dlg = $(\"#restrictionchoosedialog\").dialog({width: 450,minHeight: 10,minwidth: 10,modal: true,title: \"Add restriction\"});dlg.parent().appendTo(jQuery(\"form:first\"));return false;});});</script>";

                }
            }


            public static string GetScriptForResctrictionAdd(string buttonId, string dialogId, string title)
            {
                var newScript =
                    //"<script type=\"text/javascript\"> $(\"[id*=btnAddRestriction]\").on(\"click\", function () { var dlg = $(\"#restrictionchoosedialog\").dialog({ width: 450, minHeight: 10, minwidth: 10, modal: true, title: \"Add restriction\"}); dlg.parent().appendTo(jQuery(\"form:first\")); var parameter = Sys.WebForms.PageRequestManager.getInstance(); parameter.add_endRequest(function () { $(\"[id*=btnAddRestriction]\").on(\"click\", function () {var dlg = $(\"#restrictionchoosedialog\").dialog({width: 450,minHeight: 10,minwidth: 10,modal: true,title: \"Add restriction\"});dlg.parent().appendTo(jQuery(\"form:first\"));return false;});});return false;});var parameter1 = Sys.WebForms.PageRequestManager.getInstance();parameter1.add_endRequest(function () {$(\"[id*=btnAddRestriction]\").on(\"click\", function () {var dlg = $(\"#restrictionchoosedialog\").dialog({width: 450,minHeight: 10,minwidth: 10,modal: true,title: \"Add restriction\"});dlg.parent().appendTo(jQuery(\"form:first\"));return false;});});</script>";

                        "<script type=\"text/javascript\"> " +
                        "$(\"[id*=" + buttonId +
                        "]\").on(\"click\", function () { " +

                        "var dlg = $(\"#" + dialogId + "\")" +
                        ".dialog({ width: 450, minHeight: 10, minwidth: 10," +
                        " modal: true, title: \"" + title + "\"}); " +
                        "dlg.parent().appendTo(jQuery(\"form:first\")); " +
                        "var parameter = Sys.WebForms.PageRequestManager.getInstance(); " +
                        "parameter.add_endRequest(function () { " +

                        "$(\"[id*=" + buttonId +
                        "]\").on(\"click\", function () {" +

                        "var dlg = $(\"#" + dialogId + "\")" +
                        ".dialog({width: 450,minHeight: 10,minwidth: 10," +
                        "modal: true,title: \"" + title + "\"});" +
                        "dlg.parent().appendTo(jQuery(\"form:first\"));" +
                        "return false;});});return false;});" +
                        "var parameter1 = Sys.WebForms.PageRequestManager.getInstance();" +
                        "parameter1.add_endRequest(function () {" +

                        "$(\"[id*=" + buttonId +
                        "]\").on(\"click\", function () {" +

                        "var dlg = $(\"#" + dialogId + "\")" +
                        ".dialog({width: 450,minHeight: 10,minwidth: 10," +
                        "modal: true,title: \"" + title + "\"});" +
                        "dlg.parent().appendTo(jQuery(\"form:first\"));" +
                        "return false;});});</script>";
                return newScript;

                var script =
                        "<script type=\"text/javascript\"> $(\"[id*=" +
                        buttonId +
                        "]\").on(\"click\", function () { var dlg = $(\"#" +
                        dialogId +
                        "\").dialog({ width: 450, minHeight: 10, minwidth: 10, modal: true, title: \"" +
                        title +
                        "\"}); dlg.parent().appendTo(jQuery(\"form:first\")); " +
                        "var parameter = Sys.WebForms.PageRequestManager.getInstance();" +
                        " parameter.add_endRequest(function () { $(\"[id*=" +
                        buttonId +
                        "]\").on(\"click\", function () {var dlg = $(\"#" +
                        dialogId +
                        "\").dialog({width: 450,minHeight: 10,minwidth: 10,modal: true,title: \""
                        + title +
                        "\"});dlg.parent().appendTo(jQuery(\"form:first\"));return false;});});return false;});" +
                        "var parameter1 = Sys.WebForms.PageRequestManager.getInstance();" +
                        "parameter1.add_endRequest(function () {$(\"[id*="
                        + buttonId +
                        "]\").on(\"click\", function () {var dlg = $(\"#"
                        + dialogId +
                        "\").dialog({width: 450,minHeight: 10,minwidth: 10,modal: true,title: \""
                        + title +
                        "\"});dlg.parent().appendTo(jQuery(\"form:first\"));return false;});});</script>";
                return script;
            }


            #endregion




            public static int MaximimNumberOfTimesToCheckForSameFileName = 5;
            public static string IconsOfFilesLocation = "~/Content/Icons/File/";
            public static string CourseFilesLocation = "~/Content/Images/CourseFileResource/";
            public static string SchoolFileLocation = "~/Content/Images/SchoolFileResource/";

            public static string PrivateFiesLocation = "~/Content/Files/";



            #region Activity and Resource Image Urls




            //public static List<string> ActivityImages = new List<string>()
            //    {
            //        "",
            //        "~/Content/Icons/ActivityResource/Assignment/document-icon.png",

            //        ""
            //        ,""
            //        ,""
            //         ,""
            //         ,""
            //         ,""
            //         ,""
            //         ,""
            //         ,""

            //    };

            //public static List<string> ResourceImages = new List<string>()
            //{
            //    "",
            //    "~/Content/Icons/ActivityResource/Book/book.png",
            //    "~/Content/Icons/ActivityResource/File/any_file_icon.png"
            //    ,"~/Content/Icons/ActivityResource/Folder/folder_icon_plain.png"
            //    ,"~/Content/Icons/ActivityResource/Label/label_icon.png"
            //    ,"~/Content/Icons/ActivityResource/Page/page_icon.png"
            //    ,"~/Content/Icons/ActivityResource/Url/url_with_text.png"

            //};
            //"~/Content/Icons/ActivityResource/Assignment/assignment_with_yellow_pencil.png",

            #endregion

            //public enum Resources
            //{
            //    Book
            //    ,
            //    File
            //        ,
            //    Folder
            //        ,
            //    Label
            //        ,
            //    Page
            //        , Url
            //}

            public static List<string> SecurityQuestion()
            {
                return new List<string>()
                {
                    "",
                    //"What is the last name of the teacher who gave you your first failing grade?"
                    //,
                    "What is your first grade favourite teacher name?"
                    ,
                    "What was the name of your elementary / primary school?"
                    ,
                    "What time of the day were you born? (hh:mm)"
                    ,
                    "What is your pet name?"
                    ,
                    "What is your... ? "

                };
            }


            public enum FilesFrom
            {
                Server, Private
            }

            public static class WebPagePath
            {
                public static string CourseDetailPage(int subjectId, int sectionId = 0)
                {
                    return "~/Views/Course/Section/?SubId="
                        + subjectId + (sectionId == 0 ? "" : "#section_" + sectionId);
                }
            }

        }
    }
}
