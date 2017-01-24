<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ItemUc.ascx.cs" Inherits="One.Views.All_Resusable_Codes.ListDisplay.ItemUc" %>

<asp:HyperLink ID="lnk" runat="server">
    <div style="font-size: 1.3em;">
       
        <asp:Label ID="lblHeading" runat="server" Text="Label"></asp:Label>
    </div>
    <div style="padding-left: 10px; font-size: 0.8em; margin-top: -8px;">
        <asp:Literal ID="lblDescription" runat="server"></asp:Literal>
        <br />
        <span style="color: lightgray;">
            <asp:Literal ID="lblUrl" runat="server"></asp:Literal>
        </span>
    </div>
</asp:HyperLink>