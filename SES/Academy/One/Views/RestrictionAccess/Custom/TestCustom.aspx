<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="TestCustom.aspx.cs" Inherits="One.Views.RestrictionAccess.Custom.TestCustom" %>

<%@ Register Src="~/Views/RestrictionAccess/Custom/RestrictionUC.ascx" TagPrefix="uc1" TagName="RestrictionUC" %>

<asp:Content runat="server" ID="headcontent" ContentPlaceHolderID="head">
    <link href="../../All_Resusable_Codes/Dialog/CustomDialogStyles.css" rel="stylesheet" />
    <link href="RestrictionStyles.css" rel="stylesheet" />
</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
        <uc1:RestrictionUC runat="server" ID="RestrictionUC" />
</asp:Content>
