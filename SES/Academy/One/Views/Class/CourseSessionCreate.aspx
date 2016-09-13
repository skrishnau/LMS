<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="CourseSessionCreate.aspx.cs" Inherits="One.Views.Class.CourseSessionCreate" %>

<%@ Register Src="~/Views/Class/CourseSessionCreateUC.ascx" TagPrefix="uc1" TagName="CourseSessionCreateUC" %>
<asp:Content runat="server" ID="haedContent" ContentPlaceHolderID="head">
    <link rel="stylesheet" href="../../DatePickerJquery/jquery-ui-1.9.2.custom.css" />
    <script src="../../DatePickerJquery/jquery-1.8.3.js"></script>
   
</asp:Content>
 
<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <div>
        <uc1:CourseSessionCreateUC runat="server" ID="CourseSessionCreateUC1" />
    </div>
</asp:Content>