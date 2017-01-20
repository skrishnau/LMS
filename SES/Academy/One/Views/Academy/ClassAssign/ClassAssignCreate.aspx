<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="ClassAssignCreate.aspx.cs" Inherits="One.Views.Academy.ClassAssign.ClassAssignCreate" %>

<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>


<asp:Content runat="server" ID="content" ContentPlaceHolderID="Body">
    <div class="data-entry">
        <h3 class="heading-of-listing">
            Class assign
        </h3>
        <hr />
        <div style="font-weight: 700;">
            <asp:Label ID="lblAcademicInfo" runat="server" Text=""></asp:Label>
        </div>
        <br/>
        <div class="data-entry-section-body">
            <asp:Panel ID="pnlProgramListing" runat="server"></asp:Panel>
        </div>

        <asp:HiddenField ID="hidAcademicYearId" runat="server" Value="0" />
        <asp:HiddenField ID="hidSessionId" runat="server" Value="0" />
    </div>
    <div class="save-div">
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Width="72px" />
        &nbsp; &nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" Width="69px" />
        &nbsp; &nbsp;
        <asp:Label ID="lblError" runat="server" Text="Error while saving." ForeColor="red" Visible="False"></asp:Label>
    </div>
</asp:Content>



<asp:Content runat="server" ID="content1" ContentPlaceHolderID="head">
    <link href="../../../Content/CSSes/TableStyles.css" rel="stylesheet" />
</asp:Content>
<asp:Content runat="server" ID="content2" ContentPlaceHolderID="title">
    Class assign
</asp:Content>
