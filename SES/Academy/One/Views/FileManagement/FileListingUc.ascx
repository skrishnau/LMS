<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileListingUc.ascx.cs" Inherits="One.Views.FileManagement.FileListingUc" %>
<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>



<div style="margin: 0;">
    <%-- directory --%>
    <div style="background-color: #f1f1f1; padding: 5px;">
        <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
    </div>
    <br />
    <%-- Folders --%>
    <asp:Panel runat="server" ID="pnlFoldersPanel">
        <div>Folders</div>
        <asp:Panel ID="pnlFolderListing" runat="server"></asp:Panel>
        <div style="clear: both;"></div>
    </asp:Panel>
    <br />
    <%-- Files --%>
    <asp:Panel runat="server" ID="pnlFilesPanel">
        <div>Files</div>
        <asp:Panel ID="pnlFilesListing" runat="server"></asp:Panel>
        <div style="clear: both;"></div>
    </asp:Panel>
    <div style="clear: both;"></div>
    <asp:HiddenField ID="hidFilesFrom" runat="server" Value="Private" />
    <asp:HiddenField ID="hidShowEditControls" runat="server" Value="False" />
    <asp:HiddenField ID="hidFolderId" runat="server" Value="0" />
    <asp:HiddenField ID="hidIsServerFile" runat="server" Value="False" />
    <%-- Postback or Redirect --%>
    <asp:HiddenField ID="hidFolderSelectionType" runat="server" Value="True" />
</div>
