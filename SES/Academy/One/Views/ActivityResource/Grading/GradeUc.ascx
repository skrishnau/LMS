<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GradeUc.ascx.cs" Inherits="One.Views.ActivityResource.Grading.GradeUc" %>

<div class="data-entry-section-heading">
    Grades
    <hr />
</div>
<div class="data-entry-section-body" >

    <asp:Panel ID="pnlGradeList" runat="server"></asp:Panel>


    <asp:HiddenField ID="hidActivityResourceId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSubjectId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSectionId" runat="server" Value="0" />
</div>
