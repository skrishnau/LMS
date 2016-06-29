<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DetailItemUc.ascx.cs" Inherits="One.Views.Student.Batch.BatchDetail.DetailItemUc" %>


<div class="item">
    <asp:Panel ID="pnlBody" runat="server">
        <div class="item-heading">
            <asp:LinkButton ID="lblProgramName" runat="server" Text="" OnClick="lblProgramName_Click" CausesValidation="False"></asp:LinkButton>
             </div>
        <div class="item-detail">
            Currently in:
        <asp:Label ID="lblCurrentYear" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblCurrentSubYear" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="lblCourseCompleted" runat="server" Text="Course Completed" BackColor="lightgreen"></asp:Label>
        </div>
    </asp:Panel>
</div>
<div>
    <asp:HiddenField ID="hidProgramBatchId" runat="server" Value="0" />
    <asp:HiddenField ID="hidBatchId" runat="server" Value="0" />
    <asp:HiddenField ID="hidProgramId" runat="server" Value="0" />
</div>

