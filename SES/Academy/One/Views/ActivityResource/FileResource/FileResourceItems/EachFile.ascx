<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EachFile.ascx.cs" Inherits="One.Views.ActivityResource.FileResource.FileResourceItems.EachFile" %>
<%--<style>
    .whiteBackground {
        background-color: whitesmoke;
        padding: 5px;
    }

   
</style>--%>
<%--<div style="background-color: yellow; padding: 5px;">--%>
<div style="float: left; width: 75px;" class="auto-st2">
    <%-- BorderColor="black" BorderWidth="0" BorderStyle="Solid" CssClass="hover-dotted" --%>
    <div style="text-align: center;">
        <asp:LinkButton ID="lnkImage" runat="server" CausesValidation="False"
            OnClick="lnkImage_OnClick">
            <%--  BorderColor="black" BorderWidth="2" BorderStyle="Solid" --%>
            <%-- ImageAlign="Left"  BorderColor="lightgray" BorderWidth="1" BorderStyle="Solid" --%>
            <%--  CssClass="auto-st2" --%>
            <asp:Image ID="img" runat="server" Height="50" Width="50" 
                BorderColor="black" BorderWidth="2" BorderStyle="Solid" />
        </asp:LinkButton>
        <%--<span class="tooltip">--%>
        <asp:LinkButton ID="lnkRemove" runat="server" CausesValidation="False" OnClick="lnkRemove_OnClick">
            <asp:Image ID="Image1" runat="server"
                ToolTip="Remove"
                ImageUrl="~/Content/Icons/Close/cross_8x20_center.png" CssClass="topzero auto-st2-remove-button" />
            <%--<span class="tooltiptext">Remove
    </span>--%>
        </asp:LinkButton>
    </div>
    <asp:Label ID="lblName" runat="server" Text="" Font-Size="0.8em"></asp:Label>
    <asp:HiddenField ID="hidFileId" runat="server" Value="0" />
    <asp:HiddenField ID="hidLocalId" runat="server" Value="0" />
    <asp:HiddenField ID="hidFileUrl" runat="server" Value="" />
</div>
<%--</span>--%>

<%--</div>--%>
