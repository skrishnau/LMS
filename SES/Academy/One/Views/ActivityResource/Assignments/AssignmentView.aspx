<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="AssignmentView.aspx.cs" Inherits="One.Views.ActivityResource.Assignments.AssignmentView" %>

<asp:Content runat="server" ID="bodyid" ContentPlaceHolderID="Body">
    <div>
        <h3 class="heading-of-listing">
            <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
        </h3>
    </div>
    <div class="data-entry-section-body">
        <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label>
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
                    <td>Status</td>
                    <td>
                        <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>Due Date</td>
                    <td>
                        <asp:Label ID="lblDueDate" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>Time Remaining </td>
                    <td>
                        <asp:Label ID="lblTimeRemaining" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Grade</td>
                    <td></td>
                </tr>
            </table>
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_OnClick" />
        </div>
    </div>

    <asp:HiddenField ID="hidAssignmentId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSubjectId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSectionId" runat="server" Value="0" />
</asp:Content>
