<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserProfileRestriction.ascx.cs" Inherits="One.Views.RestrictionAccess.UserProfileRestriction" %>


<div class="restriction-uc-whole">
    <asp:ImageButton ID="imgVisibility" ImageUrl="~/Content/Icons/Visibility/eye_16x20_visible.png" runat="server" />    
    &nbsp;
    <span>User profile filed&nbsp; 
    <asp:DropDownList ID="ddlField" runat="server" Height="20px" Width="150px">
    </asp:DropDownList>
        &nbsp;
         <asp:DropDownList ID="ddlConstraint" runat="server" Height="20px" Width="120px">
         </asp:DropDownList>
        &nbsp;
    <asp:TextBox ID="txtValue" runat="server"></asp:TextBox>
    </span>
    &nbsp;
    <asp:ImageButton ID="imgClose" ImageUrl="~/Content/Icons/Close/cross_8x20_center.png" runat="server" />
</div>
