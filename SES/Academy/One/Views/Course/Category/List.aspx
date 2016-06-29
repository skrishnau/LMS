<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="One.Views.Course.Category.List" %>

<asp:Content runat="server" ID="contentLeft" ContentPlaceHolderID="BodyInnerLeft">
    <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Views/Course/Category/Create.aspx" runat="server">Create</asp:HyperLink>
</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
     <div>
        <asp:Panel ID="Panel1" runat="server">
            <strong>Student List</strong>
            <div style="float: right;">
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">New Student</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Student group</asp:LinkButton>
                &nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Student Group Assign</asp:LinkButton>

            </div>
            <div style="float: right;">
            </div>
            <div style="float: right; width: 100%">
                <hr />
            </div>
        </asp:Panel>
        

    </div>
</asp:Content>
