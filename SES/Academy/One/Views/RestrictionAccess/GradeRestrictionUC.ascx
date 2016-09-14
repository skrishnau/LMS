<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GradeRestrictionUC.ascx.cs" Inherits="One.Views.RestrictionAccess.GradeRestrictionUC" %>


<div class="restriction-uc-whole">
    <asp:ImageButton ID="imgVisibility" ImageUrl="~/Content/Icons/Visibility/eye_16x20_visible.png" runat="server" />    
    &nbsp;
    <span>Grade&nbsp;
    <asp:DropDownList ID="ddlActivityChoose" runat="server" Height="16px" Width="216px">
    </asp:DropDownList>
        &nbsp;
    <asp:CheckBox ID="chkGreaterThanOrEqualTo" runat="server" Text="must be ≥" />
        &nbsp;
    <asp:TextBox ID="txtGreaterThanOrEqualTo" runat="server" Width="63px"></asp:TextBox>
        %
    &nbsp;&nbsp;&nbsp;
    <asp:CheckBox ID="chkLessThan" runat="server" Text="must be <" />
        &nbsp;
    
    <asp:TextBox ID="txtLessThan" runat="server" Width="63px"></asp:TextBox>
        %
    
    </span>
    &nbsp;
    <asp:ImageButton ID="imgClose" ImageUrl="~/Content/Icons/Close/cross_8x20_center.png" runat="server" />
</div>
