<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserGradeDisplayUc.ascx.cs" Inherits="One.Views.ActivityResource.Grading.UserGradeDisplayUc" %>

<tr class="auto-st2-no-margin">
    <td>
        <asp:HyperLink ID="lnkImage" runat="server">
            <asp:Image ID="imgImage" runat="server" />
        </asp:HyperLink>
    </td>
    <td>
        <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
    </td>
    <td>
        <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>
    </td>
    <td>
        <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
    </td>
    <td>
        <asp:HyperLink ID="lnkSubmission" runat="server" Text="">
            <asp:CheckBox ID="chkSubmitted" runat="server" Enabled="False" Visible="False" />
            <asp:Label ID="lblSubmissionStatus" runat="server" Text="Label"></asp:Label>
        </asp:HyperLink>
    </td>
    <td>
        <asp:HyperLink ID="lnkGrade" runat="server" Text="">
            <asp:Label ID="lblGrade" runat="server" Text=""></asp:Label>
        </asp:HyperLink>

        <%--<asp:HiddenField ID="hidActivityId" runat="server" Value="0" />--%>
        <asp:HiddenField ID="hidSubjectId" runat="server" Value="0" />
        <asp:HiddenField ID="hidSectionId" runat="server" Value="0" />
        <%--<asp:HiddenField ID="hidUserClassId" runat="server" Value="0" />--%>
        <%--<asp:HiddenField ID="hidActivityResourceId" runat="server" Value="0" />--%>
    </td>

</tr>
