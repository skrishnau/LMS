<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="One.Views.Structure.Default" %>


<%--<%@ Register Src="~/Views/Structure/All/UserControls/CourseLinkage/CourseListUC.ascx" TagPrefix="uc1" TagName="CourseListUC" %>--%>
<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>


<%-- ~/ViewsSite/UserSite.Master --%>
<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <h3 class="heading-of-listing">Manage Programs
    </h3>
    <hr />

   <%-- <div style="float: right;">
        <asp:HyperLink ID="lnkEdit" runat="server">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Edit/edit_orange.png" />
            <asp:Label ID="lblEdit" runat="server" Text="Edit"></asp:Label>
        </asp:HyperLink>
    </div>--%>

    <div style="clear: both;"></div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="listStructureDiv" style="width: 98%;">

                <asp:PlaceHolder ID="pnlListing" runat="server"></asp:PlaceHolder>

                <div>
                    <asp:HyperLink ID="lnkAdd" runat="server" Visible="False" CssClass="link-button">
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                        <asp:Literal ID="lblAddText" runat="server" Text="Add Program"></asp:Literal>
                    </asp:HyperLink>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:HiddenField ID="hidEdit" runat="server" Value="0" />

</asp:Content>


<asp:Content runat="server" ID="headcontent" ContentPlaceHolderID="title">
    <asp:Literal ID="lblTabHead" runat="server" Text="Manage programs"></asp:Literal>
</asp:Content>
