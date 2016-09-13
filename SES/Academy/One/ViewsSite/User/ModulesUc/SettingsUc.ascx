<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SettingsUc.ascx.cs" Inherits="One.ViewsSite.User.ModulesUc.SettingsUc" %>

<div class="modules-whole">
    <%--<strong>Settings</strong>--%>
    <div class="modules-heading">
        <strong>
            <asp:HyperLink ID="HyperLink1" runat="server">Settings</asp:HyperLink>
        </strong>
    </div>
    <div class="modules-body">
        <asp:HyperLink ID="HyperLink2" runat="server"
            NavigateUrl="~/Views/Office/School/View.aspx">School</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink3" runat="server"
            NavigateUrl="~/Views/Structure/All/Master/List.aspx">Programs</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink7" runat="server"
            NavigateUrl="~/Views/Student/Batch/ListBatch.aspx">Batches</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink4" runat="server"
            NavigateUrl="~/Views/Course/List.aspx">Courses</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink5" runat="server"
            NavigateUrl="~/Views/User/List.aspx">Users</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink6" runat="server"
            NavigateUrl="~/Views/Exam/Exam/ExamsList.aspx">Exams</asp:HyperLink>
        <br />
        <span style="margin-left: 10px;">
            <asp:HyperLink ID="HyperLink9" runat="server"
                NavigateUrl="~/Views/Exam/ExamType/ExamTypeList.aspx">Exam Types</asp:HyperLink>
        </span>
        <br />
        <hr />
        <asp:HyperLink ID="HyperLink8" runat="server"
            NavigateUrl="~/Views/Academy/List.aspx">Manage Academic year and Sessions</asp:HyperLink>


    </div>


    <asp:HiddenField ID="hidUserId" runat="server" Value="0" />
</div>
