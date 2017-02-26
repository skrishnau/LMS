<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListUC.ascx.cs" Inherits="One.Views.Course.Category.ListUC" %>

<%--   --%>
<%--<span class="">--%>
<%-- CssClass="pnlcls" --%>

<asp:Panel ID="pnlName" runat="server" EnableViewState="True" Width="100%">
    <%--<asp:Label ID="lblName" runat="server" Text="CategoryName"></asp:Label>--%>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    <asp:LinkButton ID="lnkName" runat="server" OnClick="lblName_Click" CssClass="list-item-heading-normal">
        <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>

    </asp:LinkButton>
    <div style="padding-left: 20px; margin-left: 20px;">
        <asp:PlaceHolder ID="pnlSubCategories" runat="server"></asp:PlaceHolder>
    </div>
    <asp:HiddenField ID="hidCategoryId" Value="0" runat="server" />
</asp:Panel>
<%--</span>--%>


