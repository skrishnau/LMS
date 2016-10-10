<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="DiscussionView.aspx.cs" Inherits="One.Views.ActivityResource.Forum.DiscussionView" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <div>
        <h3>
            <asp:Label ID="lblForumName" runat="server" Text=""></asp:Label>
        </h3>
        <br/>
        <div style="font-weight: 600;">
            <asp:Label ID="lblDiscussionSubject" runat="server" Text=""></asp:Label>
            
        </div>
    </div>
    <br />
   <div style="margin-left: 20px;">
        <asp:Panel ID="pnlReplies" runat="server"></asp:Panel>
    </div>
    <asp:HiddenField ID="hidForumId" runat="server" Value="0" />
    <asp:HiddenField ID="hidParentDiscussionId" runat="server" Value="0" />
    <asp:HiddenField ID="hidDiscussionId" runat="server" Value="0" />
    <asp:HiddenField ID="hidPageKey" runat="server" Value="" />

    <asp:HiddenField ID="hidSubjectId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSectionId" runat="server" Value="0" />
</asp:Content>
