<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LabelAndCheckBoxUC.ascx.cs" Inherits="One.Views.Structure.All.UserControls.StructureView.LabelAndCheckBoxUC" %>

<div style="padding: 3px;" class="auto-st2-no-margin">

    <%--<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>--%>

    <span style="font-size: 1.01em; margin: 2px; padding: 5px;">
        <asp:CheckBox ID="chkBox" runat="server"  />
         <%--<asp:Label ID="lblProgramName" runat="server" Text="Name"></asp:Label>--%>
    </span>

    <asp:HiddenField ID="hidStructureId" runat="server" Value="0" />
    <%--<asp:HiddenField ID="hidStructureType" runat="server" />--%>
    <asp:HiddenField ID="hidProgramBatchId" Value="0" runat="server" />
</div>
