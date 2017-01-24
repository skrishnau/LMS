<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ViewsSite/User/UserMaster.Master" CodeBehind="Default.aspx.cs" Inherits="One.Views.Setting.Default" %>

<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    
    <div>
        <h3 class="heading-of-listing">
            Settings
        </h3>
        <hr/>
        
        <div class="data-entry-section-body">
            <div class="auto-st2">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Views/Structure/All/Master/List.aspx?edit=1" CssClass="link">
                    Programs
                </asp:HyperLink>
            </div>
            <div class="auto-st2">
                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="link"
                     NavigateUrl="~/Views/Grade/GradeListing.aspx">
                    Grade types
                </asp:HyperLink>
            </div>
             <div class="auto-st2">
                <asp:HyperLink ID="HyperLink3" runat="server" CssClass="link"
                     NavigateUrl="~/Views/Office/">
                   College
                </asp:HyperLink>
            </div>
        </div>

    </div>

</asp:Content>


<asp:Content runat="server" ID="content2" ContentPlaceHolderID="head">
    
</asp:Content>

<asp:Content runat="server" ID="content4" ContentPlaceHolderID="title">
    Settings
</asp:Content>



