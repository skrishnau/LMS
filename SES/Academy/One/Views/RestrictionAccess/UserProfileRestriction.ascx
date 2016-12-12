<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserProfileRestriction.ascx.cs" Inherits="One.Views.RestrictionAccess.UserProfileRestriction" %>


<div class="restriction-uc-whole">
    <%-- <asp:ImageButton ID="imgVisibility" ImageUrl="~/Content/Icons/Visibility/eye_16x20_visible.png" runat="server" />    
    &nbsp;--%>
    <span>User profile filed&nbsp; 
    <asp:DropDownList ID="ddlField" runat="server" Height="20px" Width="150px"
        DataSourceID="dsFields">
    </asp:DropDownList>
        &nbsp;
         <asp:DropDownList ID="ddlConstraint" runat="server" 
             DataValueField="Id"
             DataTextField="Name"
             DataSourceID="dsConstraints"
             Height="20px" Width="120px">
         </asp:DropDownList>
        &nbsp;
    <asp:TextBox ID="txtValue" runat="server"></asp:TextBox>
    </span>
    &nbsp;
     <span class="img-close">
         <asp:ImageButton ID="imgClose" CssClass="link-img-close" CausesValidation="False"
             ImageUrl="~/Content/Icons/Close/cross_8x20_center.png" runat="server" OnClick="imgClose_Click" />
     </span>

    <asp:ObjectDataSource ID="dsFields" runat="server" SelectMethod="ListUserFields" TypeName="One.Views.RestrictionAccess.UserProfileRestriction"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="dsConstraints" runat="server" 
        SelectMethod="ListUserFieldConstraints" 
        TypeName="One.Views.RestrictionAccess.UserProfileRestriction"></asp:ObjectDataSource>

    <asp:HiddenField ID="hidParentId" runat="server" Value="0" />
    <asp:HiddenField ID="hidRelativeId" runat="server" Value="1" />
    <asp:HiddenField ID="hidAbsoluteId" runat="server" Value="1" />
    <asp:HiddenField ID="hidType" runat="server" Value="" />

    <asp:HiddenField ID="hidUserProfileRestrictionId" runat="server" Value ="0"/>
    <asp:HiddenField ID="hidRestrictionId" runat="server" Value ="0"/>
</div>
