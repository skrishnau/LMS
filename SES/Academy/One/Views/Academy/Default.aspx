<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="One.Views.Academy.Default" %>


<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>



<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <h3 class="heading-of-listing">Academic years
    </h3>
    <hr />


    <%-- class="menu" style="clear: both; margin: 20px 5px; padding: 10px;" --------------Menu------------- --%>
    <div>
        <%-- <div style="text-align: right;">
            <asp:HyperLink ID="lnkEdit" runat="server" CssClass="link">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Edit/edit_orange.png" />
                <asp:Label ID="lblEdit" runat="server" Text="Edit"></asp:Label>
            </asp:HyperLink>
        </div>--%>

        <div runat="server" id="pnlOtherEdits" visible="False" style="float: right;">
            <asp:HyperLink ID="lnkAdd" runat="server" CssClass="link-dark"
                NavigateUrl="~/Views/Academy/Create.aspx">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                New Academic Year
            </asp:HyperLink>

            &nbsp;&nbsp;
            <asp:HyperLink ID="lnkStartSession" runat="server" CssClass="link-dark"
                NavigateUrl="~/Views/Academy/StartSession.aspx">
                <asp:Image ID="Image3" runat="server" ImageUrl="~/Content/Icons/Start/Start_16px.png" />
                Start Session
            </asp:HyperLink>
            &nbsp;&nbsp;
        </div>

        <div style="float: right;">

            <%--<asp:HyperLink ID="lnkDefaultSessions" runat="server" CssClass="link-dark"
                NavigateUrl="~/Views/Academy/DefaultSessions.aspx">
                Default Sessions
            </asp:HyperLink>
            &nbsp;&nbsp;--%>

             <asp:HyperLink ID="lnkBatchList" runat="server" CssClass="link-dark"
                 NavigateUrl="~/Views/Student/Batch/Default.aspx">
                 <asp:Image ID="Image4" runat="server" ImageUrl="~/Content/Icons/List/List_16px.png" />
                 Batch List
             </asp:HyperLink>
            &nbsp;&nbsp;

        </div>

        <div style="clear: both;"></div>
    </div>
    <div style="clear: both;"></div>
    <%-- ------------END of Menu --%>
    <br />


    <div style="clear: both;">
        <asp:Panel ID="pnlAcademicYearListing" runat="server"></asp:Panel>
    </div>

    <asp:HiddenField ID="hidEdit" runat="server" Value="False" />
</asp:Content>

<asp:Content runat="server" ID="contnettitle" ContentPlaceHolderID="title">
    Academic year list
</asp:Content>
