<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="CoursesOfGroupListing.aspx.cs" Inherits="One.Views.Course.ListingMain.CoursesOfGroup.CoursesOfGroupListing" %>

<%@ Register Src="~/Views/Course/ListingMain/CoursesOfGroup/ListUc.ascx" TagPrefix="uc1" TagName="ListUc" %>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <uc1:ListUc runat="server" ID="ListUc" />
</asp:Content>