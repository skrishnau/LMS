<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ActivityCompleteRestrictionUC.ascx.cs" Inherits="One.Views.RestrictionAccess.ActivityCompleteRestrictionUC" %>


<div class="restriction-uc-whole">
    <asp:ImageButton ID="imgVisibility" ImageUrl="~/Content/Icons/Visibility/eye_16x20_visible.png" runat="server" />
    &nbsp;
    <span>Activity Complettion &nbsp; 
    <asp:DropDownList ID="ddlActivity" runat="server" Height="20px" Width="150px">
    </asp:DropDownList>
        &nbsp;
    <asp:DropDownList ID="ddlConstraint" runat="server" Height="20px" Width="230px">
        <Items>
            <asp:ListItem Value="0" Text="Must be marked complete"></asp:ListItem>
            <asp:ListItem Value="1" Text="Must not be marked complete"></asp:ListItem>
            <asp:ListItem Value="2" Text="Must be complete with pass grade"></asp:ListItem>
            <asp:ListItem Value="3" Text="Must be complete with fail grade"></asp:ListItem>
            </Items>
    </asp:DropDownList>
    </span>
    &nbsp;
    <asp:ImageButton ID="imgClose" CssClass="img-close" CausesValidation="False"
         ImageUrl="~/Content/Icons/Close/cross_8x20_center.png" runat="server" OnClick="imgClose_Click" />
    
    <asp:HiddenField ID="hidParentId" runat="server" Value="0" />
    <asp:HiddenField ID="hidRelativeId" runat="server" Value="1" />
    <asp:HiddenField ID="hidAbsoluteId" runat="server" Value="1" />
    <asp:HiddenField ID="hidType" runat="server" Value="" />

</div>


