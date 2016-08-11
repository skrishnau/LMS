<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListUC.ascx.cs" Inherits="One.Views.Course.Category.ListUC" %>

<div style="margin-left: 20px">
    <asp:Panel ID="pnlName" runat="server" Width="100%" CssClass="block" EnableViewState="True">
        <%--<asp:Label ID="lblName" runat="server" Text="CategoryName"></asp:Label>--%>
        <asp:LinkButton ID="lblName" runat="server" OnClick="lblName_Click" CssClass="block">name</asp:LinkButton>
    </asp:Panel>
    <asp:HiddenField ID="hidCategoryId" Value="0" runat="server" />
    <asp:PlaceHolder ID="pnlSubCategories" runat="server"></asp:PlaceHolder>
</div>
