<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CoursesUc.ascx.cs" Inherits="One.ViewsSite.User.ModulesUc.CoursesUc" %>
<style type="text/css">
    .dashboard-modules {
        background-color: lightgoldenrodyellow;
        /*margin: 10px 5px;*/
        /*padding: 0 5px 5px 5px;*/
        /*border: 2px solid darkgray;*/
    }
</style>
<div class="module-whole">
    <div class="modules-heading">
        <asp:HyperLink ID="HyperLink2"
            NavigateUrl="~/ViewsSite/User/Dashboard/Dashboard.aspx?type=current" runat="server">
                                Courses
        </asp:HyperLink>
    </div>
    <div class="modules-body">
        <asp:DataList ID="dListCourses" runat="server" DataSourceID="RegularCourseDS">
            <ItemTemplate>
                <div style="margin: 0 5px 0  10px;">
                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("Id") %>' />
                    <asp:HyperLink ID="HyperLink5" runat="server"
                        NavigateUrl='<%# "~/Views/Course/Section/Master/CourseSectionListing.aspx?SubId="+Eval("Id") %>'
                        Font-Underline="False" ToolTip='<%# Eval("Name") %>'>
                                        ■&nbsp;<%# Eval("ShortName") %>
                    </asp:HyperLink>
                </div>
            </ItemTemplate>
        </asp:DataList>
        <asp:ObjectDataSource ID="RegularCourseDS" runat="server" SelectMethod="ListCurrentCoursesOfUser" TypeName="Academic.DbHelper.DbHelper+Subject">
            <SelectParameters>
                <asp:ControlParameter ControlID="hidUserId" DefaultValue="0" Name="userId" PropertyName="Value" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="hidUserId" runat="server" Value="0" />
        <asp:HiddenField ID="hidTopLevelRole" runat="server" Value="" />


    </div>
</div>
