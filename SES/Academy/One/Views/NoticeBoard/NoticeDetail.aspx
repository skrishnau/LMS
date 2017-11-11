<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="NoticeDetail.aspx.cs" Inherits="One.Views.NoticeBoard.NoticeDetail" %>

<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <h3 class="heading-of-listing">
        <asp:Label ID="lblNoticeName" runat="server" Text=""></asp:Label>

    </h3>
    <hr />
    <%--  --%>
    <div class="text-center" runat="server" id="menuEditDelete" visible="False">
        <asp:HyperLink ID="lnkEdit" runat="server" CssClass="btn btn-default">
                Edit
        </asp:HyperLink>
        &nbsp;
             <asp:HyperLink ID="lnkDelete" runat="server" CssClass="btn btn-default">
                Delete
             </asp:HyperLink>
    </div>

    <br />

    <div class="data-entry-section-body" runat="server" id="divPublished" visible="false">
        <asp:CheckBox ID="chkPublished" Text="Published to Notice Board" Enabled="False" runat="server" />

        <table>
            <tr>
                <td class="data-type-bold">Posted on </td>
                <td class="data-value">
                    <asp:Label ID="lblPstdOn" runat="server" Text=""></asp:Label>

                </td>
            </tr>
            <tr>
                <td class="data-type-bold">Viewers </td>
                <td class="data-value">
                    <asp:Label ID="lblViewers" runat="server" Text=""></asp:Label>

                </td>
            </tr>
        </table>
        <%--<asp:Label ID="lblPostedOn" runat="server" Text=""></asp:Label>--%>
    </div>
    <br/>
    <div class="panel panel-default">

        <div class="panel-heading">
            Notice
        </div>
        <%--style="border: 1px dashed lightgray; padding: 5px; margin: 0  20px 20px;">--%>
        <div runat="server" id="divNotice" visible="False" class="panel-body">
            <asp:Literal ID="lblNoticeContent" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>
<asp:Content runat="server" ID="content2" ContentPlaceHolderID="title">
    <asp:Literal ID="lblTitle" runat="server"></asp:Literal>
</asp:Content>
<asp:Content runat="server" ID="content4" ContentPlaceHolderID="head">
    <link href="../../Content/CSSes/TableStyles.css" rel="stylesheet" />
</asp:Content>
