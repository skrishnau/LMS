<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CourseUc.ascx.cs" Inherits="One.ViewsSite.DashBoard.Student.CourseOverView.CourseUc" %>
<%-- class="item" --%>
<%-- auto-st2 --%>
<div class="list-group-item" style="padding: 10px;">
    <%-- item-heading --%>
    <%--class="list-item-heading"--%>
    <div >
        <%-- CssClass="list-item-heading" --%>
        <asp:Hyperlink ID="lblTitle"  runat="server" Text="Heading" ></asp:Hyperlink>
       <%--<span style="font-size:1em" >--%>
         <%--  <asp:LinkButton ID="lnkWithdraw" runat="server" OnClick="lnkWithdraw_Click">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Participation/out.png" 
                Width="16" Height="16" />
            Withdraw from course
        </asp:LinkButton>--%>
       <%--</span>--%> 
    </div>

    <div class="item-message list-item-description">
        <asp:PlaceHolder ID="pnlMessages" runat="server"></asp:PlaceHolder>
    </div>

    <asp:HiddenField ID="hidSubSubscriptionId" runat="server" Value="0" />
</div>
