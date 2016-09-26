<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileUploadUc.ascx.cs" Inherits="One.Views.All_Resusable_Codes.FileTasks.FileUploadUc" %>


<div style="text-align: center;">

    <ajaxToolkit:AsyncFileUpload runat="server" ID="file_upload" OnUploadedComplete="file_upload_UploadedComplete"></ajaxToolkit:AsyncFileUpload>


    <br />
    <asp:HiddenField ID="hidPageKey" runat="server" Value="0" />
    <asp:HiddenField ID="hdnFileFolder" runat="server" Value="" />
    <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:FileUpload ID="FileUpload1" runat="server" EnableViewState="True" />
            <br />
            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload" />
        </Triggers>
    </asp:UpdatePanel>--%>

   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="btnAsyncUpload" runat="server"
                Text="Async_Upload" OnClick="btnAsyncUpload_Click" />
            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAsyncUpload"
                EventName="Click" />
            <asp:PostBackTrigger ControlID="btnUpload" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%>
</div>
