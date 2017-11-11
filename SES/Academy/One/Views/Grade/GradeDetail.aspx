<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="GradeDetail.aspx.cs" Inherits="One.Views.Grade.GradeDetail" %>

<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>

<asp:Content runat="server" ID="bodyid" ContentPlaceHolderID="Body">
    <h3 class="heading-of-display">
        <asp:Literal ID="lblHeading" runat="server"></asp:Literal>
    </h3>
    <hr />

    <div>
        <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label>
    </div>

    <table>
        <tr>
            <td class="data-type">Type</td>
            <td class="data-value">
                <asp:Label ID="lblGradeType" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr runat="server" id="rowMaximumValue" visible="False">
            <td class="data-type">Maximum value</td>
            <td class="data-value">
                <asp:Label ID="lblMaximumValue" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr runat="server" id="rowMinimumValue" visible="False">
            <td class="data-type">Minimum value</td>
            <td class="data-value">
                <asp:Label ID="lblMinimumValue" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr runat="server" id="rowMinPassValue" visible="False">
            <td class="data-type">Minimum Pass value</td>
            <td class="data-value">
                <asp:Label ID="lblMinPassValue" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr runat="server" id="rowEquivalentPercentOrPosition" visible="False">
            <td class="data-type">Percent or position</td>
            <td class="data-value">
                <asp:Label ID="lblPercentOrPosition" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>

    <br/>

    <asp:Panel runat="server" ID="pnlValues" Visible="False" CssClass="panel panel-default">
        <div class="panel-heading">
            Values
        </div>

        <asp:ListView ID="ListView1" runat="server">
            <LayoutTemplate>
                <table runat="server" id="tbl1" class="table table-hover table-responsive">
                    <thead>
                        <tr>
                            <%-- class="data-type-bold" --%>
                            <%--style="background-color: darkslategray; color: white; padding-left: 5px;"--%>
                            <th>Value</th>
                            <th>Equivalent</th>
                        </tr>
                    </thead>
                    <tr runat="server" id="itemPlaceholder"></tr>
                </table>
            </LayoutTemplate>

            <ItemTemplate>
                <tr runat="server" id="row1">
                    <td class="" style="padding-left: 5px;">
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Value") %>'></asp:Label>
                    </td>
                    <td class="" style="">
                        <asp:Label ID="Label2" runat="server" Text='<%# GetEquivalent(Eval("EquivalentPercentOrPostition"), Eval("IsFailGrade")) %>'></asp:Label>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>

    </asp:Panel>
    <asp:HiddenField ID="hidPercentOrPosition" runat="server" Value="False" />

</asp:Content>


<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <link href="../../Content/CSSes/TableStyles.css" rel="stylesheet" />
</asp:Content>


<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="title">
    <asp:Literal ID="lblTitle" runat="server">Grade detail</asp:Literal>
</asp:Content>




