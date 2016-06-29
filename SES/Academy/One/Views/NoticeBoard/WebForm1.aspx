<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="One.Views.NoticeBoard.WebForm1" %>

<%@ Register Src="~/Views/NoticeBoard/CreateUc.ascx" TagPrefix="uc1" TagName="CreateUc" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:CreateUc runat="server" ID="CreateUc" />
    </div>
    </form>
</body>
</html>
