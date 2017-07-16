<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ViewsSite/User/UserMaster.Master" CodeBehind="Detail.aspx.cs" Inherits="One.Views.User.Detail" %>



<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>


<asp:Content runat="server" ID="content" ContentPlaceHolderID="Body">
    <h3 class="heading-of-create-edit">
        <asp:Label ID="lblHeading" runat="server" Text=""></asp:Label>
    </h3>
    <div class="option-div" style="margin-top: 10px; margin-bottom: 10px;">
        <asp:HyperLink ID="lnkEdit" runat="server">Edit</asp:HyperLink>
        <asp:HyperLink ID="lnkDeelete" runat="server">Delete</asp:HyperLink>
    </div>

    <div class="data-entry-section-body" style="float: left;">
        <table>
            <tr>
                <td class="data-type">First Name</td>
                <td class="data-value">
                    <asp:Label ID="lblFirstName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="data-type">Middle Name</td>
                <td class="data-value">
                    <asp:Label ID="lblMidName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="data-type">Last Name</td>
                <td class="data-value">
                    <asp:Label ID="lblLastName" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td class="data-type">Username
                </td>
                <td class="data-value">
                    <asp:Label ID="lblUserName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="data-type">Email
                </td>
                <td class="data-value">
                    <asp:Label ID="lblEmail" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="data-type">Role</td>
                <td>
                    <asp:Label ID="lblRole" runat="server" Width="150"></asp:Label>
                </td>
            </tr>

            <tr>
                <td class="data-type">Phone</td>
                <td class="data-value">
                    <asp:Label ID="lblPhone" runat="server"></asp:Label>
                </td>
            </tr>
            <%-- --------------------------------------- --%>
            <tr>
                <td class="data-type">Gender</td>
                <td class="data-value">
                    <asp:Label ID="lblGender" runat="server" Height="20px" Width="120px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="data-type">DOB</td>
                <td class="data-value">
                    <asp:Label ID="lblDOB" ClientIDMode="Static" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="data-type">Country</td>
                <td class="data-value">
                    <asp:Label ID="lblCountry" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="data-type">City</td>
                <td class="data-value">
                    <asp:Label ID="lblCity" runat="server"></asp:Label>
                </td>
            </tr>
           <%-- <tr>
                <td class="data-type">Street</td>
                <td class="data-value">
                    <asp:Label ID="lblStreet" runat="server"></asp:Label>
                </td>
            </tr>--%>
        </table>


    </div>


    <div style="float: left; padding: 5px;">
        <asp:HyperLink ID="lnkImage" runat="server" CssClass="list-item-body">
            <asp:Image ID="imgPhoto" runat="server" Width="100" Height="100" />
        </asp:HyperLink>
    </div>

</asp:Content>



<asp:Content runat="server" ID="content1" ContentPlaceHolderID="head">
    <link href="../../Content/CSSes/TableStyles.css" rel="stylesheet" />
</asp:Content>


<asp:Content runat="server" ID="content2" ContentPlaceHolderID="title">
    <asp:Literal ID="lblPageTitle" runat="server"></asp:Literal>
</asp:Content>
