<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc1.ascx.cs" Inherits="One.Views.Test.AsyncFileUploadCheck.uc1" %>
<div>

    <ajaxToolkit:AsyncFileUpload ID="AsyncFileUpload1" runat="server" OnUploadedComplete="AsyncFileUpload1_UploadedComplete" OnUploadedFileError="AsyncFileUpload1_UploadedFileError" />

</div>
