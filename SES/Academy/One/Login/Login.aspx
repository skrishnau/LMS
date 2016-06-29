<%@ Page Language="C#" MasterPageFile="~/Login/MySite.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="One.Login.Login" %>
<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">
    <h1>Login</h1>
<div>
    <p>
        Username:
        <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
    </p>
    <p>
        Password:
             <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
    </p>
    <p>
        <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me" />
    </p>
    <p>
        <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" />
    </p>
    <p>
        <asp:Label ID="InvalidCredentialsMessage" runat="server" ForeColor="Red"
            Visible="false"
             Text="Your username or password is invalid."></asp:Label>
    </p>
</div>
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="LoginContent">
                    
                    
                    
                    <asp:LoginView ID="LoginView1" runat="server">
                        
                    </asp:LoginView>
                    <br/> <br/>
                </asp:Content>


