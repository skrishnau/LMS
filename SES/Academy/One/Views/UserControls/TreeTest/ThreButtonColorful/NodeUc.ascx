<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NodeUc.ascx.cs" Inherits="One.Views.UserControls.TreeTest.ThreButtonColorful.NodeUc" %>


<%@ Import Namespace="System.Net" %>
<%--<%@ Register Src="~/Views/Academy/CurrentAcademicYear/NodeUC.ascx" TagPrefix="uc1" TagName="NodeUC" %>--%>
<%--<%@ Reference Control="~/Views/Academy/CurrentAcademicYear/NodeUC.ascx" %>--%><%--<script type="text/javascript">
    function PanelClick() {
        _doPostBack('Panel1', 'Click');
    }
</script>--%>

<asp:HiddenField ID="hidLevel" runat="server" Value="0" />
<% 
   
%>
<div style="padding: 5px 0 5px;">
    <%-- Loop for space --%>

    <% var count = "";
       var dash = "─ ─ ─ ─";//—————∙∙∙∙∙∙∙∙∙∙∙
       for (int i = 0; i < Level; i++)
       {
           count += " &nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"; //|⁞
       }
       if (count.Length >= 19)
           count = count.Substring(0, count.Length - 31);
       if (Level > 0)
           count += "├";
    %>

    <% %>
    <%=  WebUtility.HtmlDecode(count) + Html32TextWriter.DefaultTabString %>
    <% if (Level > 0)
       {%>
    <%= dash %>
    <%  } %>
    <asp:TextBox ID="txtTitle" runat="server" Enabled="False"></asp:TextBox>
    &nbsp;&nbsp;
    <asp:ImageButton ID="imgAdd" runat="server"  ImageUrl="~/Content/Icons/AddEditDelete/add_small.png" />
    &nbsp;<asp:ImageButton ID="imgEdit" runat="server" Height="16px" ImageUrl="~/Content/Icons/AddEditDelete/edit_3.png" Width="16px" />
    &nbsp;<asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~\Content\Icons\AddEditDelete\delete-13.ico" />

    <%-- User control i.e. child nodes --%>
    <asp:PlaceHolder ID="phNodes" runat="server"></asp:PlaceHolder>
</div>

<%--<div style="float: right; width: 100%;">
    <div style="float: left;">
        <div style="float: left;">
            <% for (int i = 0; i < Level; i++)
               { %>
                    &nbsp;&nbsp;&nbsp;&nbsp;
            <% } %>
---
        <div>
            <asp:Label ID="Text" runat="server" Text="Label"></asp:Label>
            <br />

        </div>
        </div>
        |
   
    </div>

    <div style="float: right; width: 100%">
        <asp:Panel ID="Panel2" runat="server" Width="100%">
        </asp:Panel>
    </div>






    <div style="float: left;">
        <asp:PlaceHolder ID="Node" runat="server"></asp:PlaceHolder>
    </div>
</div>--%>
<%--<asp:Panel ID="Panel1" runat="server">
    <div>
        <asp:Panel ID="Panel3" runat="server" Width="100%">
        </asp:Panel>
        <div style="float: none;">
            <div style="float: right; width: 100%;">

                <div style="float: left;">
                    &nbsp;&nbsp;|-----&nbsp;
                </div>

                <div style="float: left;">

                    <asp:PlaceHolder ID="Nodes" runat="server">
                        <%--<uc1:NodeUC runat="server" id="NodeUC" />--%>
<%-- </asp:PlaceHolder>
                </div>
            </div>
        </div>
    </div>
</asp:Panel>--%>
