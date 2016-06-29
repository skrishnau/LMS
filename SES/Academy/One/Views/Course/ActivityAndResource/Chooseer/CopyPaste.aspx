<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CopyPaste.aspx.cs" Inherits="One.Views.Course.ActivityAndResource.Chooseer.CopyPaste" %>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>--%>
<!doctype html>
<html lang="en">
   <head>
       <%-- fkjadshfkj --%>
      <meta charset="utf-8">
      <title>jQuery UI Dialog functionality</title>
      <link href="http://code.jquery.com/ui/1.10.4/themes/ui-lightness/jquery-ui.css" rel="stylesheet">
      <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
      <script src="http://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
      <!-- CSS -->
      <style>
         .ui-widget-header,.ui-state-default, ui-button{
            background:#b9cd6d;
            border: 1px solid #b9cd6d;
            color: #FFFFFF;
            font-weight: bold;
         }
      </style>
      <!-- Javascript -->
      <script>
          $(function () {
              $("#dialog-1").dialog({
                  autoOpen: false,
              });
              $("#opener").click(function () {
                  $("#dialog-1").dialog("open");
              });
              $("#text_date").datepicker();
             
          });
      </script>
   </head>
   <body>
      <!-- HTML --> 
      <div id="dialog-1" title="Dialog Title goes here...">This my first jQuery UI Dialog!</div>
       <input type="text" id="text_date"/>
      <button id="opener">Open Dialog</button>
   </body>
</html>
