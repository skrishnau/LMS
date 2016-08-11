<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="One.Views.Structure.All.Master.List" %>
<%-- ~/ViewsSite/UserSite.Master --%>
<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <div>
        <div class="float-left">
            <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Views/Structure/All/Create.aspx" runat="server">Create</asp:HyperLink>
            <asp:HyperLink ID="HyperLink2" runat="server">HyperLink</asp:HyperLink>
        </div>
    </div>
    <div class="float-left">
        <div>
            List of structure
            <asp:TreeView ID="TreeView1" runat="server" ShowLines="True"></asp:TreeView>
        </div>

    </div>
    
    <div id="listStructureDiv" >
        <strong>Index</strong>
        <br/>
        <asp:PlaceHolder ID="pnlListing" runat="server">
            
        </asp:PlaceHolder>
    </div>
</asp:Content>