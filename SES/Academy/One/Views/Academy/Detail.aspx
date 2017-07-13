<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="One.Views.Academy.Detail" %>



<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content4" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <h3 class="heading-of-listing">
        <asp:Label ID="lblAcademicYearName" runat="server" Text=""></asp:Label>

        <span style="vertical-align: top; top: 0; line-height: 10px;">
            <asp:Image ID="imgActive" runat="server"
                Width="10" Height="10"
                ImageUrl="~/Content/Icons/Stop/Stop_10px.png"
                Visible="False" />
        </span>

    </h3>

    <div class="data-entry-section-body">
        <table>
            <tr>
                <%--class="auto-style1"--%>
                <td class="data-type">Start Date</td>
                <td class="data-value">
                    <asp:Label ID="lblStartDate" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="data-type">End Date</td>
                <td class="data-value">
                    <asp:Label ID="lblEndDate" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="data-type">Batch admitted in this year</td>
                <td class="data-value">
                    <asp:HyperLink ID="lnkBatch" runat="server"></asp:HyperLink>
                </td>
            </tr>
            <%--  <tr>
                <td class="data-type">Programs</td>
                <td class="data-value">
                    <asp:Label ID="lblPrograms" runat="server" Text=""></asp:Label>
                </td>
            </tr>--%>
        </table>


        <div class="data-entry-section">
            <div class="data-entry-section-heading">
                Sessions
                <hr />
            </div>

            <div class="data-entry-section-body">
                <asp:Panel ID="pnlSessions" runat="server"></asp:Panel>
            </div>
        </div>
    </div>


    <asp:HiddenField ID="hidAcademicYear" runat="server" Value="0" />
    <asp:HiddenField ID="hidEditable" runat="server" Value="False" />
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <link href="../../Content/CSSes/TableStyles.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 94px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="title">
    <asp:Literal ID="lblPageTitle" runat="server"></asp:Literal>
</asp:Content>

