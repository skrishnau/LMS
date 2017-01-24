<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ItemUc.ascx.cs" Inherits="One.Views.Student.Batch.List.ItemUc" %>


<asp:HyperLink ID="lnkBody" runat="server">
    <div class="auto-st2">
        <asp:HiddenField ID="hidBatchId" runat="server" Value="0" />
        <%-- style="padding: 5px; font-size: 1.2em; font-weight: 600;" --%>
        <div class="item-heading">

            <asp:Label ID="lblName" runat="server" CssClass="link"></asp:Label>

            &nbsp;
        <asp:HyperLink ID="lnkEdit" runat="server">
            <asp:Image ID="imgEditBtn" runat="server" ImageUrl="~/Content/Icons/Edit/edit_orange.png" />
        </asp:HyperLink>
            <asp:HyperLink ID="lnkDelete" Visible="False" runat="server" OnClick="lnkEdit_Click">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/Icons/delete/trash.gif" />
            </asp:HyperLink>

        </div>
        <div class="data-entry-section-body">
            <strong>Class commence from : </strong>&nbsp; &nbsp; 
         <asp:Label ID="lblClassCommenceFrom" runat="server" Text="N/A"></asp:Label>
        </div>
    </div>

</asp:HyperLink>