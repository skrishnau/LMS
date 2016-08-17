<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CourseListUC.ascx.cs" Inherits="One.Views.Structure.All.UserControls.CourseLinkage.CourseListUC" %>
<%@ Register Src="~/Views/Structure/All/UserControls/CourseLinkage/AddCourses.ascx" TagPrefix="uc2" TagName="AddCourses" %>


<div>
    <div style="text-align: center;">
        <strong>Courses in: 
        <asp:Literal ID="lblProgramDirectory" runat="server"></asp:Literal>
        </strong>
        <hr />
    </div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">

                <%-- =================== View 0======================== --%>
                <asp:View ID="viewMain" runat="server">
                    <div>
                        <%--<div style="/*float: left;margin: 0 auto;  height: 100%; width: 22%; min-height: 100%;*/" ></div>--%>
                        <div style="min-height: 20px; background-color: #f0f8f1;">
                            <div style=""></div>
                            <asp:DataList ID="dlistCourses" Width="100%" runat="server"
                                CellPadding="3" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" GridLines="Horizontal">
                                <AlternatingItemStyle BackColor="#F7F7F7" />
                                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                                <ItemStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                <ItemTemplate>
                                    <div style="width: 100%; margin: 4px 5px; padding: 10px  5px;">


                                        <%--Id:--%>
                                        <asp:HiddenField ID="hidSubjectId" runat="server" Value='<%# Eval("Id") %>' />
                                        <%--<br />--%>
                                        <%--Name:--%>
                                        <strong style="font-size: 1.3em;">
                                            <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                                        </strong>


                                        <%--Summary:--%>
                                        <%--<asp:Label ID="SummaryLabel" runat="server" Text='<%# Eval("Summary") %>' />--%>
                                        <%--<br />--%>
      &nbsp; (
        <asp:Label ID="CodeLabel" runat="server" Text='<%# Eval("Code") %>' />
                                        )               
                        <br />
                                        <%-- Credit:
        <asp:Label ID="CreditLabel" runat="server" Text='<%# Eval("Credit") %>' />
                        <br />--%>
                        Category:
        <asp:Label ID="SubjectCategoryIdLabel" runat="server" Text='<%# Eval("CategoryName") %>' />
                                        <%-- <br />
        SubjectCategory:
        <asp:Label ID="SubjectCategoryLabel" runat="server" Text='<%# Eval("SubjectCategory") %>' />
        <br />--%>
                                        <%-- CompletionHours:
        <asp:Label ID="CompletionHoursLabel" runat="server" Text='<%# Eval("CompletionHours") %>' />
                        <br />--%>
                                        <%-- FullMarks:
        <asp:Label ID="FullMarksLabel" runat="server" Text='<%# Eval("FullMarks") %>' />
        <br />
        PassPercentage:
        <asp:Label ID="PassPercentageLabel" runat="server" Text='<%# Eval("PassPercentage") %>' />
        <br />--%>
                                        <%--  IsActive:
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
        <asp:Label ID="SubjectSectionsLabel" runat="server" Text='<%# Eval("SubjectSections") %>' />--%>
                                    </div>

                                </ItemTemplate>
                                <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                            </asp:DataList>
                        </div>
                    </div>
                    <div style="margin-top: 15px;">
                        <asp:Button ID="btnManageSubject" runat="server" Text="Manage Subjects" OnClick="btnManageSubject_Click" />
                    </div>
                </asp:View>


                <%-- =================== View Add Courses========================== --%>
                <%-- Works:: but for now redirection is used  --%>
                <asp:View ID="viewAddCourses" runat="server">
                    <uc2:AddCourses runat="server" ID="AddCourses1" />
                </asp:View>

            </asp:MultiView>


            <asp:HiddenField ID="hidYearId" runat="server" Value="0" />
            <asp:HiddenField ID="hidSubYearId" runat="server" Value="0" />

        </ContentTemplate>
    </asp:UpdatePanel>
</div>

