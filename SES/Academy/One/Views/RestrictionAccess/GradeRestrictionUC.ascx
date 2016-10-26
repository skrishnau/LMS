<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GradeRestrictionUC.ascx.cs" Inherits="One.Views.RestrictionAccess.GradeRestrictionUC" %>


<div class="restriction-uc-whole">
    <%--<asp:ImageButton ID="imgVisibility" ImageUrl="~/Content/Icons/Visibility/eye_16x20_visible.png" runat="server" />--%>    
    &nbsp;
    <span>Grade&nbsp;
    <asp:DropDownList ID="ddlActivityChoose" runat="server" Height="22px" Width="216px" 
        ToolTip="Please be sure that target students have access to the selected Activity" DataTextField="Name" 
        DataValueField="ActivityResourceId">
    </asp:DropDownList>
        &nbsp;
    <asp:CheckBox ID="chkGreaterThanOrEqualTo" runat="server" Text="must be ≥" AutoPostBack="True" OnCheckedChanged="chkGreaterThanOrEqualTo_CheckedChanged" />
        &nbsp;
    <asp:TextBox ID="txtGreaterThanOrEqualTo" runat="server" Width="63px" Enabled="False"></asp:TextBox>
        %
    &nbsp;&nbsp;
    <asp:CheckBox ID="chkLessThan" runat="server" Text="must be <" AutoPostBack="True" OnCheckedChanged="chkLessThan_CheckedChanged" />
        &nbsp;
    
    <asp:TextBox ID="txtLessThan" runat="server" Width="63px" Enabled="False"></asp:TextBox>
        %
    
    </span>
    &nbsp;

 <asp:ImageButton ID="imgClose" CssClass="img-close" CausesValidation="False"
     ImageUrl="~/Content/Icons/Close/cross_8x20_center.png" runat="server" OnClick="imgClose_Click" />
    
    <asp:HiddenField ID="hidParentId" runat="server" Value="0" />
    <asp:HiddenField ID="hidRelativeId" runat="server" Value="1" />
    <asp:HiddenField ID="hidAbsoluteId" runat="server" Value="1" />
    <asp:HiddenField ID="hidType" runat="server" Value="" />
    
    <asp:HiddenField ID="hidGradeRestrictionId" runat="server" Value="0" />
    <asp:HiddenField ID="hidRestrictionId" runat="server" Value="0" />
    
    <asp:HiddenField ID="hidSubjectId" runat="server" Value="0" />

</div>
