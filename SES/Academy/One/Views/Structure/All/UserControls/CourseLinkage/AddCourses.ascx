<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddCourses.ascx.cs" Inherits="One.Views.Structure.All.UserControls.CourseLinkage.AddCourses" %>

<div>
    <%--<asp:View ID="View1" runat="server">--%>

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div>

                <div style="margin: 5px; width: 74%; float: left; background-color: lightgreen;">
                    <div style="text-align: center; border-bottom: 1px solid gray; font-weight: 700;">
                        Course Selection
                    </div>


                    <%-- ========================== Category Div ================================= --%>
                    <%-- ========================================================================= --%>
                    <div id="categoryDiv" style="float: left; width: 25%; background-color: white; border: 1px solid grey; padding: 2px; overflow: auto; margin: 5px;">
                        <%-- list of categories text-align: center; --%>
                        <div style="text-align: center; font-weight: bold;">
                            Categories
                            <hr />
                        </div>

                        <%-- list of categories in a tree , highlight the selected category--%>
                        <asp:Panel ID="pnlCategories" runat="server">
                        </asp:Panel>
                        <br />
                        <%-- end --%>
                        <br />

                        <asp:HiddenField ID="hidSelectedCategory" Value="0" runat="server" />
                        <asp:HiddenField ID="hidSelectedCategoryName" Value="" runat="server" />
                    </div>

                    <%-- ======================================================== --%>
                    <%-- ======================================================== --%>


                    <div style="float: left; width: 70%; margin: 5px 5px 5px 0; overflow: auto;">
                        <div style="text-align: center; height: 19px;">
                            Courses in category:&nbsp;
                                    <strong>
                                        <asp:Label ID="lblCoursesTitle" runat="server" Text="Courses"></asp:Label>
                                    </strong>
                        </div>



                        <div id="courseDiv" style="padding: 0 0 20px 5px;">


                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <%-- list of courses in this category --%>
                                <ContentTemplate>


                                    <%--     <div style="text-align: right; padding: 10px 10px 0 0;">


                                  <%--  <asp:LinkButton ID="lnkCoursCreate" runat="server" OnClick="lnkCoursCreate_Click">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                                        Add Course
                                    </asp:LinkButton>

                                </div>--%>

                                    <div style="background-color: azure; height: 100%">
                                        <asp:Panel ID="pnlCourseList" ViewStateMode="Enabled" runat="server"></asp:Panel>
                                    </div>


                                    <%--<asp:DataList ID="dlistCourses" runat="server">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("Id") %>' />
                                        <asp:CheckBox ID="CheckBox1" runat="server"  OnCheckedChanged="OnCheckedChanged"/>
                                        &nbsp;
                                                    <asp:HyperLink ID="HyperLink1" runat="server"
                                                        NavigateUrl='<%# "~/Views/Course/CourseDetail.aspx?id="+Eval("Id") %>'><%# Eval("Name") %></asp:HyperLink>
                                        &nbsp;(
                                <asp:Label ID="CodeLabel" runat="server" Text='<%# Eval("Code") %>' />
                                        )
                                <br />
                                    </ItemTemplate>
                                </asp:DataList>--%>

                                    <asp:HiddenField ID="hidSchoolId" Value="0" runat="server" />

                                </ContentTemplate>
                            </asp:UpdatePanel>


                        </div>
                    </div>

                    <div style="clear: both;"></div>
                </div>

                <%-- ======================== Selected courses ================================== --%>
                <%-- ============================================================================ --%>
                <div style="float: left; min-height: 100px; height: 100%; width: 22%; padding: 2px 5px; 
                        background-color: lightcyan; margin: 0 0 1px 5px; overflow: hidden;">
                    <div style="height: 50%; min-height: 100px; margin-bottom: 5px;">
                        <span style="font-weight: 600;">Selected Courses</span>
                        <hr />
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="pnlSelectedCourses" runat="server">
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <br />

                    <div style="border-top: 1px double black; min-height: 100px; position: relative; 
                                bottom: 0; padding-top: 20px;">
                        <span style="font-weight: 600;">Saved Courses</span>
                        <hr />
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="pnlSavedCourses" runat="server">
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <%-- ============================================================================ --%>
                <%-- ============================================================================ --%>
            </div>
            <div style="clear: both;"></div>
            <br/>
            <div style="text-align: center;">
                <asp:Button runat="server" ID="btnSaveAndContinueAdding" Text="Save and Continue adding" Width="215px" 
                    CausesValidation="False"
                    OnClick="btnSaveAndContinueAdding_Click" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button runat="server" ID="btnSaveAndReturn" Text="Save and return" Width="176px" 
                    CausesValidation="False"
                    OnClick="btnSaveAndReturn_Click" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button runat="server" ID="btnCancel" Text="Cancel" Width="142px" 
                    CausesValidation="False"
                    OnClick="btnCancel_Click" />
                <br />
                <br />

            </div>

            <asp:HiddenField ID="hidYearId" Value="0" runat="server" />
            <asp:HiddenField ID="hidSubYearId" Value="0" runat="server" />

        </ContentTemplate>
    </asp:UpdatePanel>

    <%--</asp:View>--%>
</div>
