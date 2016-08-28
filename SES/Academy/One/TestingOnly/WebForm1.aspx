<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Test.Master" CodeBehind="WebForm1.aspx.cs" Inherits="One.TestingOnly.WebForm1" %>
<%-- ~/ViewsSite/UserSite.Master --%>

<asp:Content runat="server" ID="headContent" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" href="../DatePickerJquery/jquery-ui-1.9.2.custom.css"/>
    <script src="../DatePickerJquery/jquery-1.8.3.js"></script>
    

     <%--<link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css">--%>
    <%--<link rel="stylesheet" href="/resources/demos/style.css">--%>
    <%--<script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>--%>
    <script>
        $(function () {
            $("#datepicker").datepicker();
        });
    </script>
</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="MainContent">
       <div>
            <p>
                Date:
                <input type="text" id="datepicker"/>
            </p>

        </div>
</asp:Content>
<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link rel="stylesheet" href="~/Content/DatePickerResourses/jquery-ui-1.9.2.custom.css"/>
    <script src="~/Content/DatePickerResourses/jquery-1.8.3.js"></script>
    

    <script>
        $(function () {
            $("#datepicker").datepicker();
        });
    </script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <p>
                    Date:
                <input type="text" id="datepicker" />
                </p>

            </div>

        </div>
    </form>
</body>
</html>--%>
