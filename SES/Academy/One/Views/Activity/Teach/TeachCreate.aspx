<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="TeachCreate.aspx.cs" Inherits="One.Views.Activity.Teach.TeachCreate" %>

<%@ Register Src="~/Views/Activity/Teach/Create.ascx" TagPrefix="uc1" TagName="Create" %>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <div>
        <asp:Panel ID="Panel1" runat="server">
            <uc1:Create runat="server" ID="Create" />

        </asp:Panel>
    </div>
</asp:Content>
