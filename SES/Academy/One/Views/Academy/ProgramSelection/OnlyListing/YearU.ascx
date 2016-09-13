<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="YearU.ascx.cs" Inherits="One.Views.Academy.ProgramSelection.OnlyListing.YearU" %>



<div style="margin: auto; text-align: left; padding-left: 5px; width: 300px;">

    <%--<asp:CheckBox ID="chkBox" runat="server" AutoPostBack="False" OnCheckedChanged="chkBox_CheckedChanged" />--%>

    <%--<asp:ImageButton ID="imgBtn" runat="server" Visible="False" OnClick="imgBtn_Click" CausesValidation="False" />--%>
    <asp:CheckBox ID="chkBox" runat="server" AutoPostBack="False" />
    <%--<asp:LinkButton ID="lnkBatchSelect" CssClass="inline-block" Font-Underline="False"
         runat="server" OnClick="lnkBtn_Click">
        <asp:Label ID="lblStructureName" runat="server" Text="" ForeColor="black"></asp:Label>
        &nbsp;|&nbsp;
        <asp:Label ID="lblBatchName" runat="server" Text="" ForeColor="darkblue" CssClass="hover-underline"></asp:Label>
        <asp:Image ID="imgBtn" runat="server" />
    </asp:LinkButton>--%>
        <asp:Label ID="lblYearName" runat="server" Text="" ForeColor="black"></asp:Label>
        <asp:Label ID="lblBatchName" runat="server" Text="" ForeColor="darkblue" CssClass="hover-underline"></asp:Label>
    

    <asp:HiddenField ID="hidSelectedProgramBatchId" runat="server" Value="0" />
    <%--<asp:Label ID="lbl" runat="server" Text="Label"></asp:Label>--%>
    <asp:HiddenField ID="hidId" runat="server" Value="0" />
    <div style="margin-left: 40px; font-size: 0.9em;">
        <asp:Panel ID="pnlSubControls" runat="server"></asp:Panel>
    </div>
    <asp:HiddenField ID="hidProgramId" runat="server" Value="0" />
    <asp:HiddenField ID="hidRunningClassId" runat="server" Value="0" />

    <asp:HiddenField ID="hidProgrameName" runat="server" Value="" />
    <asp:HiddenField ID="hidYearName" runat="server" Value="" />
    <asp:HiddenField ID="hidSubYearName" runat="server" Value="" />

    <asp:HiddenField ID="hidLevelId" runat="server" Value="0" />
    <asp:HiddenField ID="hidFacultyId" runat="server" Value="0" />
    <asp:HiddenField ID="hidExamOfClassId" runat="server" Value="0" />


</div>
