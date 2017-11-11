<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ViewsSite/User/UserMaster.Master" CodeBehind="SessionDetail.aspx.cs" Inherits="One.Views.Academy.Session.SessionDetail" %>

<%--<%@ Register Src="~/Views/Academy/UserControls/SessionsListingInAYDetailUC.ascx" TagPrefix="uc1" TagName="SessionsListingInAYDetailUC" %>--%>
<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">

    <h3 class="heading-of-listing">
        <asp:Label ID="lblHeading" runat="server" Text="Label"></asp:Label>

        <span style="vertical-align: top; top: 0; line-height: 10px;">
            <asp:Image ID="imgActive" runat="server"
                Width="10" Height="10"
                ImageUrl="~/Content/Icons/Stop/Stop_10px.png"
                Visible="False" />
        </span>

    </h3>
    <hr />

    <div>

        <%--<div style="text-align: center;">
            <asp:Button ID="btnActivate" runat="server" Text="Activate this Session" OnClick="btnActivate_Click" />
        </div>
        <br />--%>
        <div class="data-entry-section-body">
            <table>
                <tr>
                    <td class="data-type">Start date</td>
                    <td class="data-value">
                        <asp:Label ID="lblStart" runat="server" Text="Label"></asp:Label>

                    </td>
                </tr>

                <tr>
                    <td class="data-type">End date</td>
                    <td class="data-value">
                        <asp:Label ID="lblEnd" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>


            <br />


        </div>

        <div class="panel panel-default">
            <div class="panel-heading">
                Classes
            </div>
            <%--  --%>
            <asp:Panel ID="pnlListing" runat="server" CssClass="panel-body"></asp:Panel>
        </div>

        <%--<uc1:SessionsListingInAYDetailUC runat="server" ID="SessionsListingInAYDetailUC" />--%>
    </div>

    <asp:HiddenField ID="hidAcademicYearId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSessionId" runat="server" Value="0" />
    <asp:HiddenField ID="hidEditable" runat="server" Value="False" />
</asp:Content>

<asp:Content runat="server" ID="content2" ContentPlaceHolderID="head">
    <link href="../../../Content/CSSes/TableStyles.css" rel="stylesheet" />
</asp:Content>

<asp:Content runat="server" ID="content4" ContentPlaceHolderID="title">
    <asp:Literal ID="lblPageTitle" runat="server"></asp:Literal>
</asp:Content>
