<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="One.Views.Office.School.View" %>
<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <strong>SchoolName</strong>
    <br/>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Create.aspx">Edit</asp:HyperLink>
    <br/>
    Deail...
</asp:Content>


