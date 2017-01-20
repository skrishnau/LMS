<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Assign.aspx.cs" Inherits="One.Views.Role.Assign1" %>

<%@ Register Src="~/Views/Role/Assign.ascx" TagPrefix="uc1" TagName="Assign" %>
<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>


<asp:Content runat="server" id="content1" ContentPlaceHolderID="Body">
    <h3 class="heading-of-create-edit">Assign Roles</h3>
    <hr />
    <uc1:Assign runat="server" id="Assign" />
</asp:Content>

<asp:Content runat="server" ID="titleContnet" ContentPlaceHolderID="title">
    Role Assign
</asp:Content>
