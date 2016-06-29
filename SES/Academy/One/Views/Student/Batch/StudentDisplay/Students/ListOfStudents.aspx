<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="ListOfStudents.aspx.cs" Inherits="One.Views.Student.Batch.StudentDisplay.Students.ListOfStudents" %>

<%@ Register Src="~/Views/Student/Batch/StudentDisplay/Students/StudentListUc.ascx" TagPrefix="uc1" TagName="StudentListUc" %>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <div class="item-section-heading">
        <asp:Label ID="lblProgramBatchName" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <uc1:StudentListUc runat="server" id="StudentListUc" />
    </div>
    <div style="margin: 0 20px 0;">
        Add Student
        <asp:DropDownList ID="ddlAddStudent" runat="server" OnSelectedIndexChanged="ddlAddStudent_SelectedIndexChanged" AutoPostBack="True">
            <Items>
                <asp:ListItem Text="" Value="-1"></asp:ListItem>
                <asp:ListItem Text="Create Student" Value="0"></asp:ListItem>
                <asp:ListItem Text="From File" Value="1"></asp:ListItem>
                <asp:ListItem Text="From System" Value="2"></asp:ListItem>
            </Items>
        </asp:DropDownList>
        <br />
        <br/>
    </div>
    <asp:HiddenField ID="hidBatchId" runat="server" Value="0"/>
    <asp:HiddenField ID="hidProgramBatchId" runat="server" Value="0"/>
</asp:Content>