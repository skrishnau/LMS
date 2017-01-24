<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CoursesMenuUc.ascx.cs" Inherits="One.ViewsSite.User.ModulesUc.CoursesMenuUc" %>


<div class="module-whole">
    <%--<strong>Settings</strong>--%>
    <div class="modules-heading">
        <strong style="padding: -4px;">
            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="modules-title">Courses</asp:HyperLink>
        </strong>
    </div>
    <div style="font-weight: 500;" class="list-unmargined">

        <%--<div class="auto-st2">--%>
        <asp:HyperLink ID="lnkCurrent" runat="server"
            NavigateUrl="~/Views/Courses/?type=current">&nbsp;&nbsp; Current</asp:HyperLink>
         <asp:HyperLink ID="lnkEarlier" runat="server"
            NavigateUrl="~/Views/Courses/?type=earlier">&nbsp;&nbsp; Earlier</asp:HyperLink>
    </div>
</div>
