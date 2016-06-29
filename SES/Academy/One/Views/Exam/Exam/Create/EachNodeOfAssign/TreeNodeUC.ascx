<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TreeNodeUC.ascx.cs" Inherits="One.Views.Exam.Exam.Create.EachNodeOfAssign.TreeNodeUC" %>
<%@ Import Namespace="System.Net" %>
<%@ Import Namespace="System.Security.Cryptography" %>
<%--<%@ Register Src="../../StudentClass/StudentEntry.ascx" TagName="StudentEntry" TagPrefix="uc1" %>--%>

<%--<script type="text/javascript">

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

        document.getElementById('<%= hidX.ClientID %>').value = X;
        document.getElementById('<%= hidY.ClientID %>').value = Y;

        __doPostBack("", "");
            //alert("X:" + X + " Y:" + Y);
        }
    </script>--%>

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
        // var s = stringify(X + "," + Y);

        //__doPostBack('<%= this.lnlbtn123.ClientID%>', "onclick");

        //document.all('<%= this.lnlbtn123.ClientID %>').click();

        //document.getElementById("hidX").value = X;
        //document.getElementById("hidY").value = Y;
        //document.all('<%= this.lnlbtn123.ClientID %>').click();
        document.getElementById("__EVENTARGUMENT").value = X + "," + Y;
        document.getElementById("__EVENTTARGET").value = "imgStdGrp";
        alert("Left djsklfsdjlk= " + X + " , Top klsdjflkds= " + Y);
        var pnl = document.getElementById("pnlStudentEntry");
        //pnl.style.top = Y;
        //pnl.style.left = X;
        //pnl.visibility = "true";
        //__doPostBack("imgStdGrp", X + "," + Y);

        //alert("Left djsklfsdjlk= " + X + " , Top klsdjflkds= " + Y);
        //document.getElementById('<%--= this.hidX.ClientID --%>').value = X;
        //document.getElementById('<%--= this.hidY.ClientID --%>').value = Y;
        //document.getElementById("txt").text = X + " " + Y;
        //alert("X:" + X + " Y:" + Y);
        ////document.Form1.__EVENTTARGET.value = '<%--= hidX.ClientID --%>';
        ////document.Form1.__EVENTARGUMENT.value = "";// eventArgument;
        ////document.Form1.submit();
        //alert("X:" + X + " Y:" + Y);
        //__doPostBack('<%= this.lnlbtn123.ClientID %>', "onclick");
        //document.all('<%= this.lnlbtn123.ClientID %>').click();
        //alert("X:" + X + " Y:" + Y);
    }
</script>


