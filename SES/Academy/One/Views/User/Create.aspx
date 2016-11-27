<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="One.Views.User.Create" %>

<%@ Register Src="~/Views/User/UserCreateUC.ascx" TagPrefix="uc1" TagName="UserCreateUC" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <h3 class="heading-of-create-edit">New User
    </h3>
    <hr />
    <br />

    <div>
        <uc1:UserCreateUC runat="server" ID="UserCreateUC" />
    </div>
    <ajaxToolkit:AsyncFileUpload ID="AsyncFileUpload1" runat="server" />
</asp:Content>

<asp:Content runat="server" ID="headcontene" ContentPlaceHolderID="head">
      <script type="text/javascript" src="../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.min.js"></script>
    <script src="../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.js" type="text/javascript"></script>
    <link href="../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.css" rel="stylesheet" type="text/css" />


    <link href="../All_Resusable_Codes/Dialog/CustomDialogStyles.css" rel="stylesheet" />
</asp:Content>

<asp:Content runat="server" ID="titleContnet" ContentPlaceHolderID="title">
    New User
</asp:Content>
