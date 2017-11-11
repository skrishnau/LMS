<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListUC.ascx.cs" Inherits="One.Views.Course.Category.ListUC" %>

<%--<span class="">--%>
<%-- CssClass="pnlcls" --%>

<asp:Panel ID="pnlName" runat="server" EnableViewState="True"  CssClass="list-group-item">
    <%--<asp:Label ID="lblName" runat="server" Text="CategoryName"></asp:Label>--%>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    <%-- CssClass="list-item-heading-normal" --%>
    <asp:LinkButton ID="lnkName" runat="server" OnClick="lblName_Click">
        <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
    </asp:LinkButton>
    <span class="span-edit-delete">
        <asp:HyperLink ID="lnkEdit" runat="server" CssClass="link">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Edit/edit_orange.png" />
        </asp:HyperLink>
        <asp:HyperLink ID="lnkDelete" runat="server" CssClass="link">
            <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/Icons/delete/trash.png" />
        </asp:HyperLink>
    </span>

    <div style="padding-left: 20px; margin-left: 20px;">
        <asp:PlaceHolder ID="pnlSubCategories" runat="server"></asp:PlaceHolder>
    </div>
    <asp:HiddenField ID="hidCategoryId" Value="0" runat="server" />
</asp:Panel>
<%--</span>--%>


