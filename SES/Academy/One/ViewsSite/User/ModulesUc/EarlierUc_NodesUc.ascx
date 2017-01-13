<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EarlierUc_NodesUc.ascx.cs" Inherits="One.ViewsSite.User.ModulesUc.EarlierUc_NodesUc" %>

<div class="auto-st2-hover-display-dark">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <%--  style="border-bottom: 1px solid #a0522d;" --%>
            <div>
                <em>
                    <asp:LinkButton ID="LinkButton1" runat="server" Enabled="False" OnClick="LinkButton1_Click">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Arrow/arrow_down.png" Height="10" Width="10" Visible="False" />
                        <asp:Label ID="lblStructureName" runat="server" Text=""></asp:Label>
                    </asp:LinkButton>
                </em>
            </div>
            <div style="margin-left: 5px;">

                <asp:DataList ID="dListCourses" runat="server" Width="98%">
                    <%--DataSourceID="RegularCourseDS"  --%>
                    <ItemTemplate>
                        <%--style="margin: 0 5px 0  10px;"--%>
                        <div class="auto-st2">
                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("Id") %>' />
                            <asp:HyperLink ID="HyperLink5" runat="server" CssClass="link"
                                NavigateUrl='<%# "~/Views/Course/Section/Master/CourseSectionListing.aspx?SubId="+Eval("Id") %>'
                                Font-Underline="False" ToolTip='<%# Eval("FullName") %>'>
                                        &nbsp;<%# Eval("ShortName") %>
                                <%-- ■ --%>
                            </asp:HyperLink>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                <%--<asp:ObjectDataSource ID="RegularCourseDS" runat="server" SelectMethod="ListCurrentCoursesOfUser" TypeName="Academic.DbHelper.DbHelper+Subject">
            <SelectParameters>
                <asp:ControlParameter ControlID="hidUserId" DefaultValue="0" Name="userId" PropertyName="Value" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>--%>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
