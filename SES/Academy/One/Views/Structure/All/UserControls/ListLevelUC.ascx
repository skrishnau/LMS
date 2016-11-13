<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListLevelUC.ascx.cs" Inherits="One.Views.Structure.All.UserControls.ListLevelUC" %>
<%-- lightblue --%>
<%-- background-color: #ccccff;  --%>
<div runat="server" id="panel" style="margin: 20px 0 5px 0; padding: 5px 5px 0 10px;">
    <div class="block" style="font-weight: 600; font-size: 1.1em">
        ♦
        <asp:HyperLink ID="lblName" runat="server">
                Name
        </asp:HyperLink>
        &nbsp;
        <asp:HyperLink ID="lnkEdit" runat="server">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Edit/edit_orange.png" />
        </asp:HyperLink>

    </div>

    <%--<asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>--%>
    <asp:HiddenField ID="hidStructureId" Value="0" runat="server" />
    <asp:HiddenField ID="hidStructureType" Value="0" runat="server" />

    <%-- background-color: #ddddff --%>
    <div style="margin-left: 25px; border-left: solid lightgray 1px;">
        <asp:PlaceHolder ID="pnlSubControls" runat="server"></asp:PlaceHolder>
        <div>
            <asp:HyperLink ID="lnkAdd" runat="server" Visible="False">
                <asp:Image ID="img" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                <asp:Literal ID="lblAddText" runat="server" Text=""></asp:Literal>
            </asp:HyperLink>
        </div>
    </div>

</div>
<hr />
