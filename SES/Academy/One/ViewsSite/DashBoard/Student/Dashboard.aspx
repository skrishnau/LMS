<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ViewsSite/DashBoard/StudentMaster.Master" CodeBehind="Dashboard.aspx.cs" Inherits="One.ViewsSite.DashBoard.Student.Dashboard" %>
<%--ViewsSite/DashBoard/Student/StudentMaster.Master--%>
<%@ Register Src="~/ViewsSite/DashBoard/Student/CourseOverView/LstUc.ascx" TagPrefix="uc1" TagName="LstUc" %>


<%--<%@ Register Src="~/ViewsSite/DashBoard/Student/courseUC.ascx" TagPrefix="uc1" TagName="courseUC" %>--%>

<%--<%@ Reference Control="~/ViewsSite/DashBoard/Student/courseUC.ascx" %>--%>

<asp:Content runat="server" ID="bodyTitle" ContentPlaceHolderID="BodyTitle">
    <h3>COURSE OVERVIEW  </h3>
</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <uc1:LstUc runat="server" id="LstTree" />
</asp:Content>
