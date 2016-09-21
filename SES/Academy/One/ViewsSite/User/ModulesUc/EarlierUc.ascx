<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EarlierUc.ascx.cs" Inherits="One.ViewsSite.User.ModulesUc.EarlierUc" %>

<div class="module-whole">

    <div class="modules-heading">
        <asp:HyperLink ID="HyperLink2"
            NavigateUrl="~/ViewsSite/User/Dashboard/Dashboard.aspx?type=earlier" CssClass="modules-title" runat="server">
                                Earlier
        </asp:HyperLink>
    </div>
    <div class="modules-body">
        <asp:PlaceHolder ID="pnlRegularCourses" runat="server"></asp:PlaceHolder>
        <div runat="server" id="divNonRegular" visible="False">
            <hr />
            <asp:DataList ID="dListNonRegularSubjects" runat="server">
                <%-- DataSourceID="RegularCourseDS" --%>
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
        </div>
        <asp:HiddenField ID="hidUserId" runat="server" Value="0" />
        <asp:HiddenField ID="hidTopLevelRole" runat="server" Value="" />
    </div>
</div>
