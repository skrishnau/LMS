<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUploadCheck.aspx.cs" Inherits="One.Views.Test.FileUploadCheck" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:Button ID="btnAsyncUpload" runat="server"
                        Text="Async_Upload" OnClick="btnAsyncUpload_Click"  />
                    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click"
                        />
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAsyncUpload"
                        EventName="Click" />
                    <asp:PostBackTrigger ControlID="btnUpload" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
