<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="Assign.aspx.cs" Inherits="One.Views.Role.Assign1" %>

<%@ Register Src="~/Views/Role/Assign.ascx" TagPrefix="uc1" TagName="Assign" %>


<asp:Content runat="server" id="content1" ContentPlaceHolderID="Body">
    <h3>Assign Roles</h3>
    <uc1:Assign runat="server" id="Assign" />
</asp:Content>
