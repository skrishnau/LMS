<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="ExamClass.aspx.cs" Inherits="One.Views.Exam.Exam.ExamClass" %>

<asp:Content runat="server" ID="headContent" ContentPlaceHolderID="head">
    <style type="text/css">
        .margin-top-bottom-little {
            margin: 6px 0;
        }
    </style>

</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <div>
        <div style="text-align: center;">
            <strong style="font-size: 1.3em;">
                <asp:Label ID="lblExamName" runat="server" Text=""></asp:Label>
            </strong>
            <br />
            <%-- e.g. YearI, SemI | 010-Computer --%>
            <asp:Label ID="lblClassName" runat="server" Text=""></asp:Label>
            <hr />
        </div>

        <div>
            <strong>Courses in the Exam</strong>
            <hr />
            <div style="margin-left: 20px;">
                <asp:Panel ID="pnlSubjects" runat="server"></asp:Panel>
            </div>
        </div>
        <br />
        <div style="vertical-align: central;">
            <strong>Students appearing in the exam</strong>
            <hr />
            <asp:Panel ID="pnlStudents" runat="server"></asp:Panel>

        </div>
        <asp:HiddenField ID="hidExamOfClassId" runat="server" Value="0" />
    </div>
</asp:Content>
