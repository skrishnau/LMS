<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="listUc.ascx.cs" Inherits="One.Views.Student.Batch.List.listUc" %>

<div>
    <asp:PlaceHolder ID="pnlItems" runat="server"></asp:PlaceHolder>

   <%-- <div class="pager">
        <asp:ImageButton ID="btnLeft" runat="server" ImageUrl="~/Content/Icons/Arrow/arrow_left.png" />
        &nbsp;
        <asp:TextBox ID="txtPageNo" runat="server" Width="40px" TextMode="Number" Text="0"></asp:TextBox>
        &nbsp;
        <asp:ImageButton ID="btnRight" runat="server" ImageUrl="~/Content/Icons/Arrow/arrow_right.png" />
    </div>--%>
    <div>
        <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
        <asp:HiddenField ID="hidEdit" runat="server" Value="0" />
    </div>
</div>
