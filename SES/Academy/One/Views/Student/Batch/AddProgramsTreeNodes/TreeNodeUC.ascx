<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TreeNodeUC.ascx.cs" Inherits="One.Views.Student.Batch.AddProgramsTreeNodes.TreeNodeUC" %>
<%@ Import Namespace="System.Net" %>
<%@ Import Namespace="System.Security.Cryptography" %>
<%--<%@ Register Src="../../StudentClass/StudentEntry.ascx" TagName="StudentEntry" TagPrefix="uc1" %>--%>

<div>
    <asp:Label ID="Label1" runat="server"></asp:Label>

    <%-- ===================================================== --%>

    <div style="padding: 5px 0 5px;">


        <% var count = "";
           var s = hidVertBars.Value.Split(',');
           var dash = "─";
           //—————∙∙∙∙∙∙∙∙∙∙∙
           for (int i = 0; i < Level; i++)
           {
               count += " &nbsp;&nbsp;&nbsp;";
               count += (s[i] == "1") ? @"<font color=""#808080"">│</font>" : " ";

               count += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"; //|⁞
           }
           if (count.Length >= 19)
               count = count.Substring(0, count.Length - 31);
           if (IsMessage)
               count += " ";
           else if (Level > 0)
               count += "├";
        %>

        <%=  WebUtility.HtmlDecode(count) + Html32TextWriter.DefaultTabString %>
        <%--//yo muni ko code webutility.htmldecode(count bhanda muni hunu parxa--%>
        <% if (Level > 0)
           {%>
        <%= dash %>
        <%  } %>
        <%-- <%=  WebUtility.HtmlDecode(tdOpeningText) %>--%>

        <span runat="server" id="pnlItem" style="border: solid 1px grey;">
            <asp:CheckBox ID="chkBox" runat="server" AutoPostBack="True" OnCheckedChanged="chkBox_CheckedChanged" />
            <%-- onclick="GetCordinates(this)" --%>
            <asp:Label ID="cmbTitle" runat="server" Height="20px"></asp:Label>
            &nbsp;
        <%-- OnClick="imgGroup_Click" --%>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:ImageButton ID="imgGroup" runat="server" ImageUrl="~/Content/Icons/Users/users-icon.png" OnClick="imgGroup_Click" /><%--OnClientClick="GetCordinates" --%>
            <%--<asp:LinkButton runat="server" ID="lnlbtn123" Text="postme" Visible="False" OnClick="lnlbtn123_Click" ClientIDMode="AutoID"></asp:LinkButton>--%>
            <%-- onclick="GetCordinates(this)" --%>
        &nbsp;&nbsp;
        </span>
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
        <asp:HiddenField ID="hidProgramBatchId" runat="server" Value="0" />
        <%--<asp:TextBox runat="server" Visible="false" Text="0" ID="txt"></asp:TextBox>--%>
        <asp:HiddenField ID="hidNumberOfChildren" runat="server" Value="0" />
        <asp:HiddenField ID="hidPosition" runat="server" Value="0" />
        <asp:HiddenField ID="hidStructureId" runat="server" Value="0" />
        <asp:HiddenField ID="hidBatchId" runat="server" Value="0" />
        <asp:HiddenField ID="hidStudentList" runat="server" Value="0" />

    </div>

    <%-- ===================================================== --%>
</div>
