<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SettingsTeacher.ascx.cs" Inherits="One.ViewsSite.User.ModulesUc.SettingsTeacher" %>


<div class="modules-whole">
    <%--<strong>Settings</strong>--%>
    <div class="modules-heading">
        <strong>
            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="modules-title">Settings</asp:HyperLink>
        </strong>
    </div>
    <%--class="modules-body" style="font-size: 0.9em; font-weight: 500;">--%>
    <div style="font-weight: 500;" class="list-unmargined">
       <%-- CssClass="link" --%>
        <asp:HyperLink ID="HyperLink3" runat="server" 
            NavigateUrl="~/Views/Structure/">Programs</asp:HyperLink>
        
        <asp:HyperLink ID="HyperLink7" runat="server" 
            NavigateUrl="~/Views/Student/">Batches</asp:HyperLink>
        
        <asp:HyperLink ID="HyperLink4" runat="server" 
            NavigateUrl="~/Views/Course/">Courses</asp:HyperLink>
        
        <%--<span style="margin-left: 10px;">--%>
            <asp:HyperLink ID="HyperLink10" runat="server" 
                NavigateUrl="/Views/Grade/GradeListing.aspx">Grade</asp:HyperLink>
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
