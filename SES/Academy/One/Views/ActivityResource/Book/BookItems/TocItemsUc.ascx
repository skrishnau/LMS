<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TocItemsUc.ascx.cs" Inherits="One.Views.ActivityResource.Book.BookItems.TocItemsUc" %>

<asp:Panel ID="pnlMain" runat="server">
    <span runat="server" id="main_span" class="link">
        <asp:LinkButton ID="lnkChapter" runat="server"
            CssClass="link"
            OnClick="lnkChapter_Click">LinkButton</asp:LinkButton>
        &nbsp;
    <span runat="server" id="edit_panel" visible="False">
        <asp:HyperLink ID="lnkAddChapter" runat="server">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/ActivityResource/Book/Add.png" />
        </asp:HyperLink>
        <asp:LinkButton ID="lnkIn" runat="server" OnClick="lnk_Click">
            <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/Icons/Arrow/arrow_fat_right.png" />
        </asp:LinkButton>
        <asp:LinkButton ID="lnkUp" runat="server" OnClick="lnk_Click">
            <asp:Image ID="Image3" runat="server" ImageUrl="~/Content/Icons/Arrow/arrow_fat_up.png" />
        </asp:LinkButton>
        <asp:LinkButton ID="lnkDown" runat="server" OnClick="lnk_Click">
            <asp:Image ID="Image4" runat="server" ImageUrl="~/Content/Icons/Arrow/arrow_fat_down.png" />
        </asp:LinkButton>
        <asp:LinkButton ID="lnkOut" runat="server" OnClick="lnk_Click">
            <asp:Image ID="Image5" runat="server" ImageUrl="~/Content/Icons/Arrow/arrow_fat_left.png" />
        </asp:LinkButton>
    </span>

        <asp:HiddenField ID="hidBookId" runat="server" Value="0" />
        <asp:HiddenField ID="hidChapterId" runat="server" Value="0" />
    </span>
</asp:Panel>
