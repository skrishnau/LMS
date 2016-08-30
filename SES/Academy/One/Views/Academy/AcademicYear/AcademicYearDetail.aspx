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
            <div style="clear: both;">
                <div style="float: left;">
                    <strong>Programs
                    </strong>

                </div>
                <div style="float: right;">
                    <asp:HyperLink ID="lnkAddPrograms" runat="server">
                        <asp:Image ID="Image2" runat="server"
                            ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                        Add Programs
                    </asp:HyperLink>
                </div>
            </div>

            <div style="clear: both;"></div>
            <hr />
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

