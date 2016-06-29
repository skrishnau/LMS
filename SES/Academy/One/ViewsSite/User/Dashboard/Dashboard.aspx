<%@ Page Language="C#" MasterPageFile="../UserMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="One.ViewsSite.User.Dashboard.Dashboard" %>

<%@ Register Src="~/ViewsSite/DashBoard/Student/CourseOverView/LstUc.ascx" TagPrefix="uc1" TagName="LstUc" %>



<asp:Content runat="server" ID="bodyTitle" ContentPlaceHolderID="BodyTitle">
    <h3>COURSE OVERVIEW  </h3>
</asp:Content>

<asp:Content runat="server" ID="contentBody" ContentPlaceHolderID="Body">
    <uc1:LstUc runat="server" ID="LstUc1" />
</asp:Content>
