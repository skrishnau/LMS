<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StudentGradeDispalyUc.ascx.cs" Inherits="One.Views.ActivityResource.Grading.StudentGradeDispalyUc" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>


<table style="width: 98%;">
    <tr>
        <td class="data-type">Status</td>
        <td class="data-value">
            <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr runat="server" id="gradeRow">
        <td class="data-type">Grade</td>
        <td class="data-value">
            <asp:Label ID="lblGrade" runat="server" Text="N/A"></asp:Label>
        </td>
    </tr>
    <tr runat="server" id="remarksRow" visible="False">
        <td class="data-type">Remarks</td>
        <td class="data-value">
            <CKEditor:CKEditorControl ID="lblRemarks" ClientIDMode="Static" runat="server" ToolbarStartupExpanded="False"
                Enabled="False"></CKEditor:CKEditorControl>
            <%--<asp:Literal ID="lblRemarks" runat="server" Text=""></asp:Literal>--%>
        </td>
    </tr>
    <tr>
        <td></td>
        <td>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="200" Height="30" OnClick="btnSubmit_OnClick" />

        </td>
    </tr>

</table>
<%--<div style="text-align: center; padding: 5px;">
</div>--%>
<asp:HiddenField ID="hidReturnUrl" runat="server" Value="" />
