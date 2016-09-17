<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupRestrictionUC.ascx.cs" Inherits="One.Views.RestrictionAccess.GroupRestrictionUC" %>




<div class="restriction-uc-whole">
    <asp:ImageButton ID="ImageButton1" ImageUrl="~/Content/Icons/Visibility/eye_16x20_visible.png" runat="server" />
    &nbsp;
    <span>Students in &nbsp; 
    <asp:DropDownList ID="ddlClassGroup" runat="server" Height="20px" Width="100px">
        <Items>
            <asp:ListItem Value="0" Text="Class"></asp:ListItem>
            <asp:ListItem Value="1" Text="Group"></asp:ListItem>
        </Items>
    </asp:DropDownList>
        &nbsp;
         <asp:DropDownList ID="ddlClassValue" runat="server" Height="20px" Width="140px">
         </asp:DropDownList>

        <asp:PlaceHolder ID="PlaceHolder1" runat="server">&nbsp;
            and group
              &nbsp;
             <asp:DropDownList ID="ddlGroupValue" runat="server" Height="20px" Width="120px">
             </asp:DropDownList>
        </asp:PlaceHolder>
    </span>
    &nbsp;
    
 <asp:ImageButton ID="imgClose" CssClass="img-close" ImageUrl="~/Content/Icons/Close/cross_8x20_center.png" runat="server" OnClick="imgClose_Click" />
    
    <asp:HiddenField ID="hidParentId" runat="server" Value="0" />
    <asp:HiddenField ID="hidRelativeId" runat="server" Value="1" />
    <asp:HiddenField ID="hidAbsoluteId" runat="server" Value="1" />
    <asp:HiddenField ID="hidType" runat="server" Value="" />

</div>
