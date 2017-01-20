<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ViewsSite/User/UserMaster.Master" CodeBehind="FilesAndFolders.aspx.cs" Inherits="One.Views.FileManagement.FilesAndFolders" %>


<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <h3 class="heading-of-listing">
        Files
    </h3>
    <hr/>

    <div>
        
    </div>

</asp:Content>


<asp:Content runat="server" ID="content2" ContentPlaceHolderID="head">
    
</asp:Content>

<asp:Content runat="server" ID="content4" ContentPlaceHolderID="title">
    
</asp:Content>