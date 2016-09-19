<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GradeValuesUC.ascx.cs" Inherits="One.Views.Grade.GradeValuesUC" %>

<div  style="width: 100%;">
    <span style="border: 1px solid lightgray; padding: 0 5px;">
    Value&nbsp;
    <asp:TextBox ID="txtValue" runat="server" Width="192px"></asp:TextBox>
    &nbsp;&nbsp;&nbsp; Equivalent&nbsp;
    <asp:TextBox ID="txtEquivalent" runat="server" Width="66px" 
        
        ></asp:TextBox>

&nbsp;&nbsp;
    <asp:CheckBox ID="chkFail" runat="server" Text="Fail " ToolTip="To mark if this is a fail value." />
    </span>
     &nbsp;&nbsp;
       
    <asp:ImageButton ID="btnClose" runat="server" ImageUrl="~/Content/Icons/Close/cross_8x20_center.png" CausesValidation="False" OnClick="btnClose_Click" style="width: 8px"/>

    <asp:HiddenField ID="hidId" runat="server" Value="0"/>
    <asp:HiddenField ID="hidLocalId" runat="server" Value="0"/>
</div>