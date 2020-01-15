<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="CategoryCreate.aspx.cs" Inherits="One.Views.Course.CategoryCreate" %>

<%@ Register Src="~/Views/Course/Category/Create.ascx" TagPrefix="uc1" TagName="Create" %>

<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>
<asp:Content runat="server" ID="bodyocntent" ContentPlaceHolderID="Body">
    <h3 class="heading-of-create-edit">
        <asp:Label ID="lblCategoryName" runat="server" Text="Course Category edit"></asp:Label>
    </h3>
    <hr />
    <uc1:Create runat="server" ID="Create1" />
</asp:Content>


<asp:Content runat="server" ID="content2" ContentPlaceHolderID="head">
    <link href="../../Content/CSSes/TableStyles.css" rel="stylesheet" />
</asp:Content>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="title">
    Category edit
</asp:Content>
