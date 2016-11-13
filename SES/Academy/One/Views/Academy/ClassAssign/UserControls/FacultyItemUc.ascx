<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FacultyItemUc.ascx.cs" Inherits="One.Views.Academy.ClassAssign.UserControls.FacultyItemUc" %>

<div class="data-entry-section-body">
    <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
    <asp:HiddenField ID="hidId" runat="server" Value="0"/>
    <div style="margin-left: 20px;">
        <asp:Panel ID="pnlPrograms" runat="server"></asp:Panel>
    </div>
    <hr style="border: 1px solid lightgray; background-color: lightgray;"/>
    
     <asp:HiddenField ID="hidAcademicYearId" runat="server" Value="0" />
        <asp:HiddenField ID="hidSessionId" runat="server" Value="0" />

</div>