<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AutoCloseSolution.aspx.cs" Inherits="One.Views.Course.ActivityAndResource.Chooseer.AutoCloseSolution" %>

<%@ Register Src="~/Views/Course/ActivityAndResource/ActResChoose/ActResChooseUc.ascx" TagPrefix="uc1" TagName="ActResChooseUc" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/flick/jquery-ui.css" rel="Stylesheet" media="screen" type="text/css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#Panel1').dialog({
                title: "My Dialog",
                autoOpen: false,
                modal: true
            });
            $("#textbox_date").datepicker();
            $('#Button1').click(function (evt) {
                evt.preventDefault();

                $('#Panel1').dialog('open');
            });

            // Remove the onchange event for AutoPostBack="true".
            $('#DropDownList1').removeAttr('onchange');

            $('#DropDownList1').change(function () {
                // Set up the request.
                var requestDTO = {
                    actionName: this.id,
                    selectedValue: this.value
                };

                // Perform AJAX call.
                $.ajax({
                    type: "post",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    url: "/Default.aspx/GetMessage",
                    data: JSON.stringify(requestDTO),
                    success: function (responseDTO) {
                        $('#Label1').text(responseDTO.d);
                    }
                });
            });

            $('#Button3').click(function (evt) {
                evt.preventDefault();

                // Set up the request.
                var requestDTO = {
                    actionName: this.id,
                    selectedValue: ""
                };

                // Perform AJAX call.
                $.ajax({
                    type: "post",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    url: "/Default.aspx/GetMessage",
                    data: JSON.stringify(requestDTO),
                    success: function (responseDTO) {
                        $('#Label1').text(responseDTO.d);
                    }
                });

                $('#Panel1').dialog('close');
            });

            $('#Button2').click(function (evt) {
                evt.preventDefault();

                // Set up the request.
                var requestDTO = {
                    actionName: this.id,
                    selectedValue: ""
                };

                // Perform AJAX call.
                $.ajax({
                    type: "post",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    url: "/Default.aspx/GetMessage",
                    data: JSON.stringify(requestDTO),
                    success: function (responseDTO) {
                        $('#Label1').text(responseDTO.d);
                    }
                });

                $('#Panel1').dialog('close');
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="Popup" ></asp:Button>
        <asp:Panel ID="Panel1" runat="server">
            <fieldset>
                <legend>Popup</legend>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" >
                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Label1" runat="server"></asp:Label>
                <asp:Button ID="Button3" runat="server" Text="Save"  />
                <asp:Button ID="Button2" runat="server" Text="Close"  />
                <uc1:ActResChooseUc runat="server" ID="ActResChooseUc" />
            </fieldset>
        </asp:Panel>
        <br/>
        <hr/>
         
              <asp:TextBox runat="server" ID="textbox_date" ></asp:TextBox>
    </div>
    </form>
</body>
</html>
