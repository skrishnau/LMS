<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RestrictionUC.ascx.cs" Inherits="One.Views.RestrictionAccess.Custom.RestrictionUC" %>



<%--<%@ Register Src="~/Views/RestrictionAccess/Main/RestrictionFifth.ascx" TagPrefix="uc1" TagName="RestrictionFifth" %>--%>
<%--<%@ Register Src="~/Views/RestrictionAccess/ChooseRestrictionTypeUC.ascx" TagPrefix="uc1" TagName="ChooseRestrictionTypeUC" %>--%>
<%@ Register Src="~/Views/RestrictionAccess/Custom/EachRestriction.ascx" TagPrefix="uc1" TagName="EachRestriction" %>


<asp:HiddenField ID="hidPageKeyForUniqueSession" runat="server" Value="" />

<%--<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">--%>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div style="margin: 10px 20px 0; ">

            <%--<uc1:RestrictionFifth runat="server" ID="RestrictionFifth1" />--%>
            <uc1:EachRestriction runat="server" ID="EachRestriction1" />
        </div>
        
        <asp:HiddenField ID="hidActivityResourceType" runat="server" Value="0"/>
        <asp:HiddenField ID="hidActivityOrResource" runat="server" Value="False"/>
        
        <asp:HiddenField ID="hidActivityOrResourceId" runat="server" Value="0"/>
        <asp:HiddenField ID="hidSectionId" runat="server" Value="0"/>


        <%--  <div id="restrictionchoosedialog" style="display: none;">
            <uc1:ChooseRestrictionTypeUC runat="server" ID="ChooseRestrictionTypeUC1" />
        </div>--%>
        <script type="text/javascript">
            $('[class*=date_text_box]').unbind();
            $('[class*=date_text_box]').datepicker();
        </script>
    </ContentTemplate>
</asp:UpdatePanel>

<%-- Second commented block one is current  --%>
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

<%--<script type="text/javascript">

    //$("[class*=res_type_choose_item")
    //    .on("click",
    //        function () {
    //            $("#restrictionchoosedialog").dialog("close");
    //        });
    $("#close").on("click", function () {
        $('#restrictionchoosedialog').dialog("close");

    });
    //click(function () {
    //    $('#restrictionchoosedialog').dialog("close");
    //});

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
            //$("[class*=res_type_choose_item")
            //    .on("click",
            //        function () {
            //            $("#restrictionchoosedialog").dialog("close");
            //        });
            $("#close").on("click", function () {
                $('#restrictionchoosedialog').dialog("close");

            });

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
        $("#close").on("click", function () {
            $('#restrictionchoosedialog').dialog("close");

        });
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
</script>--%>

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

