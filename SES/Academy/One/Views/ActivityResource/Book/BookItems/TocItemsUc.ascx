<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TocItemsUc.ascx.cs" Inherits="One.Views.ActivityResource.Book.BookItems.TocItemsUc" %>

<span runat="server"  ID="main_span">
    <asp:LinkButton ID="lnkChapter" runat="server" CssClass="block" OnClick="lnkChapter_Click">LinkButton</asp:LinkButton>
    <asp:HiddenField ID="hidChapterId" runat="server" Value="0"/>
</span>
<br />