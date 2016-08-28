<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SessionsListingInAYDetailUC.ascx.cs" Inherits="One.Views.Academy.UserControls.SessionsListingInAYDetailUC" %>

<div>
    <div>
        <table>
            <tr>
                <td>Start Date</td>
                <td>
                    <asp:Label ID="lblStartDate" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td>End Date</td>
                <td>
                    <asp:Label ID="lblEndDate" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
    </div>

    <br />

    <div>
        <strong>Programs:</strong>
        <hr />
        <asp:Panel ID="pnlSessionPrograms" runat="server"></asp:Panel>
    </div>
</div>
