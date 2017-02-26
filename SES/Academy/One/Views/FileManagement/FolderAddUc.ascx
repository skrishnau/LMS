<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FolderAddUc.ascx.cs" Inherits="One.Views.FileManagement.FolderAddUc" %>

<%--<div class="list-item-heading">
    New Folder
</div>--%>
<div class="list-item-description">
    <asp:TextBox ID="txtNewFolder" runat="server" placeholder="Folder name" TabIndex="1"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
        ForeColor="red" ControlToValidate="txtNewFolder"
        ValidationGroup="folder_add"
        ErrorMessage="Required"></asp:RequiredFieldValidator>
</div>

<div style="margin: 5px;">
    <asp:Button ID="btnOkay" runat="server"
        ValidationGroup="folder_add"
        Text="Save" OnClick="btnOkay_OnClick" />
    
    <asp:Button ID="btnCancel" runat="server"
        ValidationGroup="folder_add_cancel"
        Text="Cancel" OnClick="btnCancel_OnClick" />

</div>

<asp:HiddenField ID="hidParentFolderId" runat="server" Value="0" />
<asp:HiddenField ID="hidFolderId" runat="server" Value="0" />
    <asp:HiddenField ID="hidIsServerFile" runat="server" Value="False" />
