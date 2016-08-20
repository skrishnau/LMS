<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LabelAndCheckBoxUC.ascx.cs" Inherits="One.Views.Structure.All.UserControls.StructureView.LabelAndCheckBoxUC" %>

<div style="margin:5px 0 7px 20px; padding: 2px 0px 2px 5px;">
    <%--<div style="float: left;">
        <asp:Table ID="Table1" runat="server"></asp:Table>
    </div>--%>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

    <span style="font-size: 1.3em; margin: 2px 2px 2px 2px; padding: 5px; background-color: aliceblue;">
        <asp:Label ID="lblProgramName" runat="server" Text="Name"></asp:Label>
        &nbsp; &nbsp;
            <asp:ImageButton ID="imgCheckBox" Width="22px" Height="22px" runat="server"
        ImageUrl="~/Content/Icons/Check/unchecked_grey_18x18.png" OnClick="imgCheckBox_Click" />
        &nbsp;&nbsp;
    </span>

    <asp:HiddenField ID="hidIsChecked" Value="0" runat="server" />
    <asp:HiddenField ID="hidStructureId" runat="server" Value="0" />
    <asp:HiddenField ID="hidStructureType" runat="server" />
    <asp:HiddenField ID="hidProgramBatchId" Value="0" runat="server" />
    <%--<div style="clear: both;"></div>--%>
</div>
