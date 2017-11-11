<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ActivityAndResourceUc.ascx.cs" Inherits="One.Views.Course.Section.ActivityAndResourceUc" %>

<%--<div class="course-act-res-whole">--%>
<asp:Panel ID="pnlHeading" runat="server">
    <%-- class="course-act-res-heading" --%>
    <div style="padding: 10px 0;">

        <table>
            <tr>
                <td>
                    <asp:HyperLink ID="lnkImgIcon" CssClass="link-act-res-title" runat="server" Text="">
                        <asp:Image ID="imgIcon" runat="server" AlternateText="" Height="25" Width="25" />
                    </asp:HyperLink>
                </td>
                <td>
                    <div style="float: left;">
                        &nbsp;
                        <asp:HyperLink ID="lblTitle" CssClass="link-act-res-title" runat="server" Text="">
                        </asp:HyperLink>
                        <asp:Label ID="lblNoLinkTitle" CssClass="link-act-res-description" runat="server" Visible="False"></asp:Label>
                    </div>
                    <%-- runat="server" id="divOptionSpan" --%>
                    <div style="float: left;">

                        <span class="span-edit-delete">&nbsp;
                        <span>
                            <asp:Image ID="imgNew" runat="server" Visible="False" />
                        </span>
                            &nbsp;
                        <asp:HyperLink ID="lnkEdit" runat="server" Visible="False">
                            <asp:Image ID="imgedt" runat="server" ToolTip="Edit"
                                ImageUrl="~/Content/Icons/Edit/edit_orange.png" />
                        </asp:HyperLink>
                            <asp:HyperLink ID="lnkDelete" Visible="False" runat="server">
                                <asp:Image ID="Image2" runat="server" ToolTip="Delete"
                                    ImageUrl="~/Content/Icons/delete/trash.png" />
                            </asp:HyperLink>
                        </span>
                    </div>
                </td>
            </tr>
            <tr>
                <td></td>
                <td style="padding-left: 8px;">
                    <asp:Panel ID="pnlDescription" runat="server" CssClass="course-act-res-description">
                        <asp:Label ID="lblDescription" CssClass="link-act-res-description" runat="server" Text=""></asp:Label>
                    </asp:Panel>
                </td>
            </tr>
        </table>

        <%-- course-act-res-title --%>


        <%-- class="course-act-res-body" --%>
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
