<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="One.Views.Student.Create.Student" %>

<%@ Register Src="~/Views/Student/Create/StudentCreateUc.ascx" TagPrefix="uc1" TagName="StudentCreateUc" %>



<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Body">
    <uc1:StudentCreateUc runat="server" id="StudentCreateUc" />
</asp:Content>
