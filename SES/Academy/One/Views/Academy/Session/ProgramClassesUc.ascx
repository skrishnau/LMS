<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProgramClassesUc.ascx.cs" Inherits="One.Views.Academy.Session.ProgramClassesUc" %>


<div class="">
    <%-- style="margin-top: 8px;" --%>
    <div class="">
        <asp:HyperLink ID="lnkProgramName" runat="server"></asp:HyperLink>
    </div>
    <%-- class="list" style="margin-top: 5px;" --%>
    <div class="list-group">
        <asp:Panel ID="pnlListing" runat="server"></asp:Panel>
    </div>
</div>