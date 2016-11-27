<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ViewsSite/User/UserMaster.Master" CodeBehind="CourseDetail.aspx.cs" Inherits="One.Views.Course.CourseDetail" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <div style="margin-left: 10px;">

        <div>
            <h3 class="heading-of-listing">
                <asp:Literal ID="lblHeading" runat="server" Text="Heading"></asp:Literal>
            </h3>
            <hr />

            <div style="text-align: center;">
                <asp:HyperLink ID="lnkView" runat="server">View</asp:HyperLink>
                <asp:HyperLink ID="lnkEdit" runat="server"> | Edit</asp:HyperLink>
                <asp:HyperLink ID="lnkDelete" runat="server"> | Delete</asp:HyperLink>
                <%-- | 
                <asp:HyperLink ID="HyperLink4" runat="server">Hide</asp:HyperLink>
                | 
                <asp:HyperLink ID="HyperLink5" runat="server">Backup</asp:HyperLink>
                | 
                <asp:HyperLink ID="HyperLink6" runat="server">Restore</asp:HyperLink>--%>
            </div>
        </div>
        <br />
        <div class="data-entry-section">
            <div class="data-entry-section-heading">Detail</div>
            <hr />
            <div style="margin-left: 10px;">
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

            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <%-- ---update panel here --%>
                    <div>
                        <div runat="server" id="pnlClasses" visible="False">
                            <strong>Classes</strong>
                            <%--<span>Use filter to filter the completed, Due and Not-started yet coureses</span>--%>
                            <div style="float: right;">
                                <span style="text-align: right; display: block;">
                                    <asp:HyperLink ID="lnkNewClass" runat="server" CssClass="link_smaller"
                                        ToolTip="For different group studying the Course at the same time, there can be different Subject Sessions,so as to differentiate the course content for each group.">
                                        <asp:Image ID="Image1" ImageUrl="~/Content/Icons/Add/Add-icon.png" runat="server" />
                                        Create New Class
                                    </asp:HyperLink>
                                </span>
                            </div>
                            <div style="clear: both;"></div>
                            <hr />
                            <%-- List of currently studying students --%>
                            <%-- Give to choose the year --%>

                            <div style="padding: 3px; border: 1px solid #557d96; margin-left: 15px;">
                                <asp:LinkButton ID="lnkClassFilter" runat="server" CssClass="link"
                                    Font-Underline="False" OnClick="lnkClassFilter_Click">
                                    <%--<asp:Image runat="server" ID="imgFilter" ImageUrl="~/Content/Icons/Arrow/arrow_right.png" Visible="False" />--%>
                                    <asp:Literal ID="lblFilterArrow" runat="server" Text="►"></asp:Literal>
                                    Filter
                                </asp:LinkButton>

                                <div style="margin-left: 10px;">
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
                                                <span style="background-color: #00ea00;" class="class-filter-table-cell"></span>
                                                    Currently Running
                                                    </asp:LinkButton>
                                                    &nbsp;
                                                </td>
                                                <td class="table-row-padding">
                                                    <asp:LinkButton ID="btnDue" runat="server" OnClick="btnFilterCrieteria_Click">
                                                <span style="background-color: #ff9aaa;" class="class-filter-table-cell"></span>
                                                Due
                                                    </asp:LinkButton>
                                                    &nbsp;
                                                </td>
                                                <td class="table-row-padding">
                                                    <asp:LinkButton ID="btnNotStartedYet" runat="server" OnClick="btnFilterCrieteria_Click">
                                                <span style="background-color: #fbfb3f;" class="class-filter-table-cell"></span>
                                                Not yet Started
                                                    </asp:LinkButton>
                                                    &nbsp;
                                                </td>

                                                <td class="table-row-padding">
                                                    <asp:LinkButton ID="btnCompleted" runat="server" OnClick="btnFilterCrieteria_Click">
                                                <span style="background-color: #bfbfbf;" class="class-filter-table-cell"></span>
                                                Completed
                                                    </asp:LinkButton>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>


                                    </asp:Panel>
                                </div>
                            </div>

                        </div>
                        <%-- background-color: lightgoldenrodyellow; --%>
                        <div style="padding: 10px;">

                            <asp:DataList ID="dlistClasses" runat="server" Width="100%" ForeColor="#333333">
                                <%--<AlternatingItemStyle BackColor="White" />--%>
                                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <ItemStyle ForeColor="#333333" />
                                <%-- BackColor="#FFFBD6" --%>

                                <ItemTemplate>
                                    <div class="auto-st2-border-no-margin">
                                        <table>
                                            <tr>
                                                <td style="width: 15px;">
                                                    <asp:Panel runat="server" ID="panel1" Width="15" Height="80"
                                                        BackColor='<%# GetCompletedColor(DataBinder.Eval(
                                                        Container.DataItem,"SessionComplete")
                                                        ,Eval("StartDate") ,Eval("EndDate")
                                                        ) %>'>
                                                    </asp:Panel>
                                                </td>
                                                <td>
                                                    <div style="font-size: 1.2em; padding-left: 10px;">
                                                        <asp:HyperLink ID="lblName" runat="server" CssClass="link"
                                                            NavigateUrl='<%# "~/Views/Class/CourseClassDetail.aspx?ccId="+Eval("Id") %>'
                                                            Text='<%# Eval("GetName") %>'></asp:HyperLink>
                                                        <asp:Literal ID="lblRegularOrNot" runat="server" Text=""></asp:Literal>
                                                    </div>
                                                    <div style="padding: 0 25px 10px;">
                                                        No. of Sections:
                                                        <br />
                                                        Total Students:
                                                        <br />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>


                                    </div>
                                </ItemTemplate>
                                <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                            </asp:DataList>
                        </div>

                    </div>
                    <asp:HiddenField ID="hidCourseId" Value="0" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
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


