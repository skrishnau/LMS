<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ViewsSite/User/UserMaster.Master" CodeBehind="CourseDetail.aspx.cs" Inherits="One.Views.Course.CourseDetail" %>

<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>



<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <h3 class="heading-of-listing">
        <asp:Literal ID="lblHeading" runat="server" Text="Heading"></asp:Literal>
    </h3>
    <hr />
    <div>

        <div class="text-center">
            <asp:HyperLink ID="lnkView" runat="server" CssClass="btn btn-default">View</asp:HyperLink>
            &nbsp;&nbsp;
                <asp:HyperLink ID="lnkEdit" runat="server" CssClass="btn btn-default">Edit</asp:HyperLink>
            &nbsp;&nbsp;
                <asp:HyperLink ID="lnkDelete" runat="server" CssClass="btn btn-default">Delete</asp:HyperLink>
            <%-- | 
                <asp:HyperLink ID="HyperLink4" runat="server">Hide</asp:HyperLink>
                | 
                <asp:HyperLink ID="HyperLink5" runat="server">Backup</asp:HyperLink>
                | 
                <asp:HyperLink ID="HyperLink6" runat="server">Restore</asp:HyperLink>--%>
        </div>

        <br />
      
        <div>
            <%-- style="border-collapse: collapse;" --%>
            <table>
                <tr>
                    <td class="data-type">Full Name</td>
                    <td class="data-value">
                        <asp:Literal ID="lblFullName" runat="server"></asp:Literal>
                    </td>
                </tr>

                <tr>
                    <td class="data-type">Short Name</td>
                    <td class="data-value">
                        <asp:Literal ID="lblShortName" runat="server"></asp:Literal>
                    </td>
                </tr>

                <tr>
                    <td class="data-type">Category</td>
                    <td class="data-value">
                        <asp:Literal ID="lblCategory" runat="server"></asp:Literal>
                    </td>
                </tr>

            </table>
        </div>
        <br />
        <%--<div class="data-entry-section-heading">
                Detail
            <hr />
            </div>   style="margin-left: 10px;"--%>
        <div>
            <%-- <div class="border-bottom1">
                    <span class="width10">Short Name
                    </span>
                    <span>
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    </span>
                </div>--%>
        </div>

        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <%-- ---update panel here --%>
                <div>
                    <div runat="server" id="pnlClasses" visible="False" class="panel panel-default">
                        <div class="panel-heading clearfix">
                            Classes
                                <div style="float: right;" class="">
                                    <%--<span style="margin-left: 10px; font-size: 0.9em;">--%>
                                    <%-- CssClass="link_smaller" --%>
                                    <asp:HyperLink ID="lnkNewClass" runat="server" CssClass="link-outer"
                                        ToolTip="For different group studying the Course at the same time, there can be different Subject Sessions,so as to differentiate the course content for each group.">
                                        <asp:Image ID="Image1" ImageUrl="~/Content/Icons/Add/Add-icon.png" runat="server" />
                                        Create New Class
                                    </asp:HyperLink>
                                    <%--</span>--%>
                                </div>
                            <div style="clear: both;"></div>
                        </div>

                        <%-- margin-left: 3px; margin-right: 3px; padding: 3px; border: 1px solid lightgrey; --%>
                        <div style="" class="well well-sm ">
                            <asp:LinkButton ID="lnkClassFilter" runat="server" CssClass="link"
                                Font-Underline="False" OnClick="lnkClassFilter_Click">
                                <%--<asp:Image runat="server" ID="imgFilter" ImageUrl="~/Content/Icons/Arrow/arrow_right.png" Visible="False" />--%>
                                <asp:Literal ID="lblFilterArrow" runat="server" Text="►"></asp:Literal>
                                Filter
                            </asp:LinkButton>

                            <asp:Panel ID="pnlClassFilter" runat="server" Visible="False" Style="padding-left: 20px;">
                                <%--<hr />--%>
                                <table>
                                    <tr>
                                        <td class="table-row-padding">
                                            <asp:LinkButton ID="btnAll"
                                                CssClass="btn btn-default active"
                                                runat="server" OnClick="btnFilterCrieteria_Click">
                                                    <span style="background-color: #ffffff;" class="class-filter-table-cell"></span>
                                                    All
                                            </asp:LinkButton>
                                            &nbsp;
                                        </td>
                                        <td class="table-row-padding">
                                            <asp:LinkButton ID="btnCurrentlyRunning"
                                                CssClass="btn btn-default"
                                                runat="server" OnClick="btnFilterCrieteria_Click">
                                                <%--<span style="background-color: #00ea00;" class="class-filter-table-cell"></span>--%>
                                                <asp:Image ID="Image5" runat="server" ImageUrl="~/Content/Icons/Start/active_icon_10px.png" />
                                                Currently Running
                                            </asp:LinkButton>
                                            &nbsp;
                                        </td>
                                        <td class="table-row-padding">
                                            <asp:LinkButton ID="btnDue"
                                                CssClass="btn btn-default"
                                                runat="server" OnClick="btnFilterCrieteria_Click">
                                                <%--<span style="background-color: #ff9aaa;" class="class-filter-table-cell"></span>--%>
                                                <asp:Image ID="Image4" runat="server"
                                                    Height="14" Width="14"
                                                    ImageUrl="~/Content/Icons/Watch/alarm_clock_14px.png" />

                                                Due
                                            </asp:LinkButton>
                                            &nbsp;
                                        </td>
                                        <td class="table-row-padding">
                                            <asp:LinkButton ID="btnNotStartedYet"
                                                CssClass="btn btn-default"
                                                runat="server" OnClick="btnFilterCrieteria_Click">
                                                <%--<span style="background-color: #fbfb3f;" class="class-filter-table-cell"></span>--%>
                                                <asp:Image ID="Image3" runat="server"
                                                    Height="14" Width="14"
                                                    ImageUrl="~/Content/Icons/Hourglass/schedule_14px.png" />
                                                Upcoming
                                            </asp:LinkButton>
                                            &nbsp;
                                        </td>

                                        <td class="table-row-padding">
                                            <asp:LinkButton ID="btnCompleted"
                                                CssClass="btn btn-default"
                                                runat="server" OnClick="btnFilterCrieteria_Click">
                                                <%--<span style="background-color: #bfbfbf;" class="class-filter-table-cell"></span>--%>
                                                <asp:Image ID="Image6" runat="server" ImageUrl="~/Content/Icons/Stop/Stop_10px.png" />
                                                Completed
                                            </asp:LinkButton>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>


                            </asp:Panel>

                        </div>


                        <%-- List of currently studying students --%>
                        <%-- Give to choose the year --%>
                        <%-- style="margin-left: 10px;" --%>
                        <div>
                            <%-- #557d96 --%>



                            <asp:DataList ID="dlistClasses" runat="server" Width="100%" ForeColor="#333333"
                                CssClass="table table-hover table-responsive">
                                <%--<AlternatingItemStyle BackColor="White" />--%>
                                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <ItemStyle ForeColor="#333333" />
                                <%-- BackColor="#FFFBD6" --%>

                                <ItemTemplate>
                                    <%-- class="auto-st2-border-no-margin" --%>
                                    <%-- list-item-datalist --%>
                                    <div class="">
                                        <%--  style=" padding-left: 10px; padding-top: 3px;" --%>
                                        <asp:HyperLink ID="lblName" runat="server" CssClass="link"
                                            NavigateUrl='<%# "~/Views/Class/CourseClassDetail.aspx?ccId="+Eval("ClassId") %>'
                                            Text='<%# Eval("ClassName") %>'></asp:HyperLink>
                                        <asp:Literal ID="lblRegularOrNot" runat="server" Text=""></asp:Literal>

                                        <asp:Image ID="Image2" runat="server" Height="10" Width="10"
                                            ImageUrl='<%# Eval("IconUrl") %>' />
                                        <%-- ImageUrl='<%# GetImageUrl(Eval("SessionComplete"),Eval("StartDate"),Eval("EndDate")) %>' --%>
                                            &nbsp;&nbsp;
                                                <span class="span-edit-delete">
                                                    <asp:HyperLink ID="lnkEdit" runat="server" Visible='<%# Edit && !Convert.ToBoolean(Eval("IsRegular")) %>'
                                                        NavigateUrl='<%# "~/Views/Class/CourseSessionCreate.aspx?cId="+Eval("SubjectId")+"&subclsId="+Eval("ClassId") %>'>
                                                        <asp:Image ID="imgEditBtn" runat="server" ImageUrl="~/Content/Icons/Edit/edit_orange.png" />
                                                    </asp:HyperLink>
                                                    <asp:HyperLink ID="lnkDelete" runat="server" Visible='<%# Edit && !Convert.ToBoolean(Eval("IsRegular")) %>'
                                                        NavigateUrl='<%# "~/Views/All_Resusable_Codes/Delete/DeleteForm.aspx?task=c3ViamVjdENsYXNz&subclsId="+Eval("ClassId") %>'>
                                                        <asp:Image ID="Image22" runat="server" ImageUrl="~/Content/Icons/delete/trash.png" />
                                                    </asp:HyperLink>
                                                </span>
                                    </div>
                                </ItemTemplate>
                                <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                            </asp:DataList>
                        </div>

                    </div>

                </div>
                <asp:HiddenField ID="hidCourseId" Value="0" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:HiddenField ID="hidEditClasses" runat="server" Value="False" />
    </div>
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <link href="../../Content/CSSes/TableStyles.css" rel="stylesheet" />
</asp:Content>

<asp:Content runat="server" ID="titleContnet" ContentPlaceHolderID="title">
    Course Detail
</asp:Content>


