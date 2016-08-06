<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SettingsUc.ascx.cs" Inherits="One.ViewsSite.User.ModulesUc.SettingsUc" %>

<div class="dashboard-modules">
    <%--<strong>Settings</strong>--%>
    <hr />
    <asp:HyperLink ID="HyperLink1" runat="server">Settings</asp:HyperLink>

    <div>
        <asp:HyperLink ID="HyperLink2" runat="server"
             NavigateUrl="~/Views/Office/School/View.aspx">School</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink3" runat="server"
            NavigateUrl="">Programs</asp:HyperLink>
        <br />

        <asp:HyperLink ID="HyperLink4" runat="server"
            NavigateUrl="">Courses</asp:HyperLink>
        <br/>
        <asp:HyperLink ID="HyperLink5" runat="server"
            NavigateUrl="">Users</asp:HyperLink>
        <br/>
    </div>


    <asp:HiddenField ID="hidUserId" runat="server" Value="0" />
</div>
