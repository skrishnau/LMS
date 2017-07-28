<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ViewsSite/User/UserMaster.Master" CodeBehind="PageView.aspx.cs" Inherits="One.Views.ActivityResource.Page.PageView" %>




<asp:Content runat="server" ID="bodycontent" ContentPlaceHolderID="Body">

    <h3 class="heading-of-create-edit">
        <asp:Label ID="lblHeading" runat="server" Text="Label"></asp:Label>
    </h3>
    <br/>
    <br />
   <%-- <div>
        <asp:Panel ID="pnlError" runat="server" Visible="False">
            <img src="../../../Content/Icons/Notice/Warning_Shield_16px.png" />
            There's no file attached with this resource!
        </asp:Panel>
    </div>--%>

    <div>
        <asp:Label ID="lblContent" runat="server" Text="Label"></asp:Label>
        <%--<asp:Panel ID="pnlIFrame" runat="server" Visible="True">
            <iframe runat="server" clientidmode="Static" id="frame"
                sandbox="allow-scripts,allow-same-origin" style="height: 400px; width: 100%;border: none; "></iframe>
        </asp:Panel>--%>

    </div>

    <asp:HiddenField ID="hidFileResourceId" runat="server" Value="0" />
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        #frame {
            width: 442px;
            height: 264px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="title">
    <asp:Literal ID="lblTitle" runat="server"></asp:Literal>
</asp:Content>
