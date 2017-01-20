<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListUC.ascx.cs" Inherits="One.Views.Structure.All.UserControls.ListUC" %>

<div runat="server" id="panel" style="margin: 3px 10px 10px 3px; min-height: 30px; padding: 5px 5px 5px 5px;">
    <div class="block" style="font-weight: 600; font-size: 1.1em;">
        <asp:HyperLink ID="lblName" runat="server">
               
        </asp:HyperLink>
        &nbsp;
        <asp:HyperLink ID="lnkEdit" runat="server" CssClass="edit-button">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Edit/edit_orange.png" />
        </asp:HyperLink>

        <asp:HyperLink ID="lnkDelete" Visible="False" CssClass="delete-button" runat="server" OnClick="lnkEdit_Click">
            <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/Icons/delete/trash.gif" />
        </asp:HyperLink>
    </div>

    <%--<asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>--%>
    <asp:HiddenField ID="hidStructureId" Value="0" runat="server" />
    <asp:HiddenField ID="hidStructureType" Value="0" runat="server" />
    <%-- aliceblue --%>
    <%--background-color: #e6e6ff;--%>
    <div style="margin-left: 25px; border-left: solid lightgray 1px;">
        <asp:PlaceHolder ID="pnlSubControls" runat="server"></asp:PlaceHolder>
        <div>
            <asp:HyperLink ID="lnkAdd" runat="server" Visible="False">
                <asp:Image ID="Image3" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                <asp:Literal ID="lblAddText" runat="server" Text=""></asp:Literal>
            </asp:HyperLink>
        </div>
    </div>
</div>
<hr />
