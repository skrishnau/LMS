<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListUC.ascx.cs" Inherits="One.Views.Structure.All.UserControls.ListUC" %>

<div runat="server" id="panel" style="margin: 3px 10px 10px 3px; min-height: 30px; padding: 5px 5px 5px 5px; ">
    <div class="block" style="font-weight: 600; font-size: 1.1em;">
        <asp:HyperLink ID="lblName" runat="server" >
               
        </asp:HyperLink>
    </div>

    <%--<asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>--%>
    <asp:HiddenField ID="hidStructureId" Value="0" runat="server" />
    <asp:HiddenField ID="hidStructureType" Value="0" runat="server" />
    <%-- aliceblue --%>
    <div style="margin-left: 25px; border-left: solid lightgray 1px; background-color: #e6e6ff; ">
        <asp:PlaceHolder ID="pnlSubControls" runat="server"></asp:PlaceHolder>
    </div>
</div>
