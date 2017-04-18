<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FolderAddUc.ascx.cs" Inherits="One.Views.FileManagement.FolderAddUc" %>

<%--<div class="list-item-heading">
    New Folder
</div>--%>
<div class="list-item-description">
    <strong>Name:</strong>&nbsp; &nbsp;
    <asp:TextBox ID="txtNewFolder" runat="server" placeholder="Folder name" TabIndex="1"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
        ForeColor="red" ControlToValidate="txtNewFolder"
        ValidationGroup="folder_add"
        ErrorMessage="Required"></asp:RequiredFieldValidator>
</div>

<div style="margin: 8px 5px 5px 0px;" class="button-div">
    <span class="button-span">
        <asp:Button ID="btnOkay" runat="server"
            Width="70px"
            ValidationGroup="folder_add"
            Text="Save" OnClick="btnOkay_OnClick" />
        &nbsp;
        <asp:Button ID="btnCancel" runat="server"
            Width="70px"
            CausesValidation="False"
            ValidationGroup="folder_add_cancel"
            Text="Cancel" OnClick="btnCancel_OnClick" />
        &nbsp;
    </span>

</div>

<asp:HiddenField ID="hidParentFolderId" runat="server" Value="0" />
<asp:HiddenField ID="hidFolderId" runat="server" Value="0" />
<asp:HiddenField ID="hidIsServerFile" runat="server" Value="False" />
