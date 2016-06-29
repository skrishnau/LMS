<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChooserJQueryTest.aspx.cs" Inherits="One.Views.Course.ActivityAndResource.Chooseer.ChooserJQueryTest" %>

<!DOCTYPE html>
<%--  xmlns="http://www.w3.org/1999/xhtml" --%>
<html lang="en">
<%-- runat="server" --%>
<head>
    <meta charset="utf-8">
    <title>test 1</title>
    <%--<script src="../../../../Scripts/jquery-1.7.1.min.js"></script>
    <link href="../../../../Content/themes/base/jquery.ui.dialog.css" rel="stylesheet" />
    <link href="../../../../Content/themes/base/jquery-ui.min.css" rel="stylesheet" />--%>
   <%-- <link rel="stylesheet" href="http://code.jquery.com/mobile/1.4.5/jquery.mobile-1.4.5.min.css">
    <script src="http://code.jquery.com/jquery-1.11.3.min.js"></script>
    <script src="http://code.jquery.com/mobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>--%>
    
    <%-- ======================================================================================== --%>
    <%--<link href="http://code.jquery.com/ui/1.10.4/themes/ui-lightness/jquery-ui.css" rel="stylesheet">--%>
    <%--<link rel="stylesheet" href="http://code.jquery.com/mobile/1.4.5/jquery.mobile-1.4.5.min.css">--%>
    <%--<link href="../../../../Content/themes/base/jquery.ui.all.css" rel="stylesheet" />--%>
    <%--<link href="../../../../Content/themes/base/jquery-ui.css" rel="stylesheet" />--%>
    <link href="http://code.jquery.com/ui/1.10.4/themes/ui-lightness/jquery-ui.css" rel="stylesheet">
    <%-- ======================================================================================== --%>
    <%--<link href="../../../../Scripts/WorkingJquery/jquery-ui.css" rel="stylesheet" />--%>
    <%-- second one works --%>
    <%--<script src="http://code.jquery.com/jquery-1.11.3.min.js"></script>--%>
      <%--<script src="http://code.jquery.com/jquery-1.10.2.js"></script>--%>
    <script src="../../../../Scripts/WorkingJquery/jquery-1.10.2.js"></script>
    
    

    <%-- ==================================================================================== --%>
    <%-- This link is a mistake... Bad "copy-paste" idea...   but the line below it which is commented works...--%>
    <%--<script src="http://code.jquery.com/mobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>--%>
    <%-- yo muni ko link le dialog box lai bich am rakhxa... --%>
    <%--<script src="http://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>--%>
    <script src="../../../../Scripts/WorkingJquery/jquery-ui.js"></script>
    
    

    <%--  Test purpose  --%>
    <%--<script src="../../../../Scripts/jquery-1.7.1.js"></script>--%>
    <%--<script src="../../../../Scripts/jquery-1.7.1.min.js"></script>--%>

    <%-- This below code works, both two lines but bich ma rakhxa... --%>
    <%--<script src="../../../../Scripts/jquery-ui-1.8.20.js"></script>--%>
    <%-- yo muni ko link le dialog box lai bich ma rakhdaina --%>
    <%--<script src="../../../../Scripts/jquery-ui-1.8.20.min.js"></script>--%>
    <%-- =================================================================================== --%>
    

    <%--  <script type="text/javascript">
        //This is dialog open code
        $(function () {
            $("#div1").dialog({
                autoOpen: false,
            });
            $("#btnOpenDialog").click(function () {
                $("#div1").dialog("open");
            });
        });


        //end of dialog open code
    </script>--%>

    <!-- CSS -->
    <style>
        .ui-widget-header, .ui-state-default, ui-button {
            background: #b9cd6d;
            border: 1px solid #b9cd6d;
            color: #FFFFFF;
            font-weight: bold;
        }
    </style>

    <script>
        $(function () {
            $("#dialog-1").dialog({
                autoOpen: false,
            });
            $("#opener").click(function () {
                $("#dialog-1").dialog("open");
            });
            $("#datepicker-text").datepicker();
        });
    </script>
