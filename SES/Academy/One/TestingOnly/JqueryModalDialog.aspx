<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JqueryModalDialog.aspx.cs" Inherits="One.TestingOnly.JqueryModalDialog" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="http://localhost:1240/code.jquery.com/ui/1.12.0/themes/smoothness/jquery-ui.css" />
    <script src="//code.jquery.com/jquery-1.12.4.js"></script>
    <script src="//code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
     <script type="text/javascript">
         jQuery(function () {
             var dlg = jQuery("#dialog").dialog({
                 draggable: true,
                 resizable: true,
                 show: 'Transfer',
                 hide: 'Transfer',
                 width: 320,
                 autoOpen: false,
                 minHeight: 10,
                 minwidth: 10
             });
             dlg.parent().appendTo(jQuery("form:first"));
         });

         jQuery(document).ready(function () {
             jQuery("#button_id").click(function (e) {
                 jQuery('#dialog').dialog('option', 'position', [e.pageX + 10, e.pageY + 10]);
                 jQuery('#dialog').dialog('open');
             });
         });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="button" id="button_id" value="open dialog" />
            <div id="dialog">
                hello hello hello
            </div>

        </div>
    </form>
   
</body>
</html>
