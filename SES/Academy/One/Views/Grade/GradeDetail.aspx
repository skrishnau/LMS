<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="GradeDetail.aspx.cs" Inherits="One.Views.Grade.GradeDetail" %>

<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>

<asp:Content runat="server" ID="bodyid" ContentPlaceHolderID="Body">
    <div>
        <h3 class="heading-of-display">
            <asp:Literal ID="lblHeading" runat="server"></asp:Literal>
        </h3>
        <hr />


        <div class="data-entry-section-body">
            <div>
                <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label>
            </div>
            
            <table>
                <tr>
                    <td class="data-type-bold">Type</td>
                    <td class="data-value">
                        <asp:Label ID="lblGradeType" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr runat="server" id="rowMaximumValue" visible="False">
                    <td class="data-type-bold">Maximum value</td>
                    <td class="data-value">
                        <asp:Label ID="lblMaximumValue" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr runat="server" id="rowMinimumValue" visible="False">
                    <td class="data-type-bold">Minimum value</td>
                    <td class="data-value">
                        <asp:Label ID="lblMinimumValue" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr runat="server" id="rowMinPassValue" visible="False">
                    <td class="data-type-bold">Minimum Pass value</td>
                    <td class="data-value">
                        <asp:Label ID="lblMinPassValue" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr runat="server" id="rowEquivalentPercentOrPosition" visible="False">
                    <td class="data-type-bold">Percent or position</td>
                    <td class="data-value">
                        <asp:Label ID="lblPercentOrPosition" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
          <br />

            <asp:Panel runat="server" ID="pnlValues" Visible="False">
                <div class="data-entry-section-heading">
                    Values
                </div>
                <hr />
                <asp:ListView ID="ListView1" runat="server" >
                    <LayoutTemplate>
                        <table runat="server" id="tbl1" >
                            <tr>
                                <td class="data-type-bold" 
                                    style="background-color: darkslategray; color: white; padding-left: 5px;" >Value</td>
                                <td class="data-value-bold" 
                                    style="background-color: darkslategray; color: white; padding-left: 5px; padding-right: 5px;">Equivalent</td>
                            </tr>
                            <tr runat="server" id="itemPlaceholder"></tr>
                        </table>
                    </LayoutTemplate>

                    <ItemTemplate>
                        <tr runat="server" id="row1">
                            <td class="data-type" style="padding-left: 5px;">
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Value") %>'></asp:Label>
                            </td>
                            <td class="data-value" style="">
                                <asp:Label ID="Label2" runat="server" Text='<%# GetEquivalent(Eval("EquivalentPercentOrPostition"), Eval("IsFailGrade")) %>'></asp:Label>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>

            </asp:Panel>

        </div>

        <asp:HiddenField ID="hidPercentOrPosition" runat="server" Value="False" />
    </div>
</asp:Content>


<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
</asp:Content>


<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="title">
    <asp:Literal ID="lblTitle" runat="server">Grade detail</asp:Literal>
</asp:Content>




