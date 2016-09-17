<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="javascriptcallfromcode.aspx.cs" Inherits="One.Views.Test.javascriptcallfromcode" %>

<%@ Register Src="~/Views/Test/javascriptcallFromusercontrol.ascx" TagPrefix="uc1" TagName="javascriptcallFromusercontrol" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <asp:Label ID="lblDisplayDate" ClientIDMode="Static" runat="server" Text="Label"></asp:Label>
        <asp:Button ID="btnPostBack2" runat="server" Text="Button" OnClick="btnPostBack2_Click" />
        <hr/>
        <uc1:javascriptcallFromusercontrol runat="server" id="javascriptcallFromusercontrol" />
    </div>
    </form>
</body>
</html>
