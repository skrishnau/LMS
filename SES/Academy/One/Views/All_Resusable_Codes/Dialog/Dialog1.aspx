<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dialog1.aspx.cs" Inherits="One.Views.All_Resusable_Codes.Dialog.Dialog1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="~/Content/CSSes/All.css" />
    <style type="text/css">
        div.transbox {
            margin: 30px;
            /*background-color: #ffffff;*/
            border: 1px solid black;
            opacity: 0.6;
            filter: alpha(opacity=60); /* For IE8 and earlier */
        }

        div.dialog-body {
            background: rgba(76, 175, 80, 0.5);
            background-image: url("/Content/Images/background-repeater1.png");
            /*background-color: #cccccc;*/
            background-repeat: repeat;
            height: 100%;
            width: 100%;
            position: fixed;
            background-color: grey;
            opacity: 0.5;
            filter: alpha(opacity=50);
            /*top: 0;
    left: 0;*/
            /*top: 50%;
            left: 50%;
            -webkit-transform: translate(-50%, -50%);
            transform: translate(-50%, -50%);*/
            /*z-index: 1;*/
            bottom: 0;
        }

        div.whole-body {
            width: 100%;
            height: 100%;
        }

        div.dialog-heading {
            -moz-border-radius: 5px;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            font-family: Trebuchet MS,Tahoma,Verdana,Arial,sans-serif;
        }

        div.dialog-content {
            -moz-border-radius: 5px;
            -webkit-border-radius: 5px;
            border-radius: 5px;
        }

        div.button-div {
            text-align: center;
            padding: 5px 10px;
        }

        div.item-div {
            font-family: Trebuchet MS,Tahoma,Verdana,Arial,sans-serif;
        }

        .dialog-item {
            padding: 5px;
            width: 100%;
            display: inline-block;
        }
         .dialog-item-div {
            width: 100%;
            display: inline-block;
        }

            .dialog-item-div :hover {
                background-color: lightsalmon;
                color: white;
            }

        .inline-block {
            display: inline-block;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div class="whole-body">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">open dialog</asp:LinkButton>

            <%-- whole body --%>
            <div runat="server" id="dialogdiv" visible="False" class="whole-body">
                <%-- background --%>
                <div class="dialog-body">
                </div>
                <%-- Dialog part --%>
                <div>
                    <div style="width: 400px; padding: 5px; z-index: 2; border: 1px solid darkgray; background-color: white"
                        class="popup dialog-content">
                        <div id="dialog-heading" class="dialog-heading" style="background-color: #f7ae37; padding: 10px 15px;">
                            <asp:Label ID="lblHeading" runat="server"
                                ForeColor="white" Font-Size="1.2em"
                                Text="Heading here"></asp:Label>
                            <div style="float: right;">
                                <asp:LinkButton ID="btnClose" runat="server" OnClick="btnClose_Click">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Close/white_cross.png" />
                                </asp:LinkButton>
                            </div>
                            <div style="clear: both;"></div>
                        </div>
                        <div class="item-div" style="margin: 10px; padding-left: 10px; font-size: 1.1em;">
                            <asp:DataList ID="dataList"  runat="server" OnItemCommand="dataList_ItemCommand">
                                <ItemTemplate>
                                    <div class="dialog-item-div">
                                        <asp:LinkButton ID="lnkRestrictChoose"
                                            CssClass="dialog-item" CausesValidation="False"
                                            Font-Underline="False"
                                            BorderColor="lightgrey"
                                            CommandName='<<%# GetClickMode() %>'
                                            CommandArgument='<%#  Eval("Id")+","+Eval("Name") %>'
                                            runat="server">
                                                    <%# Eval("Name")%>
                                        </asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                                <SelectedItemStyle BackColor="lightblue"></SelectedItemStyle>
                            </asp:DataList>
                        </div>
                        <div class="button-div" runat="server" id="buttonsDiv">
                            <span class="button-span">&nbsp;
                                <asp:Button ID="btnSave" runat="server" Text="Save" Width="70px" Visible="False" />
                                &nbsp;
                                <asp:Button ID="btnOk" runat="server" Text="Ok" Width="70px" Visible="False" />
                                &nbsp;
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="70px" Visible="False" />
                                &nbsp;
                            </span>
                        </div>
                    </div>
                </div>
            <asp:HiddenField ID="hidItemClickMode" runat="server" Value=""/>
            </div>

            The quick brown fox jumps over the lazy dog 
            <div>
                Server not found

Firefox can’t find the server at stackoverflow.com.

    Check the address for typing errors such as ww.example.com instead of www.example.com
    If you are unable to load any pages, check your computer’s network connection.
    If your computer or network is protected by a firewall or proxy, make sure that Firefox is permitted to access the Web.


            </div>
            <div>
                Server not found

Firefox can’t find the server at stackoverflow.com.

    Check the address for typing errors such as ww.example.com instead of www.example.com
    If you are unable to load any pages, check your computer’s network connection.
    If your computer or network is protected by a firewall or proxy, make sure that Firefox is permitted to access the Web.


            </div>
            <div>
                Server not found

Firefox can’t find the server at stackoverflow.com.

    Check the address for typing errors such as ww.example.com instead of www.example.com
    If you are unable to load any pages, check your computer’s network connection.
    If your computer or network is protected by a firewall or proxy, make sure that Firefox is permitted to access the Web.


            </div>
            <div>
                Server not found

Firefox can’t find the server at stackoverflow.com.

    Check the address for typing errors such as ww.example.com instead of www.example.com
    If you are unable to load any pages, check your computer’s network connection.
    If your computer or network is protected by a firewall or proxy, make sure that Firefox is permitted to access the Web.


            </div>
            <div>
                Server not found

Firefox can’t find the server at stackoverflow.com.

    Check the address for typing errors such as ww.example.com instead of www.example.com
    If you are unable to load any pages, check your computer’s network connection.
    If your computer or network is protected by a firewall or proxy, make sure that Firefox is permitted to access the Web.


            </div>
            <div>
                Server not found

Firefox can’t find the server at stackoverflow.com.

    Check the address for typing errors such as ww.example.com instead of www.example.com
    If you are unable to load any pages, check your computer’s network connection.
    If your computer or network is protected by a firewall or proxy, make sure that Firefox is permitted to access the Web.


            </div>
        </div>
    </form>
</body>
</html>
