<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SessionsListingInAYDetailUC.ascx.cs" Inherits="One.Views.Academy.UserControls.SessionsListingInAYDetailUC" %>

<div style="margin-left: 20px;">
    <strong>
        <asp:HyperLink ID="lnkSessionName" runat="server" Text="Label"></asp:HyperLink></strong>
    <div style="margin-left: 20px;">
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

        <asp:Panel ID="pnlSessionPrograms" runat="server" Visible="False">
            <strong>Programs:</strong>
            <hr />
        </asp:Panel>
    </div>
</div>
