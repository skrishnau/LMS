<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CourseListUC.ascx.cs" Inherits="One.Views.Structure.All.UserControls.CourseLinkage.CourseListUC" %>
<%@ Register Src="~/Views/Structure/All/UserControls/CourseLinkage/AddCourses.ascx" TagPrefix="uc2" TagName="AddCourses" %>


<div>
    <h3 class="heading-of-listing">Courses in: 
       <em>
           <asp:Literal ID="lblProgramDirectory" runat="server"></asp:Literal></em>
    </h3>
    <hr />

    <%--   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    <%--<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">--%>

    <%-- =================== View 0======================== --%>
    <%--<asp:View ID="viewMain" runat="server">--%>
    <div>
        <div style="margin-left: 5px; margin-top: 10px;">
            <asp:Button ID="btnManageSubject" runat="server" Text="Manage Subjects" OnClick="btnManageSubject_Click" />
        </div>
        <%--<div style="/*float: left;margin: 0 auto;  height: 100%; width: 22%; min-height: 100%;*/" ></div>--%>
        <div style="min-height: 20px; background-color: #f0f8f1;">
            <div style=""></div>
            <asp:DataList ID="dlistCourses" Width="100%" runat="server"
                CellPadding="1" BackColor="White" GridLines="None">
                <%-- CellPadding="3" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" --%>
                <%--<AlternatingItemStyle BackColor="#F7F7F7" />--%>
                <%--<FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />--%>
                <%--<HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />--%>
                <%--<ItemStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />--%>
                <ItemTemplate>
                    <%--style="width: 100%; margin: 4px 5px; padding: 10px  5px;"--%>
                    <div class="auto-st2">


                        <%--Id:--%>
                        <asp:HiddenField ID="hidSubjectId" runat="server" Value='<%# Eval("Id") %>' />
                        <%--<br />--%>
                        <%--Name:--%>

                        <%--  NavigateUrl='<%# "~/Views/Course/Section/Master/CourseSectionListing.aspx?SubId="+Eval("Id") %>' --%>
                        <strong style="font-size: 1.3em;">
                            <asp:HyperLink ID="NameLabel" runat="server" CssClass="link"
                                NavigateUrl='<%# "~/Views/Course/Section/?SubId="+Eval("Id")
                                            +"&yId="+hidYearId.Value+"&sId="+hidSubYearId.Value
                                            +"&edit="+ hidEdit.Value %>'
                                Text='<%# Eval("Name") %>' />
                        </strong>

                        <%--&nbsp; (--%>
                        <asp:Label ID="CodeLabel" runat="server" Text='<%# GetCode(Eval("Code")) %>' />
                        <%--)--%>
                        <br />
                        <%-- Credit:
                                         <asp:Label ID="CreditLabel" runat="server" Text='<%# Eval("Credit") %>' />
                                        <br />--%>
                                        Category:
                                         <asp:Label ID="SubjectCategoryIdLabel" runat="server" Text='<%# Eval("CategoryName") %>' />

                    </div>

                </ItemTemplate>
                <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            </asp:DataList>
        </div>
    </div>

    <%--</asp:View>--%>


    <%-- =================== View Add Courses========================== --%>
    <%-- Works:: but for now redirection is used  --%>
    <asp:View ID="viewAddCourses" runat="server">
        <%--<uc2:AddCourses runat="server" ID="AddCourses1" />--%>
    </asp:View>

    <%--</asp:MultiView>--%>


    <asp:HiddenField ID="hidYearId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSubYearId" runat="server" Value="0" />
    <asp:HiddenField ID="hidEdit" runat="server" Value="0" />

    <%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
</div>

