<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="One.Views.User.List" %>

<asp:Content runat="server" ID="contentLeft" ContentPlaceHolderID="BodyInnerLeft">
    
    <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Views/User/Create.aspx" runat="server">Create User</asp:HyperLink>
    <asp:HyperLink ID="HyperLink2" NavigateUrl="~/Views/Student/StudentList.aspx" runat="server">Students</asp:HyperLink>

</asp:Content>


<asp:Content runat="server" id="content" ContentPlaceHolderID="Body">
<div>
    
        
    
     <div>
        <asp:Panel ID="Panel1" runat="server">
            <strong>Users</strong>
            <div style="float: right;">
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">New User</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Assign Role</asp:LinkButton>
            </div>
            <div style="float: right;">
            </div>
            <div style="float: right; width: 100%">
                <hr />
            </div>
        </asp:Panel>
        

    </div>

    <asp:TextBox ID="txtSchoolId" runat="server" Visible="False" Text="Random"></asp:TextBox>
    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" Width="509px">
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>

    <br />
    </div>
    </asp:Content>
