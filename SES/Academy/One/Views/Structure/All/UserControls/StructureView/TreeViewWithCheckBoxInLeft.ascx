<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TreeViewWithCheckBoxInLeft.ascx.cs" Inherits="One.Views.Structure.All.UserControls.StructureView.TreeViewWithCheckBoxInLeft" %>

<div >
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlTree" runat="server"></asp:Panel>
            <asp:HiddenField ID="hidBatchId" runat="server" Value="0"/>
        </ContentTemplate>
    </asp:UpdatePanel>

</div>
