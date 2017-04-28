<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PositionTest.aspx.cs" Inherits="TreeViewTest.ControlsPosition.PositionTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">

        function GetCordinates(obj) {
            var X = obj.offsetLeft;
            var Y = obj.offsetTop;
            while (obj.offsetParent) {
                X = X + obj.offsetParent.offsetLeft;
                Y = Y + obj.offsetParent.offsetTop;
                if (obj == document.getElementsByTagName("body")[0]) {
                    break;
                }
                else {
                    obj = obj.offsetParent;
                }
            }
            alert("Left = " + X + " , Top = " + Y);

            document.getElementById('<%= TextBox1.ClientID %>').value = X;
            document.getElementById('<%= TextBox2.ClientID %>').value = Y;
            alert("X:" + X + " Y:" + Y);
        }
    </script>
    //Next function
        <script type="text/javascript">
            function GetScreenCordinates(obj) {
                var p = {};
                p.x = obj.offsetLeft;
                p.y = obj.offsetTop;
                while (obj.offsetParent) {
                    p.x = p.x + obj.offsetParent.offsetLeft;
                    p.y = p.y + obj.offsetParent.offsetTop;
                    if (obj == document.getElementsByTagName("body")[0]) {
                        break;
                    }
                    else {
                        obj = obj.offsetParent;
                    }
                }
                return p;
            }
        </script>
    <script type="text/javascript">
        function GetTextboxCordinates() {
            var txt = document.getElementById("txtText");
            var p = GetScreenCordinates(txt);
            alert("X:" + p.x + " Y:" + p.y);
        }


    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div style="border: 2px solid green;">
            <asp:Label ID="Label1" runat="server" Text="Click Me" onclick="GetCordinates(this)"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:LinkButton ID="LinkButton1" runat="server">Post</asp:LinkButton>
        </div>
        <%-- =============================== --%>
        <div style="border: 2px solid red;">

            <input id="txtText" type="text" />
            <input value="Get Coordinates(Click)" type="button" onclick="GetTextboxCordinates()" />
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:HiddenField ID="HiddenField2" runat="server" />
            <asp:Panel runat="server" ID="panel3" style="z-index: 1; left: 352px; top: -50px; position: relative; height: 38px; width: 287px">
                <asp:LinkButton ID="LinkButton2" runat="server">Post Data</asp:LinkButton>

            </asp:Panel>

        </div>
        <br />
        <div style="border: 2px dashed blue;">
            <span onclick="GetTextboxCordinates()">Hello click me test for span</span>

            <span onclick="GetCordinates(this)">Click me for my Position</span>

        </div>
    </form>



</body>
</html>
