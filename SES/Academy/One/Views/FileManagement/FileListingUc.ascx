<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileListingUc.ascx.cs" Inherits="One.Views.FileManagement.FileListingUc" %>
<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>



<div style="margin: 0;">
    <%-- directory --%>
    <%-- style="background-color: #f1f1f1; padding: 5px;" --%>
    <div style="margin-left:  -10px;" >
        <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
    </div>
    <%-- Folders --%>
    <asp:Panel runat="server" ID="pnlFoldersPanel" CssClass="panel panel-default">
        <%-- data-entry-section-heading --%>
        <div class="panel-heading">
            Folders
        </div>
        <div class="panel-body">
            <asp:Panel ID="pnlFolderListing" runat="server"></asp:Panel>
        </div>
        <div style="clear: both;"></div>
        <br />
    </asp:Panel>
    <br />
    <%-- Files --%>
    <asp:Panel runat="server" ID="pnlFilesPanel" CssClass="panel panel-default">
        <div class="panel-heading">
            Files
        </div>
        <div class="panel-body">
            <asp:Panel ID="pnlFilesListing" runat="server"></asp:Panel>
        </div>
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

