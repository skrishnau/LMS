<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NoticeBoardUc.ascx.cs" Inherits="One.ViewsSite.User.ModulesUc.NoticeBoardUc" %>


<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="module-whole">
            <div class="modules-title">
                <asp:HyperLink ID="HyperLink1" CssClass="modules-title" runat="server"
                    NavigateUrl="~/Views/NoticeBoard/NoticeListing.aspx">Notice</asp:HyperLink>
                <asp:Label ID="lblNoticeIndication" runat="server" Text="" ForeColor="white" BackColor="red"></asp:Label>

            </div>
            <%-- 180px; style="font-size: 0.9em;"--%>
            <%-- class="modules-body" list-unmargined"class="list-datalist"--%>
            <div  class="list-dark-datalist">
                <%-- DataSourceID="NotificationListDS" --%>
                <div>
                    <asp:Label ID="lblEmptyNotice" runat="server" Text=" &nbsp; No notices" ForeColor="darkgray" Font-Size="0.9em"></asp:Label>
                </div>
                <asp:DataList ID="DataList1"  runat="server" Width="100%" OnItemCommand="DataList1_ItemCommand">
                    <ItemTemplate>
                        <%-- style="border-bottom: 1px solid lightgray; vertical-align: top;" --%>
                        <%-- Here Void is already assigned to indicate Viewed or not-Viewed Notices. --%>
                        <asp:HyperLink ID="HyperLink2" runat="server" 
                            NavigateUrl='<%# "~/Views/NoticeBoard/NoticeDetail.aspx?nId="+Eval("Id") %>'>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Title")  %>'></asp:Label>
                            <div class="list-item-description">
                                <asp:Label ID="UpdatedDateLabel" runat="server" Text='<%# GetPublishDate(Eval("PublishedDate")) %>' />
                            </div>
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:DataList>

                <asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
                <asp:HiddenField ID="hidUserId" runat="server" Value="0" />
                <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
            </div>
        </div>

    </ContentTemplate>
</asp:UpdatePanel>
