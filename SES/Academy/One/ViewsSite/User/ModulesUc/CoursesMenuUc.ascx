<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CoursesMenuUc.ascx.cs" Inherits="One.ViewsSite.User.ModulesUc.CoursesMenuUc" %>


<div class="module-whole">
    <%--<strong>Settings</strong>--%>
    <div class="modules-heading">
        <strong style="padding: -4px;">
            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="modules-title">Courses</asp:HyperLink>
        </strong>
    </div>
    <%-- class="list-unmargined" --%>
    <div style="font-weight: 500;" class="course-menu">

        <%--<div class="auto-st2">--%>
        <asp:HyperLink ID="lnkCurrent" runat="server" CssClass="course-menu-current-earlier"
            NavigateUrl="~/Views/Courses/?type=current">Current</asp:HyperLink>
        <asp:PlaceHolder ID="pHolderCurrent" runat="server"></asp:PlaceHolder>


        <asp:HyperLink ID="lnkEarlier" runat="server" CssClass="course-menu-current-earlier"
            NavigateUrl="~/Views/Courses/?type=earlier">Earlier</asp:HyperLink>

        <asp:PlaceHolder ID="pHolderEarlier" runat="server"></asp:PlaceHolder>

    </div>

    <asp:HiddenField ID="hidUserId" runat="server" Value="0" />

</div>

<style type="text/css">
    .padding-left-10px {
        padding-left: 10px;
    }

    .padding-left-20px {
        padding-left: 20px;
    }

    .padding-left-30px {
        padding-left: 30px;
    }

    .padding-left-40px {
        padding-left: 40px;
    }
</style>
