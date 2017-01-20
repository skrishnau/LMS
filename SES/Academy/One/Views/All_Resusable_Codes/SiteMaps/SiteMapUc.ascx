<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SiteMapUc.ascx.cs" Inherits="One.Views.All_Resusable_Codes.SiteMaps.SiteMapUc" %>
<div>

    <asp:ListView ID="ListView1" runat="server">
        <LayoutTemplate>
            <span runat="server" id="itemPlaceholder"></span>
        </LayoutTemplate>
        <ItemTemplate>
            <%--CssClass="link-white"--%>
            <span class="sitemap-items">
                <asp:HyperLink ID="lnkSite" runat="server" Text='<%# Eval("Name") %>'
                    CssClass='<%# string.IsNullOrEmpty((Eval("Value")??"").ToString())?"link-grey":"link-white" %>'
                    NavigateUrl='<%# Eval("Value") %>'></asp:HyperLink>
            </span>
            <%--&nbsp;--%>
            <asp:Label ID="Label1" runat="server" Visible='<%# Eval("Void") %>' Text=">" ForeColor="white"></asp:Label>
        </ItemTemplate>
    </asp:ListView>
</div>
