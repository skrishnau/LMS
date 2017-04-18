<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EachFile.ascx.cs" Inherits="One.Views.FileManagement.EachFile" %>

<div style="float: left; z-index: 0; margin: 6px; text-align: center; vertical-align: top; border: 1px solid lightgray;"
    class="tooltip-filelisting list-item-file-listing">
    <span style="text-align: center">
        <%--  --%>
        <asp:LinkButton ID="lnkFile" runat="server" CssClass="link-folder"
            Visible="False" OnClick="lnkFile_OnClick">
            <asp:Image ID="imgFile" runat="server" Height="60" Width="60" />
            <br />
            <asp:Label ID="lblDisplayName" runat="server" Text=""></asp:Label>
        </asp:LinkButton>
    </span>

    <asp:LinkButton ID="lnkFolder" runat="server" CssClass="link-folder"
        Visible="False"
        OnClick="lnkFile_OnClick">
        <%--  Width="130" --%>
        <table style="padding: 0; margin: -3px 0 -10px;" class="link-folder">
            <tr>
                <td style="vertical-align: central">
                    <asp:Image ID="imgFolder" runat="server" Height="26" Width="26" />
                </td>
                <td style="vertical-align: central; text-align: left;">
                    <asp:Label ID="lblDisplayNameFolder" runat="server" Text="" Width="100px"></asp:Label>
                </td>
            </tr>
        </table>
    </asp:LinkButton>



    <%--<br />--%>
    <span class="tooltiptext-filelisting list-item-option" style="background-color: lightblue; text-align: center;">
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
        <asp:Label ID="lblFileNotEditableDisplay" runat="server" Text="Not editable" Visible="False"></asp:Label>
    </span>


    <span style="position: absolute; right: 0%; top: 0%; border: 1px solid darkgray; height: 16px; width: 16px;"
        visible="False"
        runat="server" id="spanPictureIndication">
        <asp:Image ID="imgPictureIndication" runat="server" Height="16" Width="16" ImageUrl="~/Content/Icons/Picture/picture.png" Visible="False" />
    </span>

    <asp:HiddenField ID="hidFileId" runat="server" Value="0" />
    <asp:HiddenField ID="hidFileUrl" runat="server" Value="" />
    <asp:HiddenField ID="hidLocalId" runat="server" Value="0" />
    <asp:HiddenField ID="hidIsFolder" runat="server" Value="False" />
    <asp:HiddenField ID="hidIsConstantAndNotEditable" runat="server" Value="False" />
</div>

