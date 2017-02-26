<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileManagementMenuUc.ascx.cs" Inherits="One.ViewsSite.User.ModulesUc.FileManagementMenuUc" %>



<div class="module-whole">
    <%--<strong>Settings</strong>--%>
    <div class="modules-heading">
        <strong style="padding: -4px;">
            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="modules-title">File Management</asp:HyperLink>
        </strong>
    </div>
    <div style="font-weight: 500;" class="list-unmargined">

        <%--<div class="auto-st2">--%>
        <asp:HyperLink ID="lnkPrivate" runat="server"
            NavigateUrl="~/Views/FileManagement/?folId=0&type=private">Private</asp:HyperLink>
        <asp:HyperLink ID="lnkServer" runat="server" Visible="False"
            NavigateUrl="~/Views/FileManagement/?folId=0&type=server">Server</asp:HyperLink>
    </div>
</div>
