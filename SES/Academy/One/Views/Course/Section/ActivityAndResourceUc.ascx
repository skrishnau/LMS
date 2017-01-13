<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ActivityAndResourceUc.ascx.cs" Inherits="One.Views.Course.Section.ActivityAndResourceUc" %>

<%--<div class="course-act-res-whole">--%>
<asp:Panel ID="pnlHeading" runat="server">
    <div class="course-act-res-heading">
        <asp:Image ID="imgIcon" runat="server" ImageUrl="" AlternateText="" Height="22" Width="22" />

        <asp:HyperLink ID="lblTitle" CssClass="course-act-res-title" runat="server" Text="Heading">
        </asp:HyperLink>
        
        &nbsp;
        <span>
            <asp:Image ID="imgNew" runat="server" Visible="False" />
        </span>

        &nbsp;
            
            <asp:HyperLink ID="lnkEdit" CssClass="course-act-res-title" runat="server" Visible="False">
                <asp:Image ID="imgedt" runat="server"
                    ImageUrl="~/Content/Icons/Edit/edit_orange.png" />
            </asp:HyperLink>
        <asp:HyperLink ID="lnkDelete" Visible="False" runat="server" OnClick="lnkEdit_Click">
            <asp:Image ID="Image2" runat="server"
                ImageUrl="~/Content/Icons/delete/trash.gif" />
        </asp:HyperLink>



    </div>
    <div class="course-act-res-body" id="divDescription" runat="server">
        <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label>
    </div>

    <%--<div class="item-message">
            <asp:PlaceHolder ID="pnlMessages" runat="server"></asp:PlaceHolder>
        </div>--%>
    <%-- True- activity, False- resource --%>
    <asp:HiddenField ID="hidActOrRes" runat="server" Value="True" />

    <asp:HiddenField ID="hid" runat="server" Value="0" />
    <asp:HiddenField ID="hidActOrResId" runat="server" Value="0" />
    <asp:HiddenField ID="hidType" runat="server" Value="0" />
</asp:Panel>

<%--</div>--%>
