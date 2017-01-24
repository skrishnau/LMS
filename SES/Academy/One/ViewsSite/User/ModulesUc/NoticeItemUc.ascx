<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NoticeItemUc.ascx.cs" Inherits="One.ViewsSite.User.ModulesUc.NoticeItemUc" %>

<asp:HyperLink ID="lnkNotice" runat="server">
    <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
    <asp:Image ID="imgNewIndicator" runat="server" ImageUrl="~/Content/Icons/Exclamation/exclamation.png" />
    <span style="display: block; font-size: 0.8em;">
        <asp:Label ID="lblPostedOn" runat="server" Text="Label"></asp:Label>
    </span>
</asp:HyperLink>