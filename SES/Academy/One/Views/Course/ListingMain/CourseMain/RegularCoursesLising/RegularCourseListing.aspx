<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="RegularCourseListing.aspx.cs" Inherits="One.Views.Course.ListingMain.CourseMain.RegularCoursesLising.RegularCourseListing" %>

<%@ Register Src="~/Views/Course/ListingMain/CourseMain/RegularCoursesLising/ListUc.ascx" TagPrefix="uc1" TagName="ListUc" %>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <uc1:ListUc runat="server" id="ListUc" />
</asp:Content>
