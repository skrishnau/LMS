<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="CourseListing.aspx.cs" Inherits="One.Views.Structure.CourseListing" %>


<%@ Register Src="~/Views/Structure/All/UserControls/CourseLinkage/CourseListUC.ascx" TagPrefix="uc1" TagName="CourseListUC" %>
<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>



<asp:Content runat="server" ID="content2" ContentPlaceHolderID="Body">
    <uc1:CourseListUC runat="server" ID="CourseListUC" />
</asp:Content>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="title">
    Course listing
</asp:Content>
