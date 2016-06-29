<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="One.Views.Office.School.Dashboard" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
      <asp:Panel ID="Panel1" runat="server">
            <strong>School OverView</strong>
        <div style="float: right;">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Edit</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;
            <%--<asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">New Session</asp:LinkButton>--%>
        </div>
        <div style="float: right;">
            
        </div>
            <div style="float: right; width:100%">
                <hr/>
                <br/>
            </div>
        

        </asp:Panel>
    <asp:FormView ID="FormView1" runat="server">
        <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
            <br/>
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
        </ItemTemplate>
    </asp:FormView>

</asp:Content>
