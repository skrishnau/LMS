<%@ Page Language="C#" MasterPageFile="~/ViewsSite/DefaultSite.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="One.ViewsSite.Account.Login" %>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="MainContent">
    <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate"></asp:Login>
    <asp:HyperLink ID="registerLink1" runat="server" 
        Enabled="false"
         href="~/ViewsSite/Account/Register.aspx">Register</asp:HyperLink>

    <%--<asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            
        </AnonymousTemplate>
        <LoggedInTemplate>
            <div style="float: right">
                <asp:LoginName ID="LoginName1" runat="server" />
                <asp:LoginStatus ID="LoginStatus1" runat="server" />
            </div>
        </LoggedInTemplate>
    </asp:LoginView>--%>
</asp:Content>
