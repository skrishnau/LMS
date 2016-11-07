<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListUC.ascx.cs" Inherits="One.Views.Course.Category.ListUC" %>

<%--   --%>
<span>
    <asp:Panel ID="pnlName" runat="server" CssClass="pnlcls" EnableViewState="True" Width="100%">
        <%--<asp:Label ID="lblName" runat="server" Text="CategoryName"></asp:Label>--%>
        <span class="category-text">
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            <asp:LinkButton ID="lblName" runat="server" OnClick="lblName_Click" CssClass="linkbutton">name</asp:LinkButton>
        </span>
        <asp:HiddenField ID="hidCategoryId" Value="0" runat="server" />
        <asp:PlaceHolder ID="pnlSubCategories" runat="server"></asp:PlaceHolder>
    </asp:Panel>
</span>
<style type="text/css">
    .category-text {
        display: block;
        overflow: auto;
        font-size: 1.2em;
        word-wrap: normal;
        /*background-color: white;*/
    }

        .category-text:hover {
            background-color: #dcecf1;
            color: darkorange;
        }

    .pnlcls {
        display: block;
        padding: 2px;
    }
      .linkbutton, .linkbutton:visited {
            /*color: darkslategrey;*/
            text-decoration: none;
            /*display: inline-block;*/
        }

        .linkbutton:hover {
            color: darkorange;
            text-decoration: underline;
        }

        .linkbutton:active {
            color: blueviolet;
            text-decoration: underline;
        }
</style>

