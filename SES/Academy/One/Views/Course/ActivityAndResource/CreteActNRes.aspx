<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="CreteActNRes.aspx.cs" Inherits="One.Views.Course.ActivityAndResource.CreteActNRes" %>

<%@ Register Src="~/Views/Course/ActivityAndResource/CreateActNResUc.ascx" TagPrefix="uc1" TagName="CreateActNResUc" %>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <uc1:CreateActNResUc runat="server" id="CreateActNResUc" />
</asp:Content>