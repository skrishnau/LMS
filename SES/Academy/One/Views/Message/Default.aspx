<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ViewsSite/User/UserMaster.Master" CodeBehind="Default.aspx.cs" Inherits="One.Views.Message.Default" %>



<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>


<asp:Content runat="server" ID="contentBodyid" ContentPlaceHolderID="Body">
    <h3 class="heading-of-create-edit">
        Messages
    </h3>
    <div class="data-entry-body">
        <asp:DataList ID="DataList1" runat="server">
            

        </asp:DataList>
    </div>

</asp:Content>

