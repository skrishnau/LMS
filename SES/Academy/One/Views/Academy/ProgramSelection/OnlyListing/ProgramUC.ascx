<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProgramUC.ascx.cs" Inherits="One.Views.Academy.ProgramSelection.OnlyListing.ProgramUC" %>



<div style=" width: 300px; margin: auto; margin-top: 5px; margin-bottom: 5px; padding: 10px 10px; background-color: lightsalmon;">
    <asp:CheckBox ID="chkBox" runat="server" OnCheckedChanged="chkBox_CheckedChanged" AutoPostBack="True" />
    <%--<asp:Label ID="lbl" runat="server" Text="Label"></asp:Label>--%>
    <asp:HiddenField ID="hidId" runat="server" Value="0" />
    <hr/>
    <asp:Panel ID="pnlSubControls" runat="server"></asp:Panel>
</div>