<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SingleProgramInListingUC.ascx.cs" Inherits="One.Views.Academy.UserControls.SingleProgramInListingUC" %>

<div style="margin-left: 20px;">
    <asp:HyperLink ID="lnkProgram" runat="server">HyperLink</asp:HyperLink>
    <div>
        <strong>Currently In:</strong>
        &nbsp;<asp:Literal ID="lblCurrentlyIn" runat="server" Text="None"></asp:Literal>
    </div>
</div>