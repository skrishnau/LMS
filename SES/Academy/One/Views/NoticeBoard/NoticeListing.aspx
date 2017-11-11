<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="NoticeListing.aspx.cs" Inherits="One.Views.NoticeBoard.NoticeListing" %>


<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>



<asp:Content runat="server" ID="contentbody" ContentPlaceHolderID="Body">
    <div>
        <h3 class="heading-of-listing">Notices
        </h3>
        <hr />

        <div class="text-right">
            <asp:HyperLink ID="lnkAddNotice" runat="server" CssClass="btn btn-default"
                Visible="False">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                New notice
            </asp:HyperLink>
        </div>
        <br/>
        <div class="panel panel-default">

            <%--  class="detail-view" --%>

            <asp:DataList ID="DataList1" runat="server" DataSourceID="NotificationListDS" Width="100%" CssClass="list-group">
                <ItemTemplate>
                    <%-- auto-st2 --%>
                    <%-- list-item-body style="padding: 10px;" --%>
                    <div class="list-group-item"  >
                        <asp:HiddenField ID="IdLabel" runat="server" Value='<%# Eval("Id") %>' />
                        <strong>
                            <asp:HyperLink ID="HeadiingLabel" runat="server"
                                CssClass="list-item-heading"
                                NavigateUrl='<%# "~/Views/NoticeBoard/NoticeDetail.aspx?nId="+Eval("Id") %>'>
                                <asp:Label ID="Label1" CssClass="list-item-heading" runat="server" Text='<%# Eval("Title") %>'></asp:Label>

                            </asp:HyperLink>
                        </strong>
                        <br />
                        <span style="" class="list-item-description">Posted on:
                            <asp:Label ID="UpdatedDateLabel" runat="server" Text='<%# GetPublishDate(Eval("PublishedDate")) %>' />
                        </span>
                    </div>
                </ItemTemplate>
            </asp:DataList>

            <asp:ObjectDataSource ID="NotificationListDS" runat="server" SelectMethod="ListNotices" TypeName="Academic.DbHelper.DbHelper+Notice">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hidSchoolId" DefaultValue="0" Name="schoolId" PropertyName="Value" Type="Int32" />
                    <asp:ControlParameter ControlID="hidUserId" DefaultValue="0" Name="userId" PropertyName="Value" Type="Int32" />
                    <asp:ControlParameter ControlID="hidDisplayAll" DefaultValue="False" Name="displayAll" PropertyName="Value" Type="Boolean" />
                </SelectParameters>
            </asp:ObjectDataSource>

            <asp:HiddenField ID="hidUserId" runat="server" Value="0" />
            <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
            <asp:HiddenField ID="hidDisplayAll" runat="server" Value="False" />
        </div>
    </div>
</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="title">
    Notices
</asp:Content>
