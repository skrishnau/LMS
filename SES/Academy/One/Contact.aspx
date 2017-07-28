<%@ Page Title="Contact" Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="One.Contact" %>



<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">

    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="Body">
    
     <div class="roboto-light"
        style="padding: 10px 0 10px; text-align: center; font-size: 3em; vertical-align: central;">
        Learning Management
        <br />
        System
    </div>

    <hgroup class="title">
        <h1 class="roboto-light"><%: Title %>.</h1>
    </hgroup>

    <section class="contact">
        <header>
            <h3 class="roboto-light">Phone:</h3>
        </header>
        <p>
            <span class="label">Main:</span>
            <%--<span>425.555.0100</span>--%>
            <span>
                <asp:Label ID="lblPhoneMain" runat="server" Text="M/A"></asp:Label></span>
        </p>
        <p>
            <span class="label">After Hours:</span>
            <%--<span>425.555.0199</span>--%>
            <span>
                <asp:Label ID="lblPhoneAfterHours" runat="server" Text="N/A"></asp:Label></span>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3 class="roboto-light">Email:</h3>
        </header>
        <p>
            <span class="label">Support:</span>
            <span>
                <asp:HyperLink ID="lnkEmailSupport" runat="server">N/a</asp:HyperLink></span>
            <%--<span><a href="mailto:Support@example.com">Support@example.com</a></span>--%>
        </p>
        <p>
            <span class="label">Marketing:</span>
              <span>
                <asp:HyperLink ID="lnkEmailMarketing" runat="server">N/a</asp:HyperLink></span>
            <%--<span><a href="mailto:Marketing@example.com">Marketing@example.com</a></span>--%>
        </p>
        <p>
            <span class="label">General:</span>
              <span>
                <asp:HyperLink ID="lnkEmailGeneral" runat="server">N/a</asp:HyperLink></span>
            <%--<span><a href="mailto:General@example.com">General@example.com</a></span>--%>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3 class="roboto-light">Address:</h3>
        </header>
        <p>
            <asp:Label ID="lblAddress" runat="server" Text="N/a"></asp:Label>
           <%-- One Microsoft Way<br />
            Redmond, WA 98052-6399--%>
        </p>
    </section>
</asp:Content>


<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="right">
    <div class="box roboto-regular" runat="server" id="loginDiv" visible="True">
        <span style="padding: 0 0 5px; text-align: left; color: darkgray;">You are not logged in. 
        </span>
        <br />
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/ViewsSite/Account/Login.aspx">Login</asp:HyperLink>
    </div>
</asp:Content>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="title">
    Contact
</asp:Content>