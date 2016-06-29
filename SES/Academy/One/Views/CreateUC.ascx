<%@ Control Language="C#" AutoEventWireup="true"
    CodeBehind="CreateUC.ascx.cs" Inherits="One.Views.CreateUC" %>
<asp:Panel ID="pnlCreateUc" runat="server">
    <%--<asp:ListBox ID="ListBox1" runat="server" CssClass="dark-theme" SelectionMode="Single"  OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"
         Width="136px" Height="190px">
        <asp:ListItem>Teacher</asp:ListItem>
         <asp:ListItem>Staff</asp:ListItem>
         <asp:ListItem>Student</asp:ListItem>
         <asp:ListItem>Subject</asp:ListItem>
         <asp:ListItem></asp:ListItem>
         <asp:ListItem>Academic Year</asp:ListItem>

    </asp:ListBox>--%>
    <div>
        <strong>Current</strong>
        <hr />
        <ul>


            <li>
                <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Views/Exam/Exam/Master/ListExams.aspx" runat="server">Exam</asp:HyperLink>
            </li>

            <li>
                <asp:HyperLink ID="HyperLink6" NavigateUrl="~/Views/AcademicPlacement/Master/List.aspx" runat="server">Regular Classes</asp:HyperLink>
            </li>
            
              <li>
                <asp:HyperLink ID="HyperLink9" NavigateUrl="#" runat="server">Extra Classes</asp:HyperLink>
            </li>

            <li>
                <asp:HyperLink ID="HyperLink4" NavigateUrl="~/Views/Course/ListingMain/CourseMain/ListSubjectGroup.aspx" runat="server">
                    Course Groups
                </asp:HyperLink>
            </li>
            
            <li>
                <asp:HyperLink ID="HyperLink8" NavigateUrl="~/Views/Student/Batch/ListBatch.aspx" runat="server">Batches</asp:HyperLink>
            </li>
        </ul>
    </div>

    <div>
        <strong>Settings</strong>
        <hr style="margin-left: 10px; margin-right: 10px;" />
        <ul>
            <li>
                <asp:HyperLink ID="HyperLink2" NavigateUrl="~/Views/Structure/All/Master/List.aspx" runat="server">Manage Programs</asp:HyperLink>
            </li>

            <li>Roles
            </li>

            <li>
                <asp:HyperLink ID="HyperLink5" NavigateUrl="~/Views/User/List.aspx" runat="server">Users</asp:HyperLink>
                <ul>
                    <li>Teacher</li>
                    <li>
                        <asp:HyperLink ID="HyperLink7" NavigateUrl="~/Views/Student/StudentGroup/List.aspx" runat="server">
                            Students
                        </asp:HyperLink>
                    </li>
                    <li>Staff</li>
                </ul>
            </li>
            <li>
                <asp:HyperLink ID="HyperLink3" NavigateUrl="~/Views/Course/Display/CourseList/CourseList.aspx"
                    runat="server">Courses</asp:HyperLink>
            </li>

            <li>School
            </li>
            <li></li>
            <li></li>
        </ul>
    </div>
</asp:Panel>
