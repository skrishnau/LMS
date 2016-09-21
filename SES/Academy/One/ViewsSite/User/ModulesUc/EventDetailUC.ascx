<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EventDetailUC.ascx.cs" Inherits="One.ViewsSite.User.ModulesUc.EventDetailUC" %>
<div style="margin-left: 3px; margin-right: 3px;">
    
    <asp:Label ID="lblTime" runat="server" Text="Label"  Font-Bold="True"></asp:Label>
    <hr />
    <asp:Label ID="lblTitle" runat="server" Text="Label"  Font-Bold="True"></asp:Label>
    <div style="margin-left: 8px;">
        <asp:Label ID="lblDescription" runat="server" Text="Label"></asp:Label>
        <br/>
        <em><strong>
            Location:
        </strong>
            <asp:Label ID="lblLocation" runat="server" Text="Label"></asp:Label>
        </em>
    </div>
    <br />
</div>