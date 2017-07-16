<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="RunningClassForm.aspx.cs" Inherits="One.Views.Academy.RunningClassForm" %>


<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">

    <h3 class="heading-of-create-edit">
        <asp:Label ID="lblProgramBatchName" runat="server" Text=""></asp:Label>
    </h3>
    <div>
        <strong>
            <asp:Label ID="lblYearSubYearName" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="lblAcademicSessionName" runat="server" Text=""></asp:Label>
        </strong>
    </div>

    <br />
    <div class="data-entry-section">
        <div class="data-entry-section-heading">
            Subjects
            <hr />
        </div>
        <%-- data-entry-section-link-listing --%>
        <div class="list">
            <asp:Panel ID="pnlSubjects" runat="server"></asp:Panel>
        </div>
    </div>

</asp:Content>

<asp:Content runat="server" ID="content2" ContentPlaceHolderID="head">
    <link href="../../Content/CSSes/TableStyles.css" rel="stylesheet" />
</asp:Content>


<asp:Content runat="server" ID="content4" ContentPlaceHolderID="title">
    <asp:Literal runat="server" ID="lblTitle"></asp:Literal>
</asp:Content>
