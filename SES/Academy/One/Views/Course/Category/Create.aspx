<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="One.Views.Course.Category.Create1" %>

<%@ Register Src="~/Views/Course/Category/Create.ascx" TagPrefix="uc1" TagName="Create" %>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <uc1:Create runat="server" id="Create" />
</asp:Content>
