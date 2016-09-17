<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="javascriptcallfromupdatepanel.aspx.cs" Inherits="One.Views.Test.javascriptcallfromupdatepanel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <asp:Label ID="lblDisplayDate" ClientIDMode="Static" runat="server" Text="Label">
                        
                    </asp:Label><asp:Button ID="btnPostBack2" runat="server" Text="Button" OnClick="btnPostBack2_Click" />
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
    <script type="text/javascript">
        var dialogOpened = false;
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function (s, e) {
            alert('Postback!');
        });
    </script>
</body>
</html>
