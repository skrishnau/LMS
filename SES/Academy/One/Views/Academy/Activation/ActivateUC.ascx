<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ActivateUC.ascx.cs" Inherits="One.Views.Academy.Activation.ActivateUC" %>

<div>
    <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
    &nbsp;
    <asp:Button ID="btnActivate" runat="server" Text="Activate" OnClick="btnActivate_Click" />

    <asp:HiddenField ID="hidAcademicYearId" runat="server" Value="0"/>
    <asp:HiddenField ID="hidSessionId" runat="server" Value="0"/>

</div>