<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListFacultyUC.ascx.cs" Inherits="One.Views.Academy.ProgramSelection.ListFacultyUC" %>

<div runat="server" id="panel" style="padding-bottom: 10px;">
    <%-- class="block" --%>
    <div  style="font-weight: 600; font-size: 1em;">
        <asp:HyperLink ID="lblName" runat="server" >
               
        </asp:HyperLink>
    </div>

    <%--<asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>--%>
    <asp:HiddenField ID="hidStructureId" Value="0" runat="server" />
    <asp:HiddenField ID="hidStructureType" Value="0" runat="server" />
    <%-- aliceblue --%>
    <div style=" text-align: center;">
        <asp:PlaceHolder ID="pnlSubControls" runat="server"></asp:PlaceHolder>
    </div>
</div>
