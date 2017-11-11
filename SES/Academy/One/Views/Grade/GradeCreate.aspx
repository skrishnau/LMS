<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="GradeCreate.aspx.cs" Inherits="One.Views.Grade.GradeCreate" %>

<%@ Register Src="~/Views/Grade/GradeTypeUc.ascx" TagPrefix="uc1" TagName="GradeTypeUc" %>

<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>


<asp:Content runat="server" ID="contentBodyid" ContentPlaceHolderID="Body">
    <h3 class="heading-of-create-edit">
        <asp:Label ID="lblHeading" runat="server" Text="Grade edit"></asp:Label>
    </h3>
    <hr />
    <br />
    <%-- class="data-entry-body" --%>

    <div class="panel panel-default">

        <div class="panel-heading">
            General
        </div>
        <div class="panel-body">

            <table>
                <tr>
                    <td class="data-type">Name</td>
                    <td class="data-value">
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ForeColor="red" ControlToValidate="txtName" ValidationGroup="gradevaligroup"
                            ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="data-type">Description</td>
                    <td class="data-value">
                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="77px" Width="237px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="data-type">Type
                    </td>
                    <td class="data-value">
                        <uc1:GradeTypeUc runat="server" ID="GradeTypeUc1" />
                    </td>
                </tr>
            </table>

        </div>

    </div>
    <div class="save-div">
        <asp:Button ID="btnSave" runat="server" Text="Save" Width="75px" ValidationGroup="gradevaligroup" OnClick="btnSave_OnClick" />
        &nbsp; &nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="75px"
                    ValidationGroup="cancelgroup" OnClick="btnCancel_OnClick" />

        <asp:Label ID="lblError" runat="server" Text="Error while saving." Visible="False" ForeColor="red"></asp:Label>
    </div>

    <%--<asp:HiddenField ID="hidPageKey" runat="server" Value="0" />--%>
    <asp:HiddenField ID="hidId" runat="server" Value="0" />
</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <link href="../../Content/CSSes/TableStyles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="title">
    Grade edit
</asp:Content>


