<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EachFile.ascx.cs" Inherits="One.Views.FileManagement.EachFile" %>

<div style="float: left; margin: 10px; z-index: 0; text-align: center;" class="tooltip list-item">
    <span style="text-align: center">
        <asp:LinkButton ID="lnkFile" runat="server" CssClass="link-dark" OnClick="lnkFile_OnClick">
            <asp:Image ID="imgFile" runat="server" Height="60" Width="60" />
            <br />
            <asp:Label ID="lblDisplayName" runat="server" Text=""></asp:Label>
        </asp:LinkButton>

    </span>
    <br />
    <span class="tooltiptext list-item-option" style="background-color: lightblue; text-align: center;">
        <asp:LinkButton ID="lnkDownload" runat="server">
            <asp:Image ID="imgDownload" runat="server"
                ImageUrl="~/Content/Icons/Download/download_icon_13x13.png" />
        </asp:LinkButton>

        <asp:LinkButton ID="lnkRename" runat="server" OnClick="lnkRename_OnClick">
            <asp:Image ID="imgRename" runat="server"
                ImageUrl="~/Content/Icons/Rename/rename_icon_13x13.png" />
        </asp:LinkButton>
        <asp:LinkButton ID="lnkDelete" runat="server" OnClick="lnkDelete_OnClick">
            <asp:Image ID="imgDelete" runat="server"
                ImageUrl="~/Content/Icons/delete/trash.gif" />
        </asp:LinkButton>
        <asp:LinkButton ID="lnkMove" runat="server">
            <asp:Image ID="imgMove" runat="server"
                ImageUrl="~/Content/Icons/Move/move1_13x13.png" />
        </asp:LinkButton>
        <asp:LinkButton ID="lnkCopy" runat="server">
            <asp:Image ID="imgCopy" runat="server"
                ImageUrl="~/Content/Icons/Copy/copy-content.png" />
        </asp:LinkButton>
    </span>
    <asp:HiddenField ID="hidFileId" runat="server" Value="0" />
    <asp:HiddenField ID="hidFileUrl" runat="server" Value="" />
    <asp:HiddenField ID="hidLocalId" runat="server" Value="0" />
    <asp:HiddenField ID="hidIsFolder" runat="server" Value="False" />
</div>

