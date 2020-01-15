<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SettingsUc.ascx.cs" Inherits="One.ViewsSite.User.ModulesUc.SettingsUc" %>

<%-- module-whole --%>
<div class="panel panel-default">
    <%--<strong>Settings</strong>  "modules-heading--%>
    <div class="panel-heading">
        <strong style="padding: -4px;">
            <asp:Label ID="label1" runat="server" CssClass="modules-title">Setup</asp:Label>
        </strong>
    </div>
    <%--class="modules-body" font-size: 0.9em; --%>
    <%-- list-unmargined --%>

    <div class="list-group">

        <%--<div class="auto-st2">--%>
        <%-- <asp:HyperLink ID="lnkBatch" runat="server"
            NavigateUrl="~/Views/Student/">Batches</asp:HyperLink>--%>
        <%--</div>--%>
        <%--<br />--%>
        <%--<div class="auto-st2">--%>
        <asp:HyperLink ID="lnkAcademicSession" runat="server" CssClass="list-group-item"
            NavigateUrl="~/Views/Academy/">Academic</asp:HyperLink>
        <%--</div>--%>

        <%--<div class="auto-st2">--%>
        <asp:HyperLink ID="lnkCourse" runat="server" CssClass="list-group-item"
            NavigateUrl="~/Views/Course/">Courses</asp:HyperLink>
        <%--</div>--%>
        <%--<br />--%>
        <asp:HyperLink ID="lnkPrograms" runat="server" CssClass="list-group-item"
            NavigateUrl="~/Views/Structure/">Programs</asp:HyperLink>
        <%--<div class="auto-st2">--%>

        <%--</div>--%>


        <asp:HyperLink ID="lnkUsers" runat="server" CssClass="list-group-item"
            NavigateUrl="~/Views/User/List.aspx">Users</asp:HyperLink>
        <%--<hr />--%>
        <%--<strong>Settings</strong>--%>
        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="list-group-item"
            NavigateUrl="~/Views/Grade/GradeListing.aspx">
                    Grade types
        </asp:HyperLink>


        <%--<div class="auto-st2">--%>

        <%--</div>--%>

        <%--<span style="margin-left: 10px;">--%>
        <%--   <div class="auto-st2">
            <asp:HyperLink ID="HyperLink10" runat="server" CssClass="link"
                NavigateUrl="/Views/Grade/GradeListing.aspx"> Grade</asp:HyperLink>
        </div>
        
         <div class="auto-st2">
            <asp:HyperLink ID="HyperLink2" runat="server" CssClass="link"
                NavigateUrl="~/Views/Office/School/View.aspx"> College</asp:HyperLink>
        </div>--%>
        <%--</span>--%>

        <%-- <asp:HyperLink ID="HyperLink6" runat="server" CssClass="link"
            NavigateUrl="~/Views/Exam/Exam/ExamsList.aspx">Exams</asp:HyperLink>
        <br />
        <span style="margin-left: 10px;">
            <asp:HyperLink ID="HyperLink9" runat="server" CssClass="link"
                NavigateUrl="~/Views/Exam/ExamType/ExamTypeList.aspx">Exam Types</asp:HyperLink>
        </span>
        <br />--%>
        <asp:HiddenField ID="hidUserId" runat="server" Value="0" />
    </div>
</div>
