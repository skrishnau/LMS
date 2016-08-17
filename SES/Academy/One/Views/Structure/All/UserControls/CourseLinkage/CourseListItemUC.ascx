<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CourseListItemUC.ascx.cs" Inherits="One.Views.Structure.All.UserControls.CourseLinkage.CourseListItemUC" %>


<div style="padding: 5px 0 5px 5px;">
    <span>
        <asp:CheckBox ID="chkbox" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="True" />
    </span>
    &nbsp;
    <span style="font-weight: 500; width: 100%;" >
        <asp:LinkButton ID="lblName" runat="server" CssClass="no-underline" OnClick="lblName_Click">
        </asp:LinkButton>
    </span>
    &nbsp;
    (
        <asp:Label ID="lblCode" runat="server" Text='<%# Eval("Code") %>' />
    )
    
    
    <asp:HiddenField ID="hidCourseId" Value="0" runat="server" />
    <asp:HiddenField ID="hidCourseName" Value="" runat="server" />
</div>
