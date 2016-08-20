<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LabelOnly.ascx.cs" Inherits="One.Views.Structure.All.UserControls.StructureView.LabelOnly" %>


<div style="margin-left: 20px; padding: 2px 0px 2px 5px;">
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    <span style="font-size: 1.2em;  margin: 2px 2px 2px 2px; padding: 5px;">
        <asp:Label ID="lblStructureName" runat="server" Text="Name"></asp:Label>
</span>
    <asp:HiddenField ID="hidStructureType" Value="" runat="server" />
    <asp:HiddenField ID="hidStructureId" Value="0" runat="server" />

    <asp:HiddenField ID="hidProgramBatchId" Value="0" runat="server" />

  <%--&nbsp;  <asp:ImageButton ID="imgCheckBox" Width="18px" Height="18px" runat="server"
      ImageUrl="~/Content/Icons/Check/unchecked_grey_18x18.png" OnClick="imgCheckBox_Click" />
    <div style="clear: both;"></div>--%>
</div>