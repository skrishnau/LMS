<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OnlineUsersUc.ascx.cs" Inherits="One.ViewsSite.User.ModulesUc.OnlineUsersUc" %>

<div class="module-whole">
    <div class="modules-heading"style="margin: -4px;">
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="modules-title">Online Users</asp:HyperLink>
        <asp:HiddenField ID="hidUserId" runat="server" Value="0" />
        <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
    </div>
    <%-- modules-body --%>
    <div >
        <span >
            <asp:Label ID="lblEmptyOnlineUsers" runat="server" Text=" &nbsp; No users online" ForeColor="darkgray" Font-Size="0.9em"></asp:Label>
        </span>
        <asp:DataList ID="DataList1" runat="server">
            <ItemTemplate>
                <div>
                    &nbsp;&nbsp;&nbsp;
                    <span style="color: green">●</span>
                    <asp:HyperLink ID="Label1" runat="server" Text='<%# GetName(Eval("FirstName"),Eval("MiddleName"),Eval("LastName")) %>'></asp:HyperLink>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>



</div>
