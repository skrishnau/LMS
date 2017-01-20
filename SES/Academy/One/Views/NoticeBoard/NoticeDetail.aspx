<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="NoticeDetail.aspx.cs" Inherits="One.Views.NoticeBoard.NoticeDetail" %>

<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <div style="width: 100%;">
        <h3 class="heading-of-listing">
            <asp:Label ID="lblNoticeName" runat="server" Text=""></asp:Label>

        </h3>
        <hr />
        <div class="heading-menu" runat="server" ID="menuEditDelete" Visible="False">
            <asp:HyperLink ID="lnkEdit" runat="server">
                Edit
            </asp:HyperLink>
            &nbsp;|&nbsp;
             <asp:HyperLink ID="lnkDelete" runat="server"
                 >
                Delete
             </asp:HyperLink>
        </div>
        <%-- style="margin-left: 20px; padding: 5px;"  --%>
        <div class="data-entry-section">
            <div class="data-entry-section-body" runat="server" id="divPublished" visible="false">
                <asp:CheckBox ID="chkPublished" Font-Bold="True" Text="Published to Notice Board" Enabled="False" runat="server" />

                <table>
                    <tr>
                        <td class="data-type-bold">Posted on</td>
                        <td class="data-value">
                            <asp:Label ID="lblPstdOn" runat="server" Text=""></asp:Label>

                        </td>
                    </tr>
                    <tr>
                        <td class="data-type-bold">Viewers</td>
                        <td class="data-value">
                            <asp:Label ID="lblViewers" runat="server" Text=""></asp:Label>

                        </td>
                    </tr>
                </table>
                <%--<asp:Label ID="lblPostedOn" runat="server" Text=""></asp:Label>--%>
            </div>

            <br />
            <%-- style="font-weight: bold; margin-left: 20px;" --%>
            <div class="data-entry-section-heading">
                Notice<hr />
            </div>

            <div style="border: 2px dashed lightgray; padding: 5px; margin: 0  20px 20px;">
                <div style="width: 100%;">
                    <asp:Literal ID="lblNoticeContent" runat="server"></asp:Literal>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content runat="server" ID="content2" ContentPlaceHolderID="title">
    <asp:Literal ID="lblTitle" runat="server"></asp:Literal>
</asp:Content>