<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChoiceOptionsCreate.ascx.cs" Inherits="One.Views.ActivityResource.Choice.ChoiceOptionsCreate" %>

<div>

    <asp:Label ID="lblOption" runat="server" Text="Option"></asp:Label>
    <asp:TextBox ID="txtOption" runat="server"></asp:TextBox>

    <asp:Label ID="lblLimit" runat="server" Text="Limit"></asp:Label>
    <asp:TextBox ID="txtLimit" runat="server" Enabled="False"></asp:TextBox>

    &nbsp;
    <asp:LinkButton ID="lnkRemove" runat="server" OnClick="lnkRemove_Click">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Close/cross_8x20_center.png" />
    </asp:LinkButton>
    <asp:HiddenField ID="hidChoiceId" runat="server" Value="0" />
    <asp:HiddenField ID="hidOptionId" runat="server" Value="0" />
    <asp:HiddenField ID="hidPageKey" runat="server" Value="" />
    <asp:HiddenField ID="hidPosition" runat="server" Value="0" />

</div>
