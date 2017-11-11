<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileManagementMenuUc.ascx.cs" Inherits="One.ViewsSite.User.ModulesUc.FileManagementMenuUc" %>


<%-- module-whole --%>
<div class="panel panel-default">
    <%-- modules-heading --%>
    <div class="panel-heading">
        <strong style="padding: -4px;">
            <asp:Label ID="label1" runat="server" CssClass="modules-title">File Management</asp:Label>
        </strong>
    </div>
    <%-- list-unmargined --%>
    <div style="" class="list-group">

        <asp:HyperLink ID="lnkPrivate" runat="server" CssClass="list-group-item"
            NavigateUrl="~/Views/FileManagement/?folId=0&type=private">Private</asp:HyperLink>
        <asp:HyperLink ID="lnkServer" runat="server" Visible="False" CssClass="list-group-item"
            NavigateUrl="~/Views/FileManagement/?folId=0&type=server">Server</asp:HyperLink>
    </div>
</div>
