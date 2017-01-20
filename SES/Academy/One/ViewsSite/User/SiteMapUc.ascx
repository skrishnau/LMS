<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SiteMapUc.ascx.cs" Inherits="One.ViewsSite.User.SiteMapUc" %>

<div>
   <%-- <asp:DataList ID="DataList1" runat="server">
        <ItemTemplate>
            <span>
                <asp:HyperLink ID="lnkSite" runat="server" Text='<%# Eval("Name") %>'
                    NavigateUrl='<%# Eval("Value") %>'></asp:HyperLink>
            </span>
        </ItemTemplate>
    </asp:DataList>--%>
    <asp:ListView ID="ListView1" runat="server">
        <LayoutTemplate>
            <span runat="server" id="itemPlaceholder"></span>
        </LayoutTemplate>
        <ItemTemplate>
            <span class="sitemap-items" >
                <asp:HyperLink ID="lnkSite" runat="server" Text='<%# Eval("Name") %>'
                    NavigateUrl='<%# Eval("Value") %>'></asp:HyperLink>
            </span>
            <%--&nbsp;--%>
            <asp:Label ID="Label1" runat="server" Visible='<%# Eval("Void") %>' Text=">" ForeColor="white"></asp:Label>
        </ItemTemplate>
    </asp:ListView>
</div>
