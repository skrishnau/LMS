<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DetailItemUc.ascx.cs" Inherits="One.Views.Student.Batch.BatchDetail.DetailItemUc" %>


<div class="item">
    <asp:Panel ID="pnlBody" runat="server">
        <div style="font-size: 1.1em ; font-weight: 700; padding: 5px; margin: 5px;">
            <asp:HyperLink ID="lnkProgrameName" runat="server" Text="" 
                 ></asp:HyperLink>
        </div>
        <div style="margin-left: 30px; padding-bottom: 10px;">
            No. Of Students:&nbsp;
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

