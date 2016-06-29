<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="test_uc_delete_on_unused.ascx.cs" Inherits="One.Views.Course.Section.Master.test_uc_delete_on_unused" %>
<div>
    <p>
        <asp:PlaceHolder ID="pnlActAndRes" runat="server"></asp:PlaceHolder>

        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">LinkButton</asp:LinkButton>
    </p>
    <div>
        <asp:HiddenField ID="hidId" runat="server" Value="0"/>
        <asp:HiddenField ID="HiddenField2" runat="server" />
    </div>
</div>
