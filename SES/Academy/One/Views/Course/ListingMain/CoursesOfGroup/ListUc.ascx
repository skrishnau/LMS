<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListUc.ascx.cs" Inherits="One.Views.Course.ListingMain.CoursesOfGroup.ListUc" %>
<%@ Register Src="~/Views/Course/CourseCreate/CourseCreateUc.ascx" TagPrefix="uc1" TagName="CourseCreateUc" %>
<%@ Register Src="~/Views/Course/Category/Create.ascx" TagPrefix="uc1" TagName="Create" %>



<div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="item-section-heading">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </div>
            <div style="float: right; clear: both;">
                <asp:LinkButton ID="btnNewGroup" runat="server" OnClick="btnNewGroup_Click">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />&nbsp;New Subject
                </asp:LinkButton>
                <div>
                    Add Subject &nbsp;&nbsp;
        <asp:DropDownList ID="cmbNewSubject" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbNewSubject_SelectedIndexChanged">
            <Items>
                <asp:ListItem Value="0" Text=""></asp:ListItem>
                <asp:ListItem Value="1" Text="Create New"></asp:ListItem>
                <asp:ListItem Value="2" Text="Choose Existing"></asp:ListItem>
                <asp:ListItem Value="3" Text="Import"></asp:ListItem>
            </Items>
        </asp:DropDownList>
                </div>
            </div>



            <div style="clear: both;"></div>

            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View0" runat="server">
                    <div style="width: 100%; margin: 5px 20px 5px;">
                        <asp:DataList ID="DataList1" runat="server" DataSourceID="SubjectsOfAGroup">
                            <ItemTemplate>
                                <div style="margin: 20px; float: left;">


                                    <asp:HiddenField ID="IdLabel" runat="server" Value='<%# Eval("Id") %>' />
                                    <strong>
                                        <asp:LinkButton ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                                    </strong>
                                    <br />

                                    <asp:Label ID="SummaryLabel" runat="server" Text='<%# Eval("Summary") %>' />

                                    <div style="margin: 0 20px 0;">
                                        Code:
                <asp:Label ID="CodeLabel" runat="server" Text='<%# Eval("Code") %>' />
                                        <br />
                                        Credit:
                <asp:Label ID="CreditLabel" runat="server" Text='<%# Eval("Credit") %>' />
                                        <br />
                                        SubjectCategoryId:
                    <asp:HiddenField ID="SubjectCategoryIdLabel" runat="server" Value='<%# Eval("SubjectCategoryId") %>' />
                                        <br />
                                        SubjectCategory:
               <%-- <asp:Label ID="SubjectCategoryLabel" runat="server" Text='<%# Eval("SubjectCategory") %>' />--%>
                                        <br />
                                        CompletionHours:
                <asp:Label ID="CompletionHoursLabel" runat="server" Text='<%# Eval("CompletionHours") %>' />
                                        <%-- <br />
                    FullMarks:
                <asp:Label ID="FullMarksLabel" runat="server" Text='<%# Eval("FullMarks") %>' />
                    <br />
                    PassPercentage:
                <asp:Label ID="PassPercentageLabel" runat="server" Text='<%# Eval("PassPercentage") %>' />
                    <br />--%>
                                        <%--      IsActive:
                <asp:Label ID="IsActiveLabel" runat="server" Text='<%# Eval("IsActive") %>' />
                  <br /> --%>
                                        <%--Void:
                <asp:Label ID="VoidLabel" runat="server" Text='<%# Eval("Void") %>' />
                <br />--%>
                                        <%--       HasLab:
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
                    <br />--%>
                                        <%-- CreatedDate:
                <asp:Label ID="CreatedDateLabel" runat="server" Text='<%# Eval("CreatedDate") %>' />
                <br />--%>
                                        <%--SubjectGroupSubjects:
                <asp:Label ID="SubjectGroupSubjectsLabel" runat="server" Text='<%# Eval("SubjectGroupSubjects") %>' />
                <br />--%>
                                        <%--Teach:
                <asp:Label ID="TeachLabel" runat="server" Text='<%# Eval("Teach") %>' />
                <br />--%>
                                        <%-- SubjectSections:
                <asp:Label ID="SubjectSectionsLabel" runat="server" Text='<%# Eval("SubjectSections") %>' />
                <br />--%>
                                        <br />

                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:ObjectDataSource ID="SubjectsOfAGroup" runat="server" SelectMethod="GetSubjectsOfAGroup" TypeName="Academic.DbHelper.DbHelper+Subject">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="hidSubjectGroupId" DefaultValue="0" Name="subjectGroupId" PropertyName="Value" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </div>
                </asp:View>
                <%-- =============View 1 Course create=============== --%>
                <asp:View ID="View1" runat="server">

                    <uc1:CourseCreateUc runat="server" ID="CourseCreateUc" />
                </asp:View>

                <%-- =============View 2 Course Select=============== --%>
                <asp:View ID="View2" runat="server">
                </asp:View>
                
                <asp:View ID="View3" runat="server">
                </asp:View>
                
                <%-- ===============Category Crate================== --%>
                 <asp:View ID="View4" runat="server">
                    <uc1:Create runat="server" ID="CategoryCreate" />
                </asp:View>

            </asp:MultiView>


        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:HiddenField ID="hidSubjectGroupId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
</div>
