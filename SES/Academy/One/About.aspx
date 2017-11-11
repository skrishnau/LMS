<%@ Page Title="About" Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="One.About" %>



<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">

    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>

<asp:Content runat="server" ID="Content4" ContentPlaceHolderID="BodyTitle">
    <%--font-size: 3em; style="padding: 10px 0 10px; text-align: center;  vertical-align: central;"--%>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="Body">



    <%-- <hgroup class="title roboto-light">
        <h1 class="roboto-light"><%: Title %>.</h1>

    </hgroup>--%>
    <%-- font-size: 1.2em; --%>
    <h3 class="roboto-light" style=" margin: 10px 0 0 5px; color: darkgrey;">
        Learning Management System
    </h3>
    <hr/>
    <%-- style="text-align: right;" --%>
    <div class="text-right">
        <asp:HyperLink ID="lnkEdit" runat="server"
            Visible="False" CssClass="btn btn-default"
            NavigateUrl="~/Views/Office/School/Create.aspx">Edit</asp:HyperLink>
    </div>

    <article>
        <asp:Label ID="lblDescription" runat="server" Text="Label"></asp:Label>

        <%-- <p>
            <div>
                Teaching staff use the LMS to:
            </div>
            <ul>
                <li>Manage basic subject administration such as announcements, class lists and group management            
                </li>
                <li>Provide online versions of class materials and readings
                </li>
                <li>Offer extended content such as multimedia files
                </li>
                <li>Allow electronic submission of assignments
                </li>
                <li>Download, mark and return assignments and feedback
                </li>
                <li>Conduct online tests and surveys
                </li>
                <li>Provide a portal to TurnItIn, the originality checking software to which students can submit essays for checking
                </li>
                <li>Offer students the opportunity to participate in online communication activities such as blogs, journals and wikis.
                </li>
            </ul>
        </p>--%>
    </article>

    <%-- <aside>
        <h1 class="roboto-light">About Nepal Engineering College</h1>
        <p>
            The vision of nec is to evolve as the center of higher learning, excelling in academics, through continued engagements in education, research and outreach as three integrated functions of the college
            <br />

            In approaching the stated vision, the mission of nec include:
            <ul>
                <li>Providing the youth with the best opportunities and environment of learning to help them attain high level of academic standard, scientific temper, technical and professional competence and life-skills.
                </li>
                <li>Train and develop youth as total person, ready to serve the society and people to alleviate their sufferings and improve their quality of life.
                </li>
                <li>Inculcate the values to appreciate the need for ethical standards in personal, social and public life, to become leaders, to be a voice to influence the society and the nation, and to uphold just social order.
                </li>
            </ul>

        </p>

    </aside>--%>
</asp:Content>

<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="right">
    <div class="row">
        <div>
            <div class="box roboto-regular" runat="server" id="loginDiv" visible="True">
                <span style="padding: 0 0 5px; text-align: left; color: darkgray;">You are not logged in. 
                </span>
                <br />
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/ViewsSite/Account/Login.aspx">Login</asp:HyperLink>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="title">
    About LMS
</asp:Content>
