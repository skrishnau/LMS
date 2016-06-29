<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="One.Views.Role.Dashboard" %>

<%@ Register Src="~/Views/Role/Create.ascx" TagPrefix="uc1" TagName="Create" %>

<%@ Reference Control="~/Views/Role/Create.ascx" %>

<asp:Content runat="server" ContentPlaceHolderID="Body" ID="content1">

         <asp:Panel ID="Panel1" runat="server">
            <strong>Roles List</strong>
        <div style="float: right;">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">New Role</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Assign Roles</asp:LinkButton>
        </div>
        <div style="float: right;">
            
        </div>
            <div style="float: right; width:100%">
                <hr/>
            </div>
             </asp:Panel>
    <div style="padding: 5px 10px 5px;" runat="server">
     <asp:GridView ID="GridView1" runat="server" Width="100%">
    </asp:GridView>
        </div>
    <%--<asp:Panel ID="pnlCreate" runat="server" Visible="False">
        <uc1:Create runat="server" ID="Create" />
    </asp:Panel>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>--%>
</asp:Content>
