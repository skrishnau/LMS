<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AcademicYearListUC.ascx.cs" Inherits="One.Views.Academy.UserControls.AcademicYearListUC" %>

<div class="list-item-body" runat="server" id="divBody">

    <%--<asp:Panel ID="pnlBody" runat="server" CssClass="auto-st1">--%>
    <div>
        <asp:HyperLink ID="lnkAcademicYearName" runat="server" CssClass="list-item-heading"></asp:HyperLink>
        <asp:Image ID="imgActive" runat="server"
            Width="10" Height="10"
            ImageUrl="~/Content/Icons/Stop/Stop_10px.png"
            Visible="False" />


        <span class="list-item-option">
            <asp:HyperLink ID="lnkEdit" runat="server" CssClass="link">
                <asp:Image ID="Image1" runat="server" ToolTip="Edit" ImageUrl="~/Content/Icons/Edit/edit_orange.png" />
            </asp:HyperLink>
            <asp:HyperLink ID="lnkDelete" runat="server" CssClass="link">
                <asp:Image ID="Image2" runat="server" ToolTip="Delete" ImageUrl="~/Content/Icons/delete/trash.png" />
            </asp:HyperLink>
        </span>
        <%--<asp:Label ID="lblActiveIndicator" runat="server" Text=""></asp:Label>--%>
    </div>
   <%-- <div style="margin: 1px 5px 2px 20px;">
        <table>
            <tr>
                <td>Start Date :</td>
                <td>
                </td>
            </tr>
            <tr>
                <td>End Date &nbsp;:</td>
                <td>
                </td>
            </tr>
          
        </table>
    </div>--%>
    
    <div>
    <div class="data-entry-section-body">
        <table>
            <tr>
                <%--class="auto-style1"--%>
                <td class="data-type">Start Date</td>
                <td class="data-value">
                    <asp:Label ID="lblStartDate" runat="server" Text=""></asp:Label>
                    <%--<asp:Label ID="Label1" runat="server" Text=""></asp:Label>--%></td>
            </tr>
            <tr>
                <td class="data-type">End Date</td>
                <td class="data-value">
                    <asp:Label ID="lblEndDate" runat="server" Text=""></asp:Label>
                    <%--<asp:Label ID="Label2" runat="server" Text=""></asp:Label>--%>
                </td>
            </tr>
            <tr>
                <td class="data-type">Batch admitted in this year</td>
                <td class="data-value">
                    <asp:HyperLink ID="lnkBatch" runat="server"></asp:HyperLink>
                </td>
            </tr>
            <%--  <tr>
                <td class="data-type">Programs</td>
                <td class="data-value">
                    <asp:Label ID="lblPrograms" runat="server" Text=""></asp:Label>
                </td>
            </tr>--%>
        </table>


        <div class="data-entry-section">
            <div class="data-entry-section-heading">
                Sessions
                <hr />
            </div>

            <div class="data-entry-section-body">
                <asp:Panel ID="pnlSessions" runat="server"></asp:Panel>
            </div>
        </div>
    </div>
        
    </div>

    <%--</asp:Panel>--%>
</div>
