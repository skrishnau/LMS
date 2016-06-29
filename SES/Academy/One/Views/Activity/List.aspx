<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="One.Views.Activity.List" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
      <asp:Panel ID="Panel1" runat="server">
            <strong> Subject Teach

            </strong>
        <div style="float: right;">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Teacher Assign</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Student Assign</asp:LinkButton>
        </div>
        <div style="float: right;">
            
        </div>
            <div style="float: right; width:100%">
                <hr/>
            </div>
        
        </asp:Panel>
</asp:Content>
