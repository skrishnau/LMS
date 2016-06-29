<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CourseUc.ascx.cs" Inherits="One.ViewsSite.DashBoard.Student.CourseOverView.CourseUc" %>
<div class="item">
    <div class="item-heading">
        <asp:LinkButton ID="lblTitle" runat="server" Text="Heading" OnClick="lblTitle_Click"></asp:LinkButton>
        &nbsp;&nbsp;&nbsp;&nbsp; 
       <font size="1em">
           <asp:LinkButton ID="lnkWithdraw" runat="server" OnClick="lnkWithdraw_Click">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Participation/out.png" 
                Width="16" Height="16" />
            Withdraw from course
        </asp:LinkButton>
       </font> 
    </div>

    <div class="item-message">
        <asp:PlaceHolder ID="pnlMessages" runat="server"></asp:PlaceHolder>
    </div>

    <asp:HiddenField ID="hidSubSubscriptionId" runat="server" Value="0" />
</div>
