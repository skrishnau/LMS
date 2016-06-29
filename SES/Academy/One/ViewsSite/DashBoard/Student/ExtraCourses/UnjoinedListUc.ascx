<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UnjoinedListUc.ascx.cs" Inherits="One.ViewsSite.DashBoard.Student.ExtraCourses.UnjoinedListUc" %>



<div class="item">
    <asp:Panel ID="pnlContent" runat="server">
        <div class="item-heading">
            <asp:LinkButton ID="lblTitle" runat="server" Text="Heading" Font-Names="Berlin Sans FB" Font-Size="Large" OnClick="lblTitle_Click"></asp:LinkButton>
        </div>

        <div class="item-message">
            <asp:PlaceHolder ID="pnlDescription" runat="server"></asp:PlaceHolder>
        </div>
        <div style="">
            &nbsp;&nbsp;
        <span class="item-detail">
            <asp:ImageButton ID="ImageButton1" runat="server" Height="16px" ImageUrl="~/Content/Icons/Participation/degree_icon.jpg" OnClick="ImageButton1_Click" Width="16px" />
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Participate</asp:LinkButton>
        </span>
            &nbsp;
        </div>
        <asp:HiddenField ID="hidSubClsId" runat="server" Value="0" />
        <asp:HiddenField ID="hidStdClsId" runat="server" Value="0" />
    </asp:Panel>
    <asp:Panel ID="pnlStatus" runat="server" Visible="false">
        <asp:Literal ID="lblStat" runat="server"></asp:Literal>
    </asp:Panel>
</div>
