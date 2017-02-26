﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SectionUc.ascx.cs" Inherits="One.Views.Course.Section.SectionUc" %>

<%--<section runat="server" id="section_" clientidmode="Static">
</section>--%>
<div style="margin-left: 10px;">


    <%--class="item-section"--%>
    <div  style="font-size: 24px; font-weight: normal; font-family: Helvetica, Verdana, Geneva, sans-serif;">
        <asp:Label ID="lblTitle" runat="server" Text="Heading"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkEdit" Visible="False" runat="server" OnClick="lnkEdit_Click">
            <asp:Image ID="imgEditBtn" runat="server"
                ImageUrl="~/Content/Icons/Edit/edit_orange.png" />
        </asp:LinkButton>
         <asp:HyperLink ID="lnkDelete" Visible="False" runat="server" OnClick="lnkEdit_Click">
            <asp:Image ID="Image2" runat="server"
                ImageUrl="~/Content/Icons/delete/trash.gif" />
        </asp:HyperLink>
    </div>
    <%-- class="item-summary" --%>
    <div style="margin-left: 15px;">
        <%--style="padding: 10px ; " margin-right: 25px; --%>
        <div style="padding: 5px;">
            <asp:Label ID="lblSummary" runat="server" Text="Summary"></asp:Label>

        </div>
        <%--style="padding:10px; " margin-left: 20px; --%>
        

        <div >
            <asp:PlaceHolder ID="pnlActAndRes" runat="server"></asp:PlaceHolder>

            <div style="margin: 10px 0;">
                <%-- OnClick="lnkAddActOrRes_Click"  --%>
                <asp:LinkButton ID="lnkAddActOrRes" ClientIDMode="Static"
                    CssClass="link_act_res"
                    Visible="False" runat="server">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                    Add an Activity or Resource
                </asp:LinkButton>
            </div>
        </div>
    </div>

    <hr style="border: none; background-color: lightgray; height: 1px;" />


    <asp:HiddenField ID="hid" runat="server" Value="0" />
    <asp:HiddenField ID="hidSubjectId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSectionName" runat="server" Value="" />
    <asp:HiddenField ID="hidUserId" runat="server" Value="0" />
    <asp:HiddenField ID="hidElligibleToView" runat="server" Value="False" />
</div>
