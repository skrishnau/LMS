<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Home.aspx.cs" Inherits="One.Home" %>





<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">

    <%--<div style="margin: 0 auto; width: 80%; background-image: url('Content/Images/banner-1.jpg');  background-clip: content-box; background-repeat: no-repeat; background-position: left center; background-attachment: local; height: 200px;">--%>

    <%--</div>--%>
    <div class="roboto-light"
        style="padding: 10px 0 10px; text-align: center; font-size: 3em; vertical-align: central;">
        Learning Management
        <br />
        System
    </div>

    <div class="roboto-regular">
        <div style="font-size: 1.1em; margin-top: 15px;">
            The LMS is the College’s online system for delivering subject content to students.
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/About.aspx">Learn more</asp:HyperLink>
        </div>
        <br />
        <br />
        <div>
            Please 
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/ViewsSite/Account/Login.aspx">Login</asp:HyperLink>
            to access your classes
        </div>
        <br />
        <br />
        <div>
            You can view courses as guest
            <span class="roboto-regular">
                <asp:HyperLink runat="server" ID="hyperlink1" NavigateUrl="#">Go to courses</asp:HyperLink>
            </span>
        </div>


        <br />
    </div>
</asp:Content>


<asp:Content runat="server" ID="content3" ContentPlaceHolderID="title">
    Home : Learning Management System
</asp:Content>



