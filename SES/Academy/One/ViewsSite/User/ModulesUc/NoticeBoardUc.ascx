<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NoticeBoardUc.ascx.cs" Inherits="One.ViewsSite.User.ModulesUc.NoticeBoardUc" %>



<div style="width: 100%; background-color: gainsboro;">
    <strong > &nbsp;&nbsp;Notice Board </strong>
    <asp:Label ID="lblNoticeIndication" runat="server" Text="" ForeColor="white" BackColor="red"></asp:Label>
    <hr />
</div>
<%-- 180px; --%>
<div style="overflow: auto; margin-top: 5px; height: 10px;">
    <%-- DataSourceID="NotificationListDS" --%>
    <asp:DataList ID="DataList1" Height="100%" runat="server" >
        <ItemTemplate>
            <asp:HiddenField ID="IdLabel" runat="server" Value='<%# Eval("Id") %>' />
            <strong>
                <asp:Label ID="HeadiingLabel" runat="server" Text='<%# Eval("Headiing") %>' />
                &nbsp;&nbsp; &nbsp;
                <asp:ImageButton ID="ImageButton1" runat="server"  Height="10px" Width="10px"
                     ImageUrl="~/Content/Icons/Star/star_red.png"
                    Visible='<%# Eval("ViewerLimited")%>'/>
                <%--<asp:Label ID="lblNoticeIndication" runat="server" ForeColor="white" Text=" &nbsp;* &nbsp;" BackColor="red" Visible='<%# Eval("ViewerLimited") %>'></asp:Label>--%>
            </strong>
            <div style="margin-left: 20px;">
                <asp:Literal ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>' />
            </div>

            <%--CreatedById:
            <asp:Label ID="CreatedByIdLabel" runat="server" Text='<%# Eval("CreatedById") %>' />
            <br />
            CreatedBy:
            <asp:Label ID="CreatedByLabel" runat="server" Text='<%# Eval("CreatedBy") %>' />
            <br />--%>
            <%-- Date:
            <asp:Label ID="CreatedDateLabel" runat="server" Text='<%# Eval("CreatedDate") %>' />
            --%>
            <em style="font-size: 0.7em">Last Update:
                <asp:Label ID="UpdatedDateLabel" runat="server" Text='<%# Eval("UpdatedDate") %>' />
            </em>
            <%--<br />
            ViewerLimited:
            <asp:Label ID="ViewerLimitedLabel" runat="server" Text='<%# Eval("ViewerLimited") %>' />
            <br />--%>
            <hr />
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

</div>
