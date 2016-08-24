<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ViewsSite/User/UserMaster.Master" CodeBehind="CourseDetail.aspx.cs" Inherits="One.Views.Course.CourseDetail" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <div style="margin-left: 10px;">

        <div>
            <strong style="font-size: 1.3em; display: block; text-align: center;">
                <asp:Literal ID="lblHeading" runat="server" Text="Heading"></asp:Literal>
            </strong>
            <div style="text-align: center;">
                View | Edit | Delete | Hide | BackUp | Restore
            </div>
        </div>
        <br />
        <div>
            <strong>Detail</strong>
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

                    <tr class="border-bottom1">
                        <td class="width10">No. of Global Sections</td>
                        <td>
                            <asp:Literal ID="lblNoOfGlobalSections" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </table>

            </div>

            <br />

            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <%-- ---update panel here --%>
                    <div>
                        <div>
                            <strong>Classes</strong>
                            <%--<span>Use filter to filter the completed, Due and Not-started yet coureses</span>--%>
                            <div style="float: right;">
                                <span style="text-align: right; display: block;">
                                    <asp:HyperLink ID="lnkNewClass" runat="server"
                                        ToolTip="For different group studying the Course at the same time, there can be different Subject Sessions,so as to differentiate the course content for each group.">
                                        <asp:Image ID="Image1" ImageUrl="~/Content/Icons/Add/Add-icon.png" runat="server" />
                                        &nbsp;
                                        Create New Class for this Course
                                    </asp:HyperLink>
                                </span>
                            </div>
                            <div style="clear: both;"></div>
                            <hr />
                            <%-- List of currently studying students --%>
                            <%-- Give to choose the year --%>

                            <div style="padding: 5px; border: 2px solid lightgray;">
                                <asp:LinkButton ID="lnkClassFilter" runat="server"
                                    Font-Underline="False" OnClick="lnkClassFilter_Click">
                                    <asp:Image runat="server" ID="imgFilter" ImageUrl="~/Content/Icons/Arrow/arrow_right.png" />
                                    Filter
                                </asp:LinkButton>

                                <asp:Panel ID="pnlClassFilter" runat="server" Visible="False">
                                    <hr />
                                    <table>
                                        <tr>
                                            <td class="table-row-padding">
                                                <asp:LinkButton ID="btnAll" runat="server" Font-Underline="False" OnClick="btnFilterCrieteria_Click">
                                            <span style="background-color: #ffffff;" class="class-filter-table-cell"></span>
                                                &nbsp;All
                                                </asp:LinkButton>

                                            </td >
                                            <td class="table-row-padding">
                                                <asp:LinkButton ID="btnCurrentlyRunning" runat="server" Font-Underline="False" OnClick="btnFilterCrieteria_Click">
                                            <span style="background-color: #d7e3e7;" class="class-filter-table-cell"></span>
                                                &nbsp;Currently Running
                                                </asp:LinkButton>

                                            </td>
                                            <td class="table-row-padding">
                                                <asp:LinkButton ID="btnDue" runat="server" Font-Underline="False" OnClick="btnFilterCrieteria_Click">
                                        <span style="background-color: #fdd6dc;" class="class-filter-table-cell"></span>
                                        &nbsp;Due
                                                </asp:LinkButton>
                                            </td>
                                            <td class="table-row-padding">
                                                <asp:LinkButton ID="btnNotStartedYet" runat="server" Font-Underline="False" OnClick="btnFilterCrieteria_Click">
                                        <span style="background-color: #fdfdc2;" class="class-filter-table-cell"></span>
                                        &nbsp;Not yet Started
                                                </asp:LinkButton>
                                            </td>

                                            <td class="table-row-padding">
                                                <asp:LinkButton ID="btnCompleted" runat="server" Font-Underline="False" OnClick="btnFilterCrieteria_Click">
                                                <span style="background-color: #bcf4bc;" class="class-filter-table-cell"></span>
                                                &nbsp;Completed
                                                </asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>


                                </asp:Panel>

                            </div>

                        </div>
                        <%-- background-color: lightgoldenrodyellow; --%>
                        <div style="padding: 10px;">

                            <asp:DataList ID="dlistClasses" runat="server"
                                CellPadding="3" Width="100%"
                                ForeColor="#333333">
                                <%--<AlternatingItemStyle BackColor="White" />--%>
                                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <ItemStyle ForeColor="#333333" />
                                <%-- BackColor="#FFFBD6" --%>

                                <ItemTemplate>
                                    <div style="padding: 2px 6px;">
                                        <asp:Panel runat="server" ID="panel1"
                                            BackColor='<%# GetCompletedColor(DataBinder.Eval(
                                    Container.DataItem,"SessionComplete")
                                    ,Eval("StartDate") ,Eval("EndDate")
                                    ) %>'>

                                            <div style="font-size: 1.2em; padding: 10px 10px 0;">
                                                <asp:HyperLink ID="lblName" runat="server"
                                                    NavigateUrl='<%# "~/Views/Class/CourseClassDetail.aspx?cdId"+Eval("Id") %>'
                                                    Text='<%# Eval("GetName") %>'></asp:HyperLink>
                                                <asp:Literal ID="lblRegularOrNot" runat="server" Text="(Regular)"></asp:Literal>
                                            </div>
                                            <div style="padding: 0 25px 10px;">
                                                No. of Sections:
                                                <br />
                                                Total Students:
                                                <br />
                                            </div>
                                        </asp:Panel>
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
            border-bottom: 1px solid grey;
            width: 100%;
            padding: 10px 0;
        }

        .width10 {
            width: 170px;
            padding: 10px 0;
            display: inline-block;
        }

        .width-Remain {
            width: 74%;
        }

        .class-filter-table-cell {
            /*margin-left: 10px;*/
            width: 20px;
            height: 20px;
            display: inline-block;
            border: 2px solid lightgray;
        }
        .table-row-padding {
            padding-left: 10px;
        }
    </style>
</asp:Content>


