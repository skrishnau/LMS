﻿<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="One.Views.Academy.List" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <h3 class="heading-of-listing" >
        <strong>Academic year List</strong>
        <hr />
    </h3>


    <%-- class="menu" style="clear: both; margin: 20px 5px; padding: 10px;" --------------Menu------------- --%>
    <div>
        <div style="text-align: right;">
            <asp:HyperLink ID="lnkEdit" runat="server" CssClass="link">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Edit/edit_orange.png" />
                <asp:Label ID="lblEdit" runat="server" Text="Edit"></asp:Label>
            </asp:HyperLink>
        </div>
        <div runat="server" id="pnlOtherEdits" visible="False">
            <asp:HyperLink ID="lnkAdd" runat="server" CssClass="link"
                NavigateUrl="~/Views/Academy/AcademicYear/AcademyCreate.aspx">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                New Academic Year
            </asp:HyperLink>
            &nbsp;&nbsp;
                <asp:Button ID="btnAutoUpdate" Enabled="False"
                    runat="server" Height="27px"
                    Text="Auto update to next Academic year/ Session" OnClick="btnAutoUpdate_Click" />

        </div>
    </div>
    <%--<br />--%>
    <%-- ------------END of Menu --%>


    <div style="clear: both;">
        <asp:Panel ID="pnlAcademicYearListing" runat="server"></asp:Panel>
    </div>

    <asp:HiddenField ID="hidEdit" runat="server" Value="False" />
</asp:Content>

<asp:Content runat="server" ID="contnettitle" ContentPlaceHolderID="title">
    Academic year list
</asp:Content>
