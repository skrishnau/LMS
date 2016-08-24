<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListingTest.aspx.cs" Inherits="One.Views.User.Searching.ListingTest" %>

<%@ Register Src="~/Views/User/Searching/UserSearchAndList.ascx" TagPrefix="uc1" TagName="UserSearchAndList" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:UserSearchAndList runat="server" id="UserSearchAndList" />
    </div>
    </form>
</body>
</html>
