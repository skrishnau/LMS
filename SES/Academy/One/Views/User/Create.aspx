<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="One.Views.User.Create" %>

<%@ Register Src="~/Views/User/UserCreateUC.ascx" TagPrefix="uc1" TagName="UserCreateUC" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <div>
        <uc1:UserCreateUC runat="server" ID="UserCreateUC" />
    </div>
</asp:Content>

<%--<asp:Content runat="server" ID="titleContnet" ContentPlaceHolderID="title">
    
</asp:Content>--%>