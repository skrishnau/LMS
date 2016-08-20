<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProgramList.aspx.cs" Inherits="One.Views.Student.Batch.Create.ProgramList" %>

<%@ Register Src="~/Views/Structure/All/UserControls/StructureView/TreeViewWithCheckBoxInLeft.ascx" TagPrefix="uc1" TagName="TreeViewWithCheckBoxInLeft" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:TreeViewWithCheckBoxInLeft runat="server" ID="TreeViewWithCheckBoxInLeft1" />
    </div>
    </form>
</body>
</html>
