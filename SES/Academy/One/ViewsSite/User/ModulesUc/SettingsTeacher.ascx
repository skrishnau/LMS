<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SettingsTeacher.ascx.cs" Inherits="One.ViewsSite.User.ModulesUc.SettingsTeacher" %>


<div class="panel panel-default">
    <%--<strong>Settings</strong>--%>
    <div class="panel-heading">
        <strong>
            <asp:Label ID="label1" runat="server" CssClass="modules-title">Settings</asp:Label>
        </strong>
    </div>
    <%--class="modules-body" style="font-size: 0.9em; font-weight: 500;">--%>
    <div style="" class="list-group">
       <%-- CssClass="link" --%>
        <asp:HyperLink ID="lnkPrograms" runat="server"  CssClass="list-group-item"
            NavigateUrl="~/Views/Structure/">Programs</asp:HyperLink>
        
        <asp:HyperLink ID="lnkBatches" runat="server"  CssClass="list-group-item"
            NavigateUrl="~/Views/Student/">Batches</asp:HyperLink>
        
        <asp:HyperLink ID="lnkCourses" runat="server" CssClass="list-group-item"
            NavigateUrl="~/Views/Course/">Courses</asp:HyperLink>
        
        <%--<span style="margin-left: 10px;">--%>
           <%-- <asp:HyperLink ID="lnkGradeListing" runat="server" 
                NavigateUrl="/Views/Grade/GradeListing.aspx">Grade</asp:HyperLink>--%>
        <%--</span>--%>
        
        <%--<asp:HyperLink ID="HyperLink5" runat="server" CssClass="link"
            NavigateUrl="~/Views/User/List.aspx">Users</asp:HyperLink>
        <br />

        <hr />
        <asp:HyperLink ID="HyperLink8" runat="server" CssClass="link"
            NavigateUrl="~/Views/Academy/List.aspx">Manage Academic year and Sessions</asp:HyperLink>
        <br />--%>
       <%-- <asp:HyperLink ID="HyperLink6" runat="server" CssClass="link"
            NavigateUrl="~/Views/Exam/Exam/ExamsList.aspx">Exams</asp:HyperLink>
        <br />
        <span style="margin-left: 10px;">
            <asp:HyperLink ID="HyperLink9" runat="server" CssClass="link"
                NavigateUrl="~/Views/Exam/ExamType/ExamTypeList.aspx">Exam Types</asp:HyperLink>
        </span>
        <br />--%>

    </div>


    <asp:HiddenField ID="hidUserId" runat="server" Value="0" />
</div>
