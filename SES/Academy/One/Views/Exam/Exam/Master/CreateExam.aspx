<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="CreateExam.aspx.cs" Inherits="One.Views.Exam.Exam.Master.CreateExam" %>

<%@ Register Src="~/Views/Exam/Exam/Create/CreateExamUc.ascx" TagPrefix="uc1" TagName="CreateExamUc" %>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <uc1:CreateExamUc runat="server" id="CreateExamUc" />
</asp:Content>
