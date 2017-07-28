﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ViewsSite/User/UserMaster.Master" CodeBehind="Default.aspx.cs" Inherits="One.Views.Course.Default" %>

<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">


    <h3 class="heading-of-listing">
        <asp:Label ID="lblHeading" runat="server" Text="Course and Category Management"></asp:Label>
    </h3>
    <hr />
    <%-- <br />--%>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <%--<asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">--%>
            <%--<asp:View ID="View1" runat="server">--%>
            <div>

                <div style="width: 100%;">

                    <div style="margin: 5px;">
                        <table>
                            <tr>

                                <%-- %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %%  --%>
                                <%-- Category side width: 28%; fdcab6--%>
                                <td style="width: 200px; vertical-align: top;">
                                    <%-- id="categoryDiv"  class="text-wrap-div" --%>
                                    <div class="category-list-header">
                                        Categories
                                    </div>
                                    <div class="category-body-outer" style="width: 250px; height: 350px;">

                                        <div style="padding-top: 5px;">
                                            <asp:PlaceHolder ID="pnlCategories" runat="server"></asp:PlaceHolder>
                                        </div>
                                        <asp:HiddenField ID="hidSelectedCategory" Value="0" runat="server" />
                                        <asp:HiddenField ID="hidSelectedCategoryName" Value="" runat="server" />
                                    </div>
                                    <br />
                                    <div style="text-align: left;" class="option-div">
                                        <asp:LinkButton ID="lnkCatCreate" runat="server" OnClick="lnkCatCreate_Click"
                                            CssClass="link-dark">
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                                            New Category
                                        </asp:LinkButton>
                                    </div>
                                </td>

                                <%-- ============================================================================================= --%>
                                <%-- Course side --%>
                                <%-- border-left: 2px solid #cacfd2; --%>
                                <td style="vertical-align: top; width: 100%;">
                                    <%-- style="min-height: 100%;" --%>
                                    <div class="category-list-header">
                                        Courses in category :&nbsp;
                                                    <asp:Label ID="lblCoursesTitle" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="category-body-outer" style="height: 350px;">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>


                                                <div style="padding-top: 5px; height: 340px;">
                                                    <asp:DataList ID="dlistCourses" runat="server" Width="99%">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="course-list-item-datalist"
                                                                NavigateUrl='<%# "~/Views/Course/CourseDetail.aspx?cId="+Eval("Id") %>'>
                                                                <%# Eval("FullName") %>
                                                                <asp:Label ID="CodeLabel" runat="server"
                                                                    Text='<%# GetCode(Eval("Code")) %>' />
                                                            </asp:HyperLink>
                                                            <%--&nbsp;(--%>

                                                            <%--)--%>
                                                            <%--</div>--%>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                </div>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div style="text-align: right;" class="option-div">
                                        <asp:LinkButton ID="lnkCoursCreate" runat="server" Visible="False"
                                            CssClass="link-dark-for-dark-backcolor"
                                            OnClick="lnkCoursCreate_Click">
                                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                                            Add Course
                                        </asp:LinkButton>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <%-- 28% --%>


                        <%-- ======================================================== --%>
                        <%-- ==================width: 68%;====================================== --%>


                        <div style="clear: both;"></div>
                    </div>
                </div>

            </div>
            <%--</asp:View>--%>





            <%-- <asp:View ID="viewCategoryCreate" runat="server">
                    <uc1:Create runat="server" ID="categoryCreate" />
                </asp:View>

                <asp:View ID="viewCourseCreate" runat="server">
                    <uc1:CreateUC runat="server" ID="courseCreate" />
                </asp:View>--%>

            <%--</asp:MultiView>--%>

            <asp:HiddenField ID="hidSchoolId" Value="0" runat="server" />
            <asp:HiddenField ID="hidManager" Value="False" runat="server" />

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .text-wrap-div {
            word-wrap: normal;
        }

        .text-wrap {
            background: grey;
            width: 400px;
            height: 100px;
            word-wrap: normal;
            overflow: hidden;
            white-space: pre-line;
            text-overflow: ellipsis;
        }
    </style>
    <link href="../../Content/CSSes/CourseListingStyles.css" rel="stylesheet" />

</asp:Content>

<asp:Content runat="server" ID="contenttitle" ContentPlaceHolderID="title">
    Course and Category Management
</asp:Content>


