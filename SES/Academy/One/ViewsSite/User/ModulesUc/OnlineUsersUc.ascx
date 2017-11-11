<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OnlineUsersUc.ascx.cs" Inherits="One.ViewsSite.User.ModulesUc.OnlineUsersUc" %>

<div class="panel panel-default">
    <%-- style="margin: -4px;" --%>
    <div class="panel-heading">
        <%-- CssClass="modules-title" --%>
        <asp:Label ID="label1" runat="server" >Online Users</asp:Label>
        <asp:HiddenField ID="hidUserId" runat="server" Value="0" />
        <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
    </div>
    <%-- modules-body --%>
    <div class="list-group">
        <span >
            <asp:Label ID="lblEmptyOnlineUsers" runat="server" Text=" &nbsp; No users online" ForeColor="darkgray" Font-Size="0.9em"></asp:Label>
        </span>
        <asp:DataList ID="DataList1" runat="server">
            <ItemTemplate>
                <div class="list-group-item">
                    &nbsp;&nbsp;&nbsp;
                    <span style="color: green">●</span>
                    <asp:HyperLink ID="Label1" runat="server" Text='<%# GetName(Eval("FirstName"),Eval("MiddleName"),Eval("LastName")) %>'></asp:HyperLink>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>



</div>
