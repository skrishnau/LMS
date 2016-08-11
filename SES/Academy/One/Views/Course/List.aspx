<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="One.Views.Course.List" %>

<%-- ~/ViewsSite/UserSite.Master --%>
<%@ Register TagPrefix="uc1" TagName="LstUc" Src="~/ViewsSite/DashBoard/Student/CourseOverView/LstUc.ascx" %>
<%@ Register Src="~/Views/Course/Course/CreateUC.ascx" TagPrefix="uc1" TagName="CreateUC" %>
<%@ Register Src="~/Views/Course/Category/Create.ascx" TagPrefix="uc1" TagName="Create" %>



<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>



            <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
                <asp:View ID="View1" runat="server">
                    <div>
                        <div style="text-align: center;">
                            <strong>Course and Category Management</strong>
                            <hr />
                        </div>


                        <div style="clear: both;"></div>
                        <br />
                        <div style="width: 100%;">

                            <div style="margin: 5px;">
                                <div id="categoryDiv" style="float: left; width: 28%; 
                                                background-color: white; border: 1px solid grey; 
                                                padding: 5px 10px 10px 0;">
                                    <%-- list of categories --%>
                                    <div style="text-align: center; font-weight: bold;">Categories</div>
                                    <br />
                                    <%-- list of categories in a tree , highlight the selected category--%>
                                    <asp:Panel ID="pnlCategories" runat="server" ViewStateMode="Enabled">
                                    </asp:Panel>
                                    <br />
                                    <%-- end --%>
                                    <br />
                                    <div style="text-align: left;">
                                        &nbsp;&nbsp;
                                    <asp:LinkButton ID="lnkCatCreate" runat="server" OnClick="lnkCatCreate_Click">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                                        New Category
                                    </asp:LinkButton>


                                        <%-- <asp:HyperLink ID="lnkCategoryCreate" runat="server"
                                NavigateUrl="~/Views/Course/Category/Create.aspx">
                                <asp:Image ID="imgCategoryCreate" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                                New Category
                            </asp:HyperLink>--%>
                                    </div>
                                    <br />
                                    <asp:HiddenField ID="hidSelectedCategory" Value="0" runat="server" />
                                    <asp:HiddenField ID="hidSelectedCategoryName" Value="" runat="server" />
                                </div>

                                <%-- ======================================================== --%>
                                <%-- ======================================================== --%>

                                <div style="float: left; width: 68%; margin-left: 2%;">
                                    <div style="text-align: center; height: 19px;">
                                        Courses in category:&nbsp;
                                    <strong>
                                        <asp:Label ID="lblCoursesTitle" runat="server" Text="Courses"></asp:Label>
                                    </strong>
                                    </div>
                                    <div id="courseDiv" style="background-color: azure; padding: 0 0 20px 5px;">


                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <%-- list of courses in this category --%>
                                            <ContentTemplate>
                                                <asp:Panel ID="pnlCourses" runat="server">
                                                </asp:Panel>


                                                <div style="text-align: right; padding: 10px 10px 0 0;">


                                                    <asp:LinkButton ID="lnkCoursCreate" runat="server" OnClick="lnkCoursCreate_Click">
                                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                                                        Add Course
                                                    </asp:LinkButton>


                                                    <%-- <asp:HyperLink ID="lnkCourseCreate" runat="server"
                                    NavigateUrl="~/Views/Course/CourseEntryForm.aspx">
                                    <asp:Image ID="imgCourseCreate" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                                    Add Courses
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
                                                        NavigateUrl='<%# "~/Views/Course/CourseDetail.aspx?id="+Eval("Id") %>'><%# Eval("Name") %></asp:HyperLink>
                                                        &nbsp;(
                                <asp:Label ID="CodeLabel" runat="server" Text='<%# Eval("Code") %>' />
                                                        )
                                <br />
                                                        <%-- Summary:
                                <asp:Label ID="SummaryLabel" runat="server" Text='<%# Eval("Summary") %>' />
                                <br />
                               
                                <br />
                                Credit:
                                <asp:Label ID="CreditLabel" runat="server" Text='<%# Eval("Credit") %>' />
                                <br />
                                SubjectCategoryId:
                                <asp:Label ID="SubjectCategoryIdLabel" runat="server" Text='<%# Eval("SubjectCategoryId") %>' />
                                <br />
                                SubjectCategory:
                                <asp:Label ID="SubjectCategoryLabel" runat="server" Text='<%# Eval("SubjectCategory") %>' />
                                <br />
                                CompletionHours:
                                <asp:Label ID="CompletionHoursLabel" runat="server" Text='<%# Eval("CompletionHours") %>' />
                                <br />
                                FullMarks:
                                <asp:Label ID="FullMarksLabel" runat="server" Text='<%# Eval("FullMarks") %>' />
                                <br />
                                PassPercentage:
                                <asp:Label ID="PassPercentageLabel" runat="server" Text='<%# Eval("PassPercentage") %>' />
                                <br />
                                IsActive:
                                <asp:Label ID="IsActiveLabel" runat="server" Text='<%# Eval("IsActive") %>' />
                                <br />
                                Void:
                                <asp:Label ID="VoidLabel" runat="server" Text='<%# Eval("Void") %>' />
                                <br />
                                HasLab:
                                <asp:Label ID="HasLabLabel" runat="server" Text='<%# Eval("HasLab") %>' />
                                <br />
                                HasTheory:
                                <asp:Label ID="HasTheoryLabel" runat="server" Text='<%# Eval("HasTheory") %>' />
                                <br />
                                HasProject:
                                <asp:Label ID="HasProjectLabel" runat="server" Text='<%# Eval("HasProject") %>' />
                                <br />
                                HasTutorial:
                                <asp:Label ID="HasTutorialLabel" runat="server" Text='<%# Eval("HasTutorial") %>' />
                                <br />
                                IsElective:
                                <asp:Label ID="IsElectiveLabel" runat="server" Text='<%# Eval("IsElective") %>' />
                                <br />
                                IsOutOfSyllabus:
                                <asp:Label ID="IsOutOfSyllabusLabel" runat="server" Text='<%# Eval("IsOutOfSyllabus") %>' />
                                <br />
                                CreatedDate:
                                <asp:Label ID="CreatedDateLabel" runat="server" Text='<%# Eval("CreatedDate") %>' />
                                <br />
                                SubjectGroupSubjects:
                                <asp:Label ID="SubjectGroupSubjectsLabel" runat="server" Text='<%# Eval("SubjectGroupSubjects") %>' />
                                <br />
                                Teach:
                                <asp:Label ID="TeachLabel" runat="server" Text='<%# Eval("Teach") %>' />
                                <br />
                                SubjectSections:
                                <asp:Label ID="SubjectSectionsLabel" runat="server" Text='<%# Eval("SubjectSections") %>' />
                                <br />
                                <br />--%>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                                <%-- <asp:ObjectDataSource ID="courseListingDS" runat="server" SelectMethod="ListCourses" TypeName="Academic.DbHelper.DbHelper+Subject">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="HiddenField1" DefaultValue="0" Name="schoolId" PropertyName="Value" Type="Int32" />
                                                    <asp:ControlParameter ControlID="HiddenField1" DefaultValue="0" Name="categoryId" PropertyName="Value" Type="Int32" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>--%>
                                                <asp:HiddenField ID="HiddenField1" runat="server" />

                                            </ContentTemplate>
                                        </asp:UpdatePanel>


                                    </div>
                                </div>
                                <div style="clear: both;"></div>
                            </div>
                        </div>

                    </div>
                </asp:View>

                <%-- ======================================================== --%>
                <%-- Second View  --%>
                <asp:View ID="viewCategoryCreate" runat="server">
                    <%--<a href="CourseEntryForm.aspx">CourseEntryForm.aspx</a>--%>
                    <uc1:Create runat="server" ID="categoryCreate" />
                </asp:View>

                <%-- ======================================================== --%>
                <%-- Third View --%>
                <asp:View ID="viewCourseCreate" runat="server">
                    <uc1:CreateUC runat="server" ID="courseCreate" />
                </asp:View>
            </asp:MultiView>


        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>


