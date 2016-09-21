<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NoticeBoardUc.ascx.cs" Inherits="One.ViewsSite.User.ModulesUc.NoticeBoardUc" %>


<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="module-whole">
            <div class="modules-heading">
                <asp:HyperLink ID="HyperLink1" CssClass="modules-title" runat="server"
                    NavigateUrl="~/Views/NoticeBoard/NoticeListing.aspx"
                    >Notice</asp:HyperLink>
                <asp:Label ID="lblNoticeIndication" runat="server" Text="" ForeColor="white" BackColor="red"></asp:Label>

            </div>

            <%-- 180px; --%>
            <div class="modules-body">
                <%-- DataSourceID="NotificationListDS" --%>
                <asp:DataList ID="DataList1" Height="100%" runat="server" Width="100%" OnItemCommand="DataList1_ItemCommand">
                    <ItemTemplate>
                        <div style="border-bottom: 1px solid lightgray; vertical-align: top;">
                            <strong>
                                <asp:HyperLink ID="HeadiingLabel" runat="server" Font-Underline="False"
                                    NavigateUrl='<%# "~/Views/NoticeBoard/NoticeDetail.aspx?nId="+Eval("Id") %>'
                                    Text='<%# Eval("Title")  %>'>
                                </asp:HyperLink>
                            </strong>
                            <%-- Here Void is already assigned to indicate Viewed or not-Viewed Notices. --%>
                            <asp:ImageButton ID="ImageButton1" runat="server"
                                ImageUrl="~/Content/Icons/Exclamation/exclamation.png" AlternateText="*"
                                CommandArgument='<%# Eval("Id") %>' CommandName="Click" Visible='<%# Eval("Void")%>' />
                            <%--<asp:ImageButton ID="ImageButton2" runat="server"  
                            ImageUrl="~/Content/Icons/Exclamation/exclamation.png" 
                            CommandArgument='<%# Eval("Id") %>' CommandName="Click"
                            Visible='<%# Eval("Void")%>'
                            />--%>
                            <%--<asp:ImageButton ID="ImageButton1"  runat="server" Height="14px" Width="10px"
                            />--%>
                            <%--<asp:Label ID="lblNoticeIndication" runat="server" ForeColor="white" Text=" &nbsp;* &nbsp;" BackColor="red" Visible='<%# Eval("ViewerLimited") %>'></asp:Label>--%>

                            <%--  <div style="margin: 20px; padding: 5px; ">
                <asp:Literal ID="DescriptionLabel" runat="server" Text='<%# Eval("Content") %>' />
            </div>--%>

                            <br />
                            <em style="font-size: 0.7em; color: grey;">&nbsp;&nbsp;posted on:
                    <asp:Label ID="UpdatedDateLabel" runat="server" Text='<%# GetPublishDate(Eval("PublishedDate")) %>' />
                            </em>
                        </div>


                        <%--<hr style="background-color: lightgray; height: 1px; border: none;"/>--%>
                    </ItemTemplate>
                </asp:DataList>

                <%--  This below code works
      <asp:ObjectDataSource ID="NotificationListDS" runat="server" SelectMethod="GetNotices" TypeName="Academic.DbHelper.DbHelper+Notice">
        <SelectParameters>
            <asp:ControlParameter ControlID="hidUserId" DefaultValue="0" Name="userId" PropertyName="Value" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>--%>

                <asp:HiddenField ID="HiddenField1" runat="server" Value="0" />


                <asp:HiddenField ID="hidUserId" runat="server" Value="0" />
                <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />

            </div>
        </div>

    </ContentTemplate>
</asp:UpdatePanel>
