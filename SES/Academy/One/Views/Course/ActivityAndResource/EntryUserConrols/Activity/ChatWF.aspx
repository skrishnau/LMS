<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="ChatWF.aspx.cs" Inherits="One.Views.Course.ActivityAndResource.EntryUserConrols.Activity.ChatWF" %>

<%@ Register Src="~/Views/Course/ActivityAndResource/EntryUserConrols/Activity/ChatUc.ascx" TagPrefix="uc1" TagName="ChatUc" %>


<asp:Content runat="server" ContentPlaceHolderID="Body">
    <uc1:ChatUc runat="server" id="ChatUc" />
</asp:Content>
