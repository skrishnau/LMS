<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListSubYearUC.ascx.cs" Inherits="One.Views.Structure.All.UserControls.ListSubYearUC" %>

<%-- style="margin: 3px; padding: 8px " --%>
<div runat="server" id="panel" style="padding: 3px;" class="list-item">
    <asp:Panel ID="pnlBody" runat="server">
        <asp:HyperLink ID="lnkName" runat="server" CssClass="link-dark-bold">
        </asp:HyperLink>
        <span class="list-item-option">
            <asp:HyperLink ID="lnkEdit" runat="server" CssClass="edit-button">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Edit/edit_orange.png" />
            </asp:HyperLink>
            <asp:HyperLink ID="lnkDelete" Visible="False" CssClass="delete-button" runat="server" OnClick="lnkEdit_Click">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/Icons/delete/trash.gif" />
            </asp:HyperLink>
        </span>

        <div class="list-item-description">
            <table>
                <tr runat="server" id="row_currentBatch">
                    <td>
                        <asp:HyperLink ID="lnkCurrentBatch" runat="server">
                            <span style="font-weight: 500; font-style: italic;">Current Batch: </span>&nbsp;
                            <asp:Label ID="lblCurrentBatch" runat="server" Text=" N/A "></asp:Label>
                        </asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <em>
                            <asp:Label ID="lblNoOfCourses" runat="server" Text="0"></asp:Label>
                        </em>
                    </td>
                </tr>
            </table>
        </div>

        <asp:HiddenField ID="hidStructureType" Value="0" runat="server" />
        <asp:HiddenField ID="hidYearId" runat="server" />
        <asp:HiddenField ID="hidSubYearId" runat="server" />

    </asp:Panel>
</div>
