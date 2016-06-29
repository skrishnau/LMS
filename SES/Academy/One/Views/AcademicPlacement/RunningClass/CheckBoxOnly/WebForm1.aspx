<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="One.Views.AcademicPlacement.RunningClass.CheckBoxOnly.WebForm1" %>

<%@ Register Src="~/Views/AcademicPlacement/RunningClass/CheckBoxOnly/TreeViewUC.ascx" TagPrefix="uc2" TagName="TreeViewUC" %>

<asp:Content runat="server" ID="script1" ContentPlaceHolderID="head">
   <%-- <script type="text/javascript">

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

            document.getElementById("hidX").value = X;
            document.getElementById("hidY").value = Y;
            document.getElementById("txt").text = X + " " + Y;
            __doPostBack("imgStdGrp", "OnClick");
        //alert("X:" + X + " Y:" + Y);
    }
    </script>--%>
   <%-- <script type="text/javascript">
        function getPanelMouseCoOrds(e) {
            var mouseX = event.clientX + document.body.scrollLeft;
            var mouseY = event.clientY + document.body.scrollTop;

            document.form.xPos.value = mouseX;
            document.form.yPos.value = mouseY;

            document.form.hidX.value = mouseX;
            document.form.hidY.value = mouseY;
            return true;
        }

        function handlePanelClick() {
            document.Form1.submit();
        }


        window.onload = init;
        function init() {
            if (window.Event) {
                document.captureEvents(Event.MOUSEMOVE);
            }
            document.onmousemove = getXY;
        }
        function getXY(e) {
            x = (window.Event) ? e.pageX : event.clientX;
            y = (window.Event) ? e.pageY : event.clientY;
            //document.forms[0].sd.value = x + ":" + y;
        }
    </script>--%>
</asp:Content>
<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    This is not generally used.. please use: 
    <a href="~/Views/AcademicPlacement/RunningClass/AddClasses/AddClasses.aspx">/Views/AcademicPlacement/RunningClass/AddClasses/AddClasses.aspx</a>
    <uc2:TreeViewUC runat="server" ID="TreeViewUC1" />
</asp:Content>
