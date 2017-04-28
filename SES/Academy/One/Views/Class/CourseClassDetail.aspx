<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ViewsSite/User/UserMaster.Master" CodeBehind="CourseClassDetail.aspx.cs" Inherits="One.Views.Class.CourseClassDetail" %>


<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>


<asp:Content runat="server" ID="content" ContentPlaceHolderID="Body">
    <h3 class="heading-of-display">
        <asp:Label ID="lblCourseName" runat="server" Text=""></asp:Label>
    </h3>

    <div class="data-entry-section">
        <div>
            <div style="float: left;">
                <h3 class="heading-of-display">
                    <asp:Label ID="lblClassName" runat="server" Text=""></asp:Label>
                </h3>
            </div>

            <div style="text-align: center; vertical-align: bottom; float: left; padding-top: 8px; padding-left: 20px;">
                <asp:HyperLink ID="lnkReport" runat="server" CssClass="auto-st2 link">View Report</asp:HyperLink>
                &nbsp;
                <asp:HyperLink ID="lnkMarkCompletion" runat="server" CssClass="auto-st2 link">Mark Complete</asp:HyperLink>
            </div>


            <div style="clear: both;"></div>
        </div>
        <div class="data-entry-section">

            <table class="table-detail">
                <%-- <tr class="row-detail">
                    <td class="data-detail">Class Name</td>
                    <td>
                        <asp:Literal ID="lblFullName" runat="server"></asp:Literal>
                    </td>
                </tr>--%>
                <tr>
                    <td class="data-type">Start Date</td>
                    <td class="data-value">
                        <asp:Literal ID="lblStartDate" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="data-type">End Date</td>
                    <td class="data-value">
                        <asp:Literal ID="lblEndDate" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="data-type">Enrollment Method</td>
                    <td class="data-value">
                        <asp:Literal ID="lblEnrollmentMethod" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="data-type">Student Grouping
                    </td>
                    <td class="data-value">
                        <asp:Literal ID="lblGrouping" runat="server"></asp:Literal>
                        <div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <br />

        <div class="data-entry-section-body">

            <div class="data-entry-section-heading">
                <div style="float: left;">
                    Enrolled users                     
                </div>
                <%-- &nbsp; &nbsp; --%>
                <div style="float: right;">
                    <asp:Button ID="btnEnroll" runat="server" Text="Enroll Users" OnClick="btnEnroll_Click" />
                </div>
                <div style="clear: both;"></div>
                <hr />
            </div>
            <%--  ===================Listing of Enrolled Users ========================= --%>
            <asp:ListView ID="ListView1" runat="server">
                <LayoutTemplate>
                    <%--  border-collapse: collapse; --%>
                    <table id="Table1" runat="server" style="width: 99%;">
                        <thead>
                            <tr style="background-color: darkslategray; color: white;">
                                <td></td>
                                <td>Name</td>
                                <td>Email</td>
                                <td>Last Access to Course</td>
                                <td>Roles</td>
                                <td>Groups</td>
                            </tr>
                        </thead>
                        <tr runat="server" id="itemPlaceholder">
                        </tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#  GetImageUrl(DataBinder.Eval(Container.DataItem,"UserImageId")) %>'>
                                <asp:Image ID="Image1" runat="server"
                                    Height="20" Width="20"
                                    ImageUrl='<%#  GetImageUrl(DataBinder.Eval(Container.DataItem,"UserImageId")) %>' />
                            </asp:HyperLink>
                        </td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text='<%# GetName(DataBinder.Eval(Container.DataItem,"FirstName"),Eval("MiddleName"),Eval("LastName"))  %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                        </td>
                        <td>
                            <span style="font-size: 0.8em">
                                <asp:Label ID="Label8" runat="server" Text='<%# GetLastOnline(DataBinder.Eval(Container.DataItem,"LastOnline"))  %>'></asp:Label>
                            </span>
                        </td>
                        <td>
                            <tr></tr>
                        </td>
                        <td>
                            <asp:Label ID="lblGroup" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>

        </div>
    </div>
    <asp:HiddenField ID="hidSubjectSessionId" runat="server" Value="0" />

</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="title">
    <asp:Literal ID="lblTitle" runat="server"></asp:Literal>
</asp:Content>

<asp:Content runat="server" ID="content2" ContentPlaceHolderID="head">
    <link href="../../Content/CSSes/TableStyles.css" rel="stylesheet" />
</asp:Content>
