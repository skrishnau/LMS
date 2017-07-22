<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ItemUc.ascx.cs" Inherits="One.Views.Student.Batch.List.ItemUc" %>


<%-- class="auto-st2" --%>
<div class="list-item">
    <%--class="list-item-heading" style="padding: 5px; font-size: 1.2em; font-weight: 600;" CssClass="list-item"--%>
    <asp:HyperLink ID="lnkBody" runat="server" class="list-item-heading">
        <asp:Label ID="lblName" runat="server"></asp:Label>
    </asp:HyperLink>
    
    <%--<span class="list-item-option">--%>
        <%--<asp:HyperLink ID="lnkEdit" runat="server">
            <asp:Image ID="imgEditBtn" runat="server" ImageUrl="~/Content/Icons/Edit/edit_orange.png" />
        </asp:HyperLink>
        <asp:HyperLink ID="lnkDelete" Visible="False" runat="server" OnClick="lnkEdit_Click">
            <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/Icons/delete/trash.gif" />
        </asp:HyperLink>--%>
    <%--</span>--%>
    <div class="list-item-description">
        <span>Class commence from : </span>&nbsp; &nbsp; 
         <asp:Label ID="lblClassCommenceFrom" runat="server" Text="N/A"></asp:Label>
    </div>
    <asp:HiddenField ID="hidBatchId" runat="server" Value="0" />
</div>