<div>


    <%-- ======================================== --%>
    <%--<input id="hidX" name="hidX" type="hidden"/>
    <input id="hidY"
           name="hidY" type="hidden"/>--%>
    <%--<asp:HiddenField ID="sd" runat="server" Value="0"/>--%>
    <%--<asp:Panel ID="Panel1" runat="server" Width="423px" Height="94px"
        BorderStyle="Solid">
        Panel
    </asp:Panel>--%>
    <%--<p>X:
        <input name="xPos" type="text" size="5" ></p>
    <p>Y:
        <input name="yPos" type="text" size="5"></p>--%>
    <asp:Label ID="Label1" runat="server"></asp:Label>
    <%-- ======================================== --%>


    <div style="padding: 5px 0 5px;">

        <%-- Loop for space --%>        <% 
            /*  var td = @"<td>";
           var tdOpeningText = @"<td style=""white-space:nowrap;"">";
           var tdClosingText = @"</td>";
           var divBlank = @"<div style=""width:20px;height:1px;""></div>";
           //var divThree = @"<div style=""width:20px"">├─</div>";
           var divUpTwo = @"<div style=""width:20px"">└─</div>";
           var divUpTwoWONode = @"<div style=""width:20px;"">└─</div>";
           var divVert = @"<div style=""width:20px;"">│</div>";
           var divHor = @"<div style=""width:20px;"">──</div>";
           */
        %>       <%-- <table>
            <tr>--%>
        <%
                   
            /*
                    var text = "";
                    var bars = hidVertBars.Value.Split(',');
                    //text += divBlank;
                    for (int i = 0; i < Level; i++)
                    {
                        text += td;

                        if (bars[i] == "1")//vertical
                        {

                            text += divVert;
                        }
                        else if (bars[i] == "0") //without node i.e. divUpTwoWONode
                        {
                            text+= divBlank;
                        }
                        else if (bars[i] == "2") //
                        {
                            text += divUpTwoWONode;
                        }
                        //if (Level > 0)
                        //{

                        //}
                        //text += "├";
                        
                        text += tdClosingText;
                        
                    }
                   */

                       
        %>
        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>                <%--<%=  WebUtility.HtmlDecode(text) %>--%>
        <% var count = "";
           var s = hidVertBars.Value.Split(',');
           var dash = "─";
           //List<bool> initialVerticalBar = (List<bool>)ViewState["initialVerticalBar"];
           //—————∙∙∙∙∙∙∙∙∙∙∙
           for (int i = 0; i < Level; i++)
           {
               count += " &nbsp;&nbsp;&nbsp;";
               count += (s[i] == "1") ? @"<font color=""#808080"">│</font>" : " ";


               //if ()
               //{
               //    count += "│";
               //}
               count += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"; //|⁞
           }
           if (count.Length >= 19)
               count = count.Substring(0, count.Length - 31);
           if (Level > 0)
               count += "├";
        %>

        <%=  WebUtility.HtmlDecode(count) + Html32TextWriter.DefaultTabString %>
        <%--//yo muni ko code webutility.htmldecode(count bhanda muni hunu parxa--%>                      <% if (Level > 0)
                                                                                                             {%>                <%= dash %>                <%  } %>

        <%-- <%=  WebUtility.HtmlDecode(tdOpeningText) %>--%>



        <asp:CheckBox ID="chkBox" runat="server" onclick="GetCordinates(this)" AutoPostBack="True" OnCheckedChanged="chkBox_CheckedChanged" />
        <asp:TextBox ID="cmbTitle" runat="server" Height="20px" Width="120px"></asp:TextBox>
        &nbsp;
        <%-- OnClick="imgGroup_Click" --%>
        <asp:ImageButton ID="imgStudent" runat="server" ImageUrl="~/Content/Icons/Users/users-icon.png" OnClick="imgStudent_Click" OnClientClick="GetCordinates" />
        &nbsp;<asp:ImageButton ID="imgTeacher" runat="server" />
&nbsp;
        <asp:LinkButton runat="server" ID="lnlbtn123" Text="Teachers" Visible="False" OnClick="lnlbtn123_Click" ClientIDMode="AutoID"></asp:LinkButton>
        <%-- onclick="GetCordinates(this)" --%>
        &nbsp;&nbsp;

           <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>                <%--<%=  WebUtility.HtmlDecode(tdClosingText) %>--%>           <%-- </tr>
        </table>--%>
        <%-- <asp:ImageButton ID="imgAdd" runat="server" ImageUrl="~/Content/Icons/AddEditDelete/add_small.png" Height="12px" OnClick="imgAdd_Click" Width="12px" />
    <asp:ImageButton ID="imgEdit" runat="server" Height="12px" ImageUrl="~/Content/Icons/AddEditDelete/edit_3.png" Width="12px" OnClick="imgEdit_Click" />
    <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~\Content\Icons\AddEditDelete\delete-13.ico" Height="12px" OnClick="imgDelete_Click" Width="12px" />--%>
        <%-- User control i.e. child nodes --%>
        <%-- height: 173px; --%>
        <asp:Panel ID="pnlStudentEntry" runat="server" Visible="true"
            Style="width: 242px;">

            <%--<uc1:StudentEntry ID="StudentEntry1" runat="server" />--%>
        </asp:Panel>
        <%
            pnlStudentEntry.Style["margin-left"] = Level * 50 + "px;";
        %>
        <asp:PlaceHolder ID="phChildNodes" runat="server"></asp:PlaceHolder>


        <asp:HiddenField ID="hidLevel" runat="server" Value="0" />
        <asp:HiddenField ID="hidVertBars" runat="server" Value="" />
        <asp:HiddenField ID="hidRunningClassId" runat="server" Value="0" />
        <asp:HiddenField ID="hidNumberOfChildren" runat="server" Value="0" />
        <asp:HiddenField ID="hidPosition" runat="server" Value="0" />
        <%--<asp:HiddenField ID="hidX" ClientIDMode="AutoID" runat="server" Value="0"/>
    <asp:HiddenField ID="hidY" ClientIDMode="AutoID" runat="server" Value="0"/>--%>
        <%--<asp:TextBox runat="server" Visible="false" Text="0" ID="txt"></asp:TextBox>--%>

    </div>
</div>
