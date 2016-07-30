<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChatRoom.ascx.cs" Inherits="One.Views.Course.ActivityAndResource.EntryUserConrols.Activity.ChatViews.ChatRoom" %>

<div>

    <div class="form-title">
        <strong>
            <asp:Label ID="Label1" runat="server" Text="Title"></asp:Label>
        </strong>
    </div>

    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br/>
        <asp:Button ID="Button1" runat="server" Text="Send" /> &nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="Refresh" />
    </div>
    <br/>
    <div>
        <strong>Messages</strong>

        <div>
            <asp:DataList ID="DataList1" runat="server"></asp:DataList>
        </div>
    </div>

    <div style="position: fixed; right: 0; overflow: auto;">
        
    </div>

    <%--
    <div style="position: fixed; bottom: 0; left: 0; width: 100%;">
            
    </div>--%>
</div>
