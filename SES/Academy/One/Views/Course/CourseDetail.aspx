<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ViewsSite/User/UserMaster.Master" CodeBehind="CourseDetail.aspx.cs" Inherits="One.Views.Course.CourseDetail" %>

<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>



<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <div style="margin-left: 10px;">

        <div>
            <h3 class="heading-of-listing">
                <asp:Literal ID="lblHeading" runat="server" Text="Heading"></asp:Literal>
            </h3>
            <hr />

            <div class="option-div">
                <asp:HyperLink ID="lnkView" runat="server">View</asp:HyperLink>
                <asp:HyperLink ID="lnkEdit" runat="server">Edit</asp:HyperLink>
                <asp:HyperLink ID="lnkDelete" runat="server">Delete</asp:HyperLink>
                <%-- | 
                <asp:HyperLink ID="HyperLink4" runat="server">Hide</asp:HyperLink>
                | 
                <asp:HyperLink ID="HyperLink5" runat="server">Backup</asp:HyperLink>
                | 
                <asp:HyperLink ID="HyperLink6" runat="server">Restore</asp:HyperLink>--%>
            </div>
        </div>
        <br/>
        <div class="data-entry-section">
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

                <table style="border-collapse: collapse;">
                    <tr class="border-bottom1">
                        <td class="width10">Full Name</td>
                        <td>
                            <asp:Literal ID="lblFullName" runat="server"></asp:Literal>
                        </td>
                    </tr>

                    <tr class="border-bottom1">
                        <td class="width10">Short Name</td>
                        <td>
                            <asp:Literal ID="lblShortName" runat="server"></asp:Literal>
                        </td>
                    </tr>

                    <tr class="border-bottom1">
                        <td class="width10">Category</td>
                        <td>
                            <asp:Literal ID="lblCategory" runat="server"></asp:Literal>
                        </td>
                    </tr>

                    <%-- <tr class="border-bottom1">
                        <td class="width10">No. of Global Sections</td>
                        <td>
                            <asp:Literal ID="lblNoOfGlobalSections" runat="server"></asp:Literal>
                        </td>
                    </tr>--%>
                </table>

            </div>

            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <%-- ---update panel here --%>
                    <div>
                        <div runat="server" id="pnlClasses" visible="False">
                            <div class="data-entry-section-heading">
                                <div style="float: left;">
                                    Classes
                                </div>
                                <%--<span>Use filter to filter the completed, Due and Not-started yet coureses</span>--%>

                                <div style="float: right;" class="option-div">
                                    <span style="margin-left: 10px;">
                                        <%-- CssClass="link_smaller" --%>
                                        <asp:HyperLink ID="lnkNewClass" runat="server"
                                            ToolTip="For different group studying the Course at the same time, there can be different Subject Sessions,so as to differentiate the course content for each group.">
                                            <asp:Image ID="Image1" ImageUrl="~/Content/Icons/Add/Add-icon.png" runat="server" />
                                            Create New Class
                                        </asp:HyperLink>
                                    </span>
                                </div>
                                <div style="clear: both;"></div>
                                <hr />
                            </div>

                            <%-- List of currently studying students --%>
                            <%-- Give to choose the year --%>
                            <div style="margin-left: 10px;">
                                <%-- #557d96 --%>
                                <div style="padding: 3px; border: 1px solid lightgrey; margin-left: 3px; margin-right: 3px;">
                                    <asp:LinkButton ID="lnkClassFilter" runat="server" CssClass="link"
                                        Font-Underline="False" OnClick="lnkClassFilter_Click">
                                        <%--<asp:Image runat="server" ID="imgFilter" ImageUrl="~/Content/Icons/Arrow/arrow_right.png" Visible="False" />--%>
                                        <asp:Literal ID="lblFilterArrow" runat="server" Text="►"></asp:Literal>
                                        Filter
                                    </asp:LinkButton>

                                    <asp:Panel ID="pnlClassFilter" runat="server" Visible="False">
                                        <%--<hr />--%>
                                        <table>
                                            <tr>
                                                <td class="table-row-padding">
                                                    <asp:LinkButton ID="btnAll" runat="server" OnClick="btnFilterCrieteria_Click">
                                                    <span style="background-color: #ffffff;" class="class-filter-table-cell"></span>
                                                    All
                                                    </asp:LinkButton>
                                                    &nbsp;
                                                </td>
                                                <td class="table-row-padding">
                                                    <asp:LinkButton ID="btnCurrentlyRunning" runat="server" OnClick="btnFilterCrieteria_Click">
                                                        <%--<span style="background-color: #00ea00;" class="class-filter-table-cell"></span>--%>
                                                        <asp:Image ID="Image5" runat="server" ImageUrl="~/Content/Icons/Start/active_icon_10px.png" />
                                                        Currently Running
                                                    </asp:LinkButton>
                                                    &nbsp;
                                                </td>
                                                <td class="table-row-padding">
                                                    <asp:LinkButton ID="btnDue" runat="server" OnClick="btnFilterCrieteria_Click">
                                                        <%--<span style="background-color: #ff9aaa;" class="class-filter-table-cell"></span>--%>
                                                        <asp:Image ID="Image4" runat="server"
                                                            Height="10" Width="10"
                                                            ImageUrl="~/Content/Icons/Watch/alarm_clock_14px.png" />

                                                        Due
                                                    </asp:LinkButton>
                                                    &nbsp;
                                                </td>
                                                <td class="table-row-padding">
                                                    <asp:LinkButton ID="btnNotStartedYet" runat="server" OnClick="btnFilterCrieteria_Click">
                                                        <%--<span style="background-color: #fbfb3f;" class="class-filter-table-cell"></span>--%>
                                                        <asp:Image ID="Image3" runat="server"
                                                            Height="11" Width="11"
                                                            ImageUrl="~/Content/Icons/Hourglass/schedule_14px.png" />
                                                        Not yet Started
                                                    </asp:LinkButton>
                                                    &nbsp;
                                                </td>

                                                <td class="table-row-padding">
                                                    <asp:LinkButton ID="btnCompleted" runat="server" OnClick="btnFilterCrieteria_Click">
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
                                <br />


                                <asp:DataList ID="dlistClasses" runat="server" Width="100%" ForeColor="#333333">
                                    <%--<AlternatingItemStyle BackColor="White" />--%>
                                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                    <ItemStyle ForeColor="#333333" />
                                    <%-- BackColor="#FFFBD6" --%>

                                    <ItemTemplate>
                                        <%-- class="auto-st2-border-no-margin" --%>
                                        <div class="list-item-datalist">
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
                        <%-- background-color: lightgoldenrodyellow; --%>
                        <div style="padding-top: 10px;">
                        </div>

                    </div>
                    <asp:HiddenField ID="hidCourseId" Value="0" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <asp:HiddenField ID="hidEditClasses" runat="server" Value="False" />
    </div>
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style1 {
            width: 101px;
        }

        .border-bottom1 {
            /*border-bottom: 1px solid grey;*/
            width: 100%;
            padding: 5px 0;
        }

        .width10 {
            width: 170px;
            padding: 5px 0;
            display: inline-block;
        }

        .width-Remain {
            width: 74%;
        }

        .class-filter-table-cell {
            /*margin-left: 10px;*/
            width: 14px;
            height: 14px;
            display: inline-block;
            border: 1px solid black;
        }

        .table-row-padding {
            padding-left: 10px;
        }
    </style>
</asp:Content>

<asp:Content runat="server" ID="titleContnet" ContentPlaceHolderID="title">
    Course Detail
</asp:Content>


