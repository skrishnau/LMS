<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="One.Views.Office.School.SchoolType.Create" %>

<%@ Register Src="~/Views/Office/School/SchoolTypeUC.ascx" TagPrefix="uc1" TagName="SchoolTypeUC" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <uc1:SchoolTypeUC runat="server" ID="SchoolTypeUC" />
    </div>
    </form>
</body>
</html>
