<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SectionUc.ascx.cs" Inherits="One.Views.Course.Section.SectionUc" %>

<%--<section runat="server" id="section_" clientidmode="Static">
</section>--%>

<div style="margin: 10px 0;">

    <asp:Panel ID="pnlMain" runat="server">

        <%-- class="hover-background-change-slight" --%>
        <div style="padding: 5px; clear: both;">
            <%--class="item-section"--%>
            <div style="font-size: 24px; font-weight: normal; font-family: Arial, Helvetica, Verdana, Geneva, sans-serif;">
                <asp:Label ID="lblTitle" runat="server" Text="Heading"></asp:Label>
                &nbsp;&nbsp;&nbsp;
            
            <span class="span-edit-delete">
                <asp:HyperLink ID="lnkEdit" Visible="False" runat="server">
                    <asp:Image ID="imgEditBtn" runat="server" ToolTip="Edit"
                        ImageUrl="~/Content/Icons/Edit/edit_orange.png" />
                </asp:HyperLink>
                <asp:HyperLink ID="lnkDelete" Visible="False" runat="server">
                    <asp:Image ID="Image2" runat="server" ToolTip="Delete"
                        ImageUrl="~/Content/Icons/delete/trash.png" />
                </asp:HyperLink>
            </span>
            </div>
            <%-- class="item-summary" --%>
            <div style="margin-left: 15px;">
                <%--style="padding: 10px ; " margin-right: 25px; --%>
                <div style="padding: 5px;">
                    <asp:Label ID="lblSummary" runat="server" Text="Summary"></asp:Label>

                </div>
                <%--style="padding:10px; " margin-left: 20px; --%>


                <div>
                    <asp:PlaceHolder ID="pnlActAndRes" runat="server"></asp:PlaceHolder>

                    <div style="margin: 5px 0 5px;">
                        <%-- OnClick="lnkAddActOrRes_Click" 
                    CssClass="link_act_res"
                        --%>
                        <asp:LinkButton ID="lnkAddActOrRes" ClientIDMode="Static" ToolTip="Add activity or resource in this section"
                            CssClass="link-button"
                            Visible="False" runat="server">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon-14px.png" />
                            Add an Activity or Resource
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <div style="border-bottom: 1px solid #e6e6e6; width: 95%; margin: 5px auto;">
        
    </div>
    <%--<hr style="border: none; background-color: lightgray; height: 1px;" />--%>


    <asp:HiddenField ID="hid" runat="server" Value="0" />
    <asp:HiddenField ID="hidSubjectId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSectionName" runat="server" Value="" />
    <asp:HiddenField ID="hidUserId" runat="server" Value="0" />
    <asp:HiddenField ID="hidElligibleToView" runat="server" Value="False" />
</div>
