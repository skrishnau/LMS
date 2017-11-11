<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EachFile.ascx.cs" Inherits="One.Views.FileManagement.EachFile" %>

<%-- border: 1px solid lightgray; --%>
<div style="float: left; z-index: 0; margin: 10px; padding:  7px 7px 10px; text-align: center; vertical-align: top; box-shadow: 0px 0px 5px #aaaaaa;"
    class="list-item-file-listing">
    <asp:Panel ID="pnlTooltipBody" runat="server">

        <span style="text-align: center">
            <%--  --%>

            <asp:LinkButton ID="lnkFile" runat="server" CssClass="link-folder"
                Visible="False" OnClick="lnkFile_OnClick">
                <asp:Image ID="imgFile" runat="server" Height="40" Width="40" />
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
                        &nbsp;
                        <asp:Label ID="lblDisplayNameFolder" runat="server" Text="" Width="100px"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:LinkButton>


        <%-- Rename/rename_icon_13x13.png --%>
        <%--<br />--%>

        <asp:Panel ID="pnlToolTipText" runat="server">
            <%--<span class="list-item-option" style="background-color: #f1f1f1; text-align: center;">--%>
                <asp:LinkButton ID="lnkDownload" runat="server" OnClick="lnkDownload_OnClick">
                    <asp:Image ID="imgDownload" runat="server"
                        ToolTip="Download" CssClass="link-dark"
                        ImageUrl="~/Content/Icons/Download/Download_14px.png" />

                </asp:LinkButton><asp:LinkButton ID="lnkRename" runat="server" OnClick="lnkRename_OnClick">
                    <asp:Image ID="imgRename" runat="server" 
                        ToolTip="Edit" Height="14" Width="14"
                        CssClass="link-white"
                        ImageUrl="~/Content/Icons/Edit/edit_orange.png" />
                </asp:LinkButton><asp:LinkButton ID="lnkDelete" runat="server" OnClick="lnkDelete_OnClick">
                    <asp:Image ID="imgDelete" runat="server" Height="14" Width="14"
                        ToolTip="Delete"
                        CssClass="link-dark"
                        ImageUrl="~/Content/Icons/delete/trash.png" />
                </asp:LinkButton><asp:LinkButton ID="lnkMove" runat="server">
                    <asp:Image ID="imgMove" runat="server"
                        ToolTip="Move"
                        CssClass="link-dark"
                        ImageUrl="~/Content/Icons/Move/Move_14px_1.png" />
                </asp:LinkButton><asp:LinkButton ID="lnkCopy" runat="server">
                    <asp:Image ID="imgCopy" runat="server"
                        ToolTip="Copy"
                        CssClass="link-dark"
                        ImageUrl="~/Content/Icons/Copy/Copy_14px.png" />
                </asp:LinkButton>
                <asp:Label ID="lblFileNotEditableDisplay" runat="server" ForeColor="#393939" Text="Not editable" Visible="False"></asp:Label>
            <%--</span>--%>
        </asp:Panel>
        <%-- border: 1px solid darkgray; --%>
        <span style="position: absolute; right: 0%; top: 0%; height: 16px; width: 16px;"
            visible="False"
            runat="server" id="spanPictureIndication">
            <asp:Image ID="imgPictureIndication" runat="server" Height="16" Width="16" ImageUrl="~/Content/Icons/Picture/picture.png" Visible="False" />
        </span>

    </asp:Panel>


    <asp:HiddenField ID="hidFileId" runat="server" Value="0" />
    <asp:HiddenField ID="hidFileUrl" runat="server" Value="" />
    <asp:HiddenField ID="hidLocalId" runat="server" Value="0" />
    <asp:HiddenField ID="hidIsFolder" runat="server" Value="False" />
    <asp:HiddenField ID="hidIsConstantAndNotEditable" runat="server" Value="False" />
    <asp:HiddenField ID="hidFileType" runat="server" Value="" />
    <asp:HiddenField ID="hidFileName" runat="server" Value="" />
</div>

