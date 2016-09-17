<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="TestOfUC.aspx.cs" Inherits="One.Views.RestrictionAccess.Main.TestOfUC" %>

<%@ Register Src="~/Views/RestrictionAccess/Main/RestrictionMainUC.ascx" TagPrefix="uc1" TagName="RestrictionMainUC" %>



<asp:Content runat="server" ID="cnt1" ContentPlaceHolderID="Body">

    <uc1:RestrictionMainUC runat="server" ID="RestrictionMainUC" />

</asp:Content>

<asp:Content runat="server" ID="headcnt" ContentPlaceHolderID="head">

    <script type="text/javascript" src="../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.min.js"></script>
    <script src="../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.js" type="text/javascript"></script>
    <link href="../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.css" rel="stylesheet" type="text/css" />

    <link href="../../All_Resusable_Codes/Dialog/CustomDialogStyles.css" rel="stylesheet" />

    <style type="text/css">
        .res_type_item {
            display: inline-block;
        }

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
