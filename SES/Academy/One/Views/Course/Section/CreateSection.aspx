<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="CreateSection.aspx.cs" Inherits="One.Views.Course.Section.CreateSection" %>

<%@ Register Src="~/Views/Course/Section/CreateSectionUc.ascx" TagPrefix="uc1" TagName="CreateSectionUc" %>
<asp:Content runat="server" ID="headContentt1" ContentPlaceHolderID="head">
    <meta http-equiv='cache-control' content='no-cache'/>
    <meta http-equiv='expires' content='0'/>
    <meta http-equiv='pragma' content='no-cache'/>
</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <uc1:CreateSectionUc runat="server" ID="CreateSectionUc1" />
</asp:Content>
