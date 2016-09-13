<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="One.TestingOnly.Dialog.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $("[id*=btnPopup]").live("click", function () {
            $("#dialog").dialog({
                title: "jQuery Dialog Popup",
                buttons: {
                    Close: function () {
                        $(this).dialog('close');
                    }
                }
            });
            return false;
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>


            <div id="dialog" style="display: none">
                This is a simple popup
            </div>
            <asp:Button ID="btnPopup" runat="server" Text="Show Popup" />

        </div>
    </form>
</body>
</html>
