<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DetailItemUc.ascx.cs" Inherits="One.Views.Student.Batch.BatchDetail.DetailItemUc" %>


<div class="list-group-item">
    <asp:Panel ID="pnlBody" runat="server">
        <div >
            <asp:HyperLink ID="lnkProgrameName" runat="server" Text=""  CssClass="list-item-heading"
                 ></asp:HyperLink>
        </div>
        <div class="list-item-description">
            Total Students:&nbsp;
            <asp:HyperLink ID="lblNoOfStudents" runat="server" Text="0"></asp:HyperLink>

            <asp:Label ID="lblCurrentYear" runat="server" ></asp:Label>
            <asp:Label ID="lblCurrentSubYear" runat="server" ></asp:Label>
           
            <asp:Label ID="lblCourseCompleted" runat="server" BackColor="lightgreen"></asp:Label>
        </div>
    </asp:Panel>
</div>
<div>
    <asp:HiddenField ID="hidProgramBatchId" runat="server" Value="0" />
    <asp:HiddenField ID="hidBatchId" runat="server" Value="0" />
    <asp:HiddenField ID="hidProgramId" runat="server" Value="0" />
</div>

