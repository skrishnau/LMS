<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="AcademicYearDetail.aspx.cs" Inherits="One.Views.Academy.AcademicYear.AcademicYearDetail" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <div style="text-align: center; font-size: 1.4em; font-weight: 700;">
        <asp:Label ID="lblAcademicYearName" runat="server" Text=""></asp:Label>
    </div>
    <hr />
    <div style="padding-left: 20px;">
        <table>
            <tr>
                <td class="auto-style1">Start Date</td>
                <td>
                    <asp:Label ID="lblStartDate" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style1">End Date</td>
                <td>
                    <asp:Label ID="lblEndDate" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <%-- Programs listing --%>
        <div>
            <div style="margin: 0 5px 20px 10px; padding-bottom: 15px;">
                <div>
                    <strong style="display: inline-block; border-bottom: 1px solid black;">Classes:
                    </strong>
                    &nbsp;
                    <asp:HyperLink ID="lnkAddClasses" runat="server">
                        <asp:Image ID="Image3" runat="server"
                            ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                    </asp:HyperLink>
                </div>
                <%--<div style="clear: both;"></div>--%>


                <asp:Panel ID="pnlSessionPrograms" runat="server" Visible="False">


                    <div style="margin-left: 70px; width: 50%;">

                        <asp:ListView ID="ListView1" runat="server">
                            <LayoutTemplate>
                                <table runat="server" id="table1" style="border-collapse: collapse; border: 1px solid lightgray;">
                                    <thead>
                                        <tr style="text-align: left; border: 1px solid lightgray;">
                                            <th style="width: 50%;">Group</th>
                                            <th>Study in (Year)</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr runat="server" id="itemPlaceholder"></tr>
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <AlternatingItemTemplate>
                                <tr id="Tr1" runat="server" style="background-color: lightgoldenrodyellow;">
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text='<%# GetName(Eval("ProgramBatch")) %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text='<%# GetCurrent(Eval("Year"),Eval("SubYear")) %>'></asp:Label>
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                            <ItemTemplate>
                                <tr id="Tr2" runat="server">
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text='<%# GetName(Eval("ProgramBatch")) %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text='<%# GetCurrent(Eval("Year"),Eval("SubYear")) %>'></asp:Label>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                </asp:Panel>

            </div>

            <asp:Panel ID="pnlAcademicPrograms" runat="server">
            </asp:Panel>
        </div>
        <br />
    </div>
    <%-- Session List --%>

    <div>
        <br />
        <div>
            <div style="clear: both;">
                <div style="float: left;">
                    <strong>Sessions</strong>
                </div>
                <div style="float: right;">
                    <asp:HyperLink ID="lnknewSession" runat="server">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                        Add Sessions
                    </asp:HyperLink>
                </div>
            </div>
            <div style="clear: both">
            </div>
            <hr />
            <asp:Panel ID="pnlSessions" runat="server"></asp:Panel>
        </div>

    </div>
    <div>

        <asp:Button ID="Button1" runat="server" Text="Button" />
        <asp:Button ID="Button2" runat="server" Text="Update Academic year/ Session " />
        <asp:Button ID="btnActivate" runat="server" Text="Activate this Academic Year" OnClick="btnActivate_Click" />
        <asp:Button ID="Button4" runat="server" Text="Mark this as completed." />

    </div>
    <asp:HiddenField ID="hidAcademicYear" runat="server" Value="0" />
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style1 {
            width: 94px;
        }
    </style>
</asp:Content>

