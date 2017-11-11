<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CoursesMenuUc.ascx.cs" Inherits="One.ViewsSite.User.ModulesUc.CoursesMenuUc" %>

<%-- module-whole --%>
<div class="panel panel-default">
    <%--<strong>Settings</strong>--%>
    <%-- modules-heading --%>
    <div class="panel-heading">
        <%--<strong style="padding: -4px;">--%>
            <asp:Label ID="label1" runat="server" CssClass="">Courses</asp:Label>
        <%--</strong>--%>
    </div>
    <%-- list-unmargined --%>
    <div style="" class="list-group">

        <%--<div class="auto-st2">  CssClass="course-menu-current-earlier"--%>
        <%-- CssClass="roboto-medium" --%>
        <asp:HyperLink ID="lnkCurrent" runat="server"  CssClass="list-group-item"
            NavigateUrl="~/Views/Courses/?type=current">Current</asp:HyperLink>
        <asp:PlaceHolder ID="pHolderCurrent" runat="server"></asp:PlaceHolder>


        <%--<asp:HyperLink ID="lnkEarlier" runat="server" 
            NavigateUrl="~/Views/Courses/?type=earlier">Earlier</asp:HyperLink>

        <asp:PlaceHolder ID="pHolderEarlier" runat="server"></asp:PlaceHolder>--%>

    </div>

    <asp:HiddenField ID="hidUserId" runat="server" Value="0" />

</div>


