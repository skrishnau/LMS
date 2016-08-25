<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testOfSelectInListView.aspx.cs" Inherits="One.Views.Class.Enrollment.testOfSelectInListView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 100px; overflow: auto; margin: auto;">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:ListView ID="ListView1" runat="server">
                        <LayoutTemplate>
                            <%-- <table runat="server">
                    <tr id="itemPlaceholder" runat="server">
                        
                    </tr>
                </table>--%>
                            <div runat="server" id="select1">
                                <span runat="server" id="itemPlaceholder"></span>
                            </div>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <div runat="server">
                                <asp:LinkButton ID="LinkButton1" CssClass="block" runat="server" Width="100%"
                                    Text='<%# Eval("FirstName") %>'>
                                </asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                    <div>
                        <asp:Button ID="remove" runat="server" Text="Button" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </form>
</body>
</html>
