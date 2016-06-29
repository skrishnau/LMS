<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="ListExams.aspx.cs" Inherits="One.Views.Exam.Exam.Master.ListExams" %>

<%@ Register Src="~/Views/Exam/Exam/ExamList/ListUc.ascx" TagPrefix="uc1" TagName="ListUc" %>

<asp:Content runat="server" ID="leftContent" ContentPlaceHolderID="BodyInnerLeft">
    <ul>
        <li>
            <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Views/Exam/Exam/Master/CreateExam.aspx" 
                runat="server">Create</asp:HyperLink>
        </li>
    </ul>
</asp:Content>
<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <uc1:ListUc runat="server" ID="ListUc1" />
</asp:Content>