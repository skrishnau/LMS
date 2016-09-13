<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListSubYearUC.ascx.cs" Inherits="One.Views.Academy.ProgramSelection.ListSubYearUC" %>

<%--<div runat="server" id="panel" style="margin-left: 25px; ">--%>

<%--<div class="block">--%>
<%--<span style="font-weight: 600">--%>
<style type="text/css">
    .subyear-div:hover {
        background-color: lightyellow;
        /*display: block;*/
    }
</style>
<div class="subyear-div">

    <asp:LinkButton ID="lnkBatchSelect" CssClass="block" runat="server" OnClick="lnkBtn_Click">
        <asp:RadioButton runat="server" ID="rdbtn" Text="" />
        <%-- AutoPostBack="True" OnCheckedChanged="rdbtn_CheckedChanged" --%>
        &nbsp;|&nbsp;
        <asp:Label ID="lblBatchName" runat="server" Text=""></asp:Label>
        <asp:Image ID="imgBtn" runat="server" ImageUrl="~/Content/Icons/Users/users-icon.png" />
    </asp:LinkButton>
    <asp:HiddenField ID="hidSelectedProgramBatchId" runat="server" Value="0" />
    <%--<asp:HiddenField ID="hidBatchSelectId" runat="server" />--%>

    <%--<asp:HyperLink ID="lblName" runat="server">
                Name
</asp:HyperLink>--%>

    <%--</span>--%>

    <br />

    <asp:HiddenField ID="hidStructureType" Value="0" runat="server" />
    <asp:HiddenField ID="hidYearId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSubYearId" runat="server" Value="0" />
    <asp:HiddenField ID="hidProgramId" runat="server" Value="0" />
    <asp:HiddenField ID="hidProgrameName" runat="server" Value="" />
    <asp:HiddenField ID="hidYearName" runat="server" Value="" />
    <asp:HiddenField ID="hidSubYearName" runat="server" Value="" />

    <asp:HiddenField ID="hidLevelId" runat="server" Value="0" />
    <asp:HiddenField ID="hidFacultyId" runat="server" Value="0" />

    <asp:HiddenField ID="hidRunningClassId" runat="server" Value="0" />
    <asp:HiddenField ID="hidEarlierSelectedBatchId" runat="server" Value="0" />
    <asp:HiddenField ID="hidEarlierSelectedBatchName" runat="server" Value="" />

</div>
