<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SiteMapUc.ascx.cs" Inherits="One.Views.All_Resusable_Codes.SiteMaps.SiteMapUc" %>

<%-- --%>
<ol class="breadcrumb"  style="background-color: transparent;">

    <asp:ListView ID="ListView1" runat="server">
        <LayoutTemplate>
            <span runat="server" id="itemPlaceholder"></span>
        </LayoutTemplate>
        <ItemTemplate>
            <%--CssClass="link-white" [link-grey , link-white]--%>
            <%--<span class="sitemap-items">--%>
            <%-- Text='<%# Eval("Name") %>' --%>
            <%----%>

            <%-- CssClass="breadcrumb-item"  CssClass="breadcrumb-item active"  --%>
            <%-- Text='<%# string.IsNullOrEmpty((Eval("Value")??"").ToString())?"":Eval("Name") %>' --%>
            <li class='<%# string.IsNullOrEmpty((Eval("Value")??"").ToString())?"breadcrumb-item active":"breadcrumb-item" %>'>
                <asp:HyperLink ID="lnkSite" runat="server" Visible='<%# !string.IsNullOrEmpty((Eval("Value")??"").ToString()) %>'
                    NavigateUrl='<%# Eval("Value") %>'
                    Text='<%# Eval("Name") %>'
                    ></asp:HyperLink>
                <asp:Literal runat="server" ID="label21" Visible='<%# string.IsNullOrEmpty((Eval("Value")??"").ToString()) %>'
                    Text='<%# Eval("Name") %>'>
                </asp:Literal>
                    
                <%-- Text='<%# string.IsNullOrEmpty((Eval("Value")??"").ToString())?Eval("Name"):"" %>'  --%>
                <%--</span>--%>
                <%--&nbsp;--%>
                <%--<asp:Label ID="Label1" runat="server" Visible='<%# Eval("Void") %>' Text="/" ForeColor="#393939"></asp:Label>--%>
            </li>
        </ItemTemplate>
    </asp:ListView>
</ol>
