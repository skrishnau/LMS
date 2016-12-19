﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SettingsUc.ascx.cs" Inherits="One.ViewsSite.User.ModulesUc.SettingsUc" %>

<div class="module-whole">
    <%--<strong>Settings</strong>--%>
    <div class="modules-heading">
        <strong>
            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="modules-title">Settings</asp:HyperLink>
        </strong>
    </div>
    <%--class="modules-body" font-size: 0.9em; --%>
    <div style="font-weight: 500;">

        <div class="auto-st2">
            <asp:HyperLink ID="HyperLink7" runat="server" CssClass="link"
                NavigateUrl="~/Views/Student/"> Batches</asp:HyperLink>
        </div>
        <%--<br />--%>
        <div class="auto-st2">
            <asp:HyperLink ID="HyperLink4" runat="server" CssClass="link"
                NavigateUrl="~/Views/Course/"> Courses</asp:HyperLink>
        </div>
        <%--<br />--%>

        <div class="auto-st2">
            <asp:HyperLink ID="HyperLink5" runat="server" CssClass="link"
                NavigateUrl="~/Views/User/List.aspx"> Users</asp:HyperLink>
        </div>

        <div class="auto-st2">
            <asp:HyperLink ID="HyperLink8" runat="server" CssClass="link"
                NavigateUrl="~/Views/Academy/List.aspx"> Manage Academic year and Sessions</asp:HyperLink>
        </div>

        <hr />
        <%--<strong>Settings</strong>--%>
       


        <div class="auto-st2">
            <asp:HyperLink ID="HyperLink3" runat="server" CssClass="link"
                NavigateUrl="~/Views/Structure/All/Master/List.aspx"> Programs</asp:HyperLink>
        </div>

        <%--<span style="margin-left: 10px;">--%>
        <div class="auto-st2">
            <asp:HyperLink ID="HyperLink10" runat="server" CssClass="link"
                NavigateUrl="/Views/Grade/GradeListing.aspx"> Grade</asp:HyperLink>
        </div>
        
         <div class="auto-st2">
            <asp:HyperLink ID="HyperLink2" runat="server" CssClass="link"
                NavigateUrl="~/Views/Office/School/View.aspx"> College</asp:HyperLink>
        </div>
        <%--</span>--%>

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
