<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RestrictionMainUC.ascx.cs" Inherits="One.Views.RestrictionAccess.Main.RestrictionMainUC" %>



<%@ Register Src="~/Views/RestrictionAccess/Main/RestrictionFifth.ascx" TagPrefix="uc1" TagName="RestrictionFifth" %>
<%@ Register Src="~/Views/RestrictionAccess/ChooseRestrictionTypeUC.ascx" TagPrefix="uc1" TagName="ChooseRestrictionTypeUC" %>


<%--<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">--%>
<asp:HiddenField ID="hidPageKeyForUniqueSession" runat="server" Value=""/>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div style="margin: 20px;">

            <uc1:RestrictionFifth runat="server" ID="RestrictionFifth1" />

        </div>

        <div>
        </div>

        <div id="restrictionchoosedialog"
            style="display: none;">

            <uc1:ChooseRestrictionTypeUC runat="server" ID="ChooseRestrictionTypeUC1" />
        </div>
        <asp:Label ID="myLabel1" ClientIDMode="Static" runat="server" Text="Label"></asp:Label>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button2_Click" />


    </ContentTemplate>
</asp:UpdatePanel>
        <asp:Label ID="lbl23" ClientIDMode="Static" runat="server" Text="Label"></asp:Label>

<script>
    //var prm = Sys.WebForms.PageRequestManager.getInstance(); prm.add_endRequest(function (s, e) { alert('Postback!'); });

</script>


<script type="text/javascript">

    //$("#close").on("click", function () {
    //    $('#restrictionchoosedialog').dialog("close");
    //});
    var dialogOpened = false;
    var myDialog;
    $("[class*=btnAdd_Restriction]").on("click", function () {
        __doPostBack('', this.name);
        var dlg = $("#restrictionchoosedialog")
            .dialog({
                width: 450,
                minHeight: 10,
                minwidth: 10,
                modal: true,
                title: "" + this.name//"Add restriction___"//
                //"Add restriction_"
            });
        dialogOpened = true;
        myDialog = dlg;
        //dlg.dialog('close');
        dlg.parent().appendTo(jQuery("form:first"));

        var parameter = Sys.WebForms.PageRequestManager.getInstance();
        parameter.add_endRequest(function () {
            //jquery code again for working after postback

            $("[class*=btnAdd_Restriction]").on("click", function () {
                __doPostBack('', this.name);
                var dlg = $("#restrictionchoosedialog")
                    .dialog({
                        width: 450,
                        minHeight: 10,
                        minwidth: 10,
                        modal: true,
                        title: "Add restriction_"
                    });
                dialogOpened = true;
                myDialog = dlg;
                //dlg.dialog('close');
                dlg.parent().appendTo(jQuery("form:first"));
                return false;
            });
        });

        return false;
    });


    //var parameter1 = Sys.WebForms.PageRequestManager.getInstance();
    //parameter1.add_endRequest(function () {
    //    //jquery code again for working after postback

    //    $("[class*=btnAdd_Restriction]").on("click", function () {
    //        __doPostBack('', this.name);
    //        var dlg = $("#restrictionchoosedialog")
    //            .dialog({
    //                width: 450,
    //                minHeight: 10,
    //                minwidth: 10,
    //                modal: true,
    //                title: "Add_restriction"
    //            });
    //        dlg.parent().appendTo(jQuery("form:first"));
    //        return false;
    //    });
    //});
</script>
<script type="text/javascript">
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    prm.add_endRequest(function (s, e) {
        if (dialogOpened === true) {
            //e.preventDefault();
            $("#restrictionchoosedialog").dialog('close');
            //var mydlg = document.getElementById("restrictionchoosedialog");
            //var mybtn = document.getElementsByClassName("btnAdd_Restriction");
            //alert('Postback!');

        //    if (mydlg != null) {
                //mydlg.dialog("close");
                dialogOpened = false;
        //    }
        }
    });
    </script>

<%--<script type="text/javascript">
    function showDialogue() {
        alert("this dialogue has been invoked through codebehind.");

    }
</script>--%>
<%--<asp:Label ID="lblJavaScript" runat="server" Text="Label"></asp:Label>--%>

<%--</asp:Content>--%>





<%--  IMPORTANT NOTE *** : tHE BELOW COMMENTED CODE NEED TO BE PLACED IN THE WEBFORM IN WHICH THIS UC IS PLACED --%>
<%-- HEAD CONTENTS --%>
<%--<asp:Content runat="server" ID="contentHead" ContentPlaceHolderID="head">--%>

<%--    <script type="text/javascript" src="../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.min.js"></script>
    <script src="../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.js" type="text/javascript"></script>
    <link href="../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.css" rel="stylesheet" type="text/css" />


    <style type="text/css">
        .img-close:hover {
            background-color: orangered;
        }
        .img-close {
            
        }
        .btnAdd_Restriction {
            width: 80px;
        }

        .restriction-main {
            border: 2px solid darkgray;
            margin: 10px 0;
        }

        .restriction-uc-whole {
            border: 1px solid lightgrey;
            padding: 2px 2px 2px 5px;
            margin: 5px 0;
            vertical-align: central;
            background-color: lightgoldenrodyellow;
        }

        .restriction-body {
            vertical-align: central;
        }

        .display-none {
            display: none;
        }
    </style>--%>

<%--</asp:Content>--%>

<%-- REF script (same as above) --%>
<%--  <script type="text/javascript">

        $("[id*=btnAddRestriction]").on("click", function () {

            var a = document.children;

            var dlg = $("#restrictionchoosedialog")
                .dialog({
                    width: 450,
                    minHeight: 10,
                    minwidth: 10,
                    modal: true,
                    title: +a.length + "_" + this.name
                    //"Add restriction_"
                });
            dlg.parent().appendTo(jQuery("form:first"));
            //__doPostBack('', this.name);

            var parameter = Sys.WebForms.PageRequestManager.getInstance();
            parameter.add_endRequest(function () {
                //jquery code again for working after postback
                $("[id*=btnAddRestriction]").on("click", function () {
                    var dlg = $("#restrictionchoosedialog")
                        .dialog({
                            width: 450,
                            minHeight: 10,
                            minwidth: 10,
                            modal: true,
                            title: "Add restriction"
                        });
                    dlg.parent().appendTo(jQuery("form:first"));
                    //__doPostBack('', this.id);
                    return false;
                });
            });

            return false;
        });


        var parameter1 = Sys.WebForms.PageRequestManager.getInstance();
        parameter1.add_endRequest(function () {
            //jquery code again for working after postback
            $("[id*=btnAddRestriction]").on("click", function () {
                var dlg = $("#restrictionchoosedialog")
                    .dialog({
                        width: 450,
                        minHeight: 10,
                        minwidth: 10,
                        modal: true,
                        title: "Add restriction"
                    });
                dlg.parent().appendTo(jQuery("form:first"));
                //__doPostBack('', this.id);
                return false;
            });
        });
    </script>--%>