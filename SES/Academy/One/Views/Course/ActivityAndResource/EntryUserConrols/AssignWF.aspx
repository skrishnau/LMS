<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="AssignWF.aspx.cs" Inherits="One.Views.Course.ActivityAndResource.EntryUserConrols.AssignWF" %>

<%@ Register Src="~/Views/Course/ActivityAndResource/EntryUserConrols/AssignmentUc.ascx" TagPrefix="uc1" TagName="AssignmentUc" %>

<asp:Content runat="server" ID="headContent" ContentPlaceHolderID="title">
   Assignment
</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
     
    <asp:TextBox ID="datepicker_text" runat="server" ClientIDMode="Static"></asp:TextBox>
    <uc1:AssignmentUc runat="server" ID="AssignmentUc" />
      <script type="text/javascript">
          $(function () {
              $("#datepicker_text").datepicker();
          });
    </script>
</asp:Content>