</head>
<body>
   <%-- <div id="dialog-1" title="Dialog Title goes here...">This my first jQuery UI Dialog!</div>
    <div style="border: 2px solid Brown; margin: 20px">
        <strong>Dialog Opener</strong>
        <hr />
        <button id="opener">Open Dialog</button>
    </div>--%>
    <div id="dialog-1" title="Dialog Title goes here...">This my first jQuery UI Dialog!</div>
      <button id="opener">Open Dialog</button>
    <input type="text" id="datepicker-text"/>
    <%-- <div data-role="page" data-dialog="true" id="div1">
        This is my first jquery dialog;
    </div>--%>

    <%--<form id="form1" runat="server">--%>
        <%-- <div>
            <p style="border: 2px solid red;">
                Hello this is my p element... i am now a grown chick in jquery 
            </p>
            <span style="border: 1px solid grey;" id="spn1">Click me too...</span>
            <input type="button" id="btn1" value="Click Me" />
            <label id="lbl1">Hello</label>

        </div>--%>

        <%-- <br />
        <br />
        <hr />
        <div>
            <strong id="test2Text">Test 2</strong>
            <br />
            <input type="text" id="txt1" />
            <br />
            <input type="date" id="date1" />
            <label id="lbl2" style="background-color: yellow; visibility: hidden;">You clicked on textbox... Click me to reopen</label>

            <br />
            <br />
            <strong>Last: multiple events on the object using "on"</strong>
            <br />
            <input type="button" id="btnMul" value="Multiple Event Test" />
            <label id="lblCross" style="background-color: red; visibility: hidden;">X</label>

        </div>
        <hr />
        <br />
        <strong>Upto jquery events finished. Now Effects start....</strong>
        w3schools.com
        
        <br />
        <br />
        <br />



        <input id="btnOpenDialog" type="button" value="Open Dialog" />
        --%>

        <%--   <div>





            <script type="text/javascript">


                $(document).ready(function () {
                    var s = true;
                    $("#btn1").click(function () {
                        if (s == false) {
                            $("p").show();
                            s = true;
                        } else {
                            $("p").hide();
                            s = false;
                        }
                    });

                    //multiple events
                    $("#btnMul").on({
                        mouseenter: function () {
                            $(this).css("background-color", "red");
                            $(this).css("color", "white");
                        },
                        mouseleave: function () {
                            $(this).css("background-color", "transparent");
                            $(this).css("color", "black");
                        },
                        click: function () {
                            $(this).disabled();
                            $("#lblCross").css("visibility", "visible");
                        }
                    });



                    $("#date1").on("click", function () {
                        $(this).hide();
                        $("#lbl2").css("visibility", "visible");
                    });
                    $("#lbl2").on("click", function () {
                        $("#date1").show();
                        $("#lbl2").css("visibility", "hidden");
                    });

                    $("#txt1").focus(function () {
                        $(this).css("background-color", "darkorange");
                        $(this).css("color", "white");
                    });

                    $("#txt1").blur(function () {
                        $(this).css("background-color", "transparent");
                        $(this).css("color", "black");
                    });

                    $("#spn1").hover(
                        function () {
                            $(this).css("background-color", "lightpink");
                        },
                        function () {
                            $(this).css("background-color", "transparent");
                        }
                    );


                    $("p").mousedown(function () {
                        alert("Mouse down over p1!");
                    });

                    $("#lbl1").dblclick(function () {
                        //$("p").backgroundColor = red;
                        alert("you clicked double");
                    });

                    //$("p").mouseleave(function () {
                    //    alert("Bye! You now leave p1!");
                    //});
                });
            </script>
        </div>--%>
    <%--</form>--%>
</body>
</html>
