<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListItemUc.ascx.cs" Inherits="One.Views.Course.ListingMain.CourseMain.ListItemUc" %>

<div class="item">
    <div class="item-heading">  <%-- -course-group-heading  --%>
        <asp:LinkButton ID="lblGroupName" runat="server" Text="" OnClick="lblGroupName_Click"></asp:LinkButton>
        <br/>
        <div style="margin: 2px 20px 4px; font-size: 0.4em;">
            <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label>
        </div>
    </div>
   
    <div class="item-summary"> <%-- -course-group-description --%>
        <asp:Label ID="lblCourseCount" runat="server" Text=""></asp:Label>
        <%--<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>--%>
    </div>
    <asp:HiddenField ID="hidSubjectGroupId" runat="server" Value="0" />
    <asp:HiddenField ID="hidYearId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSubYearId" runat="server" Value="0" />
</div>
