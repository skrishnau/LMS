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
    <%--    <div style="text-align: right;">
        <asp:HyperLink ID="lnkEdit" runat="server" CssClass="link">
            <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/Icons/Edit/edit_orange.png" />
            <asp:Label ID="lblEdit" runat="server" Text="Edit"></asp:Label>
        </asp:HyperLink>
    </div>--%>
    <%--<div style="text-align: center;">--%>


    <%--<asp:Button ID="Button2" runat="server" Text="Update Academic year/ Session " />--%>
    <%-- <asp:Button ID="btnActivate" runat="server" Text="Activate this Academic Year"
            OnClick="btnActivate_Click" Visible="False" />
        &nbsp;--%>
    <%--   <asp:Button ID="btnMarkComplete" runat="server" Text="Mark this as completed"
                Visible="False"
                OnClick="btnMarkComplete_Click" />--%>
    <%--</div>--%>
    <%--  <div>
        <asp:Label ID="lblError" runat="server" Text="Error while saving" ForeColor="red" Visible="False"></asp:Label>
    </div>--%>
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

        <br />

        <div class="data-entry-section">
            <div class="data-entry-section-heading">
                <div style="clear: both;">
                    <div style="float: left;">
                        <strong>Sessions</strong>
                    </div>
                    <%-- <div style="float: right;">
                        <asp:HyperLink ID="lnknewSession" runat="server" CssClass="link-dark"
                            Visible="False">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                            Add Session
                        </asp:HyperLink>
                    </div>--%>
                </div>
                <div style="clear: both"></div>
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

