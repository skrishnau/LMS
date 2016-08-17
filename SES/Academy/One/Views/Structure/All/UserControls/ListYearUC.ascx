<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListYearUC.ascx.cs" Inherits="One.Views.Structure.All.UserControls.ListYearUC" %>

<div runat="server" id="panel" style="margin: 3px 3px 3px 0;">
    <div class="block" style="font-weight: 600">
        <asp:HyperLink ID="lblName" runat="server">
                Name
        </asp:HyperLink>
    </div>

    <%--<asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>--%>
    <asp:HiddenField ID="hidStructureId" Value="0" runat="server" />
    <asp:HiddenField ID="hidStructureType" Value="0" runat="server" />

    <div style="margin-left: 25px; border-left: solid lightgray 1px; background-color: aliceblue">
        <asp:PlaceHolder ID="pnlSubControls" runat="server"></asp:PlaceHolder>
    </div>
</div>