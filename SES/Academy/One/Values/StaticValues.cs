using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace One.Values
{
    //public static class StaticValues
    //{
        //#region File Formats

        //public static List<string> VidoFormatList = new List<string>()
        //{
        //    "3g2",
        //    "3gp",
        //    "asf",
        //    "amv",
        //    "avi",
        //    "drc"
        //    ,
        //    "flv",
        //    "f4v",
        //    "f4p",
        //    "f4a",
        //    "f4b",
        //    "gifv"
        //    ,
        //    "mp4",
        //    "m4p",
        //    "m4v",
        //    "mpg",
        //    "mp2",
        //    "mpeg"
        //    ,
        //    "mpe",
        //    "mpv",
        //    "mpg",
        //    "mpeg",
        //    "m2v",
        //    "m4v"
        //    ,
        //    "mxf",
        //    "mkv",
        //    "mng",
        //    "mov",
        //    "nsv"
        //    ,
        //    "ogv",
        //    "ogg",
        //    "qt"
        //    ,
        //    "roq",
        //    "rm",
        //    "rmvb",
        //    "svi"
        //    ,
        //    "vob",
        //    "webm",
        //    "wmv",
        //    "yuv"
        //};

        //public static List<string> ImageFormatList = new List<string>()
        //{
        //    "tif",
        //    "tiff",
        //    "jpeg",
        //    "jpg",
        //    "jif",
        //    "jfif",
        //    "gif",
        //    "jp2",
        //    "jpx",
        //    "j2k",
        //    "j2c",
        //    "fpx",
        //    "pcd",
        //    "png",
        //};

        //public static string PdfFormat = "pdf";
        //public static string TextFormat = "txt";

        //public static List<string> WordFormatList = new List<string>()
        //{
        //    "doc",
        //    "dot",
        //    "wbk",
        //    "docx",
        //    "docm",
        //    "dotx",
        //    "dotm",
        //    "docb"
        //};

        //public static List<string> ExcelFormatList = new List<string>()
        //{
        //    "xml",
        //    "xls",
        //    "xlt",
        //    "xlm",
        //    "xlsx",
        //    "xlsm",
        //    "xltx",
        //    "xltm",
        //    "xlsb",
        //    "xla",
        //    "xlam",
        //    "xll",
        //    "xlw"
        //};

        //public static List<string> PowerPointFormatList = new List<string>()
        //{
        //    "ppt",
        //    "pot",
        //    "pps",
        //    "pptx",
        //    "pptm",
        //    "potx",
        //    "ppam",
        //    "ppsx",
        //    "ppsm",
        //    "sldx",
        //    "sldm"
        //};

        //#endregion

        //#region Event Arguments

        //public static MessageEventArgs ErrorSaveMessageEventArgs = new MessageEventArgs()
        //{
        //    Message = "Error while saving."
        //    ,
        //    TrueFalse = false
        //    ,
        //    SaveSuccess = false
        //};

        //public static MessageEventArgs SuccessSaveMessageEventArgs = new MessageEventArgs()
        //{
        //    Message = "Saving Success"
        //    ,
        //    TrueFalse = true
        //    ,
        //    SaveSuccess = true

        //};
        //public static MessageEventArgs EmptyMessageEventArgs = new MessageEventArgs()
        //{
        //    Message = ""
        //    ,
        //    TrueFalse = true
        //};

        //public static MessageEventArgs CancelClickedMessageEventArgs = new MessageEventArgs()
        //{
        //    Message = "Canceled"
        //    ,
        //    TrueFalse = false,
        //    CancelClicked = true
        //    ,
        //};

        //public static MessageEventArgs SuccessDeleteMessageEventArgs = new MessageEventArgs()
        //{
        //    Message = "Delete Success"
        //    ,
        //    TrueFalse = true
        //};

        //public static MessageEventArgs ErrorDeleteMessageEventArgs = new MessageEventArgs()
        //{
        //    Message = "Error while Deleting"
        //    ,
        //    TrueFalse = false
        //};

        //public static MessageEventArgs NewCreateMessageEventArgs = new MessageEventArgs()
        //{
        //    Message = "New Clicked"


        //};

        //#endregion

        //#region Expand Button Image Urls

        //public static string CollapsedButtonUrl
        //{
        //    get { return "~/Content/Icons/Arrow/arrow_right.png"; }
        //}
        //public static string ExpandedButtonUrl
        //{
        //    get { return "~/Content/Icons/Arrow/arrow_down.png"; }
        //}
        //#endregion

        //#region Indentation Image Urls

        //public static string CircleDot
        //{
        //    get { return "~/Content/Icons/Indent/circle_dot.png"; }
        //}
        //public static string SquareDot
        //{
        //    get { return "~/Content/Icons/Indent/square_dot.png"; }
        //}

        //#endregion

        //#region Roles

        //public static class Roles
        //{
        //    public static string Teacher { get { return "teacher"; } }
        //    public static string Manager { get { return "manager"; } }
        //    public static string Student { get { return "student"; } }
        //    public static string CourseEditor { get { return "course-editor"; } }
        //    public static string Notifier { get { return "notifier"; } }

        //    public static string Admin { get { return "admin"; } }
        //}

        //#endregion

        //#region Activity and Resource Image Urls

        //public static List<string> ActivityImages = new List<string>()
        //{
        //    "",
        //    "~/Content/Icons/ActivityResource/Assignment/document-icon.png",

        //    ""
        //};
        //    //"~/Content/Icons/ActivityResource/Assignment/assignment_with_yellow_pencil.png",

        //#endregion

        //#region Activities and Resources

        ////public TYPE Type { get; set; }

        //#endregion

        //#region Assignment : : --> GradeType and Submission type

        //public static List<ListItem> GradeTypeList = new List<ListItem>()
        //        {
        //            new ListItem("Point","Point"),
        //            new ListItem("Scale","Scale")
        //        };

        //public static List<ListItem> SubmissionTypeList = new List<ListItem>()
        //{
        //      new ListItem("Online","Online"),
        //            new ListItem("Files","Files")
        //};
        //#endregion

        //public static List<string> TreeLinkImage = new List<string>()
        //{
        //    "",
        //    "~/Content/Icons/TreeView/three_ends.png",
        //    "~/Content/Icons/TreeView/up_left.png",
        //    "~/Content/Icons/TreeView/left_down.png",
        //    "~/Content/Icons/TreeView/up_down.png"
        //};
        //public static List<string> TreeLinkImageBlack = new List<string>()
        //{
        //    "",
        //    "~/Content/Icons/TreeView/three_ends_black.png",
        //    "~/Content/Icons/TreeView/up_left_black.png",
        //    "~/Content/Icons/TreeView/left_down_black.png",
        //    "~/Content/Icons/TreeView/up_down_black.png"
        //};
        //public static List<string> TreeLinkImageFull = new List<string>()
        //{
        //     "",
        //    "~/Content/Icons/TreeView/three_ends_full.png",
        //    "~/Content/Icons/TreeView/up_left_full.png",
        //    "~/Content/Icons/TreeView/left_down_full.png",
        //    "~/Content/Icons/TreeView/up_down_full.png"
        //};

        ///// <summary>
        ///// Working script
        ///// </summary>
        //public static string ScriptRestriction
        //{
        //    get
        //    {
        //        return
        //            "<script type=\"text/javascript\"> $(\"[id*=btnAddRestriction]\").on(\"click\", function () { var dlg = $(\"#restrictionchoosedialog\").dialog({ width: 450, minHeight: 10, minwidth: 10, modal: true, title: \"Add restriction\"}); dlg.parent().appendTo(jQuery(\"form:first\")); var parameter = Sys.WebForms.PageRequestManager.getInstance(); parameter.add_endRequest(function () { $(\"[id*=btnAddRestriction]\").on(\"click\", function () {var dlg = $(\"#restrictionchoosedialog\").dialog({width: 450,minHeight: 10,minwidth: 10,modal: true,title: \"Add restriction\"});dlg.parent().appendTo(jQuery(\"form:first\"));return false;});});return false;});var parameter1 = Sys.WebForms.PageRequestManager.getInstance();parameter1.add_endRequest(function () {$(\"[id*=btnAddRestriction]\").on(\"click\", function () {var dlg = $(\"#restrictionchoosedialog\").dialog({width: 450,minHeight: 10,minwidth: 10,modal: true,title: \"Add restriction\"});dlg.parent().appendTo(jQuery(\"form:first\"));return false;});});</script>";

        //    }
        //}

        //public static string GetScriptForResctrictionAdd(string buttonId, string dialogId, string title)
        //{
        //    var newScript =
        //            //"<script type=\"text/javascript\"> $(\"[id*=btnAddRestriction]\").on(\"click\", function () { var dlg = $(\"#restrictionchoosedialog\").dialog({ width: 450, minHeight: 10, minwidth: 10, modal: true, title: \"Add restriction\"}); dlg.parent().appendTo(jQuery(\"form:first\")); var parameter = Sys.WebForms.PageRequestManager.getInstance(); parameter.add_endRequest(function () { $(\"[id*=btnAddRestriction]\").on(\"click\", function () {var dlg = $(\"#restrictionchoosedialog\").dialog({width: 450,minHeight: 10,minwidth: 10,modal: true,title: \"Add restriction\"});dlg.parent().appendTo(jQuery(\"form:first\"));return false;});});return false;});var parameter1 = Sys.WebForms.PageRequestManager.getInstance();parameter1.add_endRequest(function () {$(\"[id*=btnAddRestriction]\").on(\"click\", function () {var dlg = $(\"#restrictionchoosedialog\").dialog({width: 450,minHeight: 10,minwidth: 10,modal: true,title: \"Add restriction\"});dlg.parent().appendTo(jQuery(\"form:first\"));return false;});});</script>";
                     
        //            "<script type=\"text/javascript\"> " +
        //            "$(\"[id*=" + buttonId + 
        //            "]\").on(\"click\", function () { " +

        //            "var dlg = $(\"#"+dialogId+"\")" +
        //            ".dialog({ width: 450, minHeight: 10, minwidth: 10," +
        //            " modal: true, title: \""+title+"\"}); " +
        //            "dlg.parent().appendTo(jQuery(\"form:first\")); " +
        //            "var parameter = Sys.WebForms.PageRequestManager.getInstance(); " +
        //            "parameter.add_endRequest(function () { " +

        //            "$(\"[id*=" + buttonId +
        //            "]\").on(\"click\", function () {" +

        //            "var dlg = $(\"#"+dialogId+"\")" +
        //            ".dialog({width: 450,minHeight: 10,minwidth: 10," +
        //            "modal: true,title: \""+title+"\"});" +
        //            "dlg.parent().appendTo(jQuery(\"form:first\"));" +
        //            "return false;});});return false;});" +
        //            "var parameter1 = Sys.WebForms.PageRequestManager.getInstance();" +
        //            "parameter1.add_endRequest(function () {" +

        //            "$(\"[id*=" + buttonId + 
        //            "]\").on(\"click\", function () {" +

        //            "var dlg = $(\"#"+dialogId+"\")" +
        //            ".dialog({width: 450,minHeight: 10,minwidth: 10," +
        //            "modal: true,title: \""+title+"\"});" +
        //            "dlg.parent().appendTo(jQuery(\"form:first\"));" +
        //            "return false;});});</script>";
        //    return newScript;
            
        //    var script =
        //            "<script type=\"text/javascript\"> $(\"[id*="+
        //            buttonId+
        //            "]\").on(\"click\", function () { var dlg = $(\"#"+
        //            dialogId+
        //            "\").dialog({ width: 450, minHeight: 10, minwidth: 10, modal: true, title: \""+
        //            title+
        //            "\"}); dlg.parent().appendTo(jQuery(\"form:first\")); " +
        //            "var parameter = Sys.WebForms.PageRequestManager.getInstance();" +
        //            " parameter.add_endRequest(function () { $(\"[id*="+
        //            buttonId+
        //            "]\").on(\"click\", function () {var dlg = $(\"#"+
        //            dialogId+
        //            "\").dialog({width: 450,minHeight: 10,minwidth: 10,modal: true,title: \""
        //            +title+
        //            "\"});dlg.parent().appendTo(jQuery(\"form:first\"));return false;});});return false;});" +
        //            "var parameter1 = Sys.WebForms.PageRequestManager.getInstance();" +
        //            "parameter1.add_endRequest(function () {$(\"[id*="
        //            +buttonId+
        //            "]\").on(\"click\", function () {var dlg = $(\"#"
        //            +dialogId+
        //            "\").dialog({width: 450,minHeight: 10,minwidth: 10,modal: true,title: \""
        //            +title+
        //            "\"});dlg.parent().appendTo(jQuery(\"form:first\"));return false;});});</script>";
        //    return script;
        //}


        //public static int MaximimNumberOfTimesToCheckForSameFileName = 5;
        //public static string IconsOfFilesLocation = "~/Content/Icons/File/";
        //public static string CourseFilesLocation = "~/Content/Images/CourseFileResource/";
    //}
}