<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EachClass.ascx.cs" Inherits="One.Views.ActivityResource.Class.EachClass" %>

<div>
    <asp:Label ID="lblClassName" runat="server" Text="Label"></asp:Label>
    <asp:LinkButton ID="lnkRemove" runat="server" OnClick="lnkRemove_Click">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Close/cross_8x14_top.png"/>
    </asp:LinkButton>
    <asp:HiddenField ID="hidClassId" runat="server" Value="0"/>
</div>