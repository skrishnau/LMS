<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="CoursesList.aspx.cs" Inherits="One.Views.Structure.All.Master.CoursesList" %>

<%@ Register Src="~/Views/Structure/All/UserControls/CourseLinkage/CourseListUC.ascx" TagPrefix="uc1" TagName="CourseListUC" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <uc1:CourseListUC runat="server" ID="CourseListUC" />
</asp:Content>

