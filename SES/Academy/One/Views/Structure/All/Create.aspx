<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="One.Views.Structure.All.Create" %>

<%@ Register Src="~/Views/Structure/All/UserControls/CreateUC.ascx" TagPrefix="uc1" TagName="CreateUC" %>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <uc1:CreateUC runat="server" id="CreateUC" />
</asp:Content>