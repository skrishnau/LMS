<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Home.aspx.cs" Inherits="One.Home" %>





<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">

    <%--<div style="margin: 0 auto; width: 80%; background-image: url('Content/Images/banner-1.jpg');  background-clip: content-box; background-repeat: no-repeat; background-position: left center; background-attachment: local; height: 200px;">--%>

    <%--</div>--%>

    <%--<div class="roboto-light well"
        style="padding: 10px 0 10px; text-align: center; font-size: 3em; vertical-align: central;">
        Learning Management
        <br />
        System
    </div>--%>
    <%-- roboto-light well --%>
    <div class=" text-center">
        <asp:Image runat="server" ImageUrl="~/Content/Images/LMS-Title-For-Text.png" Height="120" Width="280" />
    </div>
    <br />
    <br />
    <div class="roboto-regular">
        <div class="row">
            <%-- style="font-size: 1.1em; margin-top: 15px;" --%>
            <div class="col-md-4" style="line-height: 32px;">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Images/lms_banner.png" Height="150" Width="250" />
                <br />
                <strong>What is LMS?</strong>
                <br />
                The LMS is the College’s online system for delivering subject content to students.
                <div>
                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/About.aspx" CssClass="btn btn-info">
                        Read more
                        <span class="glyphicon glyphicon-menu-right"></span>
                    </asp:HyperLink>
                </div>
                <br />
            </div>

            <div class="col-md-4" style="line-height: 32px; border-left: 1px solid lightgray; border-right: 1px solid lightgray;">
                <%--Please 
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/ViewsSite/Account/Login.aspx">Login</asp:HyperLink>
                to access your classes--%>
                <div class="text-center">
                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Content/Images/training_banner1.png" Height="152" Width="220" />
                </div>
                <strong>Training</strong>
                <br />
                Our training courses can help you get the most out of LMS. Designed for teachers.
                <br />
                <div>
                    <asp:HyperLink runat="server" ID="hyperlink11" NavigateUrl="#" CssClass="btn btn-info">
                        Read more
                        <span class="glyphicon glyphicon-menu-right"></span>
                    </asp:HyperLink>
                </div>
                <br />
            </div>

            <div class="col-md-4" style="line-height: 32px;">
                <asp:Image ID="Image3" runat="server" ImageUrl="~/Content/Images/courses_banner.jpg" Height="150" Width="250" />
                <br />
                <strong>Courses</strong>
                <br />
                Discover our vast collection of courses designed to fit your needs.
                You can view courses as guest
                <div>
                    <asp:HyperLink runat="server" ID="hyperlink1" NavigateUrl="#" CssClass="btn btn-info">
                        Read more
                        <span class="glyphicon glyphicon-menu-right"></span>
                    </asp:HyperLink>
                </div>
                <br />
            </div>


            <br />
        </div>

       <%-- <div class="row" style="line-height: 32px;">
            <div class="col-md-4" style="padding-top: 15px;">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/Images/aboutLMS.png" Height="150" Width="250" />
                <div>
                    <strong>Survey</strong>
                    <br />
                    Help us build a better system by taking part in survey.
                    <div>
                        <asp:HyperLink runat="server" ID="hyperlink2" NavigateUrl="#" CssClass="btn btn-info">
                            Learn more
                            <span class="glyphicon glyphicon-menu-right"></span>
                        </asp:HyperLink>
                    </div>
                    <br />
                </div>
            </div>
            <div class="col-md-4" style="border-left: 1px solid lightgray; border-right: 1px solid lightgray;">
            </div>
            <div class="col-md-4">
            </div>
        </div>--%>
    </div>
</asp:Content>


<asp:Content runat="server" ID="content3" ContentPlaceHolderID="title">
    Home : Learning Management System
</asp:Content>



