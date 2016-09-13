<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="NoticeDetail.aspx.cs" Inherits="One.Views.NoticeBoard.NoticeDetail" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <div>
        <div style="text-align: center;">
            <strong style="font-size: 1.3em">
                <asp:Label ID="lblNoticeName" runat="server" Text=""></asp:Label>
            </strong>
            <hr />
        </div>
        <div style="margin-left: 20px; padding: 5px;">
            <asp:CheckBox ID="chkPublished" Font-Bold="True" Text="Published to Notice Board" Enabled="False" runat="server" />
            <asp:Label ID="lblPostedOn" runat="server" Text=""></asp:Label>
        </div>
        <br />
        <strong>Notice</strong>
        <hr />
        <div style="margin: 20px; border: 2px solid lightgray; padding: 5px; width: 100%;">
            <asp:Literal ID="lblNoticeContent" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>
