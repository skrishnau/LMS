<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ViewsSite/User/UserMaster.Master" CodeBehind="StructureCreate.aspx.cs" Inherits="One.Views.Structure.StructureCreate" %>

<%@ Register Src="~/Views/All_Resusable_Codes/Dialog/CustomDialog.ascx" TagPrefix="uc1" TagName="CustomDialog" %>

<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>


<asp:Content runat="server" ContentPlaceHolderID="body" ID="content1">
    <h3 class="heading-of-create-edit">
        <asp:Label ID="lblHeading" runat="server" Text=""></asp:Label>
    </h3>
    <hr />
    <asp:HiddenField ID="hidStructureId" runat="server" Value="0" />
    <asp:HiddenField ID="hidParentId" runat="server" Value="0" />
    <asp:HiddenField ID="hidStructureType" runat="server" Value="" />
    <div class="data-entry-section-body">
        <div>
            <asp:Label ID="lblCopyError" runat="server" Visible="False" ForeColor="red"
                Text="Couldn't copy. Enter data manually."></asp:Label>
        </div>
        <table>
            <tr>
                <td class="data-type">Name &nbsp;</td>
                <td class="data-value">
                    <asp:TextBox ID="txtName" runat="server" Width="139px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="txtNameVali" ValidationGroup="save" runat="server" ControlToValidate="txtName"
                        Text="Required" ForeColor="red"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td class="data-type">Description&nbsp;</td>
                <td class="data-value">
                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="89px" Width="205px"></asp:TextBox>
                </td>
            </tr>

            <tr runat="server" id="position_row" visible="False">
                <td class="data-type">
                    <asp:Label ID="lblPosition" runat="server" Text="Position"></asp:Label>
                </td>
                <td class="data-value">
                    <asp:TextBox ID="txtPosition" runat="server" TextMode="Number"></asp:TextBox>
                </td>
            </tr>

        </table>
        <uc1:CustomDialog runat="server" ID="CustomDialog1" />
        <div class="save-div">
            <asp:Button ID="Save" runat="server" Text="Save" ValidationGroup="save" Width="94px" OnClick="btnSave_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="94px" OnClick="btnCancel_Click" />
            &nbsp;
        <asp:Label ID="lblError" runat="server" Text="Error while saving." ForeColor="red"></asp:Label>
        </div>
    </div>


    <br />

</asp:Content>

<asp:Content runat="server" ID="headcontent" ContentPlaceHolderID="title">
    <asp:Literal ID="lblTabHead" runat="server"></asp:Literal>
</asp:Content>
<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="head">
    <link href="../All_Resusable_Codes/Dialog/CustomDialogStyles.css" rel="stylesheet" />
    <link href="../../Content/CSSes/TableStyles.css" rel="stylesheet" />
</asp:Content>
