<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyPage.aspx.cs" Inherits="TreeViewTest.TreeViewWorking.MY.MyPage" %>

<%@ Register TagPrefix="MyTV" Namespace="TreeViewTest.TreeViewWorking.MY" Assembly="TreeViewTest" %>
<%--<%@ Register TagPrefix="MyTreeView" Namespace="TreeViewTest.TreeViewWorking.MY" Assembly="TreeViewTest" %>--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:LinkButton ID="lbtnPostBack" runat="server">postback test</asp:LinkButton>
            <MyTV:MyTreeView runat="server" id="myTreeView1" OnSelectedNodeChanged="Node_Selected" />
            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" />
        </div>
        <asp:Button ID="btnInvoke" runat="server" Text="Invoke" OnClick="btnInvoke_Click" />
    </form>
</body>
</html>
