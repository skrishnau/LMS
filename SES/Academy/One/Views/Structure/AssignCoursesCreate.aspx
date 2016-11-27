<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="AssignCoursesCreate.aspx.cs" Inherits="One.Views.Structure.AssignCoursesCreate" %>




<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="body">

    <h3 class="heading-of-listing">
        <asp:Label ID="lblHeading" runat="server" Text="Course Assign"></asp:Label>
    </h3>
    <hr />
    <br />
    <div>
        <%--<asp:View ID="View1" runat="server">--%>

        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div style="width: 99%;">
                    <table style="width: 100%; border-collapse: collapse;">
                        <tr>
                            <td style="background-color: #557d96; border: 1px solid #557d96; 
color: white; text-align: center; font-size: 1.1em;">
                                Course Selection
                            </td>
                            <td></td>
                            <td style="background-color: #557d96; border: 1px solid #557d96; 
color: white; text-align: center; font-size: 1.1em;">
                                Selected Courses
                            </td>
                        </tr>
                        <tr>

                            <%-- ---------------------Left panel --%>
                            <td style="width: 74%; vertical-align: top; border: 1px solid #557d96;">
                                <div>


                                    <table style="border-collapse: collapse;">

                                        <tr>
                                            <td style="text-align: center; font-weight: bold; background-color: lightgray;">Categories                                                
                                            </td>
                                            <td style="text-align: center; font-weight: bold; background-color: lightgray;">Courses in category:&nbsp;
                                                    <strong>
                                                        <asp:Label ID="lblCoursesTitle" runat="server" Text="Courses"></asp:Label>
                                                    </strong>
                                            </td>
                                        </tr>

                                        <tr>


                                            <%-- ---------------------------Categories section --%>
                                            <td style="width: 25%; vertical-align: top;  ">
                                                <div id="categoryDiv" >
                                                    <asp:Panel ID="pnlCategories" runat="server">
                                                    </asp:Panel>
                                                    <br />

                                                    <asp:HiddenField ID="hidSelectedCategory" Value="0" runat="server" />
                                                    <asp:HiddenField ID="hidSelectedCategoryName" Value="" runat="server" />
                                                </div>
                                            </td>
                                            


                                            <%-- -------------------------------Course section --%>
                                            <td style="width: 70%; vertical-align: top;  ">
                                                <div id="courseDiv"  style="border-left: 1px solid #557d96;">
                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                        <ContentTemplate>
                                                            <div style="">
                                                                <asp:Panel ID="pnlCourseList" ViewStateMode="Enabled" runat="server"></asp:Panel>
                                                            </div>
                                                            <asp:HiddenField ID="hidSchoolId" Value="0" runat="server" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </td>


                                        </tr>

                                    </table>


                                </div>
                            </td>


                            <%-- -------------------------Mid section --%>
                            <td style="width: 20px; vertical-align: central; "></td>




                            <%-- ----------------------Right panel --%>
                            <td style="width: 22%; border: 1px solid #557d96; vertical-align: top;">
                                <div style="padding: 2px;">
                                    <div style="height: 50%; min-height: 100px; margin-bottom: 5px;">
                                        <%--<span style="font-weight: 600;">Selected Courses</span>
                                        <hr />--%>
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <asp:Panel ID="pnlSelectedCourses" runat="server">
                                                </asp:Panel>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <br />

                                   <%-- <div style="border-top: 1px double black; min-height: 100px; position: relative; bottom: 0; padding-top: 20px;">
                                        <span style="font-weight: 600;">Saved Courses</span>
                                        <hr />
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <asp:Panel ID="pnlSavedCourses" runat="server">
                                                </asp:Panel>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>--%>
                                </div>
                            </td>

                        </tr>

                    </table>


                    <%-- ======================== Selected courses ================================== --%>
                    <%-- ============================================================================ --%>

                    <%-- ============================================================================ --%>
                    <%-- ============================================================================ --%>
                </div>
                <div style="clear: both;"></div>
                <br />
                <div style="text-align: left;">
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

</asp:Content>





<asp:Content runat="server" ID="titleContnet" ContentPlaceHolderID="title">
    Assign Courses
</asp:Content>
