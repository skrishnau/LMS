<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="NoticeDetail.aspx.cs" Inherits="One.Views.NoticeBoard.NoticeDetail" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <div style="width: 100%;">
        <h3 class="heading-of-listing">
            <asp:Label ID="lblNoticeName" runat="server" Text=""></asp:Label>
            
        </h3>
        <hr />
        <div class="heading-menu">
            <asp:HyperLink ID="lnkEdit" runat="server"
                >
                Edit
            </asp:HyperLink>
            &nbsp;|&nbsp;
             <asp:HyperLink ID="lnkDelete" runat="server"
                NavigateUrl="">
                Delete
            </asp:HyperLink>
        </div>

        <div style="margin-left: 20px; padding: 5px;" runat="server" ID="divPublished" visible="false">
            <asp:CheckBox ID="chkPublished" Font-Bold="True" Text="Published to Notice Board" Enabled="False" runat="server" />
            &nbsp;<asp:Label ID="lblPostedOn" runat="server" Text=""></asp:Label>
        </div>

        <%--  --%><div style="border: 2px solid lightgray; padding: 5px; margin: 20px;">
            <div style="width: 100%;">
                <asp:Literal ID="lblNoticeContent" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
</asp:Content>
