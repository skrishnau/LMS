<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CourseListUC.ascx.cs" Inherits="One.Views.Structure.All.UserControls.CourseLinkage.CourseListUC" %>
<%@ Register Src="~/Views/Structure/All/UserControls/CourseLinkage/AddCourses.ascx" TagPrefix="uc2" TagName="AddCourses" %>


<div>
    <h3 class="heading-of-listing">Courses in: 
       <em>
           <asp:Literal ID="lblProgramDirectory" runat="server"></asp:Literal></em>
    </h3>
    <div style="margin: 10px; text-align: right;">
        <asp:LinkButton ID="btnManageSubject" runat="server" Text="Manage Subjects" 
            CssClass="link-outer"
            OnClick="btnManageSubject_Click">
        </asp:LinkButton>
    </div>
    <%--   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    <%--<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">--%>

    <%-- =================== View 0======================== --%>
    <%--<asp:View ID="viewMain" runat="server">--%>
    <div>

        <%--<div style="/*float: left;margin: 0 auto;  height: 100%; width: 22%; min-height: 100%;*/" ></div>--%>
        <div style="min-height: 20px; background-color: #f0f8f1;">
            <%--<div style=""></div>--%>
            <asp:DataList ID="dlistCourses" Width="100%" runat="server"
                CellPadding="1" BackColor="White" GridLines="None">

                <ItemTemplate>
                    <div class="list-item">
                        <asp:HyperLink ID="NameLabel" runat="server" CssClass="list-item-heading"
                            NavigateUrl='<%# "~/Views/Course/Section/?SubId="+Eval("Id")
                                            +"&yId="+hidYearId.Value+"&sId="+hidSubYearId.Value
                                            +"&edit="+ hidEdit.Value %>'
                            Text='<%# Eval("Name") %>' />
                        &nbsp;
                        <asp:Label ID="CodeLabel" runat="server" Text='<%# GetCode(Eval("Code")) %>' />
                        &nbsp;
                        &nbsp;
                        <asp:Label ID="Label2" runat="server" ForeColor="#858575" Text='<%# GetElectiveText(Eval("IsElective")) %>' />

                        <br />
                        <table>
                            <tr>
                                <td style="width: 40px;">Category:
                                </td>
                                <td>
                                    <asp:Label ID="SubjectCategoryIdLabel" runat="server" Text='<%# Eval("CategoryName") %>' />
                                </td>
                            </tr>
                            <%--  <tr>
                                <td style="width: 40px;">
                                    Elective
                                </td>
                                <td>
                                    <asp:CheckBox ID="CheckBox1" runat="server" 
                                        Enabled="False"
                                        Checked='<%# Eval("IsElective") %>'/>
                                </td>
                            </tr>--%>
                            <tr>
                                <td style="width: 40px;">Credit</td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Credit") %>' />

                                </td>
                            </tr>
                        </table>

                    </div>
                </ItemTemplate>
                <%--<SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />--%>
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

