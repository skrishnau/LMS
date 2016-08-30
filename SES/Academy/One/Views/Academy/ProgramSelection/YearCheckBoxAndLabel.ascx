<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="YearCheckBoxAndLabel.ascx.cs" Inherits="One.Views.Academy.ProgramSelection.YearCheckBoxAndLabel" %>

<div style="margin: auto; text-align: left; padding-left: 5px; width: 300px;">

    <asp:CheckBox ID="chkBox" runat="server" OnCheckedChanged="chkBox_CheckedChanged" />
    &nbsp;|&nbsp;
    <%--<asp:ImageButton ID="imgBtn" runat="server" Visible="False" OnClick="imgBtn_Click" CausesValidation="False" />--%>
    <asp:LinkButton ID="lnkBatchSelect" runat="server" OnClick="lnkBtn_Click">
        <asp:Label ID="lblBatchName" runat="server" Text=""></asp:Label>
        <asp:Image ID="imgBtn" runat="server" />
    </asp:LinkButton>
    <asp:HiddenField ID="hidSelectedProgramBatchId" runat="server" Value="0"/>
    <%--<asp:Label ID="lbl" runat="server" Text="Label"></asp:Label>--%>
    <asp:HiddenField ID="hidId" runat="server" Value="0" />
    <div style="margin-left: 20px;">
        <asp:Panel ID="pnlSubControls" runat="server"></asp:Panel>
    </div>
    <asp:HiddenField ID="hidProgramId" runat="server" Value="0" />
    <asp:HiddenField ID="hidRunningClassId" runat="server" Value="0" />

    <asp:HiddenField ID="hidProgrameName" runat="server" Value="" />
    <asp:HiddenField ID="hidYearName" runat="server" Value="" />
    <asp:HiddenField ID="hidSubYearName" runat="server" Value="" />

    <asp:HiddenField ID="hidLevelId" runat="server" Value="0" />
    <asp:HiddenField ID="hidFacultyId" runat="server" Value="0" />


</div>
