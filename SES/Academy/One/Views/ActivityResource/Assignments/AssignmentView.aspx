<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="AssignmentView.aspx.cs" Inherits="One.Views.ActivityResource.Assignments.AssignmentView" %>

<%--<%@ Register Src="~/Views/ActivityResource/Assignments/TeacherViewUc.ascx" TagPrefix="uc1" TagName="TeacherViewUc" %>
<%@ Register Src="~/Views/ActivityResource/Grading/GradeUc.ascx" TagPrefix="uc1" TagName="GradeUc" %>--%>


<asp:Content runat="server" ID="bodyid" ContentPlaceHolderID="Body">
    <h3 class="heading-of-create-edit">
        <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
    </h3>
    <div class="data-entry-section-body">
        <asp:Label ID="lblDescription" runat="server" Text="" Visible="True"></asp:Label>
    </div>
    <br />
    <div class="data-entry-section-body">
        <div class="data-entry-section-heading">
            Submission
            <hr />
        </div>
        <div class="data-entry-section-body">
            <table>
                <tr>
                    <td class="data-type">Due Date</td>
                    <td class="data-value">
                        <asp:Label ID="lblDueDate" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td class="data-type">Time Remaining </td>
                    <td class="data-value">
                        <asp:Label ID="lblTimeRemaining" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br/>
        <div class="data-entry-section-heading">
            Grades
         <hr />
        </div>

        <asp:Panel ID="pnlGradeList" runat="server"></asp:Panel>
    </div>

    <asp:HiddenField ID="hidAssignmentId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSubjectId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSectionId" runat="server" Value="0" />
    <asp:HiddenField ID="hidUserClassId" runat="server" Value="0" />
</asp:Content>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="title">
    <asp:Literal ID="lblPageTitle" runat="server" Text="Assignment view"></asp:Literal>
</asp:Content>

<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="head">
    <link href="../../../Content/CSSes/TableStyles.css" rel="stylesheet" />
</asp:Content>
