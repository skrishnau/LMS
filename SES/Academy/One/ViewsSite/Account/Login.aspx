<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="One.ViewsSite.Account.Login" %>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <div class="col-md-10">
        <div class=" text-right" style="color: darkgray;">
            Learning Management System
        
        </div>
        <div class=" roboto-thin panel panel-default">
            <div style="color: darkgray;">
            </div>
            <%-- style="font-size: 3em;" --%>
            <div class="roboto-thin panel-heading">
                Login 
            </div>
            <div class="panel-body">
                <div style="padding: 5px 0 10px; text-align: left; color: darkgray;">
                    Login with your college username and password
                </div>



                <div style="padding-left: 10px;">
                    <asp:Login ID="Login1" Width="100%" runat="server" OnAuthenticate="Login1_Authenticate">
                        <LayoutTemplate>
                            <div class="row">
                                <%-- Width="170" --%>
                                <div class="form-group">
                                    <div class="col-md-3">Username</div>
                                    <div class="col-md-6">
                                        <span class="roboto-light">
                                            <asp:TextBox ID="UserName" runat="server" CssClass="roboto-light form-control"></asp:TextBox>
                                        </span>
                                    </div>
                                </div>
                                <br />
                                <br />
                                <div class="form-group">
                                    <div class="col-md-3">Password</div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="Password" runat="server"
                                            TextMode="Password"
                                            CssClass="roboto-light form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-md-6 col-md-offset-3">
                                        <div class="checkbox" style="padding-left: 25px;">
                                            <asp:CheckBox ID="RememberMe" runat="server" Text="Remember my login"></asp:CheckBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-6 col-md-offset-3">
                                        <div style="color: lightcoral;">
                                            <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-md-8 col-md-offset-3">
                                        <%-- link-button  --%>
                                        <asp:Button ID="Login" CssClass="btn btn-primary"
                                            runat="server" Text="Login" CommandName="Login" CommandArgument="login" />
                                        <%--<button type="submit" class="btn btn-primary">
                        Login
                    </button>--%>

                                        <a class="btn btn-link" href="#">Forgot Your Password?
                                        </a>
                                    </div>
                                </div>

                                <%-- <div style="margin-bottom: 5px; padding-right: 5px; text-align: left;">
                            <table style="width: 100%;">
                                <tr>
                                    <td>Username :                                
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>Password :</td>
                                </tr>
                                <tr>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td></td>
                                </tr>
                            </table>
                        </div>
                    <div style="text-align: left;">
                    </div>--%>
                            </div>
                        </LayoutTemplate>
                    </asp:Login>
                </div>


            </div>
        </div>
    </div>
</asp:Content>


<%--<asp:Content runat="server" ID="content2" ContentPlaceHolderID="right">--%>
<%-- <asp:HyperLink ID="registerLink1" runat="server"
        NavigateUrl="~/ViewsSite/Account/Register.aspx">Register</asp:HyperLink>--%>
<%--</asp:Content>--%>

<asp:Content runat="server" ID="content3" ContentPlaceHolderID="title">
    Home : Learning Management System
</asp:Content>


