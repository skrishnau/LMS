<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="BatchCreate.aspx.cs" Inherits="One.Views.Student.Batch.Create.BatchCreate" %>

<%@ Register Src="~/Views/Student/Batch/Create/CreateBatchUc.ascx" TagPrefix="uc1" TagName="CreateBatchUc" %>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <uc1:CreateBatchUc runat="server" ID="CreateBatchUc" />
</asp:Content>



<asp:Content runat="server" ID="content2" ContentPlaceHolderID="head">
     <script type="text/javascript" src="../../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.min.js"></script>
    <script src="../../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.js" type="text/javascript"></script>
    <link href="../../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.css" rel="stylesheet" type="text/css" />

</asp:Content>