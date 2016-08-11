<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListUC.ascx.cs" Inherits="One.Views.Structure.All.UserControls.ListUC" %>

<div runat="server" ID="panel" style="border: solid lightgray 1px; margin: 0 25px;">
    <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
    <asp:HiddenField ID="hidStructureId" Value="0" runat="server" />
    <asp:PlaceHolder ID="pnlSubControls" runat="server"></asp:PlaceHolder>
</div>