<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ItemUc.ascx.cs" Inherits="One.Views.Student.Batch.List.ItemUc" %>

<div class="auto-st2">
    <asp:HiddenField ID="hidBatchId" runat="server" Value="0" />
    <div style="padding: 5px; font-size: 1.2em;">
        
        <asp:HyperLink ID="lnkName" runat="server" CssClass="link"></asp:HyperLink>
        &nbsp;
                <asp:HyperLink ID="lnkEdit" runat="server">
                    <asp:Image ID="imgEditBtn" runat="server" ImageUrl="~/Content/Icons/Edit/edit_orange.png" />
                </asp:HyperLink>
    </div>
</div>
