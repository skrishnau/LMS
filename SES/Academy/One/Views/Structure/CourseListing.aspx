<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="CourseListing.aspx.cs" Inherits="One.Views.Structure.CourseListing" %>


<%@ Register Src="~/Views/Structure/All/UserControls/CourseLinkage/CourseListUC.ascx" TagPrefix="uc1" TagName="CourseListUC" %>

<asp:Content runat="server" ID="content2" ContentPlaceHolderID="Body">
    <uc1:CourseListUC runat="server" ID="CourseListUC" />
</asp:Content>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="title">
    Course listing
</asp:Content>
