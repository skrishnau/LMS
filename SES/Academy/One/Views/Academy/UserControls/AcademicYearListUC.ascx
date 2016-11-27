<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AcademicYearListUC.ascx.cs" Inherits="One.Views.Academy.UserControls.AcademicYearListUC" %>

<div class="auto-st2" runat="server" ID="divBody">
    
    <%--<asp:Panel ID="pnlBody" runat="server" CssClass="auto-st1">--%>
        <div>
            <span style="font-size: 1.2em; font-weight: 700;">
                <asp:HyperLink ID="lnkAcademicYearName" runat="server" CssClass="link"></asp:HyperLink>
            </span>
            <asp:Label ID="lblActiveIndicator" runat="server" Text=""></asp:Label>
        </div>
        <div style="margin: 1px 5px 2px 20px;">
            <table>
                <tr>
                    <td>Start Date : </td>
                    <td>
                        <asp:Label ID="lblStartDate" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>End Date &nbsp;: 
                    </td>
                    <td>
                        <asp:Label ID="lblEndDate" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <div style="margin-top: 5px;">
                <strong>&nbsp;Sessions
                    <asp:Label ID="lblTitleInSessionsList" runat="server" Text="" ForeColor="darkred"></asp:Label>
                </strong>
                <div style="margin-left: 20px;">
                    <asp:Panel ID="pnlSessionsList" runat="server"></asp:Panel>
                </div>
            </div>
        </div>
    <%--</asp:Panel>--%>
</div>
