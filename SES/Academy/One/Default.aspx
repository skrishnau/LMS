<%@ Page Title="Home Page"  Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="One._Default" %>

<%-- MasterPageFile="~/Site.Master" --%>

<%@ Register Src="~/ViewsSite/DashBoard/Student/CourseOverView/LstUc.ascx" TagPrefix="uc1" TagName="LstUc" %>



<asp:Content runat="server" ID="bodyTitle" ContentPlaceHolderID="BodyTitle">
    <h3>COURSE OVERVIEW  </h3>
</asp:Content>

<asp:Content runat="server" ID="contentBody" ContentPlaceHolderID="Body">
    <uc1:LstUc runat="server" ID="LstUc1" />
</asp:Content>

<%--<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Modify this template to jump-start your ASP.NET application.</h2>
            </hgroup>
            <p>
                To learn more about ASP.NET, visit <a href="http://asp.net" title="ASP.NET Website">http://asp.net</a>.
                The page features <mark>videos, tutorials, and samples</mark> to help you get the most from ASP.NET.
                If you have any questions about ASP.NET visit
                <a href="http://forums.asp.net/18.aspx" title="ASP.NET Forum">our forums</a>.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
    <h3>We suggest the following:</h3>
    <ol class="round">
        <li class="one">
            <h5>Getting Started</h5>
            ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            <a href="http://go.microsoft.com/fwlink/?LinkId=245146">Learn more…</a>
        </li>
        <li class="two">
            <h5>Add NuGet packages and jump-start your coding</h5>
            NuGet makes it easy to install and update free libraries and tools.
            <a href="http://go.microsoft.com/fwlink/?LinkId=245147">Learn more…</a>
        </li>
        <li class="three">
            <h5>Find Web Hosting</h5>
            You can easily find a web hosting company that offers the right mix of features and price for your applications.
            <a href="http://go.microsoft.com/fwlink/?LinkId=245143">Learn more…</a>
        </li>
    </ol>
</asp:Content>--%>

<asp:Content runat="server" ID="titleContnet" ContentPlaceHolderID="title">
    Dashboard
</asp:Content>



<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <link href="Content/CSSes/ToolTip.css" rel="stylesheet" />
</asp:Content>
