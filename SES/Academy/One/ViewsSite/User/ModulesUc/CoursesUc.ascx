<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CoursesUc.ascx.cs" Inherits="One.ViewsSite.User.ModulesUc.CoursesUc" %>

<div class="dashboard-modules">
    <asp:HyperLink ID="HyperLink2" NavigateUrl="~/ViewsSite/User/Dashboard/Dashboard.aspx" runat="server">
                                Courses
                        <hr />
    </asp:HyperLink>
    <div>
        <asp:DataList ID="dListCourses" runat="server" DataSourceID="RegularCourseDS">
            <ItemTemplate>
                <div style="margin: 0 5px 0  10px;">
                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("SubjectId") %>' />
                    <asp:HyperLink ID="HyperLink5" runat="server"
                        NavigateUrl='<%# "~/Views/Course/Section/Master/CourseSectionListing.aspx?SubId="+Eval("SubjectId") %>' Font-Underline="False">
                                        ■&nbsp;<%# Eval("SubjectName") %>
                    </asp:HyperLink>
                </div>
            </ItemTemplate>
        </asp:DataList>
        <asp:ObjectDataSource ID="RegularCourseDS" runat="server" SelectMethod="GetCurrentRegularSubjectsOfUser" TypeName="Academic.DbHelper.DbHelper+Subject">
            <SelectParameters>
                <asp:ControlParameter ControlID="hidUserId" DefaultValue="0" Name="userId" PropertyName="Value" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
            <asp:HiddenField ID="hidUserId" runat="server" Value="0" />
            <asp:HiddenField ID="hidTopLevelRole" runat="server" Value="" />


    </div>
</div>
