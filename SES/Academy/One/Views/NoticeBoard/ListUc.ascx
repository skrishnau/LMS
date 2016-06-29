<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListUc.ascx.cs" Inherits="One.Views.NoticeBoard.ListUc" %>


<div>
    <asp:DataList ID="DataList1" runat="server" DataSourceID="NotificationListDS">
        <ItemTemplate>
            <asp:HiddenField ID="IdLabel" runat="server" Value='<%# Eval("Id") %>' />
            <strong>
                <asp:Label ID="HeadiingLabel" runat="server" Text='<%# Eval("Headiing") %>' />
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
            <em style="font-size: 0.8em">Last Update:
                <asp:Label ID="UpdatedDateLabel" runat="server" Text='<%# Eval("UpdatedDate") %>' />
            </em>
            <%--<br />
            ViewerLimited:
            <asp:Label ID="ViewerLimitedLabel" runat="server" Text='<%# Eval("ViewerLimited") %>' />
            <br />--%>
            <br />
        </ItemTemplate>
    </asp:DataList>

    <asp:ObjectDataSource ID="NotificationListDS" runat="server" SelectMethod="GetNotices" TypeName="Academic.DbHelper.DbHelper+Notice">
        <SelectParameters>
            <asp:ControlParameter ControlID="hidUserId" DefaultValue="0" Name="userId" PropertyName="Value" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:HiddenField ID="hidUserId" runat="server" Value="0" />
</div>
