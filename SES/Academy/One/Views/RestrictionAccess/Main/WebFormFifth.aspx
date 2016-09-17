<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="WebFormFifth.aspx.cs" Inherits="One.Views.RestrictionAccess.Main.WebFormFifth" %>


<%@ Register Src="~/Views/RestrictionAccess/Main/RestrictionFifth.ascx" TagPrefix="uc1" TagName="RestrictionFifth" %>
<%@ Register Src="~/Views/RestrictionAccess/ChooseRestrictionTypeUC.ascx" TagPrefix="uc1" TagName="ChooseRestrictionTypeUC" %>




<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">

    <div style="margin: 20px;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <uc1:RestrictionFifth runat="server" ID="RestrictionFifth1" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <div id="restrictionchoosedialog"
        style="display: none;">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <uc1:ChooseRestrictionTypeUC runat="server" ID="ChooseRestrictionTypeUC1" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

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

    <script type="text/javascript">

        $("[class*=btnAdd_Restriction]").on("click", function () {

            //var a = document.children;

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
                    dlg.parent().appendTo(jQuery("form:first"));
                    return false;
                });
            });

            return false;
        });


        var parameter1 = Sys.WebForms.PageRequestManager.getInstance();
        parameter1.add_endRequest(function () {
            //jquery code again for working after postback
            $("[class*=btnAdd_Restriction]").on("click", function () {
                __doPostBack('', this.name);
                var dlg = $("#restrictionchoosedialog")
                    .dialog({
                        width: 450,
                        minHeight: 10,
                        minwidth: 10,
                        modal: true,
                        title: "Add_restriction"
                    });
                dlg.parent().appendTo(jQuery("form:first"));
                return false;
            });
        });
    </script>

</asp:Content>





<%-- HEAD CONTENTS --%>
<asp:Content runat="server" ID="contentHead" ContentPlaceHolderID="head">

    <script type="text/javascript" src="../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.min.js"></script>
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
    </style>
</asp:Content>

