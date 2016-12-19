<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EachClass.ascx.cs" Inherits="One.Views.ActivityResource.Class.EachClass" %>

<div>
    <asp:Label ID="lblClassName" runat="server" Text="Label"></asp:Label>

    &nbsp; &nbsp;
   <%-- <strong>Group : </strong>
    <asp:DropDownList ID="ddlGroup" runat="server"></asp:DropDownList>--%>
    <div class="tooltip">
        <%-- <asp:LinkButton ID="lnkRemove" runat="server" Font-Names="arial,tahoma" Font-Bold="True"
                CssClass="removeButton"
                Text="X"
                OnClick="lnkRemove_Click" Font-Underline="False">
               
                <%--<asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Close/cross_8x14_top.png"/>
            </asp:LinkButton>--%>
        <span class="img-close">
            <asp:ImageButton ID="imgClose" CssClass="link-img-close" CausesValidation="False"
                ImageUrl="~/Content/Icons/Close/cross_8x20_center.png" runat="server" OnClick="lnkRemove_Click" />
        </span>
        <span class="tooltiptext">Remove</span>
    </div>
    <asp:HiddenField ID="hidClassId" runat="server" Value="0" />
</div>
