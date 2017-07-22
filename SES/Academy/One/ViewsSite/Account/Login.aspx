<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="One.ViewsSite.Account.Login" %>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <div class="roboto-thin">
        <div style="color: darkgray;">
            Learning Management System
        </div>
        <div class="roboto-thin" style="font-size: 3em;">
            Login 
        </div>
        <br />
        <div>
            <div style="padding: 5px 0 10px; text-align: left; color: darkgray;">
                Login with your college username and password
            </div>
            <div style="padding-left: 10px;">
                <asp:Login ID="Login1" Width="100%" runat="server" OnAuthenticate="Login1_Authenticate">
                    <LayoutTemplate>
                        <div style="margin-bottom: 5px; padding-right: 5px; text-align: left;">
                            <table style="width: 100%;">
                                <tr>
                                    <td>Username :                                
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span class="roboto-light">
                                            <asp:TextBox ID="UserName" runat="server" Width="170" CssClass="roboto-light"></asp:TextBox>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Password :</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="Password" runat="server" Width="170"
                                            TextMode="Password"
                                            CssClass="roboto-light"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>

                                        <asp:CheckBox ID="RememberMe" runat="server" Text="Remember my login"></asp:CheckBox>

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="color: lightcoral;">
                                            <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                                    </td>
                        </div>
                        </tr>
                        </table>
                    </div>
                    
                    <div style="text-align: left;">
                        <asp:LinkButton ID="Login" CssClass="link-button" runat="server" Text="Login" CommandName="Login" CommandArgument="login" />
                    </div>
                    </LayoutTemplate>
                </asp:Login>
            </div>
        </div>
    </div>
</asp:Content>


<asp:Content runat="server" ID="content2" ContentPlaceHolderID="right">
    <%-- <asp:HyperLink ID="registerLink1" runat="server"
        NavigateUrl="~/ViewsSite/Account/Register.aspx">Register</asp:HyperLink>--%>
</asp:Content>

<asp:Content runat="server" ID="content3" ContentPlaceHolderID="title">
    Home : Learning Management System
</asp:Content>


