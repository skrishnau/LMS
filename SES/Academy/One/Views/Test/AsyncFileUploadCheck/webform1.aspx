<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="webform1.aspx.cs" Inherits="One.Views.Test.AsyncFileUploadCheck.webform1" %>

<%@ Register Src="~/Views/Test/AsyncFileUploadCheck/uc1.ascx" TagPrefix="uc1" TagName="uc1" %>



<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Button ID="Button1" runat="server" Text="Show upload" OnClick="Button1_Click" />
            <%--<asp:Panel ID="Panel1" runat="server" Visible="False"></asp:Panel>--%>
            <uc1:uc1 runat="server" id="uc1" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
