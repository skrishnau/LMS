<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ViewsSite/User/UserMaster.Master" CodeBehind="ExamsList.aspx.cs" Inherits="One.Views.Exam.Exam.ExamsList" %>

<asp:Content runat="server" ID="headcontent1" ContentPlaceHolderID="head">
    <style type="text/css">
        .aca-ses-side {
            padding: 5px 10px 5px 5px;
            width: 25%;
            border: 2px solid grey;
        }

        .aca-ses-inner-div {
            width: 100%;
            padding: 2px;
        }

        .exam-list-side {
            padding: 5px;
            width: 100%;
            border: 2px solid lightgray;
        }

        .exam-inner-div {
            padding: 3px 7px;
            margin: 2px;
        }

        .span-width {
            display: inline-block;
            width: 20px;
        }

        .aca {
            margin-left: 1px;
            display: inline-block;
        }

        .ses {
            margin-left: 20px;
            display: inline-block;
        }

        .aca-ses-inner-div:hover {
            background-color: lightblue;
        }
    </style>
</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <div style="background-color: lightgray;">
        <div>
            <h3 class="heading-of-listing">Exams list            
            </h3>
            <hr />
        </div>
        <br />
        <%--in all  active academic year and session--%>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="data-entry-section">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <strong>Academic year/ Sessions</strong>
                            </td>
                            <td>
                                <div style="text-align: center;">
                                    Exams in: &nbsp;<strong>
                                        <asp:Label ID="lblAcaSesName" runat="server" Text=""></asp:Label>
                                    </strong>
                                </div>

                            </td>
                        </tr>
                        <tr style="vertical-align: top;">
                            <%-- AcademicYearAndSession --%>
                            <td class="aca-ses-side">
                                <asp:DataList ID="dlistAcademic" runat="server" Width="100%"
                                    OnItemCommand="dlistAcademic_ItemCommand">
                                    <ItemTemplate>
                                        <div class="aca-ses-inner-div">
                                            <%-- <% if (Eval("SessionId").ToString() != "0")
                                   {%>
                                <span class="span-width"></span>
                                <% } %>--%>
                                            <%--<asp:Label runat="server" ID="Literal1" Width="20px" CssClass="inline"
                                   Text="" Visible='<%# GetPaddingVisibility(Eval("SessionId"))%>'></asp:Label>--%>
                                            <asp:HiddenField ID="hidAcademicYearId" runat="server" Value='<%# Eval("AcademicYearId") %>' />
                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("SessionId") %>' />
                                            <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("Completed") %>' />

                                            <asp:LinkButton ID="Label1" Width="100%" CommandName="Select" Font-Underline="False"
                                                CommandArgument='<%# Eval("AcademicYearId")+","+Eval("SessionId")
                                                           +"," +Eval("BothNameCombined")
                                                           +","+ Eval("Completed")%>'
                                                CssClass='<%# GetClass(Eval("SessionId"))%>'
                                                runat="server" Text='<%# (GetIndent(Eval("SessionId")))+Eval("Name") %>'></asp:LinkButton>
                                        </div>

                                    </ItemTemplate>
                                    <SelectedItemStyle BackColor="lightgrey"></SelectedItemStyle>
                                </asp:DataList>
                            </td>

                            <%-- Exam list --%>
                            <td class="exam-list-side">
                                <div style="text-align: right;">
                                    <asp:HyperLink ID="btnNewExam" runat="server"
                                        NavigateUrl="~/Views/Exam/Create.aspx">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                                        New Exam
                                    </asp:HyperLink>
                                </div>
                                <asp:DataList ID="dlistExam" runat="server">
                                    <ItemTemplate>
                                        <div class="exam-inner-div ">
                                            <asp:HyperLink ID="HyperLink1" runat="server"
                                                NavigateUrl='<%# "~/Views/Exam/Exam/ExamDetail.aspx?eId="+Eval("Id") %>'
                                                Text='<%# Eval("Name") %>'></asp:HyperLink>
                                            <div style="margin-left: 20px;">
                                                Exam start date:
                                <br />
                                                Weight:
                                <br />
                                            </div>

                                        </div>
                                    </ItemTemplate>
                                    <SelectedItemTemplate></SelectedItemTemplate>
                                </asp:DataList>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:HiddenField ID="hidManager" runat="server" Value="False" />
        <asp:HiddenField ID="hidTeacher" runat="server" Value="False" />
    </div>
</asp:Content>
