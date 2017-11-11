<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ViewsSite/User/UserMaster.Master" CodeBehind="Default.aspx.cs" Inherits="One.Views.Setting.Default" %>

<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">

    <h3 class="heading-of-listing">Settings
    </h3>
    <hr />

    <div class="panel panel-default">


        <%--<div class="panel-body">--%>
        <%--<div class="auto-st2">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Views/Structure/All/Master/List.aspx?edit=1" CssClass="link">
                    Programs
                </asp:HyperLink>
            </div>--%>
        <div class="list-group">
            
            <%-- link --%>
            <asp:HyperLink ID="HyperLink3" runat="server" CssClass="list-group-item"
                NavigateUrl="~/Views/Office/">
                   College
            </asp:HyperLink>
        </div>

        <%--</div>--%>
    </div>

</asp:Content>


<asp:Content runat="server" ID="content2" ContentPlaceHolderID="head">
</asp:Content>

<asp:Content runat="server" ID="content4" ContentPlaceHolderID="title">
    Settings
</asp:Content>



