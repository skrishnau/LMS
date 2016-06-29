<%@ Page Language="C#"  MasterPageFile="~/Login/MySite.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="One.Login._default" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    
   
    <div>
        <asp:Panel ID="authPanel" runat="server">
            <asp:Label ID="Label1" runat="server" Text="welcome back"></asp:Label>
        </asp:Panel>
         <asp:Panel ID="anonymPanel" runat="server">
             <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login/Login.aspx">Login</asp:HyperLink>
        </asp:Panel>
    
    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>
    </div>
   

</asp:Content>

