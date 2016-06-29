<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThreeButtonTest.aspx.cs" Inherits="One.Views.UserControls.TreeTest.ThreButtonColorful.ThreeButtonTest" %>

<%@ Register Src="~/Views/UserControls/TreeTest/ThreButtonColorful/NodeUc.ascx" TagPrefix="uc1" TagName="NodeUc" %>


<%--<%@ Reference Control="~/Views/Academy/CurrentAcademicYear/NodeUC.ascx" %>--%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:NodeUc runat="server" ID="NodeUC1" />
    </div>
    </form>
</body>
</html>
