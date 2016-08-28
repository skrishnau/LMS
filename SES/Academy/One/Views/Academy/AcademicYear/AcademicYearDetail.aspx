<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="AcademicYearDetail.aspx.cs" Inherits="One.Views.Academy.AcademicYear.AcademicYearDetail" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <div>
        //Academic year Name
    </div>
    <hr />
    <div>
        <table>
            <tr>
                <td class="auto-style1">Start Date</td>
                <td>
                    <asp:Label ID="lblStartDate" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style1">End Date</td>
                <td>
                    <asp:Label ID="lblEndDate" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <div>
            <strong>Programs
            </strong>
            <hr/>
            <asp:Panel ID="pnlAcademicPrograms" runat="server"></asp:Panel>
        </div>
        <br />
        <div>
            <strong> Sessions</strong>
            <hr/>
            <asp:Panel ID="pnlSessions" runat="server"></asp:Panel>
        </div>
        <asp:Button ID="Button1" runat="server" Text="Button" />
    </div>
    <asp:Button ID="Button2" runat="server" Text="Update Academic year/ Session " />
    <asp:Button ID="btnActivate" runat="server" Text="Activate this Academic Year" OnClick="btnActivate_Click" />
    <asp:Button ID="Button4" runat="server" Text="Mark this as completed." />

    <div>
        <br />
        <strong>Sessions </strong>
        <hr />
        List of sessions
    </div>
    <asp:HiddenField ID="hidAcademicYear" runat="server" Value="0" />
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            width: 94px;
        }
    </style>
</asp:Content>

