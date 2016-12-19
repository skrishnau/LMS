<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="NoticeListing.aspx.cs" Inherits="One.Views.NoticeBoard.NoticeListing" %>

<asp:Content runat="server" ID="contentbody" ContentPlaceHolderID="Body">
    <div>
        <h3 class="heading-of-listing">Notices
        </h3>
        <hr />

        <div>
            <table style="width: 99%;">
                <tr>
                    <td>
                       

                    </td>
                    <td>
                      <%--  <div style="text-align: right;">
                            <asp:HyperLink ID="lnkEdit" runat="server">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/Icons/Edit/edit_orange.png" />
                                <asp:Label ID="lblEdit" runat="server" Text="Edit"></asp:Label>
                            </asp:HyperLink>
                        </div>--%>
                         <div style="text-align: right; margin: 5px;">
                            <asp:HyperLink ID="lnkAddNotice" runat="server" CssClass="link"
                                Visible="False">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                                New notice
                            </asp:HyperLink>
                        </div>
                    </td>
                </tr>

            </table>



            <%--  class="detail-view" --%>

            <asp:DataList ID="DataList1" runat="server" DataSourceID="NotificationListDS" Width="98%">
                <ItemTemplate>
                    <div class="auto-st2" style="padding: 10px;">
                        <asp:HiddenField ID="IdLabel" runat="server" Value='<%# Eval("Id") %>' />
                        <strong>
                            <asp:HyperLink ID="HeadiingLabel" runat="server"
                                CssClass="link"
                                Text='<%# Eval("Title") %>'
                                NavigateUrl='<%# "~/Views/NoticeBoard/NoticeDetail.aspx?nId="+Eval("Id") %>'>
                            </asp:HyperLink>
                        </strong>

                        <em style="font-size: 0.8em">Last Update:
                                <asp:Label ID="UpdatedDateLabel" runat="server" Text='<%# GetPublishDate(Eval("PublishedDate")) %>' />
                        </em>

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
