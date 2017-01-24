<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ViewsSite/User/UserMaster.Master" CodeBehind="Default.aspx.cs" Inherits="One.Views.Search.Default" %>


<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    
    <h3 class="heading-of-listing">
        Search for "<asp:Label ID="lblHeading" runat="server" Text=""></asp:Label>"
    </h3>

    <br/>

    <asp:Label ID="lblEmptyData" runat="server" Text="No result found"></asp:Label>
    <div class="list-inside-body">
        <asp:Panel ID="pnlSearchResult" runat="server"></asp:Panel>
    </div>

</asp:Content>


<asp:Content runat="server" ID="content2" ContentPlaceHolderID="head">
    
</asp:Content>


<asp:Content runat="server" ID="content4" ContentPlaceHolderID="title">
    Search
    &nbsp;
    <asp:Literal ID="lblTitle" runat="server"></asp:Literal>
</asp:Content>


