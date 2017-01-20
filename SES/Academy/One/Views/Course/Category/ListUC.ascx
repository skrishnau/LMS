<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListUC.ascx.cs" Inherits="One.Views.Course.Category.ListUC" %>

<%--   --%>
<span>
    <asp:Panel ID="pnlName" runat="server" CssClass="pnlcls" EnableViewState="True" Width="100%">
        <%--<asp:Label ID="lblName" runat="server" Text="CategoryName"></asp:Label>--%>
        <span class="category-text">
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            <asp:LinkButton ID="lblName" runat="server" OnClick="lblName_Click" CssClass="link">name</asp:LinkButton>
        </span>
        <asp:HiddenField ID="hidCategoryId" Value="0" runat="server" />
        <asp:PlaceHolder ID="pnlSubCategories" runat="server"></asp:PlaceHolder>
    </asp:Panel>
</span>


