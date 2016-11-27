<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListYearUC.ascx.cs" Inherits="One.Views.Structure.All.UserControls.ListYearUC" %>

<div runat="server" id="panel" style="margin: 3px 3px 3px 0; width: 100%;">
    <div class="block" style="font-weight: 600">
        <asp:HyperLink ID="lblName" runat="server">
                Name
        </asp:HyperLink>
        &nbsp;
        <asp:HyperLink ID="lnkEdit" runat="server">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Edit/edit_orange.png" />
        </asp:HyperLink>
    </div>

    <asp:HiddenField ID="hidStructureId" Value="0" runat="server" />
    <asp:HiddenField ID="hidStructureType" Value="0" runat="server" />
    <div style="margin-left: 20px;  border-left: solid lightgray 1px; ">
        <asp:PlaceHolder ID="pnlSubControls" runat="server"></asp:PlaceHolder>
        <div>
            <asp:HyperLink ID="lnkAdd" runat="server" Visible="False">
                <asp:Image ID="Image3" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                <asp:Literal ID="lblAddText" runat="server" Text=""></asp:Literal>
            </asp:HyperLink>
        </div>
    </div>
    <div style="clear: both;"></div>

</div>
