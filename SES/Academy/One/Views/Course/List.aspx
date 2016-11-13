<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="One.Views.Course.List" %>

<%-- ~/ViewsSite/UserSite.Master --%>
<%@ Register TagPrefix="uc1" TagName="LstUc" Src="~/ViewsSite/DashBoard/Student/CourseOverView/LstUc.ascx" %>
<%@ Register Src="~/Views/Course/Course/CreateUC.ascx" TagPrefix="uc1" TagName="CreateUC" %>
<%@ Register Src="~/Views/Course/Category/Create.ascx" TagPrefix="uc1" TagName="Create" %>



<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">


    <div style="text-align: center; font-size: 1.3em;">
        <strong>
            <asp:Label ID="lblHeading" runat="server" Text="Course and Category Management"></asp:Label></strong>
        <hr />
    </div>
    <br />
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
                                <%-- ================================================================================ --%>
                                <%-- %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %%  --%>
                                <%-- Category side width: 28%; fdcab6--%>
                                <td style="width: 200px;  vertical-align: top; ">
                                    <div id="categoryDiv"
                                        class="text-wrap-div" style="overflow-y: scroll; width: 300px; height: 100%; ">

                                        <%-- <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                    <ContentTemplate>--%>
                                        <%-- list of categories --%>
                                        <div style="text-align: center; padding: 5px 0; margin: 0 0 3px;  font-weight: bold; background-color: #cacfd2;">
                                            Categories
                                        </div>
                                        <div style="padding-left: 5px;" >
                                            <asp:PlaceHolder ID="pnlCategories" runat="server"></asp:PlaceHolder>
                                        </div>
                                        <asp:HiddenField ID="hidSelectedCategory" Value="0" runat="server" />
                                        <asp:HiddenField ID="hidSelectedCategoryName" Value="" runat="server" />
                                        <%--  </ContentTemplate>
                                                </asp:UpdatePanel>--%>

                                        <%-- end --%>
                                        <div style="text-align: left; padding: 5px 0; background-color: #cacfd2;">
                                            &nbsp;&nbsp;
                                                <asp:LinkButton ID="lnkCatCreate" runat="server" OnClick="lnkCatCreate_Click">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                                                    New Category
                                                </asp:LinkButton>
                                        </div>

                                    </div>
                                </td>

                                <%-- %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %%  --%>
                                <%-- ============================================================================================= --%>
                                <%-- %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %% %%  --%>
                                <%-- Course side --%>
                                <td style="vertical-align: top; width: 100%;">
                                    <div style="min-height: 100%; border: 2px solid #cacfd2;">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <%-- list of courses in this category --%>
                                            <ContentTemplate>
                                                <div style="text-align: center; padding: 3px; background-color: #cacfd2">
                                                    Courses in category :&nbsp;
                                                <strong>
                                                    <asp:Label ID="lblCoursesTitle" runat="server" Text=""></asp:Label>
                                                </strong>
                                                    <div style="float: right;">
                                                        <asp:LinkButton ID="lnkCoursCreate" runat="server" Visible="False"
                                                            OnClick="lnkCoursCreate_Click">
                                                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                                                            Add Course
                                                        </asp:LinkButton>
                                                    </div>
                                                    <div style="clear: both;"></div>
                                                </div>
                                                <div id="courseDiv" style="background-color: azure; padding: 0 0 20px 5px;">



                                                    <asp:Panel ID="pnlCourses" runat="server">
                                                    </asp:Panel>


                                                    <div style="text-align: right; padding: 10px 10px 0 0;">



                                                        <%-- <asp:HyperLink ID="lnkCoursCreate" runat="server" 
                                                                    Na="lnkCoursCreate_Click">
                                                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                                                                    Add Course
                                                                </asp:HyperLink>--%>
                                                    </div>

                                                    <%-- DataSourceID="courseListingDS" --%>
                                                    <asp:DataList ID="dlistCourses" runat="server">
                                                        <ItemTemplate>

                                                            <%--<asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />--%>
                                                            <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("Id") %>' />

                                                            <%--<asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />--%>
                                                    
                                                                ●&nbsp;
                                                                <asp:HyperLink ID="HyperLink1" runat="server"
                                                                    NavigateUrl='<%# "~/Views/Course/CourseDetail.aspx?cId="+Eval("Id") %>'><%# Eval("FullName") %></asp:HyperLink>
                                                            &nbsp;(
                                                            <asp:Label ID="CodeLabel" runat="server" Text='<%# Eval("Code") %>' />
                                                            )
                                                            <br />

                                                        </ItemTemplate>
                                                    </asp:DataList>

                                                    <asp:HiddenField ID="HiddenField1" runat="server" />


                                                </div>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>

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
</asp:Content>

<asp:Content runat="server" ID="contenttitle" ContentPlaceHolderID="title">
    Course and Category Management
</asp:Content>



