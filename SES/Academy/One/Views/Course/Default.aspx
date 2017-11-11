<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ViewsSite/User/UserMaster.Master" CodeBehind="Default.aspx.cs" Inherits="One.Views.Course.Default" %>

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

                <div class="row">
                    <div class="col-md-4">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <div class="panel-title">
                                    Categories
                                </div>
                            </div>

                            <div class="list-group">
                                <asp:PlaceHolder ID="pnlCategories" runat="server"></asp:PlaceHolder>
                                <asp:HiddenField ID="hidSelectedCategory" Value="0" runat="server" />
                                <asp:HiddenField ID="hidSelectedCategoryName" Value="" runat="server" />

                                <div style="text-align: right; margin-top: 8px;" class="">
                                    <asp:LinkButton ID="lnkCatCreate" runat="server" OnClick="lnkCatCreate_Click"
                                        CssClass="btn btn-default">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                                        New Category
                                    </asp:LinkButton>
                                </div>
                                <br />
                            </div>
                        </div>
                    </div>

                    <%-- End of col-md-3 --%>

                    <div class="col-md-8">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <div class="panel-title">
                                    Courses in category :&nbsp;
                                    <asp:Label ID="lblCoursesTitle" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <%--<div class="list-group">--%>
                            <%--<div class="category-body-outer" style="height: 350px;">--%>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <%-- course-list-item-datalist --%>
                                    <asp:DataList ID="dlistCourses" CssClass="list-group" runat="server" Width="100%">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server"
                                                CssClass="list-group-item"
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

                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <%--</div>--%>
                            <%-- link-dark-for-dark-backcolor   option-div  CssClass="link-outer" --%>
                            <div style="text-align: right; margin-top: 7px;">
                                <asp:LinkButton ID="lnkCoursCreate" runat="server" Visible="False"
                                    CssClass="btn btn-default"
                                    OnClick="lnkCoursCreate_Click">
                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                                    Add Course
                                </asp:LinkButton>
                            </div>
                            <%--</div>--%>
                        </div>

                    </div>

                </div>

            </div>


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


