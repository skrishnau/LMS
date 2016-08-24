<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testForm.aspx.cs" Inherits="One.Views.Class.Enrollment.testForm" %>

<%@ Register Src="~/Views/Class/Enrollment/UserEnrollUC.ascx" TagPrefix="uc1" TagName="UserEnrollUC" %>
<%@ Register Src="~/Views/Class/Enrollment/UserEnrollUC_ListDisplay.ascx" TagPrefix="uc1" TagName="UserEnrollUC_ListDisplay" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <%--<uc1:UserEnrollUC runat="server" id="UserEnrollUC" />--%>
            <uc1:UserEnrollUC_ListDisplay runat="server" id="UserEnrollUC_ListDisplay" />
        </div>
    </form>
</body>
</html>
