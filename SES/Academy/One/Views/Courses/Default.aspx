<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ViewsSite/User/UserMaster.Master" CodeBehind="Default.aspx.cs" Inherits="One.Views.Courses.Default" %>

<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">

    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>

<%@ Register Src="~/ViewsSite/DashBoard/Student/CourseOverView/LstUc.ascx" TagPrefix="uc1" TagName="LstUc" %>
<asp:Content runat="server" ID="contnet1" ContentPlaceHolderID="Body">
    <h3 class="heading-of-display">
        <asp:Label ID="lblHeading" runat="server" Text="Label"></asp:Label>
    </h3>
    <hr />
    <uc1:LstUc runat="server" ID="LstUc1" />
</asp:Content>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <%--<link href="../../Content/CSSes/TableStyles.css" rel="stylesheet" />--%>
</asp:Content>

<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="title">
    <asp:Literal ID="lblTitle" runat="server"></asp:Literal>
</asp:Content>
